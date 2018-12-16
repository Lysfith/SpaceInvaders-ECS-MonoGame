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
    public class ShootEnemiesSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public int _startNbEnemies = 50;

        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var entitiesToProcess = entities.Where(x => !x.ToRemove && x.HasComponent(6) && ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.ENEMY)
                .Select(x => new { Entity = x, Transform = ((TransformComponent)x.GetComponent(0)) })
                .OrderByDescending(x => x.Transform.Y)
                .GroupBy(x => x.Transform.X)
                .Select(x => x.FirstOrDefault());

            foreach (var e in entitiesToProcess)
            {
                ShootComponent shootComponent = (ShootComponent)e.Entity.GetComponent(6);
                var transformComponent = (TransformComponent)e.Entity.GetComponent(0);
                var typeComponent = (TypeComponent)e.Entity.GetComponent(5);

                shootComponent.LastShootTime += elapsedTime;
                if (shootComponent.LastShootTime > shootComponent.IntervalBetweenShoot * 1000)
                {
                    var shoot = MyGame.Instance.World.EntityManager.CreateEntity();
                    FactoryEntity.CreateShoot(shoot, transformComponent.X, transformComponent.Y, 0, 1, 33, Enums.EnumTypeEntity.SHOOT_ENEMY);

                    shootComponent.LastShootTime = 0;
                }
            }
        }
    }
}
