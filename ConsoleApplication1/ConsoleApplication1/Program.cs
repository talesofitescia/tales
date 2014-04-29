using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Toto
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Type> tests = new HashSet<Type>();
            //List<Type> tests = new List<Type>();
            tests.Add(new Toto().GetType());
            tests.Add(new Toto().GetType());
            foreach (Type type in tests)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            

            //tests.Remove(new Toto().GetType());
            foreach (Type type in tests)
            {
                Console.WriteLine(type);
            }
        }
    }
}