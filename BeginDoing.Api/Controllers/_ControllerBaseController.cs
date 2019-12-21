using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// Team
using BeginDoing.Api.Model;

namespace BeginDoing.Api.Controllers
{
    public class ControllerBase : Controller
    {
        protected Return Invoke<T>(Task<T> action)
        {
            Return response = new Return();
            try
            {
                action.RunSynchronously();
                response.Data = action.Result;

                if (response.Data == null)
                {
                    response.SetMessage(Level.MissingData, "");
                }
            }
            catch
            {
                response.SetMessage(Level.Error, "SystemFailure");
            }
            return response;

        }

        protected ReturnLogin InvokeLogin<T>(Task<T> action)
        {
            ReturnLogin response = new ReturnLogin();
            try
            {
                action.RunSynchronously();
                response.Data = action.Result;
                response.Token = "token1";

                if (response.Data == null)
                {
                    response.SetMessage(Level.MissingData, "");
                }
            }
            catch
            {
                response.SetMessage(Level.Error, "SystemFailure");
            }
            return response;
        }
    }
}