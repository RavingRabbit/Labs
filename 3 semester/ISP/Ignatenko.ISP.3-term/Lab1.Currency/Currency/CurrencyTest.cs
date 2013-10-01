using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public static class CurrencyTest
    {
        public static bool TestMathMethods()
        {
            var testCurrency1 = Currency.GetCurrency("usd", 58);
            if ((testCurrency1 * 2).Amount != 116)
                return false;
            if ((testCurrency1 / 2).Amount != 29)
                return false;
            var testCurrency2 = Currency.USD(12);
            if ((testCurrency1 + testCurrency2).Amount != 70)
                return false;
            return true;
        }

        public static bool TestStringMethods()
        {
            var testCurrency1 = Currency.GetCurrency("usd", 58);
            if (Currency.Parse(testCurrency1.ToString()).Amount != 58)
                return false;
            return true;
        }
    }
}
