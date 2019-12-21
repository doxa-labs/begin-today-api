using System.Collections.Generic;
using BeginDoing.Data.Model;
using BeginDoing.Data.Repository.Interface;
using BeginDoing.Data.Service.Interface;
using MongoDB.Driver;

namespace BeginDoing.Data.Service
{
    public class SpiritService : ISpiritService
    {
        ISpiritRepository Repository { get; }
        ICalendarRepository CalendarRepository { get; }
        public SpiritService(ISpiritRepository repository, ICalendarRepository calendarRepository) //: base(repository)
        {
            Repository = repository;
            CalendarRepository = calendarRepository;
        }

        public IEnumerable<Spirit> Get()
        {
            return Repository.FindAll();
        }

        public Spirit Get(string id)
        {
            return Repository.First(s => s.Id == id);
        }

        //todo not completed
        public Spirit Login(RequestLogin value)
        {
            var spirit = Repository.First(s => s.Username == value.Username);

            if (spirit == null)
            {
                return Register(value);
            } else
            {
                if (spirit.IsActive == true && spirit.Password == value.Password)
                {
                    return spirit;
                } else
                {
                    return new Spirit();
                }
            }
        }

        public Spirit Register(RequestLogin value)
        {
            Calendar c = CalendarRepository.First();

            Spirit s = new Spirit();
            s.Username = value.Username;
            s.Password = value.Password;
            s.Chain = new Chain();
            s.Chain.Months = c.Months;
            s.IsActive = false;

            Repository.Insert(s);

            return Login(value);
        }

        public Spirit SetDaily(List<Daily> value, string id)
        {
            var filter = Builders<Spirit>.Filter.Where(s => s.Id == id);
            var update = Builders<Spirit>.Update.Set(s => s.Daily, value);
            var result = Repository.Update(filter, update);

            if (result == true)
            {
                return Get(id);
            }
            else
            {
                return new Spirit(); // todo: return false status..
            }
        }

        public Spirit SetTodo(List<Daily> value, string id)
        {
            var filter = Builders<Spirit>.Filter.Where(s => s.Id == id);
            var update = Builders<Spirit>.Update.Set(s => s.Chain.Todos, value);
            var result = Repository.Update(filter, update);

            if (result == true)
            {
                return Get(id);
            }
            else
            {
                return new Spirit(); // todo: return false status..
            }
        }

        public Spirit SetChain(RequestChain value, string id)
        {
            Spirit spirit = Get(id);
            spirit.Chain.Months[value.Month].Days[value.Day].IsDone = value.isDone;

            var filter = Builders<Spirit>.Filter.Where(s => s.Id == id);
            var update = Builders<Spirit>.Update.Set(s => s.Chain, spirit.Chain);
            var result = Repository.Update(filter, update);

            if (result == true)
            {
                return Get(id);
            }
            else
            {
                return new Spirit(); // todo: return false status..
            }
        }
    }
}
