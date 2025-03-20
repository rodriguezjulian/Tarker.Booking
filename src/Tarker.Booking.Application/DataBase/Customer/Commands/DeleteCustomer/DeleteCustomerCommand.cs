using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    internal class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseService _databaseService;

        public DeleteCustomerCommand(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(int id) 
        {
            CustomerEntity? customer = await _databaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (customer == null) return false;
            _databaseService.Customer.Remove(customer);
            return await _databaseService.SaveAsync();
        }
    }
}
