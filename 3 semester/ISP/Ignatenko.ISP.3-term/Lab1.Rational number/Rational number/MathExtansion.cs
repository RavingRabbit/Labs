using System;

namespace RationalNumber
{
    static class MathExtansion
    {
        public static long GCD(long m, long n)
        {
            m = Math.Abs(m);
            n = Math.Abs(n);
            while ((m != 0) && (n != 0))
                if (m > n)
                    m %= n;
                else
                    n %= m;
            return m + n;
        }

        public static long LCM(long m, long n)
        {
            return m / GCD(m, n) * n;
        }

        public static double Round(double value, int digits)
        {
            var scale = Math.Pow(10, digits);
            var round = Math.Floor(Math.Abs(value) * scale + 0.5);
            return (Math.Sign(value) * round / scale);
        } 
    }
}
