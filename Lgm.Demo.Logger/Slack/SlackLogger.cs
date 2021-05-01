using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lgm.Demo.Logger.Slack
{
    public class SlackLogger : ILogger
    {
        protected readonly SlackLoggerProvider slackProvider;
        private readonly ISlackClient slackClient;

        public SlackLogger([NotNull] SlackLoggerProvider slackLoggerProvider, ISlackClient slackClient)
        {
            slackProvider = slackLoggerProvider;
            this.slackClient = slackClient;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var logRecord = string.Format("{0} [{1}] {2} {3}", "[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]", logLevel.ToString(), formatter(state, exception), exception != null ? exception.StackTrace : "");
            slackClient.PostMessage(logRecord);
        }
    }
}
