using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba_4_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackOfValues = new Stack<string>();
            GetInitialValuesFromArgs(args, ref stackOfValues);
            var demoSet1 = new Set<string>(stackOfValues.ToArray());
            Console.WriteLine(demoSet1.ToString());
            var demoSet3 = new SortedSet(stackOfValues.ToArray());
            Console.WriteLine(demoSet3.ToString());
            Console.ReadKey();
        }

        private static void GetInitialValuesFromArgs(string[] args, ref Stack<string> stackOfValues)
        {
            for (var i = 0; i < ((ICollection)args).Count; ++i)
            {
                var subArgs = args[i].Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (subArgs.Length != 1)
                    switch (subArgs[0])
                    {
                        case "/v":
                            stackOfValues.Push(subArgs[1]);
                            break;
                    }
            }
        }
    }
}

