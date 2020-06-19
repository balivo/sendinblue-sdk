using Newtonsoft.Json;
using System.Collections.Generic;

namespace Balivo.SendInBlue
{
    public sealed class SmtpSendTransactionalArgs
    {
        [JsonRequired, JsonProperty("sender")]
        public SendInBlueEmailInfo Sender { get; set; }

        [JsonRequired, JsonProperty("to")]
        public List<SendInBlueEmailInfo> To { get; set; }

        [JsonRequired, JsonProperty("bcc")]
        public List<SendInBlueEmailInfo> Bcc { get; set; }

        [JsonProperty("cc")]
        public List<SendInBlueEmailInfo> Cc { get; set; }

        [JsonRequired, JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonRequired, JsonProperty("textContent")]
        public string TextContent { get; set; }

        [JsonRequired, JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonRequired, JsonProperty("replyTo")]
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