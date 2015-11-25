using iCalendar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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
                throw new ArgumentNullException("calendar");
            }

            if (candleBridgeSettings == null)
            {
                throw new ArgumentNullException("candleBridgeSettings");
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
                    Console.WriteLine("{0} on...", candleBridgeSetting.Name);
                    Process.Start("/var/www/rfoutlet/codesend", candleBridgeSetting.OnCode);
                }
                else
                {
                    Console.WriteLine("{0} off...", candleBridgeSetting.Name);
                    Process.Start("/var/www/rfoutlet/codesend", candleBridgeSetting.OffCode);
                }

                Thread.Sleep(500);
            }
        }

        private bool ShouldTurnOnCandleBridge(CandleBridgeSetting candleBridge, Calendar calendar)
        {
            return calendar.Events.Any(calendarEvent => calendarEvent.Summary.Equals(candleBridge.Name) && calendarEvent.Ongoing);
        }
    }
}
