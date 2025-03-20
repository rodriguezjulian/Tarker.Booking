using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber
{
    internal class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingsByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber) 
        {
            return _mapper.Map<List<GetBookingsByDocumentNumberModel>>(await _dataBaseService.Booking.Where(x => x.Customer.DocumentNumber == documentNumber).ToListAsync());
        }
    }
}
