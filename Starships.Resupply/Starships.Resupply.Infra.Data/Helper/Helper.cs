using Newtonsoft.Json;
using System.Collections.Generic;

namespace Starships.Resupply.Infra.Data.Helper
{
    public class Helper<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }
    }
}
