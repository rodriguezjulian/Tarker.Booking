using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers
{
    public interface IGetAllCustomersQuery
    {
        Task<List<GetAllCustomersModel>> Execute();
    }
}
