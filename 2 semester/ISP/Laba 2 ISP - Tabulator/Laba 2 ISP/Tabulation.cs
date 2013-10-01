using System.Linq;

namespace Laba_2_ISP
{
    public static class Tabulator
    {
        public delegate double UnaryFunction(double x);

        public static double[] Tabulate(double low, double high, double step, UnaryFunction func)
        {
            if (step <= 0)
                return null;
            if (low > high)
                return Tabulate(high, low, step, func).Reverse().ToArray();
            var arrayOfValues = new double[(int)((high - low + step) / step)];
            var x = low;
            for (int i = 0; x <= high; ++i, x += step)
                arrayOfValues[i] = func(x);
            return arrayOfValues;
        }
    }
}
