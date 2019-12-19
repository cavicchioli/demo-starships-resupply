using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Starships.Resupply.Domain;
using Starships.Resupply.Domain.Interfaces;
using Starships.Resupply.Infra.Data.Helper;

namespace Starships.Resupply.Infra.Data.Repository
{
    public class StarshipRepository : IStarshipRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public StarshipRepository(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Starship>> GetAllStarships()
        {
            var page = "page=1";
            var client = _httpClientFactory.CreateClient("swapi");
            Helper<Starship> result;
            List<Starship> starships = new List<Starship>();

            do
            {
                var response = await client.GetAsync($"starships/?{page}");

                response.EnsureSuccessStatusCode();
                string content =
                    response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<Helper<Starship>>(content);
                starships.AddRange(result.Results);
                page = result.Next != null ? (result.Next.Split("?")[1].ToString()) : null;

            } while (page != null);

            return starships;

        }
    }
}
