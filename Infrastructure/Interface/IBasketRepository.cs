using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IBasketRepository : IGenericRepository<RoomBasket>
    {
        public IEnumerable<RoomBasket> GetUserBasket(string userID);
        public void RemoveUserBasket(string userID);
    }
}
