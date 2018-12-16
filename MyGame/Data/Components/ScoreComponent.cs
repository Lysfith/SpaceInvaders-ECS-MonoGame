using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Data.Components
{
    public class ScoreComponent : IComponent
    {
        public int Score { get; set; }
    }
}
