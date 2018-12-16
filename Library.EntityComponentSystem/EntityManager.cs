using Library.EntityComponentSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem
{
    public class EntityManager
    {
        private int _idToAssign = 0;
        private List<Entity> _entities;

        public EntityManager()
        {
            _entities = new List<Entity>();
        }

        public Entity CreateEntity()
        {
            var e = new Entity(_idToAssign);
            _entities.Add(e);

            _idToAssign++;

            return e;
        }

        public void RemoveEntity(int id)
        {
            _entities.RemoveAll(x => x.Id == id);
        }

        public void Update(double elapsedTime)
        {
            var entitiesToRemove = _entities.Where(x => x.ToRemove && x.TimeBeforeRemove > 0);

            foreach(var e in entitiesToRemove)
            {
                e.TimeBeforeRemove -= elapsedTime / 1000;
            }

            _entities.RemoveAll(x => x.ToRemove && x.TimeBeforeRemove <= 0);
        }

        public IList<Entity> GetEntities()
        {
            return new List<Entity>(_entities);
        }
    }
}
