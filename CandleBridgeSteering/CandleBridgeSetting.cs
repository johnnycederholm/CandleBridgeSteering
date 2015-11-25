using System;

namespace CandleBridgeSteering
{
    /// <summary>
    /// Settings for a candle bridge.
    /// </summary>
    class CandleBridgeSetting
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public CandleBridgeSetting(string name, string code)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            Name = name;
            Code = code;
        }
    }
}
