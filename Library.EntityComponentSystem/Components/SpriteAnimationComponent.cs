using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Components
{
    public class SpriteAnimationComponent : IComponent
    {
        public int IndexStart { get; set; }
        public int IndexEnd { get; set; }
        public double LastFrameChanged { get; set; }
        public double IntervalFrameChanged { get; set; }
    }
}
