using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public int Delete(T obj);
        public int Update(T obj);
        public int Add(T obj);
        public Task<IReadOnlyList<T>> GetAll();
        public Task<T> GetById(int id);

    }
}
