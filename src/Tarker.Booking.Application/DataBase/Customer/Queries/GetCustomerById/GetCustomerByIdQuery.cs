using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    internal class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdModel> Execute (int id)
        {
            var customer = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            return  _mapper.Map<GetCustomerByIdModel>(customer);
        }
    }
}
