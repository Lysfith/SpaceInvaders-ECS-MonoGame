using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class LifeComponent : IComponent
    {
        public int CurrentLife { get; set; }
        public int LifeMax { get; set; }
    }
}
