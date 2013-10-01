using System;
using RationalNumber;

namespace Currency
{
    public class CurrencyInfo : IEquatable<CurrencyInfo>
    {
        /// <summary>
        /// Числовой код валюты.
        /// </summary>
        public int NumberCode { get; private set; }

        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Name { get; private set; }

        internal CurrencyInfo(int numberCode)
        {
            if (!CurrencyCodeTable.IsValidNumberCode(numberCode))
                throw new ArgumentException();
            NumberCode = numberCode;
            Name = CurrencyCodeTable.GetName(NumberCode);
        }

        internal CurrencyInfo(string alphaCode)
        {
            if (!CurrencyCodeTable.IsValidAlphaCode(alphaCode))
                throw new ArgumentException();
            NumberCode = CurrencyCodeTable.GetNumberCode(alphaCode);
            Name = CurrencyCodeTable.GetName(NumberCode);
        }

        /// <summary>
        /// Получить указанное количество данной валюты.
        /// </summary>
        public Currency GetCurrency(Rational amount)
        {
            return Currency.GetCurrency(NumberCode, amount);
        }

        /// <summary>
        /// Возврат значения, показывающего, равен ли данный экземпляр заданному объекту.
        /// </summary>
        /// <returns>
        /// true, если параметр <paramref name="obj"/> является экземпляром типа <see cref="T:Currency.CurrencyInfo"/> и равен значению данного экземпляра; в противном случае — false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj) || !(obj is CurrencyInfo))
                return false;
            return Equals((CurrencyInfo)obj);
        }

        /// <summary>
        /// Возврат значения, показывающего, равен ли данный экземпляр заданному объекту.
        /// </summary>
        /// <returns>
        /// true, если параметр <paramref name="other"/> равен значению данного экземпляра; в противном случае — false.
        /// </returns>
        /// <param name="other">Информация о валюте для сравнения с данным экземпляром.</param>
        public bool Equals(CurrencyInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return NumberCode == other.NumberCode && string.Equals(Name, other.Name);
        }

        public static bool operator ==(CurrencyInfo info1, CurrencyInfo info2)
        {
            if (ReferenceEquals(info1, info2))
                return true;
            if (ReferenceEquals(null, info1) || ReferenceEquals(null, info2))
                return false;
            return info1.Equals(info2);
        }

        public static bool operator !=(CurrencyInfo info1, CurrencyInfo info2)
        {
            return !(info1 == info2);
        }

        /// <summary>
        /// Возвращает хэш-код для данного экземпляра.
        /// </summary>
        /// <returns>
        /// Хэш-код в виде 32-битовым целым числом со знаком.
        /// </returns>
        public override int GetHashCode()
        {
            return (NumberCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
