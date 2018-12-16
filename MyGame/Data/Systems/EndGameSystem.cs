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
    public class EndGameSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var player = entities.Where(x => ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.PLAYER).First();

            if(player.ToRemove)
            {
                MyGame.Instance.World.Stop();
            }
            else
            {
                var enemies = entities.Where(x => ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.ENEMY).ToList();

                if(!enemies.Any())
                {
                    MyGame.Instance.World.Stop();
                }
            }
        }
    }
}
