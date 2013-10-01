using System.Collections.Generic;
using RationalNumber;

namespace Currency
{
    public static class CurrencyRounder
    {
        private static Dictionary<int, Rational> _roundingOptions;

        private static Dictionary<int, Rational> RoundingOptions
        {
            get
            {
                if (_roundingOptions != null)
                    return _roundingOptions;
                _roundingOptions = new Dictionary<int, Rational>
                    {
                        {840, Rational.Create(0.01, 2)},    //USD
                        {978, Rational.Create(0.01, 2)},    //EUR
                        {974, Rational.Create(10)},         //BYR
                        {643, Rational.Create(0.01, 2)},    //RUB
                        {980, Rational.Create(0.01, 2)}     //UAH
                    };
                return _roundingOptions;
            }
        }

        /// <summary>
        /// Округление согласно наименьшему наминалу выбранной валюты.
        /// </summary>
        /// <param name="info">Информация о валюте.</param>
        /// <param name="amount">Количество валюты.</param>
        /// <returns>Округлённое количество валюты.</returns>
        public static Rational Round(CurrencyInfo info, Rational amount)
        {
            var minNominal = GetMinCurrencyNominal(info);
            var maxBanknoteNumber = (int)(amount/minNominal);
            return maxBanknoteNumber * minNominal;
        }

        /// <summary>
        /// Получить наименьший номинал выбранной валюты.
        /// </summary>
        /// <param name="info">Информация о валюте.</param>
        /// <returns>Наименьший номинал выбранной валюты.</returns>
        public static Rational GetMinCurrencyNominal(CurrencyInfo info)
        {
            return RoundingOptions[info.NumberCode];
        }

        /// <summary>
        /// Установить наименьший номинал для валюты.
        /// </summary>
        /// <param name="info">Информация о валюте.</param>
        /// <param name="minNominal">Наименьший номинал выбранной валюты.</param>
        public static void SetMinCurrencyNominal(CurrencyInfo info, Rational minNominal)
        {
            RoundingOptions[info.NumberCode] = minNominal;
        }
    }
}
