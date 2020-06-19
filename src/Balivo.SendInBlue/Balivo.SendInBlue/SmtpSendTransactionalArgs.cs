using Newtonsoft.Json;
using System.Collections.Generic;

namespace Balivo.SendInBlue
{
    public sealed class SmtpSendTransactionalArgs
    {
        [JsonProperty("sender")]
        public SendInBlueEmailInfo Sender { get; set; }

        [JsonProperty("to")]
        public List<SendInBlueEmailInfo> To { get; set; }

        [JsonProperty("bcc")]
        public List<SendInBlueEmailInfo> Bcc { get; set; }

        [JsonProperty("cc")]
        public List<SendInBlueEmailInfo> Cc { get; set; }

        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonProperty("textContent")]
        public string TextContent { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("replyTo")]
        public SendInBlueEmailInfo ReplyTo { get; set; }

        // [JsonProperty("attachment")]
        // public List<string> Attachment { get; set; }

        // [JsonProperty("headers")]
        // public List<string> Headers { get; set; }

        [JsonProperty("templateId")]
        public long TemplateId { get; set; }

        // [JsonProperty("params")]
        // public List<string> Params { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}