using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Custommer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _databaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var test = _mapper.Map<CustomerEntity>(model);
            await _databaseService.Customer.AddAsync(test);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
