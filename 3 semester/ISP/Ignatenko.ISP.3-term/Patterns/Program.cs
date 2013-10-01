using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyGen = KeyGenerator.Instance;
            Console.WriteLine(keyGen.GetKey());
            Console.Read();
        }
    }
}
