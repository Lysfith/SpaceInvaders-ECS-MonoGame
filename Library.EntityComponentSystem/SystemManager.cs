using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem
{
    public class SystemManager
    {
        private List<Systems.UpdateSystem> _systems;

        public SystemManager()
        {
            _systems = new List<Systems.UpdateSystem>();
        }

        public void AddSystem(Systems.UpdateSystem system)
        {
            _systems.Add(system);
        }

        public void RemoveSystem(Systems.UpdateSystem system)
        {
            _systems.Remove(system);
        }

        public void ClearAll()
        {
            _systems.Clear();
        }

        public void Update()
        {
            _systems.RemoveAll(x => x.ToRemove);
        }

        public IList<Systems.UpdateSystem> GetSystems()
        {
            return _systems;
        }

        public IList<DrawSystem> GetDrawSystems()
        {
            return _systems.Where(x => x is DrawSystem).Select(x => (DrawSystem)x).ToList();
        }
    }
}
