using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Components
{
    public class SpriteComponent : IComponent
    {
        public float OriginX { get; set; } //De 0 à 1
        public float OriginY { get; set; } //De 0 à 1
        public int CurrentIndex { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public Color Color { get; set; }
        public bool Visible { get; set; }
        public SpriteEffects Effect { get; set; }
    }
}
