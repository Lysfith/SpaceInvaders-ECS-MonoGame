using Library.EntityComponentSystem.Components;
using MyGame.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class ShootComponent : IComponent
    {
        public int Index { get; set; }
        public double LastShootTime { get; set; }
        public double IntervalBetweenShoot { get; set; }
        public bool ShootAsked { get; set; }
    }
}
