using CandleBridgeSteering.Configuration;
using System.Collections.Generic;
using System.Configuration;

namespace CandleBridgeSteering
{
    class ApplicationSettings
    {
        public string CalendarUrl { get;  }
        public string CodesendLocation { get; }
        public int SleepTimeBetweenCandleBridge { get; }
        public IEnumerable<CandleBridge> CandleBridges { get; }

        private ApplicationSettings(string calendarUrl, IEnumerable<CandleBridge> candleBridges, string codesendLocation, int sleepTimeBetweenCandleBridge)
        {
            CalendarUrl = calendarUrl;
            CandleBridges = candleBridges;
            CodesendLocation = codesendLocation;
            SleepTimeBetweenCandleBridge = sleepTimeBetweenCandleBridge;
        }

        /// <summary>
        /// Get instance of settings for application.
        /// </summary>
        /// <returns></returns>
        public static ApplicationSettings GetInstance()
        {
            List<CandleBridge> candleBridgeSettings = new List<CandleBridge>();
            CandleBridgeSection section = (CandleBridgeSection)ConfigurationManager.GetSection("candleBridgeSettings");

            foreach (CandleBridgeElement candleBridge in section.CandleBridges)
            {
                candleBridgeSettings.Add(new CandleBridge(
                    candleBridge.Name,
                    candleBridge.OnCode,
                    candleBridge.OffCode
                ));
            }

            return new ApplicationSettings(
                ConfigurationManager.AppSettings["CalendarUrl"],
                candleBridgeSettings,
                ConfigurationManager.AppSettings["CodesendLocation"],
                GetSleepTime()
            );
        }

        /// <summary>
        /// Get sleep time from configuration file.
        /// </summary>
        private static int GetSleepTime()
        {
            int defaultSleepTime = 500;
            int sleepTimeBetweenCandleBridge = 0;
            int.TryParse(ConfigurationManager.AppSettings["SleepTimeBetweenCandleBridge"], out sleepTimeBetweenCandleBridge);

            return sleepTimeBetweenCandleBridge != 0 ? sleepTimeBetweenCandleBridge : defaultSleepTime;
        }
    }
}
