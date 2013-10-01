using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba_3_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeForString = new BST<int, string>();
            var stackOfValues = new Stack<string>();
            GetInitialValuesFromArgs(args, ref stackOfValues);
            while(stackOfValues.Count != 0)
            {
                var value = stackOfValues.Pop();
                treeForString.Insert(GetKeyFromString(value), value);
            }
            Console.Write(treeForString.ToString());
            string val;
            var key = 6;
            Console.Write("Find: key = " + key);
            var b = treeForString.TryFind(6, out val);
            Console.WriteLine(", value = "+val);
            Console.ReadKey();
        }

        public static int GetKeyFromString(string value)
        {
            return value.Length;
        }

        public static int GetKeyFromInt(int value)
        {
            return value;
        }

        private static void GetInitialValuesFromArgs(string[] args, ref Stack<string> stackOfValues)
        {
            for (var i = 0; i < ((ICollection)args).Count; ++i)
            {
                var subArgs = args[i].Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
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
