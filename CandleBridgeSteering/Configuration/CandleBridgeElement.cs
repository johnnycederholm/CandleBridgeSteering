using System.Configuration;

namespace CandleBridgeSteering.Configuration
{
    class CandleBridgeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }

        [ConfigurationProperty("onCode", IsRequired = true, IsKey = true)]
        public string OnCode
        {
            get
            {
                return (string)base["onCode"];
            }
        }

        [ConfigurationProperty("offCode", IsRequired = true, IsKey = true)]
        public string OffCode
        {
            get
            {
                return (string)base["offCode"];
            }
        }
    }
}
