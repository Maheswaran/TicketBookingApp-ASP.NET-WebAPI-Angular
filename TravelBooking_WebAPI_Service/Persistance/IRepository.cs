using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking_WebAPI_Service.Persistance
{
    interface IRepository<T> where T : class
    {
        void Add();
        void Delete();

        T Find(int id);

        IEnumerable<T> FindAll();
    }
}
