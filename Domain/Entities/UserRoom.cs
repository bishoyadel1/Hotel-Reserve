using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRoom
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomType { get; set; } // Single, Double, Suite

        [Required]
        public int Adults { get; set; }

        [Required]
        public int Children { get; set; }
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
       
        public Booking Booking { get; set; }
    }
}
