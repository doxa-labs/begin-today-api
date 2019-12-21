using MongoDB.Bson.Serialization.Attributes;
using Repository.Mongo;
using System.Collections.Generic;

namespace BeginDoing.Data.Model
{
    public class Spirit : Entity
    {
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("isActive")]
        public bool IsActive { get; set; }
        [BsonElement("daily")]
        public List<Daily> Daily { get; set; }
        [BsonElement("chain")]
        public Chain Chain { get; set; }
    }

    public class Daily
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("desc")]
        public string Desc { get; set; }
    }

    public class Chain
    {
        [BsonElement("todos")]
        public List<Daily> Todos { get; set; }
        [BsonElement("months")]
        public List<Month> Months { get; set; }
    }

    public class Month
    {
        [BsonElement("month")]
        public string Name { get; set; }
        [BsonElement("days")]
        public List<Day> Days { get; set; }
    }

    public class Day
    {
        [BsonElement("day")]
        public int No { get; set; }
        [BsonElement("isDone")]
        public bool IsDone { get; set; }
    }

    public class RequestLogin
    {
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
    }

    public class RequestChain
    {
        [BsonElement("month")]
        public int Month { get; set; }
        [BsonElement("day")]
        public int Day { get; set; }
        [BsonElement("isDone")]
        public bool isDone { get; set; }
    }
}
