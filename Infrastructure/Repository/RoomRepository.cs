using Domain.Context;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoomRepository : GenericRepository<Room> , IRoomRepository
    {
        private readonly HotelDbContex _hotelDbContext;

        public RoomRepository(HotelDbContex HotelDbContext) : base(HotelDbContext)
        {
            _hotelDbContext = HotelDbContext;
        }

        public async Task<List<Room>> GetAvailableRooms(int hotelId)
         => await _hotelDbContext.Rooms  .Where(r =>   (r.AvailableRooms > 0) && (r.HotelID == hotelId || hotelId == 0 )).Include(i=>i.Hotel)
           .ToListAsync();

        public async Task<Room> GetRoomWithHotel(int Id)
        {
            return await _hotelDbContext.Rooms.Where(i => i.Id == Id).Include(i => i.Hotel).FirstOrDefaultAsync(); 
        }
    }
}
