using System;
using System.Configuration;

namespace CandleBridgeSteering.Configuration
{
    [ConfigurationCollection(typeof(CandleBridgeElement), AddItemName = "candleBridge", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    class CandleBridgeCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CandleBridgeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((CandleBridgeElement)element).Name;
        }
    }
}
