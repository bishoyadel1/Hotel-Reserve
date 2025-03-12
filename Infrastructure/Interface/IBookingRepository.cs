using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        public bool CheckUserExists(string userID);
    }
}
