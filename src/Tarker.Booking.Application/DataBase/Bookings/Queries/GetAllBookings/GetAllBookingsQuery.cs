using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllBookingsQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingsModel>> Execute() 
        {
            return _mapper.Map<List<GetAllBookingsModel>>(
                await _dataBaseService.Booking
                .Include(x=> x.Customer)
                .ToListAsync()
                );
        }
    }
}
