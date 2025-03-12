using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string RoomTypeName { get; set; } 

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerNight { get; set; }  

        [Required]
        public int TotalRooms { get; set; }  

        [Required]
        public int AvailableRooms { get; set; }
        [ForeignKey("Hotel")]
        public int HotelID { get; set; }

        public Hotel Hotel { get; set; }
    }
}
