using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ConsoleAppTestSMS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ajouter Twilio qui est le package NuGet qui gere les SMS

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            string accountSid = ConfigurationManager.AppSettings["TWILIO_ACCOUNT_SID"];
            string authToken = ConfigurationManager.AppSettings["TWILIO_AUTH_TOKEN"];

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Bonjour ! Message a partir de mon app C#",
                from: new Twilio.Types.PhoneNumber("+18482855504"),
                to: new Twilio.Types.PhoneNumber("+33749073504")
            );

            Console.WriteLine(message.Sid);
        }
    }
}