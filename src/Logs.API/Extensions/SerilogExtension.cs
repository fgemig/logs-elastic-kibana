using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using Elastic.CommonSchema.Serilog;
using Serilog.Configuration;

namespace Logs.API.Extensions
{
    public static class SerilogExtension
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration)
        {            
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Async(writeTo => ConfigureElasticSink(configuration, writeTo))
                .WriteTo.Async(writeTo => writeTo.Debug())
                .WriteTo.Async(writeTo => writeTo.Console())
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger, true);

            return builder;
        }

        private static LoggerConfiguration ConfigureElasticSink(IConfiguration configuration, LoggerSinkConfiguration writeTo)
        {
            return writeTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                TypeName = null,
                AutoRegisterTemplate = true,
                IndexFormat = configuration["ElasticConfiguration:IndexName"],
                BatchAction = ElasticOpType.Create,
                CustomFormatter = new EcsTextFormatter()
            });
        }
    }
}
