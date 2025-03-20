using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery : IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _databaseservice;
        private readonly IMapper _mapper;
        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _databaseservice = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password) 
        {
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(await _databaseservice.User.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password));
        }
    }
}
