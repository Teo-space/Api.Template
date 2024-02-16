
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

public static class AddLoggingExtentions
{
    public static ILoggingBuilder AddSerilogLogging(this ILoggingBuilder loggingBuilder, IConfiguration configuration)
    {
        var loggerConfiguration = new LoggerConfiguration().ReadFrom.Configuration(configuration);
        var logger = loggerConfiguration.CreateLogger();

        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(logger);

        return loggingBuilder;
    }

}

