using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking_WebAPI_Service.Persistance
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T t);
        Task<int> DeleteAsync(T t);

        Task<int> UpdateAsync(T t);

        Task<T> GetBy(long id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
