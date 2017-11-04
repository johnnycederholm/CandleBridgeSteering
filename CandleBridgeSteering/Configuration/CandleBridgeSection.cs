using System.Configuration;

namespace CandleBridgeSteering.Configuration
{
    class CandleBridgeSection : ConfigurationSection
    {
        [ConfigurationProperty("candleBridges", Options = ConfigurationPropertyOptions.IsRequired)]
        public CandleBridgeCollection CandleBridges
        {
            get
            {
                return (CandleBridgeCollection)this["candleBridges"];
            }
        }
    }
}
