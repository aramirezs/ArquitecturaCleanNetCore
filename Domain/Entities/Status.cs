using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Status
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}