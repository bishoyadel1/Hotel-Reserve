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
    public class UserBookingRepository : GenericRepository<UserRoom>, IUserBookingRepository
    {
        private readonly HotelDbContex hotelDbContext;

        public UserBookingRepository(HotelDbContex HotelDbContext) : base(HotelDbContext)
        {
            hotelDbContext = HotelDbContext;
        }
    }
}
