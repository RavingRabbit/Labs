using System.Collections.Generic;
using RationalNumber;

namespace Currency
{
    public static class CurrencyExchanger
    {
        private static Dictionary<int, Rational> _currencyRates;

        private static Dictionary<int, Rational> CurrencyRates
        {
            get
            {
                if (_currencyRates != null)
                    return _currencyRates;
                _currencyRates = new Dictionary<int, Rational>
                    {
                        {840, 1},                         //USD
                        {978, Rational.Create(0.77, 2)},  //EUR
                        {974, 8550},                      //BYR
                        {643, Rational.Create(31.26, 2)}, //RUB
                        {980, Rational.Create(8.13, 2)}   //UAH
                    };
                return _currencyRates;
            }
        }

        /// <summary>
        /// Обменять валюту.
        /// </summary>
        /// <param name="from">Исходная валюта.</param>
        /// <param name="to">Информация о желаемой валюте.</param>
        /// <returns>Желаемая валюта.</returns>
        public static Currency Exchange(this Currency from, CurrencyInfo to)
        {
            var newAmount = from.Amount*GetExchangeRate(from.Info, to);
            return Currency.GetCurrency(to.NumberCode, newAmount);
        }

        /// <summary>
        /// Обменять валюту.
        /// </summary>
        /// <param name="from">Исходная валюта.</param>
        /// <param name="toNumberCode">Цифровой код желаемой валюты.</param>
        /// <returns>Желаемая валюта.</returns>
        public static Currency Exchange(this Currency from, int toNumberCode)
        {
            return Exchange(from, new CurrencyInfo(toNumberCode));
        }

        /// <summary>
        /// Обменять валюту.
        /// </summary>
        /// <param name="from">Исходная валюта.</param>
        /// <param name="toAlphaCode">3-х буквенный код желаемой валюты.</param>
        /// <returns>Желаемая валюта.</returns>
        public static Currency Exchange(this Currency from, string toAlphaCode)
        {
            return Exchange(from, CurrencyCodeTable.GetNumberCode(toAlphaCode));
        }

        /// <summary>
        /// Получить курс обмена валют.
        /// </summary>
        /// <param name="from">Исходная валюта.</param>
        /// <param name="to">Информация о желаемой валюте.</param>
        /// <returns>Курс обмена выбранных валют.</returns>
        public static Rational GetExchangeRate(CurrencyInfo from, CurrencyInfo to)
        {
            return CurrencyRates[to.NumberCode] / CurrencyRates[from.NumberCode];
        }

        /// <summary>
        /// Получить курс обмена валют.
        /// </summary>
        /// <param name="fromNumberCode">Цифровой код исходной валюты.</param>
        /// <param name="toNumberCode">Цифровой код желаемой валюты.</param>
        /// <returns>Курс обмена выбранных валют.</returns>
        public static Rational GetExchangeRate(int fromNumberCode, int toNumberCode)
        {
            return GetExchangeRate(new CurrencyInfo(fromNumberCode), new CurrencyInfo(toNumberCode));
        }

        /// <summary>
        /// Получить курс обмена валют.
        /// </summary>
        /// <param name="fromAlphaCode">3-х буквенный код исходной валюты.</param>
        /// <param name="toAlphaCode">3-х буквенный код желаемой валюты.</param>
        /// <returns>Курс обмена выбранных валют.</returns>
        public static Rational GetExchangeRate(string fromAlphaCode, string toAlphaCode)
        {
            return GetExchangeRate(new CurrencyInfo(fromAlphaCode), new CurrencyInfo(toAlphaCode));
        }

        /// <summary>
        /// Установить новый курс обмена валют.
        /// </summary>
        /// <param name="info">Информация о валюте.</param>
        /// <param name="newRate">Курс валюты относительно usd.</param>
        public static void SetNewExchangeRate(CurrencyInfo info, Rational newRate)
        {
            CurrencyRates[info.NumberCode] = newRate;
        }

        /// <summary>
        /// Установить новый курс обмена валют.
        /// </summary>
        /// <param name="numberCode">Цифровой код валюты.</param>
        /// <param name="newRate">Курс валюты относительно usd.</param>
        public static void SetNewExchangeRate(int numberCode, Rational newRate)
        {
            SetNewExchangeRate(new CurrencyInfo(numberCode), newRate);
        }

        /// <summary>
        /// Установить новый курс обмена валют.
        /// </summary>
        /// <param name="alphaCode">3-х буквенный код валюты.</param>
        /// <param name="newRate">Курс валюты относительно usd.</param>
        public static void SetNewExchangeRate(string alphaCode, Rational newRate)
        {
            SetNewExchangeRate(new CurrencyInfo(alphaCode), newRate);
        }
    }
}
