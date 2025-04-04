﻿using AutoMapper;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(model);
            await _databaseService.User.AddAsync(userEntity);
            await _databaseService.SaveAsync();
            return model;
        }

    }
}
