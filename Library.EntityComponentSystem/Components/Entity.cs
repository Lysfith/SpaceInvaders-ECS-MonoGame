using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem.Components
{
    public class Entity
    {
        private Dictionary<int, IComponent> _components;

        public int Id { get; private set; }
        public bool ToRemove { get; set; }
        public double TimeBeforeRemove { get; set; }

        public Entity(int id)
        {
            Id = id;
            _components = new Dictionary<int, IComponent>();
        }

        public void AddComponent(int type, IComponent component)
        {
            _components.Add(type, component);
        }

        public bool HasComponent(int type)
        {
            return _components.ContainsKey(type);
        }

        public void RemoveComponent(int type)
        {
            if (_components.ContainsKey(type))
            {
                _components.Remove(type);
            }
        }

        public IComponent GetComponent(int type)
        {
            if (_components.ContainsKey(type))
            {
                return _components[type];
            }

            return null;
        }
    }
}
