using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.PassengerAggregate;
using Infrastructure.EntityConfigurations.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.HasKey("Id");
        builder.Property("OrderDate").IsRequired();
        builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey("OrderId").OnDelete(DeleteBehavior.Cascade);
    }
}