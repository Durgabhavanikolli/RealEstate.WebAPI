using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Core.Model;
using RealEstate.Core.Services.Interface;
using RealEstate.DTO;
using RealEstate.WebAPI.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _userService.RegisterUser(request);
            if (result != null)
            {
                return Ok(new { Message = "Signup successful!" });
            }
            else
            {
                return BadRequest(new { Message = "Something went wrong- Try again" });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _userService.Authenticate(request.Email, request.Password);

            if (user.Success == false)
            {
                return Unauthorized(new { Message = user.Message });
            }

            // Generate JWT token
            JWTGenerator generator = new JWTGenerator(_configuration);
            var token = generator.JwtToken(user.Result);

            return Ok(new { Token = token });
        }

     
    }
}
