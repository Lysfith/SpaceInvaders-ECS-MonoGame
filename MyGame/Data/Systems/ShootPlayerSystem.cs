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
    public class ShootPlayerSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            //Entities
            var player = entities.Where(x => !x.ToRemove && ((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.PLAYER).First();

            ShootComponent shootComponent = (ShootComponent)player.GetComponent(6);
            var transformComponent = (TransformComponent)player.GetComponent(0);

            shootComponent.LastShootTime += elapsedTime;
            if (shootComponent.ShootAsked && shootComponent.LastShootTime > shootComponent.IntervalBetweenShoot * 1000)
            {
                var shoot = MyGame.Instance.World.EntityManager.CreateEntity();
                FactoryEntity.CreateShoot(shoot, transformComponent.X, transformComponent.Y, 0, -1, 32, Enums.EnumTypeEntity.SHOOT_PLAYER);

                shootComponent.LastShootTime = 0;
            }
        }
    }
}
