using System.Collections.Generic;
using System.Threading.Tasks;
using BeginDoing.Api.Model;
using BeginDoing.Data.Model;
using BeginDoing.Data.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BeginDoing.Api.Controllers
{
    [Produces("application/json")]
    public class SpiritsController : ControllerBase
    {
        ISpiritService SpiritService { get; }
        public SpiritsController(ISpiritService spiritService)
        {
            SpiritService = spiritService;
        }

        [HttpGet("api/v1/spirits")]
        public Return Get()
        {
            return Invoke(new Task<IEnumerable<Spirit>>(() => SpiritService.Get()));
        }

        [HttpPost("api/v1/spirits/login")]
        public ReturnLogin Login([FromBody]RequestLogin value)
        {
            return InvokeLogin(new Task<Spirit>(() => SpiritService.Login(value)));
        }

        [HttpPost("api/v1/spirits/daily/{id}/edit")]
        public Return SetDaily([FromBody]List<Daily> value, string id)
        {
            return Invoke(new Task<Spirit>(() => SpiritService.SetDaily(value, id)));
        }

        [HttpPost("api/v1/spirits/todo/{id}/edit")]
        public Return SetTodo([FromBody]List<Daily> value, string id)
        {
            return Invoke(new Task<Spirit>(() => SpiritService.SetTodo(value, id)));
        }

        [HttpPost("api/v1/spirits/chain/{id}/edit")]
        public Return SetChain([FromBody]RequestChain value, string id)
        {
            return Invoke(new Task<Spirit>(() => SpiritService.SetChain(value, id)));
        }
    }
}