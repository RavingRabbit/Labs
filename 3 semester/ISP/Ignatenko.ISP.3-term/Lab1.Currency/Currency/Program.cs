using System;
using System.Globalization;
using RationalNumber;

namespace Currency
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Format(new CultureInfo("ru-RU"), "{0:f40}", Rational.Create(3, 7)));
            Console.WriteLine(string.Format(new CultureInfo("en-US"), "{0:f40}", Rational.Create(3, 7)));
            

            Console.WriteLine("Тестирование математических методов Rational - " + RationalTest.TestMathMethods());
            Console.WriteLine("Тестирование строковых методов Rational - " + RationalTest.TestStringMethods());
            Console.WriteLine("Тестирование математических методов Currency - " + CurrencyTest.TestMathMethods());
            Console.WriteLine("Тестирование строковых методов Currency - " + CurrencyTest.TestStringMethods());
            Console.ReadLine();
        }
    }
}
