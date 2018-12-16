﻿using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class HitBoxComponent : IComponent
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
