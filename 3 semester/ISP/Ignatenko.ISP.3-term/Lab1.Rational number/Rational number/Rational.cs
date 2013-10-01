using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RationalNumber
{
    /// <summary>
    /// Представляет рациональное число.
    /// </summary>
    public class Rational : IComparable, IComparable<Rational>, IEquatable<Rational>, IFormattable
    {
        #region Fields

        private readonly int _numerator;
        private readonly Natural _denominator;

        /// <summary>
        /// Представляет наибольшее возможное значение типа <see cref="T:RationalNumber.Rational"/>.
        /// </summary>
        public static readonly Rational MaxValue = new Rational(int.MaxValue, Natural.MinValue);
        /// <summary>
        /// Представляет минимальное допустимое значение типа <see cref="T:RationalNumber.Rational"/>.
        /// </summary>
        public static readonly Rational MinValue = new Rational(int.MinValue, Natural.MinValue);

        #endregion

        #region Constructors

        /// <summary>
        /// Создаёт рациональное число по числителю и знаменателю.
        /// </summary>
        /// <param name="numerator">Числитель рационального числа - число целого типа.</param>
        /// <param name="denominator">Знаменатель рационального числа - натуральное число.</param>
        /// <returns>
        /// Рациональное целое число со знаком.
        /// </returns>
        public static Rational Create(int numerator, int denominator = 1)
        {
            return denominator == 0 ? null : new Rational(numerator, denominator);
        }

        private Rational(int numerator, int denominator = 1)
        {
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            _numerator = numerator;
            _denominator = new Natural(denominator);
            ToLowestTerm(ref _numerator, ref _denominator);
        }

        /// <summary>
        /// Создаёт рациональное число по числу типа double с заданной точностью.
        /// </summary>
        /// <param name="number">Число типа double, которое будет преобразовано в рациональное число.</param><exception cref="T:System.OverflowException">Параметр <paramref name="number"/> слишком большой либо слишком маленький.</exception>
        /// <param name="precision">Точность преобразования (число знаков после запятой).</param>
        public static Rational Create(double number, int precision = 5)
        {
            return new Rational(number, precision);
        }

        private Rational(double number, int precision = 5)
        {
            if (Math.Ceiling(Math.Abs(number)) > int.MaxValue)
                throw new OverflowException();
            number = MathExtansion.Round(number, precision);
            var parts = number.ToString(CultureInfo.InvariantCulture).Split('.');
            if (parts.Length == 2)
            {
                var pow = (int)Math.Pow(10, parts[1].Length);
                _numerator = int.Parse(parts[0]) * pow + int.Parse(parts[1]);
                _denominator = (Natural)pow;
            }
            else
            {
                _numerator = int.Parse(parts[0]);
                _denominator = (Natural)1;
            }
            ToLowestTerm(ref _numerator, ref _denominator);
        }

        /// <summary>
        /// Создаёт рациональное число по числителю и знаменателю. Существует вероятность потери точности при числах, больших <see cref="F:System.Int32.MaxValue"/>.
        /// </summary>
        /// <param name="numerator">Числитель рационального числа - число целого типа.</param>
        /// <param name="denominator">Знаменатель рационального числа - число целого типа число.</param>
        private Rational(long numerator, long denominator)
        {
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            var divider = Math.Ceiling((double)Math.Max(numerator, denominator) / (int.MaxValue));
            divider = divider > 1 ? divider : 1;
            _numerator = (int)(numerator / divider);
            _denominator = new Natural((int)(denominator / divider));
            ToLowestTerm(ref _numerator, ref _denominator);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Числитель рационального числа.
        /// </summary>
        public int Numerator
        {
            get { return _numerator; }
        }

        /// <summary>
        /// Знаменатель рационального числа.
        /// </summary>
        public int Denominator
        {
            get { return _denominator; }
        }

        /// <summary>
        /// Высота рационального числа.
        /// </summary>
        public int Height
        {
            get { return Math.Abs(_numerator) + Math.Abs(_denominator); }
        }

        #endregion

        #region Math Operators

        public static Rational operator +(Rational x, Rational y)
        {
            if (x == null || y == null)
                return null;
            var newDenominator = CommonDenomenator(x, y);
            var newNumerator = x._numerator*(newDenominator/x._denominator) +
                               y._numerator*(newDenominator/y._denominator);
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator -(Rational x, Rational y)
        {
            if (x == null || y == null)
                return null;
            var newDenominator = CommonDenomenator(x, y);
            var newNumerator = x._numerator*(newDenominator/x._denominator) -
                               y._numerator*(newDenominator/y._denominator);
            return new Rational(newNumerator, x._denominator);
        }

        public static Rational operator -(Rational x)
        {
            return x == null ? null : new Rational(-x._numerator, x._denominator);
        }

        public static Rational operator *(Rational x, Rational y)
        {
            if (x == null || y == null)
                return null;
            var numerator = Math.BigMul(x._numerator, y._numerator);
            var denumerator = Math.BigMul(x._denominator, y._denominator);
            return new Rational(numerator, denumerator);
        }

        public static Rational operator /(Rational x, Rational y)
        {
            if (x == null || y == null)
                return null;
            if (y._numerator == 0)
                return null;
            var numerator = x._numerator * y._denominator;
            var denumerator = x._denominator * y._numerator;
            if (denumerator < 0)
            {
                denumerator = -denumerator;
                numerator = -numerator;
            }
            return new Rational(numerator, (Natural)denumerator);
        }

        #endregion

        #region Comparsion Operators

        public static bool operator ==(Rational x, Rational y)
        {
            if (ReferenceEquals(x, y))
                return true;
            var ob1 = (object)x;
            var ob2 = (object)y;
            if (ob1 == null || ob2 == null)
                return false;
            return x.Equals(y);
        }

        public static bool operator !=(Rational x, Rational y)
        {
            if (x == null || y == null)
                return false;
            return !(x.Equals(y));
        }

        public static bool operator >=(Rational x, Rational y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator <=(Rational x, Rational y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >(Rational x, Rational y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator <(Rational x, Rational y)
        {
            return x.CompareTo(y) < 0;
        }

        #endregion

        #region Conversion Operators

        public static explicit operator double(Rational num)
        {
            if (num == null)
                return double.NaN;
            return (double)num._numerator / num._denominator;
        }

        public static explicit operator Rational(double num)
        {
            return new Rational(num);
        }

        public static implicit operator Rational(int num)
        {
            return new Rational(num);
        }

        public static explicit operator int(Rational num)
        {
            return num._numerator / num._denominator;
        }

        #endregion

        #region String Methods

        /// <summary>
        /// Преобразовывает строковое представление дроби в эквивалентное ему рациональное число.
        /// </summary>
        /// <returns>
        /// Рациональное целое число со знаком, эквивалентное числу, содержащемуся в параметре <paramref name="s"/>.
        /// </returns>
        /// <param name="s">Строка, содержащая преобразуемое число.</param><exception cref="T:System.ArgumentNullException">Параметр <paramref name="s"/> имеет значение null.</exception><exception cref="T:System.FormatException">Формат параметра <paramref name="s"/> является неправильным.</exception><exception cref="T:System.OverflowException">Параметр <paramref name="s"/> представляет число, которое меньше значения <see cref="F:System.Int32.MinValue"/> или больше значения <see cref="F:System.Int32.MaxValue"/>.</exception><filterpriority>1</filterpriority>
        public static Rational Parse(string s)
        {
            if (s == null)
                return null;
            if (Regex.IsMatch(s, @"^[+-]??\d+/[+-]??\d+$")) //парсим обыкновенную дробь
            {
                return ParseCommonFraction(s);
            }
            if (Regex.IsMatch(s, @"^[+-]??\d+[,\.]\d*\(\d+\)$")) //парсим периодическую дробь
            {
                return ParseCirculatingFraction(s); 
            }
            if (Regex.IsMatch(s, @"^[+-]??\d+[,.]??\d+$")) //парсим double
            {
                s = s.Replace('.', ',');
                return new Rational(double.Parse(s));
            }
            if (Regex.IsMatch(s, @"^[+-]??\d+$")) //парсим целое
            {
                return new Rational(int.Parse(s));
            }
            return null;
        }

        /// <summary>
        /// Преобразовывает числовое значение данного экземпляра в эквивалентное ему строковое представление.
        /// </summary>
        /// <returns>
        /// Строковое представление значения данного экземпляра, состоящее из знака минус, если число отрицательное, числителя и знаменателя дроби, представляющих собой последовательности цифр в диапазоне от 0 до 9 с ненулевой первой цифрой, разделённые знаком обратного слеша.
        /// </returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.InvariantCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null)
                provider = CultureInfo.InvariantCulture;
            format = format.ToUpper();
            if (Regex.IsMatch(format, @"^D\d*?$"))
                return ((int)this).ToString(format, provider);
            if (Regex.IsMatch(format, @"^F\d*?$"))
                return ((double)this).ToString(format, provider);
            if (Regex.IsMatch(format, @"^[0#]+[.,][0#]+$"))
                return ((double)this).ToString(format, provider);
            if (Regex.IsMatch(format, @"^DIV.*?$"))
                return string.Format(provider, "{0}{1}{2}", _numerator, format.Replace("DIV", string.Empty),
                                     _denominator);
            return string.Format(provider, "{0}/{1}", _numerator, _denominator);
        }

        #endregion

        #region Compare Methods
        /// <summary>
        /// Сравнивает этот экземпляр с заданным объектом и возвращает значение, указывающее, как соотносятся значения этих объектов.
        /// </summary>
        /// <returns>
        /// Знаковое число, представляющее относительные значения этого экземпляра и параметра <paramref name="value"/>. Возвращаемое значение  Описание  Меньше нуля  Данный экземпляр меньше <paramref name="value"/>.  Zero  Этот экземпляр и параметр <paramref name="value"/> равны.  Больше нуля.  Этот экземпляр больше параметра <paramref name="value"/>. -или-  Параметр <paramref name="value"/> имеет значение null.
        /// </returns>
        /// <param name="value">Объект для сравнения или значение null.</param><exception cref="T:System.ArgumentException">Параметр <paramref name="value"/> не относится к типу <see cref="T:RationalNumber.Rational"/>.</exception>
        public int CompareTo(object value)
        {
            if (value == null)
                return 1;
            if (!(value is Rational))
                throw new ArgumentException("Параметр obj не относится к типу Rational");
            return CompareTo(value as Rational);
        }

        /// <summary>
        /// Сравнивает данный экземпляр с заданным рациональным числом и возвращает значение, указывающее, как соотносятся их значения.
        /// </summary>
        /// <returns>
        /// Знаковое число, представляющее относительные значения этого экземпляра и параметра <paramref name="value"/>. Возвращаемое значение  Описание  Меньше нуля  Данный экземпляр меньше <paramref name="value"/>.  Zero  Этот экземпляр и параметр <paramref name="value"/> равны.  Больше нуля.  Этот экземпляр больше параметра <paramref name="value"/>.
        /// </returns>
        /// <param name="value">Рациональное число для сравнения.</param>
        public int CompareTo(Rational value)
        {
            return value == null ? 1 : (_numerator * value._denominator).CompareTo(value._numerator * _denominator);
        }

        /// <summary>
        /// Возврат значения, показывающего, равен ли данный экземпляр заданному объекту.
        /// </summary>
        /// <returns>
        /// true, если параметр <paramref name="obj"/> является экземпляром типа <see cref="T:RationalNumber.Rational"/> и равен значению данного экземпляра; в противном случае — false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Rational))
                return false;
            return Equals(obj as Rational);
        }

        /// <summary>
        /// Возврат значения, показывающего, равен ли данный экземпляр заданному объекту.
        /// </summary>
        /// <returns>
        /// true, если параметр <paramref name="value"/> равен значению данного экземпляра; в противном случае — false.
        /// </returns>
        /// <param name="value">Рациональное число для сравнения с данным экземпляром.</param>
        public bool Equals(Rational value)
        {
            if (ReferenceEquals(null, value)) return false;
            if (ReferenceEquals(this, value)) return true;
            return _numerator == value._numerator && _denominator == value._denominator;
        }

        /// <summary>
        /// Возвращает хэш-код для данного экземпляра.
        /// </summary>
        /// <returns>
        /// Хэш-код в виде 32-битовым целым числом со знаком.
        /// </returns>
        public override int GetHashCode()
        {
            return (_numerator) ^ (_denominator != null ? _denominator.GetHashCode() : 0);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Приводит рациональные числа к общему знаменателю
        /// </summary>
        /// <param name="x">Рациональное число.</param>
        /// <param name="y">Рациональное число.</param>
        private static int CommonDenomenator(Rational x, Rational y)
        {
            return (int)MathExtansion.LCM(x._denominator, y._denominator);
            /*var factor = lcm / x._denominator;
            var numerator = x._numerator * factor;
            var denumerator = x._denominator * factor;
            x = new Rational(numerator, denumerator);
            factor = lcm / y._denominator;
            numerator = y._numerator * factor;
            denumerator = y._denominator * factor;
            y = new Rational(numerator, denumerator);
            return lcm;*/
        }

        /// <summary>
        /// Приводит дробь к наименьшему знаменателю.
        /// </summary>
        private static void ToLowestTerm(ref int numerator, ref Natural denumerator)
        {
            var gcd = MathExtansion.GCD(numerator, denumerator);
            numerator = (int)(numerator / gcd);
            denumerator = new Natural((int)(denumerator / gcd));
        }

        private static Rational ParseCommonFraction(string s)
        {
            var nums = s.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var numerator = int.Parse(nums[0]);
                var denumerator = int.Parse(nums[1]);
                return new Rational(numerator, denumerator);
            }
            catch (FormatException)
            {
                throw new FormatException("Неверный формат задания рационального числа.");
            }
        }

        private static Rational ParseCirculatingFraction(string s)
        {
            var parts = s.Split(new[] { ',', '.', '(' });
            try
            {
                var cons = new Rational(int.Parse(parts[0] + parts[1]), (int)Math.Pow(10, parts[1].Length));
                parts[2] = parts[2].TrimEnd(')');
                var denominator = 0;
                for (var i = 0; i < parts[2].Length; i++)
                    denominator = denominator * 10 + 9;
                denominator *= (int)Math.Pow(10, parts[1].Length);
                var rep = new Rational(int.Parse(parts[2]), denominator);
                return cons + rep;
            }
            catch (FormatException)
            {
                throw new FormatException("Неверный формат задания рационального числа.");
            }
        }

        #endregion
    }
}
