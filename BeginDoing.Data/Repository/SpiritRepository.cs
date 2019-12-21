using Repository.Mongo;
using BeginDoing.Data.Model;
using BeginDoing.Data.Repository.Interface;

namespace BeginDoing.Data.Repository
{
    public class SpiritRepository : Repository<Spirit>, ISpiritRepository
    {
        public SpiritRepository(string connectionString) : base(connectionString, "spirits")
        {
        }
    }
}