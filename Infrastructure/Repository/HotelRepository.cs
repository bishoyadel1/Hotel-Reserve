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
    public class HotelRepository : GenericRepository<Hotel> ,IHotelRepository 
    {
        private readonly HotelDbContex _hotelDbContext;

        public HotelRepository(HotelDbContex HotelDbContext) : base(HotelDbContext)
        {
            _hotelDbContext = HotelDbContext;
        }
    }
}
