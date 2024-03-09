using Microsoft.AspNetCore.Hosting;
using OzonSales.Business.Mock;
using OzonSales.WebAPI;

await new MockJsonDataFiller().PrepareJsonDomain();

new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Build()
    .Run();