using Lgm.Demo.Logger.Slack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Lgm.Demo.Logger
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, Action<FileLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, SlackLoggerProvider>();
            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();

            builder.Services.AddSingleton<ISlackClient, SlackClient>();

            builder.Services.Configure(configure);
            return builder;
        }
    }
}
