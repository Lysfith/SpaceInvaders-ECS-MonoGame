using Library.EntityComponentSystem.Components;
using MyGame.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class MoveToComponent : IComponent
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public double Time { get; set; }
        public double TimeMax { get; set; }
        public bool Repeat { get; set; }
    }
}
