using BeginDoing.Data.Repository;
using BeginDoing.Data.Repository.Interface;
using BeginDoing.Data.Service;
using BeginDoing.Data.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BeginDoing.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings appSettings)
        {
            // Allow Cors
            services.AddCors();

            var data = appSettings.ConnectionString;

            services.AddTransient<ISpiritRepository>(i => new SpiritRepository(data));
            services.AddTransient<ICalendarRepository>(i => new CalendarRepository(data));

            services.AddSingleton<ISpiritService, SpiritService>();

            return services;
        }
    }
}
