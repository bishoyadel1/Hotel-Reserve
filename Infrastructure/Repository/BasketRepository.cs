using Domain.Context;
using Domain.Entities;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BasketRepository : GenericRepository<RoomBasket>, IBasketRepository
    {
        private readonly HotelDbContex hotelDbContext;

        public BasketRepository(HotelDbContex _HotelDbContext) : base(_HotelDbContext)
        {
            hotelDbContext = _HotelDbContext;
        }

        public IEnumerable<RoomBasket> GetUserBasket(string userID)
        {
            return  hotelDbContext.RoomBaskets.Where(i => i.CustomerId == userID).ToList();
        }

        public void RemoveUserBasket(string userID)
        {
           var data = GetUserBasket(userID).ToList();
            foreach (var item in data)
            {
                hotelDbContext.RoomBaskets.Remove(item);
                
            }
            hotelDbContext.SaveChanges();
        }
    }
}
