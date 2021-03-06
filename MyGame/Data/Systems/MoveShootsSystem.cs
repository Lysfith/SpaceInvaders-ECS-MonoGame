﻿using Library.EntityComponentSystem.Components;
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
    public class MoveShootsSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var shootsToProcess = entities.Where(x => x.HasComponent(4) 
            && (((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.SHOOT_ENEMY 
            || ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.SHOOT_PLAYER));

            foreach (var s in shootsToProcess)
            {
                MoveToComponent moveToComponent = (MoveToComponent)s.GetComponent(4);
                var transformComponent = (TransformComponent)s.GetComponent(0);

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
                    s.ToRemove = true;
                }
            }
        }
    }
}
