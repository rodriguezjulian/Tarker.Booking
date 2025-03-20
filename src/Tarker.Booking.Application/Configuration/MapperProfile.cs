using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.Custommer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Custommer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomersModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<CreateBookingModel , BookingEntity>()
                .ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(opt => DateTime.Now));
           
            CreateMap<BookingEntity, GetAllBookingsModel>()
                .ForPath(dest => dest.CustomerDocumentNumber, opt => opt.MapFrom(ori => ori.Customer.DocumentNumber))
                .ForPath(dest => dest.CustomerFullName, opt => opt.MapFrom(ori => ori.Customer.FullName));
           
            CreateMap<BookingEntity, GetBookingsByDocumentNumberModel>().ReverseMap();

            CreateMap<BookingEntity, GetBookingsByTypeModel>()
                .ForPath(dest => dest.CustomerDocumentNumber, opt => opt.MapFrom(ori => ori.Customer.DocumentNumber))
                .ForPath(dest => dest.CustomerFullName, opt => opt.MapFrom(ori => ori.Customer.FullName))
                .ReverseMap();
            
            #endregion

        }
    }
}
