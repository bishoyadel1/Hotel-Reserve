using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
     public interface IUnitOfWork
    {
        public  IRoomRepository roomRepository { get; set; }
        public IHotelRepository hotelRepository  { get; set; }
        public IUserBookingRepository  UserBookingRepository { get; set; }
        public IBookingRepository  BookingRepositoryy { get; set; }
        public IBasketRepository  BasketRepository { get; set; }
        public SignInManager<IdentityUser> signInManager { get; set; }
        public UserManager<IdentityUser> userManager { get; set; }
        
    }
}
