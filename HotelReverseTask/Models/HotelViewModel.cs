using System.ComponentModel.DataAnnotations;

namespace HotelReserseTask.Models
{
    public class HotelViewModel
    {
        [Required]
        public string HotelName { get; set; }
    }

}
