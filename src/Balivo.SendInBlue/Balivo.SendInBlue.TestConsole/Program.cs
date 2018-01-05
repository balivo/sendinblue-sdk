using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Balivo.SendInBlue.TestConsole
{
    class Program
    {
        static string KEY = "YOU_V3_API_KEY_HERE";

        private static SendInBlueService _SendInBlueService;

        static void Main(string[] args)
        {
            _SendInBlueService = new SendInBlueService(KEY);

            Task.Factory.StartNew(async () =>
            {
                var result = await _SendInBlueService.SmtpSendTransactionalAsync(new SmtpSendTransactionalArgs
                {
                    //Bcc
                    HtmlContent = "<p>It's just a test for \"SmtpSendTransactionalAsync\" call</p>",
                    //ReplyTo = new SendInBlueEmailInfo
                    //{
                    //},
                    Sender = new SendInBlueEmailInfo
                    {
                        Email = "sender_user@email.com",
                        Name = "Test User"
                    },
                    Subject = "Test message",
                    TextContent = "Test",
                    To = new List<SendInBlueEmailInfo>
                    {
                        new SendInBlueEmailInfo
                        {
                            Email = "user_to_1@email.com",
                            Name = "Test User"
                        }
                    }
                });

                Console.Write(JsonConvert.SerializeObject(result, Formatting.Indented));
            });

            Console.ReadLine();
        }
    }
}
