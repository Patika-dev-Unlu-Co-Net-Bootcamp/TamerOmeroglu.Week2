using HotelFinder.API.Attributes;
using HotelFinder.API.Exceptions;
using HotelFinder.API.Services;
using HotelFinder.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [SignUp]
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            var checkValidation = _userService.UserIsValid(user);

            if (!checkValidation) throw new BadRequestException("Wrong User Parameter!");

            return Ok();
        }
    }
}
