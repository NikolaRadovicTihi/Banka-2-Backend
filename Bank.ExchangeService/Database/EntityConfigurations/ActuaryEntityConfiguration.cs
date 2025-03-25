using Bank.ExchangeService.Models;
using Bank.UserService.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.ExchangeService.Database.EntityConfigurations;

public class ActuaryEntityConfiguration : IEntityTypeConfiguration<Actuary>
{
    public void Configure(EntityTypeBuilder<Actuary> builder)
    {
        builder.HasKey(actuary => actuary.Id);

        builder.Property(actuary => actuary.Id)
               .IsRequired();

        builder.Property(actuary => actuary.UserId)
               .IsRequired();

        builder.Property(actuary => actuary.Limit)
               .HasPrecision(18, 2);

        builder.Property(actuary => actuary.UsedLimit)
               .IsRequired()
               .HasPrecision(18, 2)
               .HasDefaultValue(0);

        builder.Property(actuary => actuary.NeedApproval)
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(actuary => actuary.Type)
               .IsRequired()
               .HasConversion<string>();

        builder.Property(actuary => actuary.CreatedAt)
               .IsRequired();

        builder.Property(actuary => actuary.ModifiedAt)
               .IsRequired();

        builder.HasOne(actuary => actuary.User)
               .WithOne()
               .HasForeignKey<Actuary>(actuary => actuary.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(actuary => actuary.UserId)
               .IsUnique();
    }
}
