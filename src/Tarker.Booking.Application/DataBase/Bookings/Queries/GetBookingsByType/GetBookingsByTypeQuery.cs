using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    internal class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingsByTypeQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string type) 
        {
            return _mapper.Map<List<GetBookingsByTypeModel>>(await _dataBaseService.Booking.Where(x => x.Type == type).ToListAsync());
        }
    }
}
