using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Patterns.Range;

namespace Patterns
{
    [DataContract(Name = "phone")]
    public abstract class Phone
    {
        /*[DataMember(Name = "frequecyRange", Order = 0)]
        private readonly Range<double> _frequecyRange;
        [DataMember(Name = "flushAntenna", Order = 1)]
        private readonly bool _flushAntenna;*/
        [DataMember(Name = "serialNumber", Order = 0)]
        private readonly UInt64 _serialNumber;
        [DataMember(Name = "coverage", Order = 1)]
        private readonly double _coverage;

        protected Phone(double coverage)
        {
            /*if (frequecyRange == null)
                throw new ArgumentNullException("frequecyRange");
            _frequecyRange = frequecyRange;
            _flushAntenna = flushAntenna;*/
            if (coverage <= 0)
                throw new ArgumentOutOfRangeException("coverage");
            _coverage = coverage;
            _serialNumber = KeyGenerator.Instance.GetKey();
        }

        /// <summary>
        /// Coverage range is in KM.
        /// </summary>
        public double Coverage { get { return _coverage; } }

        /*/// <summary>
        /// Frequency range is in MHz.
        /// </summary>
        public Range<double> FrequecyRange { get { return _frequecyRange; } }

        public bool FlushAntenna { get { return _flushAntenna; } }*/

        public UInt64 SerialNumber { get { return _serialNumber; } }
    }
}
