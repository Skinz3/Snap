using System;
using System.Collections.Generic;
using System.Text;

namespace Snap.Entities
{
    public abstract class Entity
    {
        private List<IComponent> Components
        {
            get;
            set;
        }
        public Entity()
        {
            this.Components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            this.Components.Add(component);
        }
        public void Remove(IComponent component)
        {
            this.Components.Remove(component);
        }
    }
}
