using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controller
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand)
        {
            var data = await createUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created,data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand)
        {
            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand)
        {
            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("deleteUser/{model}")]
            public async Task<IActionResult> DeleteUser(
            int model,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (model == 0) return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await deleteUserCommand.Execute(model);
            if (!data) return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }      

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUser(
            [FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();
            if (data.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("getUserUserNameAndPassword/{model}")]
            public async Task<IActionResult> GetUserUserNameAndPassword(
            int model,
            [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            var data = await getUserByIdQuery.Execute(model);
            if (data == null) return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("getUserByUserNameAndPassword/{userName}/{password}")]
        public async Task<IActionResult> GetUserByUserNameAndPassword(
            string userName, 
            string password,
        [FromServices] IGetUserByUserNameAndPasswordQuery getUserByUserNameAndPasswordQuery)
        {
            var data = await getUserByUserNameAndPasswordQuery.Execute(userName, password);
            if (data == null) return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
