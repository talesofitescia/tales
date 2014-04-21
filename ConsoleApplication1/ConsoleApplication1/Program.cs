using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MaList : List<List<Object>>
    {

        public void Add(List<Object> l)
        {
            base.Add(l);
        }

        public bool Remove(List<Object> l)
        {
            return base.Remove(l);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MaList list = new MaList();
            list.Add(new List<Object>());
            list.Add(new List<Object>());
            list.Remove(new List<Object>());
            foreach (List<Object> o in list)
            {
                Console.WriteLine(o);
            }
        }
    }
}