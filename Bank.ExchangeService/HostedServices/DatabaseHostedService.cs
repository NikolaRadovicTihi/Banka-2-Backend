using Bank.Application.Domain;
using Bank.ExchangeService.Database;
using Bank.ExchangeService.Database.Seeders;
using Bank.LoanService.Database.Seeders;
using Bank.UserService.Configurations;
using Bank.UserService.Database;
using Bank.UserService.Database.Seeders;

namespace Bank.ExchangeService.HostedServices;

public class DatabaseHostedService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory m_HttpClientFactory = httpClientFactory;
    private readonly IServiceProvider   m_ServiceProvider   = serviceProvider;

    private DatabaseContext Context =>
    m_ServiceProvider.CreateScope()
                     .ServiceProvider.GetRequiredService<DatabaseContext>();

    public void OnApplicationStarted()
    {
        if (Configuration.Database.CreateDrop)
            Context.Database.EnsureDeletedAsync()
                   .Wait();

        Context.Database.EnsureCreatedAsync()
               .Wait();

        Context.SeedStockExchanges()
               .Wait();
        
    }

    public void OnApplicationStopped() { }
}
