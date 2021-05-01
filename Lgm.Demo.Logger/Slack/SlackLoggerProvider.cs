using Microsoft.Extensions.Logging;

namespace Lgm.Demo.Logger.Slack
{
    public class SlackLoggerProvider : ILoggerProvider
    {
        private readonly ISlackClient slackClient;

        public SlackLoggerProvider(ISlackClient slackClient)
        {
            this.slackClient = slackClient;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SlackLogger(this, slackClient);
        }

        public void Dispose()
        {
        }
    }
}
