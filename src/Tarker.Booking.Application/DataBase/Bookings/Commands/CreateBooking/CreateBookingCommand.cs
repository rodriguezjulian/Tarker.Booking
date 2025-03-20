using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBookingCommand
{
    internal class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService= dataBaseService;
        }
        public async Task<CreateBookingModel> Execute(CreateBookingModel model) 
        {
            await _dataBaseService.Booking.AddAsync(_mapper.Map<BookingEntity>(model));
            await _dataBaseService.SaveAsync();
            return model;
        }
        
    }
}
