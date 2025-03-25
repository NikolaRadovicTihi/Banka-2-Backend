using Bank.ExchangeService.Database.EntityConfigurations;
using Bank.ExchangeService.Models;
using Bank.UserService.Models;

using Microsoft.EntityFrameworkCore;

namespace Bank.ExchangeService.Database;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Actuary>       Actuaries      { init; get; }
    public DbSet<StockExchange> StockExchanges { init; get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
               .Ignore(u => u.Accounts);
        builder.ApplyConfiguration(new ActuaryEntityConfiguration());
        builder.ApplyConfiguration(new StockExchangeEntityConfiguration());
    }
}