using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    public class Merchandiser
    {
        private const double DefaultCordlessPhoneCoverage = 0.1;
        private const double DefaultMobilePhoneCoverage = 10;
        private const double DefaultSatellitePhoneCoverage = 10000;

        public Phone GetPhoneWithCoverage(double coverage)
        {
            if (coverage <= 0)
                throw new ArgumentOutOfRangeException("coverage");
            if (coverage <= DefaultCordlessPhoneCoverage)
                return new CordlessPhone(DefaultCordlessPhoneCoverage);
            if (coverage <= DefaultMobilePhoneCoverage)
                return new MobilePhone(DefaultMobilePhoneCoverage);
            return new SatellitePhone(DefaultSatellitePhoneCoverage);
        }
    }
}
