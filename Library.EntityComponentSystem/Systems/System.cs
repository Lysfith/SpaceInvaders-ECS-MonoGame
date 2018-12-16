using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Systems
{
    public class UpdateSystem
    {
        public bool ToRemove { get; set; }

        public virtual void Update(IList<Entity> entities, double elapsedTime)
        {

        }
    }
}
