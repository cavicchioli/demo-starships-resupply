using Microsoft.Extensions.DependencyInjection;
using Starships.Resupply.Application;
using Starships.Resupply.Application.Interfaces;
using Starships.Resupply.Domain.Interfaces;
using Starships.Resupply.Infra.Data.Repository;

namespace Starships.Resupply.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection AddBootStrapperIoC(
            this IServiceCollection services
        )
        {
            //Services
            services.AddSingleton<IStarshipsAppService, StarshipsAppService>();
            
            //Repositories
            services.AddSingleton<IStarshipRepository, StarshipRepository>();


            return services;
        }
    }
}
