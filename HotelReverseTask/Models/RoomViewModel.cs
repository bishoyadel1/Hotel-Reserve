using System.ComponentModel.DataAnnotations;

namespace HotelReserseTask.Models
{
    public class RoomViewModel
    {
        [Required]
        public string RoomTypeName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PricePerNight { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TotalRooms { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableRooms { get; set; }

        [Required]
        public int HotelID { get; set; }
    }

}
