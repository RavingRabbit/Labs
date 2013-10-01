using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    public static class RationalTest
    {
        public static bool TestMathMethods()
        {
            var testNumber1 = Rational.Create(5, 8);
            var testNumber2 = Rational.Create(8, 5);
            var mul = testNumber1 * testNumber2;
            if (mul != 1)
                return false;
            var testNumber3 = Rational.Create(0.5);
            mul = testNumber3 * 2;
            if (mul != 1)
                return false;
            if (testNumber1 / 2 != Rational.Create(5, 16))
                return false;
            var sum = testNumber1 + testNumber2;
            if (sum != Rational.Create(89, 40))
                return false;
            return true;
        }

        public static bool TestStringMethods()
        {
            var testNumber1 = Rational.Create(5, 8);
            var parsedNumber = Rational.Parse(testNumber1.ToString());
            if (parsedNumber != testNumber1)
                return false;
            if (Rational.Parse("0.(3)") != Rational.Create(1, 3))
                return false;
            return true;
        }
    }
}
