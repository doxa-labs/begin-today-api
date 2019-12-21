using BeginDoing.Data.Model;
using System.Collections.Generic;

namespace BeginDoing.Data.Service.Interface
{
    public interface ISpiritService
    {
        IEnumerable<Spirit> Get();
        Spirit Get(string id);
        Spirit Login(RequestLogin value);
        Spirit Register(RequestLogin value);
        Spirit SetDaily(List<Daily> value, string id);
        Spirit SetTodo(List<Daily> value, string id);
        Spirit SetChain(RequestChain value, string id);
    }
}
