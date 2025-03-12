
using Domain.Context;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelDbContex Context;

        public GenericRepository(HotelDbContex HotelDbContext)
        {
              Context = HotelDbContext;
        }
        public int Add(T obj)
        {
           Context.Set<T>().Add(obj);
            return Context.SaveChanges();
        }

        public int Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
            return Context.SaveChanges();
        }

        public async Task<IReadOnlyList<T>> GetAll() 
            => await Context.Set<T>().ToListAsync();


        public async Task<T> GetById(int id)
         => await Context.Set<T>().FindAsync(id);

        public int Update(T obj)
        {

           Context.Set<T>().Update(obj);
            return Context.SaveChanges();
        }
    }
}
