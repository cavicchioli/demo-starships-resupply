using System;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Starships.Resupply.Infra.Data.Context
{
    public static class StarWarsAPIContext
    {
        public static IServiceCollection AddStarWarsAPIContext(
           this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient("swapi", c =>
            {
                c.BaseAddress = new Uri("http://swapi.co/api/");

                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "StarshipsResupply");
            })
             .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }));

            return services;
        }


    }
}
