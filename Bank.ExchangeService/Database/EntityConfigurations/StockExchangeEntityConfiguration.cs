using Bank.ExchangeService.Models;
using Bank.UserService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.ExchangeService.Database;

public class StockExchangeEntityConfiguration : IEntityTypeConfiguration<StockExchange>
{
    public void Configure(EntityTypeBuilder<StockExchange> builder)
    {
        builder.HasKey(stockExchange => stockExchange.Id);

        builder.Property(stockExchange => stockExchange.Id)
               .IsRequired();

        builder.Property(stockExchange => stockExchange.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(stockExchange => stockExchange.Acronym);

        builder.Property(stockExchange => stockExchange.CreatedAt)
               .IsRequired();

        builder.Property(stockExchange => stockExchange.ModifiedAt)
               .IsRequired();
    }
}