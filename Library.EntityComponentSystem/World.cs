using Library.EntityComponentSystem.Components;
using Library.EntityComponentSystem.Systems;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EntityComponentSystem
{
    public class World
    {
        public SystemManager SystemManager { get; private set; }
        public EntityManager EntityManager { get; private set; }

        private bool _isRunning;

        public World()
        {
            SystemManager = new SystemManager();
            EntityManager = new EntityManager();

            _isRunning = true;
        }

        public void Update(double elapsedTime)
        {
            if (_isRunning)
            {
                var systems = SystemManager.GetSystems();
                foreach (var s in systems)
                {
                    s.Update(EntityManager.GetEntities(), elapsedTime);
                }

                EntityManager.Update(elapsedTime);
                SystemManager.Update();
            }
        }

        public void Draw(double elapsedTime, SpriteBatch spriteBatch)
        {
            if (_isRunning)
            {
                var systems = SystemManager.GetDrawSystems();
                foreach (var s in systems)
                {
                    s.Draw(EntityManager.GetEntities(), elapsedTime, spriteBatch);
                }

            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
