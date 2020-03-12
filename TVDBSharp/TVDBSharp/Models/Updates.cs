using System;
using Newtonsoft.Json;
using TVDBSharp.Models.Deserialization;

namespace TVDBSharp.Models
{
    public class UpdateTimestamp
    {
        [JsonProperty("id")]
        public string ShowId { get; set; }

        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(EpochConverter))]
        public DateTime LastUpdatedAt { get; set; }
    }
}