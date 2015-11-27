using System.Threading.Tasks;
using iCalendar;

namespace CandleBridgeSteering
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationSettings settings = ApplicationSettings.GetInstance();
            iCalendarClient client = new iCalendarClient(settings.CalendarUrl);

            Task<Calendar> calendarTask = client.GetCalendar();
            Calendar calendar = calendarTask.Result;

            CandleBridgeController candleBridgeController = new CandleBridgeController(calendar, settings);
            candleBridgeController.UpdateStates();
        }
    }
}
