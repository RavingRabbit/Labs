using System;

namespace Laba_2_ISP
{
    class Program
    {
        private const double DefaultStepValue = 1, DefaultLowValue = 0, DefaultHighValue = 10;

        static void Main(string[] args)
        {
            double low = DefaultLowValue, high = DefaultHighValue, step = DefaultStepValue;
            bool taylor = false;
            GetInitialValuesFromArgs(args, ref low, ref high, ref step, ref taylor);
            Console.WriteLine("low = {0}, high = {1}, step = {2}.", low, high, step);
            double[] arrayOfValues;
            if (taylor)
            {
                Console.WriteLine("Tabulation of the function by Taylor: ");
                arrayOfValues = Tabulator.Tabulate(low, high, step, CalculateByTaylor);
            }
            else
            {
                Console.WriteLine("Tabulation of the function: ");
                arrayOfValues = Tabulator.Tabulate(low, high, step, Calculate);
            }
            Console.WriteLine(ArrayToString(arrayOfValues));
            Console.ReadKey();
        }

        public static double Calculate(double x)
        {
            return (1 - Math.Pow(x, 2)/2)*Math.Cos(x) - x/2*Math.Sin(x);
        }

        public static double CalculateByTaylor(double x)
        {
            const double accuracy = 0.0001;
            double a = 1, result = 1;
            for (var n = 1; Math.Abs(a) > accuracy; ++n)
            {
                a *= (-1)*Math.Pow(x, 2)/(2*n*(2*n - 1));
                result += a*(2*Math.Pow(n, 2) + 1);
            }
            return result;
        }

        private static void GetInitialValuesFromArgs(string[] args, ref double low, ref double high, ref double step, ref bool taylor)
        {
            for (var i = 0; i < args.Length - 1; ++i)
                switch (args[i])
                {
                    case "/type":
                        if (args.Length > i + 1)
                            if (args[i + 1] == "taylor")
                                taylor = true;
                        break;
                    case "/low":
                        if (!double.TryParse(args[i + 1], out low))
                            Console.WriteLine("Incorrect command-line argument." 
                                + " The default LOW value will be taken.");
                        break;
                    case "/high":
                        if (!double.TryParse(args[i + 1], out high))
                            Console.WriteLine("Incorrect command-line argument." 
                                + " The default HIGH value will be taken.");
                        break;
                    case "/step":
                        if (!double.TryParse(args[i + 1], out step))
                            Console.WriteLine("Incorrect command-line argument." 
                                + " The default STEP value will be taken.");
                        break;
                }
            if (low < high && step > 0) 
                return;
            Console.WriteLine("Incorrect initial values! The default values will be taken.");
            low = DefaultLowValue;
            high = DefaultHighValue;
            step = DefaultStepValue;
        }

        public static string ArrayToString<T>(T[] array)
        {
            if (array == null)
                return "The array is empty.";
            string result = "";
            foreach (var value in array)
                result += value + Environment.NewLine;
            return result;
        }
    }
}
