using MongoDB.Bson.Serialization.Attributes;
using Repository.Mongo;
using System.Collections.Generic;

namespace BeginDoing.Data.Model
{
    public class Calendar : Entity
    {
        [BsonElement("year")]
        public int Year { get; set; }
        [BsonElement("months")]
        public List<Month> Months { get; set; }
    }
}
