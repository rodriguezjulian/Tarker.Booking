using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int id)
        {
            UserEntity? entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == id);

            if (entity == null)
                return false;

            _dataBaseService.User.Remove(entity);

            return await _dataBaseService.SaveAsync();
        }
    }
}
