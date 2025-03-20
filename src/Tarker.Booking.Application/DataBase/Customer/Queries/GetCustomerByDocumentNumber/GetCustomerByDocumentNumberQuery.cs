using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    internal class GetCustomerByDocumentNumberQuery : IGetCustomerByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber) 
        {
            return _mapper.Map<GetCustomerByDocumentNumberModel>( await _dataBaseService.Customer.FirstOrDefaultAsync( x=>x.DocumentNumber == documentNumber));
        }
    }
}
