using System.Collections.Generic;
using System.Configuration;

namespace CandleBridgeSteering
{
    class ApplicationSettings
    {
        public string CalendarUrl { get; set; }
        public string CodesendLocation { get; set; }
        public int SleepTimeBetweenCandleBridge { get; set; }
        public IEnumerable<CandleBridgeSetting> CandleBridgeSettings { get; set; }

        private ApplicationSettings()
        {
        }

        /// <summary>
        /// Get instance of settings for application.
        /// </summary>
        /// <returns></returns>
        public static ApplicationSettings GetInstance()
        {
            List<CandleBridgeSetting> candleBridgeSettings = new List<CandleBridgeSetting>
            {
                new CandleBridgeSetting(
                    ConfigurationManager.AppSettings["FirstCandleBridgeName"],
                    ConfigurationManager.AppSettings["FirstCandleBridgeOnCode"],
                    ConfigurationManager.AppSettings["FirstCandleBridgeOffCode"]
                ),
                new CandleBridgeSetting(
                    ConfigurationManager.AppSettings["SecondCandleBridgeName"],
                    ConfigurationManager.AppSettings["SecondCandleBridgeOnCode"],
                    ConfigurationManager.AppSettings["SecondCandleBridgeOffCode"]
                ),
                new CandleBridgeSetting(
                    ConfigurationManager.AppSettings["ThirdCandleBridgeName"],
                    ConfigurationManager.AppSettings["ThirdCandleBridgeOnCode"],
                    ConfigurationManager.AppSettings["ThirdCandleBridgeOffCode"]
                )
            };

            return new ApplicationSettings
            {
                CalendarUrl = ConfigurationManager.AppSettings["CalendarUrl"],
                CandleBridgeSettings = candleBridgeSettings,
                CodesendLocation = ConfigurationManager.AppSettings["CodesendLocation"],
                SleepTimeBetweenCandleBridge = GetSleepTime()
            };
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
