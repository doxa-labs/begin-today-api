using BeginDoing.Data.Model;
using BeginDoing.Data.Repository.Interface;
using Repository.Mongo;

namespace BeginDoing.Data.Repository
{
    public class CalendarRepository : Repository<Calendar>, ICalendarRepository
    {
        public CalendarRepository(string connectionString) : base(connectionString, "calendars")
        {
        }
    }
}
