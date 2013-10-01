using System;
using System.Collections.Generic;

namespace Currency
{
    internal static class CurrencyCodeTable
    {
        private static Dictionary<string, int> _currencyCodes;

        private static Dictionary<int, string> _currencyNames;

        private static Dictionary<int, string> _currencySymbols;

        private static Dictionary<string, int> CurrencyCodes
        {
            get
            {
                if (_currencyCodes != null)
                    return _currencyCodes;
                _currencyCodes = new Dictionary<string, int>
                    {{"USD", 840}, {"EUR", 978}, {"BYR", 974}, {"RUB", 643}, {"UAH", 980}};
                return _currencyCodes;
            }
        }

        private static Dictionary<int, string> CurrencyNames
        {
            get
            {
                if (_currencyNames != null)
                    return _currencyNames;
                _currencyNames = new Dictionary<int, string>
                    {
                        {840, "US Dollar"},
                        {978, "Euro"},
                        {974, "Belarussian Ruble"},
                        {643, "Russian Ruble"},
                        {980, "Hryvnia"}
                    };
                return _currencyNames;
            }
        }

        private static Dictionary<int, string> CurrencySymbols
        {
            get
            {
                if (_currencySymbols != null)
                    return _currencySymbols;
                _currencySymbols = new Dictionary<int, string>
                    {
                        {840, "$"},
                        {978, "Eu"},
                        {974, "BYR"},
                        {643, "RUB"},
                        {980, "Hr"}
                    };
                return _currencySymbols;
            }
        }

        /// <summary>
        /// Получить числовой код валюты по её 3-х буквенному коду.
        /// </summary>
        /// <param name="alphaCode">3-х буквенный код валюты.</param>
        /// <returns>Числовой код валюты.</returns>
        public static int GetNumberCode(string alphaCode)
        {
            alphaCode = alphaCode.ToUpper();
            if (IsValidAlphaCode(alphaCode))
                return CurrencyCodes[alphaCode];
            throw new ArgumentOutOfRangeException("alphaCode");
        }

        /// <summary>
        /// Получить название валюты по её числовому коду.
        /// </summary>
        /// <param name="numberCode">Числовой код валюты.</param>
        /// <returns>Название валюты.</returns>
        public static string GetName(int numberCode)
        {
            if (IsValidNumberCode(numberCode))
                return CurrencyNames[numberCode];
            throw new ArgumentOutOfRangeException("numberCode");
        }

        /// <summary>
        /// Получить буквенное обозначение валюты по её числовому коду.
        /// </summary>
        /// <param name="numberCode">Числовой код валюты.</param>
        /// <returns>Буквенное обозначение валюты.</returns>
        public static string GetSymbol(int numberCode)
        {
            if (IsValidNumberCode(numberCode))
                return CurrencySymbols[numberCode];
            throw new ArgumentOutOfRangeException("numberCode");
        }

        public static CurrencyInfo GetInfoFromNameOfSymbol(string name)
        {
            if (CurrencyNames.ContainsValue(name))
            {
                foreach (KeyValuePair<int, string> currencyName in CurrencyNames)
                {
                    if (currencyName.Value == name)
                        return new CurrencyInfo(currencyName.Key);
                }
            }
            if (CurrencySymbols.ContainsValue(name))
            {
                foreach (KeyValuePair<int, string> currencySymbol in CurrencySymbols)
                {
                    if (currencySymbol.Value == name)
                        return new CurrencyInfo(currencySymbol.Key);
                }
            }
            throw new ArgumentOutOfRangeException("name");
        }

        /// <summary>
        /// Проверяет, правильный ли числовой код.
        /// </summary>
        /// <param name="numberCode">Числовой код валюты.</param>
        /// <returns>True, если числовой код валюты существует, в противном случае false.</returns>
        public static bool IsValidNumberCode(int numberCode)
        {
            return CurrencyCodes.ContainsValue(numberCode);
        }

        /// <summary>
        /// Проверяет, правильный ли 3-х буквенный код.
        /// </summary>
        /// <param name="alphaCode">3-х буквенный код валюты.</param>
        /// <returns>True, если 3-х буквенный код валюты существует, в противном случае false.</returns>
        public static bool IsValidAlphaCode(string alphaCode)
        {
            alphaCode = alphaCode.ToUpper();
            return CurrencyCodes.ContainsKey(alphaCode);
        }

        /// <summary>
        /// Получить массив информации обо всех поддерживаемых валютах.
        /// </summary>
        /// <returns>Массив информации обо всех поддерживаемых валютах.</returns>
        public static CurrencyInfo[] GetCurrencies()
        {
            var currencyInfoArray = new CurrencyInfo[CurrencyCodes.Count];
            var i = 0;
            foreach (var currencyCode in CurrencyCodes.Values)
            {
                currencyInfoArray[i] = new CurrencyInfo(currencyCode);
                i++;
            }
            return currencyInfoArray;
        }
    }
}
