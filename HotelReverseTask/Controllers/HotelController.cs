using Domain.Entities;
using HotelReserseTask.Models;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelReserseTask.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HotelController(IUnitOfWork _unitOfWork)
        {
             unitOfWork = _unitOfWork;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            ViewBag.hotel = await unitOfWork.hotelRepository.GetAll();
 
            return View();
        }
        
       

        [HttpGet]
        public async Task<ActionResult> SearchRooms(int hotelId = 0, int page = 1, int pageSize = 5)
        {
            var availableRooms = await unitOfWork.roomRepository.GetAvailableRooms(hotelId);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)availableRooms.Count() / pageSize);
            ViewBag.HotelId = hotelId;

            var paginatedRooms = availableRooms.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return PartialView("_RoomList", paginatedRooms);
        }

        [HttpGet]
        public async Task<ActionResult> GetRoom(int  Id)
        {
            var model = await unitOfWork.roomRepository.GetRoomWithHotel(Id);
            return View("Room",model);
        }

        [Authorize(Roles = "Administrator")]
        public  ActionResult CreateHotel() => View();
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateRoom()
        {
            ViewBag.hotel = await unitOfWork.hotelRepository.GetAll();
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<JsonResult> CreateHotel(HotelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newHotel = new Hotel
                {
                    HotelName = model.HotelName
                };

                unitOfWork.hotelRepository.Add(newHotel);
                return Json(new { success = true, message = "Hotel created successfully!" });
            }

            return Json(new { success = false, message = "Invalid data provided." });
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<JsonResult> CreateRoom(RoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input. Please check your data." });
            }

            try
            {
                var newRoom = new Room
                {
                    RoomTypeName = model.RoomTypeName,
                    PricePerNight = model.PricePerNight,
                    TotalRooms = model.TotalRooms,
                    AvailableRooms = model.AvailableRooms,
                    HotelID = model.HotelID
                };

                unitOfWork.roomRepository.Add(newRoom);

                return Json(new { success = true, message = "Room created successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }


        [Authorize ]
        public ActionResult Profile() => View();

        [Authorize]
        public  IActionResult  BookingForm(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<JsonResult> BookRoom([FromBody] BookingViewModel booking)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid input. Please check your data." });
            }

            try
            {

                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var findbyemail = await unitOfWork.userManager.FindByEmailAsync(email);
                var userId = await unitOfWork.userManager.GetUserIdAsync(findbyemail);
                var getRoom = await unitOfWork.roomRepository.GetRoomWithHotel(booking.RoomId);
                var days = (int)(booking.CheckOutDate.Day - booking.CheckInDate.Day);

                

                var newBooking = new Booking
                {
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    TotalRooms = booking.TotalRooms,
                    HotelBranch = getRoom.Hotel.HotelName,
                    TotalPrice = getRoom.PricePerNight * days,
                    CustomerID = userId


                };
                unitOfWork.BookingRepositoryy.Add(newBooking);
                int BookingId = newBooking.Id;

                //basket check 
                var basket = unitOfWork.BasketRepository.GetUserBasket(userId);
                if(basket != null)
                {
                    
                    foreach (var item in basket)
                    {
                        var GetPricePerRoom = await unitOfWork.roomRepository.GetById(item.RoomId);
                        
                        var CountDay = ((int)(item.CheckOutDate.Day - item.CheckOutDate.Day));
                        newBooking.TotalPrice += GetPricePerRoom.PricePerNight * CountDay;

                        var userRoom = new UserRoom
                        {
                            Adults = item.Adults,
                            Children = item.Children,
                            RoomType = getRoom.RoomTypeName,
                            BookingID = BookingId
                        };
                        GetPricePerRoom.AvailableRooms -= 1;
                        unitOfWork.roomRepository.Update(GetPricePerRoom);
                        unitOfWork.UserBookingRepository.Add(userRoom);

                    }

                  
                    unitOfWork.BasketRepository.RemoveUserBasket(userId);
                }
                
                   
                    var userBooking = new UserRoom
                    {
                        Adults = booking.Adults,
                        Children = booking.Children,
                        RoomType = getRoom.RoomTypeName,
                        BookingID = BookingId

                    };
                    getRoom.AvailableRooms -= 1;

                    unitOfWork.roomRepository.Update(getRoom);
                    unitOfWork.UserBookingRepository.Add(userBooking);
                

                //calc discount (5%)
                var CheckIfUserExistsBookingTable = unitOfWork.BookingRepositoryy.CheckUserExists(userId);
                if (CheckIfUserExistsBookingTable)
                    newBooking.TotalPrice -= newBooking.TotalPrice * 5 / 100;

                unitOfWork.BookingRepositoryy.Update(newBooking);

                return Json(new { success = true, message = "Booking confirmed!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<JsonResult> AddToBasketAsync([FromBody] BookingViewModel model)
        {
            if (model == null || model.RoomId <= 0)
                return Json(new { success = false, message = "Invalid booking data." });

            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var findbyemail = await unitOfWork.userManager.FindByEmailAsync(email);
            var userId = await unitOfWork.userManager.GetUserIdAsync(findbyemail);


            var data = new RoomBasket
            {
                Adults = model.Adults,
                Children = model.Children,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                RoomId = model.RoomId,
                CustomerId = userId
            };

            unitOfWork.BasketRepository.Add(data);

            return Json(new { success = true, message = "Room added to basket!"  });
        }
    }
    
         
}
