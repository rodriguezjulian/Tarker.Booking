using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    internal class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateCustomerCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model) 
        {
            _databaseService.Customer.Update(_mapper.Map<CustomerEntity>(model));
            await _databaseService.SaveAsync();
            return model;
        }

    }
}
