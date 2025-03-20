using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    public interface IGetBookingsByTypeQuery
    {
        Task<List<GetBookingsByTypeModel>> Execute(string type);
    }
}
