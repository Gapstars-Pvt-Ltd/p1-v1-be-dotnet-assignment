using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class FlightEntityTypeConfiguration : BaseEntityTypeConfiguration<Flight>
    {
        public override void Configure(EntityTypeBuilder<Flight> builder)
        {
            base.Configure(builder);


            builder.HasMany(x => x.Rates)
            .WithOne()
            .IsRequired()
            .HasForeignKey("FlightId")
            .OnDelete(DeleteBehavior.Cascade);


            var navigation = builder.Metadata.FindNavigation(nameof(Flight.Rates));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.Navigation(f => f.Rates).AutoInclude();

            builder.Property("Arrival").IsRequired();
            builder.Property("Departure").IsRequired();
            
            //builder.HasOne(i=>i.OriginAirport)
            //    .WithMany()
            //    .IsRequired()
            //    .HasForeignKey("OriginAirportId");
            
            //builder.HasOne(i => i.DestinationAirport)
            //    .WithMany()
            //    .IsRequired()
            //    .HasForeignKey("DestinationAirportId");
        }
    }
}