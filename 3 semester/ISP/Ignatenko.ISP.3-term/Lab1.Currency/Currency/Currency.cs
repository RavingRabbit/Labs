using System;
using System.Globalization;
using RationalNumber;

namespace Currency
{
    public class Currency : IEquatable<Currency>, IComparable<Currency>, IFormattable
    {
        #region Fields

        private readonly CurrencyInfo _info;

        private readonly Rational _amount;

        #endregion

        #region Properties

        /// <summary>
        /// Количество валюты.
        /// </summary>
        public Rational Amount { get { return _amount; } }

        /// <summary>
        /// Информация о валюте текущего экземпляра.
        /// </summary>
        public CurrencyInfo Info { get { return _info; } }

        #endregion

        #region Constructors

        private Currency(CurrencyInfo info, Rational amount)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            if (amount == null)
                throw new ArgumentNullException("amount");
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            if (info == null)
                throw new ArgumentNullException("info");
            _info = info;
            _amount = CurrencyRounder.Round(info, amount);
        }

        /// <summary>
        /// Получить указанное количество желаемой валюты.
        /// </summary>
        /// <param name="info">Информация о валюте.</param>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>Указанная валюта.</returns>
        public static Currency GetCurrency(CurrencyInfo info, Rational amount)
        {
            return info == null ? null : new Currency(info, amount);
        }

        /// <summary>
        /// Получить указанное количество желаемой валюты.
        /// </summary>
        /// <param name="numberCode">Числовой код валюты.</param>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>Указанная валюта.</returns>
        public static Currency GetCurrency(int numberCode, Rational amount)
        {
            return new Currency(new CurrencyInfo(numberCode), amount);
        }

        /// <summary>
        /// Получить указанное количество желаемой валюты.
        /// </summary>
        /// <param name="alfaCode">3-х буквенный код валюты.</param>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>Указанная валюта.</returns>
        public static Currency GetCurrency(string alfaCode, Rational amount)
        {
            return new Currency(new CurrencyInfo(alfaCode), amount);
        }

        /// <summary>
        /// Получить указанное количество USD - долларов США.
        /// </summary>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>USD.</returns>
        public static Currency USD(Rational amount)
        {
            return GetCurrency("USD", amount);
        }

        /// <summary>
        /// Получить указанное количество EUR - евро.
        /// </summary>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>EUR.</returns>
        public static Currency EUR(Rational amount)
        {
            return GetCurrency("EUR", amount);
        }

        /// <summary>
        /// Получить указанное количество BYR - белорусских рублей.
        /// </summary>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>BYR.</returns>
        public static Currency BYR(Rational amount)
        {
            return GetCurrency("BYR", amount);
        }

        /// <summary>
        /// Получить указанное количество RUB - российских рублей.
        /// </summary>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>RUB.</returns>
        public static Currency RUB(Rational amount)
        {
            return GetCurrency("RUB", amount);
        }

        /// <summary>
        /// Получить указанное количество UAH - гривен.
        /// </summary>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>UAH.</returns>
        public static Currency UAH(Rational amount)
        {
            return GetCurrency("UAH", amount);
        }

        #endregion

        #region Math Operators

        public static Currency operator +(Currency x, Currency y)
        {
            if (x == null || y == null)
                return null;
            if (!x.IsSameCurrency(y))
                return null;
            return GetCurrency(x.Info, x.Amount + y.Amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Currency operator -(Currency x, Currency y)
        {
            if (x == null || y == null)
                return null;
            if (!x.IsSameCurrency(y))
                return null;
            return GetCurrency(x.Info, x.Amount - y.Amount);
        }

        public static Currency operator *(Currency x, int y)
        {
            return x == null ? null : GetCurrency(x.Info, x.Amount * y);
        }

        public static Currency operator *(Currency x, Rational y)
        {
            return x == null ? null : GetCurrency(x.Info, x.Amount * y);
        }

        public static Currency operator /(Currency x, int y)
        {
            return x == null ? null : GetCurrency(x.Info, x.Amount / y);
        }

        public static Currency operator /(Currency x, Rational y)
        {
            return x == null ? null : GetCurrency(x.Info, x.Amount / y);
        }

        #endregion

        #region Comparsion Operators

        public static bool operator ==(Currency obj1, Currency obj2)
        {
            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
                return false;
            obj1 = obj1.Exchange(obj2.Info);
            return obj1.Amount == obj2.Amount;
        }

        public static bool operator !=(Currency obj1, Currency obj2)
        {
            return !(obj1 == obj2);
        }

        public static bool operator >=(Currency x, Currency y)
        {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator <=(Currency x, Currency y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >(Currency x, Currency y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator <(Currency x, Currency y)
        {
            return x.CompareTo(y) < 0;
        }

        #endregion

        #region Compare Methods

        public int CompareTo(Currency other)
        {
            if (!IsSameCurrency(other))
                other = other.Exchange(Info);
            return Amount.CompareTo(other.Amount);
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_info, other._info) && Equals(_amount, other._amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Currency)) return false;
            return Equals((Currency)obj);
        }

        public bool IsSameCurrency(Currency currency)
        {
            return Info.Equals(currency.Info);
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
        public static Currency Parse(string s)
        {
            if (s == null)
                return null;
            s = s.TrimStart(' ');
            var parts = s.Split(new[] { ' ' }, 2);
            if (parts.Length != 2)
                return null;
            var amount = Rational.Parse(parts[0]);
            var info = CurrencyCodeTable.GetInfoFromNameOfSymbol(parts[1]);
            return new Currency(info, amount);
        }
        

        /// <summary>
        /// Преобразовывает значение данного экземпляра в эквивалентное ему строковое представление.
        /// </summary>
        /// <returns>
        /// Строковое представление значения данного экземпляра, состоящее из количества валюты и её символьного обозначения.
        /// </returns>
        public override string ToString()
        {
            return ToString("S", CultureInfo.InvariantCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrWhiteSpace(format))
                format = "S";
            format = format.ToUpper();
            var result = Amount.ToString("f", provider);
            switch (format)
            {
                case "N":
                    return result + " " + Info.Name;
                case "S":
                    return result + " " + CurrencyCodeTable.GetSymbol(Info.NumberCode);
                default:
                    throw new FormatException(String.Format("Строка формата {0} не поддерживается.", format));
            }
        }

        #endregion

        #region Public Methods

        public static CurrencyInfo[] GetCurrencies()
        {
            return CurrencyCodeTable.GetCurrencies();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_info != null ? _info.GetHashCode() : 0) * 397) ^ (_amount != null ? _amount.GetHashCode() : 0);
            }
        }

        #endregion
    }
}
