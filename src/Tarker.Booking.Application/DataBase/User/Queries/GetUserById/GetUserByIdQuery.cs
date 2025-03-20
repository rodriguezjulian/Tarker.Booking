using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        public readonly IDataBaseService _dataBaseService;
        public readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task <GetUserByIdModel> Execute(int id) 
        {
            return _mapper.Map<GetUserByIdModel>(await _dataBaseService.User.FirstOrDefaultAsync(x=> x.UserId == id));
        }
    }
}
