using System.ComponentModel.DataAnnotations;

namespace HotelReserseTask.Models
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }
        [Required]
        public int Adults { get; set; }

        [Required]
        public int Children { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int TotalRooms { get; set; }

    }
}