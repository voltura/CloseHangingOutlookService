using CloseHangingOutlookService;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options => options.ServiceName = "Close Hanging Outlook Service")
    .ConfigureServices(services =>
    {
        LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);
        services.AddSingleton<CloseOutlookService>();
        services.AddHostedService<WindowsBackgroundService>();
    })
    .ConfigureLogging((context, logging) => logging.AddConfiguration(context.Configuration.GetSection("Logging")))
    .Build();

await host.RunAsync();
