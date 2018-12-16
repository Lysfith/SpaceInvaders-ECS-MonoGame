using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Components
{
    public class TransformComponent : IComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public float Rotation { get; set; }
    }
}
