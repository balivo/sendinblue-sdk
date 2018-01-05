using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Balivo.SendInBlue
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SendInBlueService
    {
        private readonly HttpClient _HttpClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        public SendInBlueService(string key, int timeout = 30)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentNullException("Account \"Key\" can't be null");

                ValidateTimeoutArg(timeout);

                _HttpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://api.sendinblue.com/v3/"),
                    Timeout = TimeSpan.FromSeconds(timeout),
                };

                _HttpClient.DefaultRequestHeaders.Add("api-key", key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ValidateTimeoutArg(int timeout)
        {
            if (timeout <= 0 || timeout > 60000)
                throw new ArgumentOutOfRangeException("Timeout value not allowed, please use value between 0 and 60000 (Default is 30 seconds)");
        }

        private async Task<T> PostAsync<T>(string resource, HttpContent content) where T : SendInBlueResultBase
        {
            try
            {
                if (resource.StartsWith("/"))
                    resource = resource.Substring(1);

                using (var response = await _HttpClient.PostAsync(resource, content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        //TODO: ERROR TRANSLATION
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(responseContent))
                        throw new InvalidOperationException("responseContent null");

                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<T> PostJsonAsync<T>(string resource, object content) where T : SendInBlueResultBase => PostAsync<T>(resource, content == null ? throw new ArgumentNullException(nameof(content)) : new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));

        /*
           Send Transactional Email.
           @param {Object} data contains dynamic object with a collection of keys and values from Dictionary.
           @options data {Array} to: Email address of the recipient(s). It should be sent as an associative array. Example: array("to@example.net"=>"to whom"). You can use commas to separate multiple recipients [Mandatory]
           @options data {String} subject: Message subject [Mandatory]
           @options data {Array} from Email address for From header. It should be sent as an array. Example: array("from@email.com","from email") [Mandatory]
           @options data {String} html: Body of the message. (HTML version) [Mandatory]. To send inline images, use <img src="{YourFileName.Extension}" alt="image" border="0" >, the 'src' attribute value inside {} (curly braces) should be same as the filename used in 'inline_image' parameter
           @options data {String} text: Body of the message. (text version) [Optional]
           @options data {Array} cc: Same as to but for Cc. Example: array("cc@example.net","cc whom") [Optional]
           @options data {Array} bcc: Same as to but for Bcc. Example: array("bcc@example.net","bcc whom") [Optional]
           @options data {Array} replyto: Same as from but for Reply To. Example: array("from@email.com","from email") [Optional]
           @options data {Array} attachment: Provide the absolute url of the attachment/s. Possible extension values = gif, png, bmp, cgm, jpg, jpeg, txt, css, shtml, html, htm, csv, zip, pdf, xml, doc, xls, ppt, tar and ez. To send attachment/s generated on the fly you have to pass your attachment/s filename & its base64 encoded chunk data as an associative array. Example: array("YourFileName.Extension"=>"Base64EncodedChunkData"). You can use commas to separate multiple attachments [Optional]
           @options data {Array} headers: The headers will be sent along with the mail headers in original email. Example: array("Content-Type"=>"text/html; charset=iso-8859-1"). You can use commas to separate multiple headers [Optional]
           @options data {Array} inline_image: Pass your inline image/s filename & its base64 encoded chunk data as an associative array. Possible extension values = gif, png, bmp, cgm, jpg and jpeg. Example: array("YourFileName.Extension"=>"Base64EncodedChunkData"). You can use commas to separate multiple inline images [Optional]
       */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<SmtpSendTransactionalResult> SmtpSendTransactionalAsync(SmtpSendTransactionalArgs args)
        {
            try
            {
                if (args == null)
                    throw new ArgumentNullException(nameof(args));

                //TODO: Validate argument instance

                return await PostJsonAsync<SmtpSendTransactionalResult>("smtp/email", args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}