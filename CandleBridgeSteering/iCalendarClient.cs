using iCalendar;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandleBridgeSteering
{
    class iCalendarClient
    {
        private string CalendarUrl { get; set; }

        /// <param name="calendarUrl">Url pointing to resource holding iCalendar-data.</param>
        public iCalendarClient(string calendarUrl)
        {
            if (string.IsNullOrWhiteSpace(calendarUrl))
            {
                throw new ArgumentException("calendarUrl is null or empty.");
            }

            CalendarUrl = calendarUrl;
        }

        /// <summary>
        /// Get calendar.
        /// </summary>
        public async Task<Calendar> GetCalendar()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(CalendarUrl);
                CalendarParser parser = new CalendarParser(response);

                return parser.Parse();
            }
        }
    }
}
