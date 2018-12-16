using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Components
{
    public class MovementComponent : IComponent
    {
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float Acceleration { get; set; }
    }
}
