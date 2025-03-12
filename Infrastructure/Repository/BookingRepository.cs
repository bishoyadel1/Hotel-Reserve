using Domain.Context;
using Domain.Entities;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly HotelDbContex hotelDbContext;

        public BookingRepository(HotelDbContex HotelDbContext) : base(HotelDbContext)
        {
            hotelDbContext = HotelDbContext;
        }

        public   bool CheckUserExists(string userID)
        => hotelDbContext.Bookings.Where(i=>i.CustomerID== userID).Any() ? true : false;
    }
}
