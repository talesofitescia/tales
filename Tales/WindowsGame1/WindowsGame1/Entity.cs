using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Entity
    {
        Dictionary<Type, Object> components;
        public HashSet<Type> ProcessSystemSet { get; set; }

        public Entity()
        {
            components = new Dictionary<Type, Object>();
            ProcessSystemSet = new HashSet<Type>();
        }

        public void add(Object component)
        {
            Type type = component.GetType();
            components.Add(type, component);
        }
        public void remove(Type type)
        {
            components.Remove(type);
        }
        public Object get(Type type)
        {
            return components[type];
        }
    }
}
