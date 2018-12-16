using Library.EntityComponentSystem;
using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Data.Components;
using MyGame.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Systems
{
    public class CollisionShootSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {

        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var shootsToProcess = entities.Where(x => !x.ToRemove && x.HasComponent(4)
            && (((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.SHOOT_ENEMY
            || ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.SHOOT_PLAYER));

            var player = entities.Where(x => ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.PLAYER).First();
            var playerTransformComponent = (TransformComponent)player.GetComponent(0);
            var playerSpriteComponent = (SpriteComponent)player.GetComponent(1);
            var playerHitBoxComponent = (HitBoxComponent)player.GetComponent(7);
            var playerLifeComponent = (LifeComponent)player.GetComponent(8);
            var playerScoreComponent = (ScoreComponent)player.GetComponent(9);

            var enemies = entities.Where(x => !x.ToRemove && ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.ENEMY).ToList();

            int enemyKills = 0;

            foreach (var s in shootsToProcess)
            {
                var shootTransformComponent = (TransformComponent)s.GetComponent(0);
                var shootTypeComponent = (TypeComponent)s.GetComponent(5);

                if (shootTypeComponent.Type == Enums.EnumTypeEntity.SHOOT_PLAYER)
                {
                    foreach (var e in enemies)
                    {
                        var enemyTransformComponent = (TransformComponent)e.GetComponent(0);
                        var enemyHitBoxComponent = (HitBoxComponent)e.GetComponent(7);
                        var enemyLifeComponent = (LifeComponent)e.GetComponent(8);
                        var enemyScoreComponent = (ScoreComponent)e.GetComponent(9);

                        if (enemyTransformComponent.X - enemyHitBoxComponent.Width * 0.5 < shootTransformComponent.X
                            && enemyTransformComponent.X + enemyHitBoxComponent.Width * 0.5 > shootTransformComponent.X
                            && enemyTransformComponent.Y - enemyHitBoxComponent.Height * 0.5 < shootTransformComponent.Y
                            && enemyTransformComponent.Y + enemyHitBoxComponent.Height * 0.5 > shootTransformComponent.Y
                            )
                        {
                            enemyLifeComponent.CurrentLife--;

                            if (enemyLifeComponent.CurrentLife <= 0)
                            {
                                e.ToRemove = true;
                                playerScoreComponent.Score += enemyScoreComponent.Score;
                                enemyKills++;
                            }

                            s.ToRemove = true;

                            break;
                        }
                    }
                }
                else
                {
                    if (playerTransformComponent.X - playerHitBoxComponent.Width * 0.5 < shootTransformComponent.X
                            && playerTransformComponent.X + playerHitBoxComponent.Width * 0.5 > shootTransformComponent.X
                            && playerTransformComponent.Y - playerHitBoxComponent.Height * 0.5 < shootTransformComponent.Y
                            && playerTransformComponent.Y + playerHitBoxComponent.Height * 0.5 > shootTransformComponent.Y
                            )
                    {
                        playerLifeComponent.CurrentLife--;
                        playerSpriteComponent.CurrentIndex =  3 - playerLifeComponent.CurrentLife;

                        if (playerLifeComponent.CurrentLife <= 0)
                        {
                            player.ToRemove = true;
                        }

                        s.ToRemove = true;
                    }
                }
            }

            if(enemyKills > 0)
            {
                foreach(var e in enemies)
                {
                    MoveToComponent moveToComponent = (MoveToComponent)e.GetComponent(4);
                    var transformComponent = (TransformComponent)e.GetComponent(0);
                    var spriteAnimationComponent = (SpriteAnimationComponent)e.GetComponent(2);

                    var percentEnemies = 1.0 - (enemyKills / 60.0);

                    moveToComponent.TimeMax *= percentEnemies;
                    if (spriteAnimationComponent != null)
                    {
                        spriteAnimationComponent.IntervalFrameChanged *= percentEnemies;
                    }
                }
            }
        }
    }
}
