using Newtonsoft.Json;

namespace Balivo.SendInBlue
{
    public sealed class SendInBlueEmailInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}