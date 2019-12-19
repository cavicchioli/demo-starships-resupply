using System;
using Newtonsoft.Json;

namespace Starships.Resupply.Application.ResponseModels
{
    public class ResupplyResponse
    {
        [JsonProperty("starship_url")]
        public Uri StarshipUrl { get; set; }
        [JsonProperty("starship_name")]
        public string StarshipName { get; set; }
        [JsonProperty("total_stops_required")]
        public string TotalStopsRequired { get; set; }
    }
}
