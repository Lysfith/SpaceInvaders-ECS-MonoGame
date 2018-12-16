using Library.EntityComponentSystem.Components;
using MyGame.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class TypeComponent : IComponent
    {
        public EnumTypeEntity Type { get; set; }
    }
}
