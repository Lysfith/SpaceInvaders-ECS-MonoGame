using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Data.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Systems
{
    public class InputSystem : Library.EntityComponentSystem.Systems.UpdateSystem
    {
        public override void Update(IList<Entity> entities, double elapsedTime)
        {
            var player = entities.Where(x => !x.ToRemove &&((TypeComponent)x.GetComponent(5)).Type == Enums.EnumTypeEntity.PLAYER).FirstOrDefault();

            if (player != null)
            {
                var transformComponent = ((TransformComponent)player.GetComponent(0));
                var shootComponent = (ShootComponent)player.GetComponent(6);
                var inputComponent = ((InputComponent)player.GetComponent(10));

                var keyboardState = Keyboard.GetState();

                inputComponent.Left = keyboardState.IsKeyDown(Keys.Q);
                inputComponent.Right = keyboardState.IsKeyDown(Keys.D);
                inputComponent.Fire = keyboardState.IsKeyDown(Keys.Space);

                if(inputComponent.Left)
                {
                    transformComponent.X -= (int)(500 * (elapsedTime / 1000));
                }
                else if (inputComponent.Right)
                {
                    transformComponent.X += (int)(500 * (elapsedTime / 1000));
                }

                if (inputComponent.Fire)
                {
                    shootComponent.ShootAsked = true;
                }
            }
        }
    }
}
