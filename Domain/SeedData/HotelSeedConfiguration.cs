using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.SeedData
{
    public class HotelSeedConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, HotelName = "Grand Palace Hotel" },
                new Hotel { Id = 2, HotelName = "Ocean View Resort" },
                new Hotel { Id = 3, HotelName = "Mountain Peak Lodge" },
                new Hotel { Id = 4, HotelName = "Sunset Bay Inn" },
                new Hotel { Id = 5, HotelName = "Urban Retreat Hotel" },
                new Hotel { Id = 6, HotelName = "Skyline Towers" },
                new Hotel { Id = 7, HotelName = "Royal Heritage Hotel" },
                new Hotel { Id = 8, HotelName = "Green Valley Resort" }
            );
        }
    }
}
