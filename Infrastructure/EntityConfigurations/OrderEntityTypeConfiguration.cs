using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property("FlightId").IsRequired();
            builder.Property("Name").IsRequired();
            builder.Property("CustomerId").IsRequired();
            builder.Property("SeatCount").IsRequired();
        }
    }
}
