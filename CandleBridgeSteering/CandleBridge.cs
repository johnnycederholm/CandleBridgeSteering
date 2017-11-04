using System;

namespace CandleBridgeSteering
{
    /// <summary>
    /// Settings for a candle bridge.
    /// </summary>
    class CandleBridge
    {
        public string Name { get; set; }
        public string OnCode { get; set; }
        public string OffCode { get; set; }

        public CandleBridge(string name, string onCode, string offCode)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (onCode == null)
                throw new ArgumentNullException("onCode");

            if (offCode == null)
                throw new ArgumentNullException("offCode");

            Name = name;
            OnCode = onCode;
            OffCode = offCode;
        }
    }
}
