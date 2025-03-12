
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
 
        public UnitOfWork( SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager , IRoomRepository _roomRepository, IHotelRepository _hotelRepository, IUserBookingRepository _UserBookingRepository, IBookingRepository _BookingRepositoryy, IBasketRepository _BasketRepository)
        {
            signInManager = _signInManager;
            userManager= _userManager;
            roomRepository = _roomRepository;

            hotelRepository = _hotelRepository;
            UserBookingRepository = _UserBookingRepository;
            BookingRepositoryy = _BookingRepositoryy;
            BasketRepository = _BasketRepository;
        }

        public SignInManager<IdentityUser> signInManager { get  ; set  ; }
        public UserManager<IdentityUser> userManager { get  ; set ; }
        public IRoomRepository roomRepository { get ; set; }
        public IHotelRepository hotelRepository { get  ; set; }
        public IUserBookingRepository UserBookingRepository { get  ; set  ; }
        public IBookingRepository BookingRepositoryy { get  ; set; }
        public IBasketRepository BasketRepository { get  ; set; }
    }
}
