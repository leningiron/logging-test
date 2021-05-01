using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Lgm.Demo.Logger.Slack
{
    public class SlackClient : ISlackClient
    {
        private readonly Uri uri;
        private readonly Encoding encoding = new UTF8Encoding();

        public SlackClient()
        {
            uri = new Uri(Environment.GetEnvironmentVariable("SLACK_URL"));
        }

        public string PostMessage(string text, string channel = null)
        {
            var payload = new Payload
            {
                Channel = channel,
                Text = text
            };

            return PostMessage(payload);
        }

        private string PostMessage(Payload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection { ["payload"] = payloadJson };

                var response = client.UploadValues(uri, "POST", data);

                return encoding.GetString(response);
            }
        }

    }
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public interface ISlackClient
    {
        string PostMessage(string text, string channel = null);
    }
}
