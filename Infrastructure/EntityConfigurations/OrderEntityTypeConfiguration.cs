using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property("FlightId").IsRequired();
            builder.Property("FlightRateId").IsRequired();
            builder.Property("CustomerId").IsRequired();
            builder.Property("SeatCount").IsRequired();

            var converter = new EnumToStringConverter<OrderState>();

            builder
                .Property(e => e.State)
                .HasConversion(converter);
        }
    }
}
