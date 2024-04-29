using httpClient_p2.Handlers;
using httpClient_p2.Services;
using httpClient_p2.Ultis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
{
    services.AddLogging(configure => configure.AddDebug().AddConsole());

    services.AddSingleton<JsonSerializerOptionsWrapper>();


    // Custom SendAsync of Http Request

    services.AddHttpClient("GetMerchants").AddHttpMessageHandler(s =>
    {

        return new LoggingHandler(s.GetRequiredService<ILogger<LoggingHandler>>());

    }).AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(

        response => !response.IsSuccessStatusCode).RetryAsync(5))

    .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(

        res => !res.IsSuccessStatusCode).CircuitBreakerAsync(5, TimeSpan.FromSeconds(60)));

    services.AddScoped<IRunAsyncService, MerchantService>();


}).Build();

try
{
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Host created....");
    logger.LogInformation("Services started....");
    await host.Services.GetRequiredService<IRunAsyncService>().RunAsync();
}
catch (Exception ex)
{
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error happens when running....");
}

Console.ReadKey();
await host.RunAsync();
