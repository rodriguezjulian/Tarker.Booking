using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;

        public UpdateUserCommand(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            UserEntity user = _mapper.Map<UserEntity>(model);
            _dataBaseService.User.Update(user);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
