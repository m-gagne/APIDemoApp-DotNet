using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;

namespace APIDemoApp_DotNet.Controllers
{
    public class MessageController : ApiController
    {
        // POST api/message
        [HttpPost]
        public void Post([FromBody]Models.Message message)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var twilio = new TwilioRestClient(appSettings["TwillioAccountSid"], appSettings["TwillioAuthToken"]);
            var msg = twilio.SendMessage(appSettings["TwillioFromNumber"], message.PhoneNumber, message.Text);
        }
    }
}
