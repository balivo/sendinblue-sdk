using Newtonsoft.Json;
using System.Collections.Generic;

namespace Balivo.SendInBlue
{
    public sealed class SmtpSendTransactionalArgs
    {
        [JsonProperty("bcc")]
        public List<SendInBlueEmailInfo> Bcc { get; set; }

        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonProperty("replyTo")]
        public SendInBlueEmailInfo ReplyTo { get; set; }

        [JsonProperty("sender")]
        public SendInBlueEmailInfo Sender { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("textContent")]
        public string TextContent { get; set; }

        [JsonProperty("to")]
        public List<SendInBlueEmailInfo> To { get; set; }
    }
}