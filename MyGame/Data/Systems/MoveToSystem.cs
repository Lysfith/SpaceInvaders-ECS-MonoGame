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
    public class MoveToSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var entitiesToProcess = entities.Where(x => !x.ToRemove && x.HasComponent(4));

            foreach (var e in entitiesToProcess)
            {
                MoveToComponent moveToComponent = (MoveToComponent)e.GetComponent(4);
                var transformComponent = (TransformComponent)e.GetComponent(0);
                var typeComponent = (TypeComponent)e.GetComponent(5);

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
                else if(typeComponent.Type == Enums.EnumTypeEntity.ENEMY 
                    && moveToComponent.Time > moveToComponent.TimeMax * 1000 
                    && !moveToComponent.Repeat)
                {
                    moveToComponent.EndX = moveToComponent.StartX;
                    moveToComponent.EndY = moveToComponent.StartY + 32;
                    moveToComponent.StartX = transformComponent.X;
                    moveToComponent.StartY = transformComponent.Y + 32;
                    moveToComponent.Time = 0;
                }
            }
        }
    }
}
