using Newtonsoft.Json;

namespace Balivo.SendInBlue
{
    public sealed class SmtpSendTransactionalResult : SendInBlueResultBase
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    }

}
