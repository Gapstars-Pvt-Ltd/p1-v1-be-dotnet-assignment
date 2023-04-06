using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.CustomerAggregate;

namespace Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            var navigation = builder.Metadata.FindNavigation(nameof(Order.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


            builder.HasOne<Customer>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("CustomerId");

            builder.HasOne<Flight>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("FlightId");
        }
    }
}
