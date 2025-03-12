using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.SeedData
{
    public class RoomSeedConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                // Rooms for Hotel 1
                new Room { Id = 1, RoomTypeName = "Deluxe Suite", PricePerNight = 250.00m, TotalRooms = 10, AvailableRooms = 8, HotelID = 1 },
                new Room { Id = 2, RoomTypeName = "Standard Room", PricePerNight = 150.00m, TotalRooms = 15, AvailableRooms = 12, HotelID = 1 },

                // Rooms for Hotel 2
                new Room { Id = 3, RoomTypeName = "Ocean View Room", PricePerNight = 300.00m, TotalRooms = 8, AvailableRooms = 6, HotelID = 2 },
                new Room { Id = 4, RoomTypeName = "Budget Room", PricePerNight = 100.00m, TotalRooms = 12, AvailableRooms = 10, HotelID = 2 },

                // Rooms for Hotel 3
                new Room { Id = 5, RoomTypeName = "Luxury King Suite", PricePerNight = 400.00m, TotalRooms = 5, AvailableRooms = 3, HotelID = 3 },
                new Room { Id = 6, RoomTypeName = "Cozy Cabin", PricePerNight = 180.00m, TotalRooms = 7, AvailableRooms = 6, HotelID = 3 },

                // Rooms for Hotel 4
                new Room { Id = 7, RoomTypeName = "Beachfront Room", PricePerNight = 280.00m, TotalRooms = 6, AvailableRooms = 4, HotelID = 4 },
                new Room { Id = 8, RoomTypeName = "Family Room", PricePerNight = 200.00m, TotalRooms = 10, AvailableRooms = 8, HotelID = 4 },

                // Rooms for Hotel 5
                new Room { Id = 9, RoomTypeName = "Business Suite", PricePerNight = 350.00m, TotalRooms = 5, AvailableRooms = 4, HotelID = 5 },
                new Room { Id = 10, RoomTypeName = "Economy Room", PricePerNight = 90.00m, TotalRooms = 15, AvailableRooms = 14, HotelID = 5 },

                // Rooms for Hotel 6
                new Room { Id = 11, RoomTypeName = "Skyline View Room", PricePerNight = 320.00m, TotalRooms = 7, AvailableRooms = 5, HotelID = 6 },
                new Room { Id = 12, RoomTypeName = "Compact Room", PricePerNight = 110.00m, TotalRooms = 10, AvailableRooms = 9, HotelID = 6 },

                // Rooms for Hotel 7
                new Room { Id = 13, RoomTypeName = "Heritage Suite", PricePerNight = 370.00m, TotalRooms = 6, AvailableRooms = 4, HotelID = 7 },
                new Room { Id = 14, RoomTypeName = "Single Room", PricePerNight = 120.00m, TotalRooms = 12, AvailableRooms = 10, HotelID = 7 },

                // Rooms for Hotel 8
                new Room { Id = 15, RoomTypeName = "Nature Retreat", PricePerNight = 260.00m, TotalRooms = 8, AvailableRooms = 7, HotelID = 8 },
                new Room { Id = 16, RoomTypeName = "Budget Cabin", PricePerNight = 130.00m, TotalRooms = 9, AvailableRooms = 8, HotelID = 8 }
            );
        }
    }
}
