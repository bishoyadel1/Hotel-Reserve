using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
