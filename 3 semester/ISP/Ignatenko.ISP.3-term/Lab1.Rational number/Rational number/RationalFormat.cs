using System;
using System.Globalization;

namespace Rational_number
{
    class RationalFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting if arg is not an Rational.
            if (arg.GetType() != typeof(Rational))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Provide default formatting for unsupported format strings.
            var ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "10D" || ufmt == "G"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            Rational number;
            if (arg is Rational)
                number = arg as Rational;
            else
            {
                return arg.ToString();
            }

            switch (ufmt)
            {
                case "10D":
                    {
                        return ((double)number).ToString(CultureInfo.InvariantCulture);
                    }
                case "G":
                    {
                        return number.Numerator + "/" + number.Denominator;
                    }
            }
            return arg.ToString();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            var formattable = arg as IFormattable;
            if (formattable != null)
                return formattable.ToString(format, CultureInfo.CurrentCulture);
            return arg != null ? arg.ToString() : String.Empty;
        }
    }
}
