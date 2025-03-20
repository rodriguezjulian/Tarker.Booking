using Tarker.Booking.Domain.Models;

namespace Tarker.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, object data = null,string message = null) 
        {
            bool succes = false;
            if(statusCode >= 200 && statusCode < 300)
                succes = true;

            var result = new BaseResponseModel 
            {
                StatusCode = statusCode,
                Succes = succes,
                Message = message,
                Data = data
            };
            return result;
        }
    }
}
