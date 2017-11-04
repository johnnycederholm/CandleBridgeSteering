using iCalendar;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CandleBridgeSteering
{
    class CandleBridgeController
    {
        public Calendar Calendar { get; private set; }
        public ApplicationSettings Settings { get; private set; }

        public CandleBridgeController(Calendar calendar, ApplicationSettings settings)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException("calendar");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Calendar = calendar;
            Settings = settings;
        }

        public void UpdateStates()
        {
            foreach (CandleBridge candleBridgeSetting in Settings.CandleBridges)
            {
                if (ShouldTurnOnCandleBridge(candleBridgeSetting, Calendar))
                {
                    Process.Start(Settings.CodesendLocation, candleBridgeSetting.OnCode);
                }
                else
                {
                    Process.Start(Settings.CodesendLocation, candleBridgeSetting.OffCode);
                }

                Thread.Sleep(Settings.SleepTimeBetweenCandleBridge);
            }
        }

        private bool ShouldTurnOnCandleBridge(CandleBridge candleBridge, Calendar calendar)
        {
            return calendar.Events.Any(calendarEvent => calendarEvent.Summary.Equals(candleBridge.Name) && calendarEvent.Ongoing);
        }
    }
}
