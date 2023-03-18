using System.Security.Cryptography.X509Certificates;
using Domain.Aggregates.PassengerAggregate;
using Infrastructure.EntityConfigurations.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class PassengerEntityTypeConfiguration : BaseEntityTypeConfiguration<Passenger>
{
    public override void Configure(EntityTypeBuilder<Passenger> builder)
    {
        base.Configure(builder);
        builder.HasKey("Id");
        builder.Property("FirstName").IsRequired();
        builder.Property("LastName").IsRequired();
        builder.Property("Age").IsRequired();
        builder.Property("Email").IsRequired();
        builder.HasMany(p => p.Orders).WithOne().HasForeignKey("PassengerId").OnDelete(DeleteBehavior.Cascade);
    }
}