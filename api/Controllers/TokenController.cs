using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Twilio.Jwt.AccessToken;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string identity)
        {
            // These values are necessary for any access token
            string twilioAccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string twilioApiKey = Environment.GetEnvironmentVariable("TWILIO_API_KEY");
            string twilioApiSecret = Environment.GetEnvironmentVariable("TWILIO_API_SECRET");

            // These are specific to Chat
            const string serviceSid = "IS47f596cddbf34ce49490ef4af838bd07";

            // Create an Chat grant for this token

            var grant = new ChatGrant
            {
                ServiceSid = serviceSid
            };

            var grants = new HashSet<IGrant>
            {
                { grant }
            };

            // Create an Access Token generator
            var token = new Token(
                twilioAccountSid,
                twilioApiKey,
                twilioApiSecret,
                identity,
                grants: grants);

            return new JsonContent(new {token = token.ToJwt()});
        }
    }
}