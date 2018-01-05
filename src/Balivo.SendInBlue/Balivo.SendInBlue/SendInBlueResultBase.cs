using Newtonsoft.Json;

namespace Balivo.SendInBlue
{
    public abstract class SendInBlueResultBase
    {
        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }

}
