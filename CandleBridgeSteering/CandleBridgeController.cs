using iCalendar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandleBridgeSteering
{
    class CandleBridgeController
    {
        public Calendar Calendar { get; private set; }
        public IEnumerable<CandleBridgeSetting> CandleBridgeSettings { get; private set; }

        public CandleBridgeController(Calendar calendar, IEnumerable<CandleBridgeSetting> candleBridgeSettings)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar));
            }

            if (candleBridgeSettings == null)
            {
                throw new ArgumentNullException(nameof(candleBridgeSettings));
            }

            Calendar = calendar;
            CandleBridgeSettings = candleBridgeSettings;
        }

        public void UpdateStates()
        {
            foreach (CandleBridgeSetting candleBridgeSetting in CandleBridgeSettings)
            {
                if (ShouldTurnOnCandleBridge(candleBridgeSetting, Calendar))
                {
                    Console.WriteLine($"{candleBridgeSetting.Name} on...");
                }
                else
                {
                    Console.WriteLine($"{candleBridgeSetting.Name} off...");
                }
            }
        }

        private bool ShouldTurnOnCandleBridge(CandleBridgeSetting candleBridge, Calendar calendar)
        {
            return calendar.Events.Any(calendarEvent => calendarEvent.Summary.Equals(candleBridge.Name) && calendarEvent.Ongoing);
        }
    }
}
