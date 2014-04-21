using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class SystemList : List<ISystem>
    {
        List<int> priorities;

        public void Add(ISystem s, int priority)
        {
            priorities.Add(priority);
            base.Add(s);
        }
        
        public new bool Remove(ISystem s)
        {
            int index = base.IndexOf(s);
            priorities.RemoveAt(index);

            return base.Remove(s);
        }

    }
}
