using System;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Infrastructure.EntityConfigurations.BaseEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderItemTypeConfiguration : BaseEntityTypeConfiguration<OrderItem>
{
    public override void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        base.Configure(builder);
        builder.HasKey("Id");
        builder.Property("FlightId").IsRequired();
        builder.Property("Quantity").IsRequired();
        builder.Property("UnitPrice").IsRequired();
    }
}