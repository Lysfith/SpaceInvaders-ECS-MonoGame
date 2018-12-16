using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class InputComponent : IComponent
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Fire { get; set; }
    }
}
