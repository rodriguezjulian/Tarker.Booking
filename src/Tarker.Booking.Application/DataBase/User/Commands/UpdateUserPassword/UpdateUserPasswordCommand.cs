using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    internal class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        public readonly IDataBaseService _dataBaseService;
        public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            UserEntity user = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == model.Id);
            if (user == null) return false;
            user.Password = model.UserPassword;
            
            return await _dataBaseService.SaveAsync();
        }
    }
}
