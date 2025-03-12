using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<List<Room>> GetAvailableRooms  (int hotelId);
        Task<Room> GetRoomWithHotel(int  Id);

    }
}
