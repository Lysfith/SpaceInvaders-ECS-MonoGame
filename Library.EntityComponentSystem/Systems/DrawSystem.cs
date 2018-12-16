using Library.EntityComponentSystem.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Systems
{
    public class DrawSystem : Systems.UpdateSystem
    {
        public virtual void Draw(IList<Entity> entities, double elapsedTime, SpriteBatch spriteBatch)
        {

        }
    }
}
