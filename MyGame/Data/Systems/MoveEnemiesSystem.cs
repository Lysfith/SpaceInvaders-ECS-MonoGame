using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Data.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Systems
{
    public class MoveEnemiesSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public int _startNbEnemies = 50;

        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var entitiesToProcess = entities.Where(x => !x.ToRemove && x.HasComponent(4) && ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.ENEMY);

            var nbEnemies = entitiesToProcess.Count();

            foreach (var e in entitiesToProcess)
            {
                MoveToComponent moveToComponent = (MoveToComponent)e.GetComponent(4);
                var transformComponent = (TransformComponent)e.GetComponent(0);
                var typeComponent = (TypeComponent)e.GetComponent(5);
                var spriteAnimationComponent = (SpriteAnimationComponent)e.GetComponent(2);

                if (moveToComponent.Time < moveToComponent.TimeMax * 1000 || moveToComponent.Repeat)
                {
                    if (moveToComponent.Time >= moveToComponent.TimeMax * 1000 && moveToComponent.Repeat)
                    {
                        moveToComponent.Time = 0;
                    }

                    moveToComponent.Time += elapsedTime;

                    var percent = moveToComponent.Time / (moveToComponent.TimeMax * 1000);

                    var positionX = (int)((moveToComponent.EndX - moveToComponent.StartX) * percent + moveToComponent.StartX);
                    var positionY = (int)((moveToComponent.EndY - moveToComponent.StartY) * percent + moveToComponent.StartY);

                    transformComponent.X = positionX;
                    transformComponent.Y = positionY;
                }
                else if(moveToComponent.Time > moveToComponent.TimeMax * 1000 
                    && !moveToComponent.Repeat)
                {
                    moveToComponent.EndX = moveToComponent.StartX;
                    moveToComponent.EndY = moveToComponent.StartY + 32;
                    moveToComponent.StartX = transformComponent.X;
                    moveToComponent.StartY = transformComponent.Y + 32;
                    moveToComponent.Time = 0;
                }

                //var percentEnemies = (double)nbEnemies / (double)_startNbEnemies;

                //moveToComponent.TimeMax *= percentEnemies;
                //if (spriteAnimationComponent != null)
                //{
                //    spriteAnimationComponent.IntervalFrameChanged *= percentEnemies;
                //}
            }
        }
    }
}
