using Hackathon_MV.Server.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_MV.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }


        [EnableCors("AllowAll")]
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(new User
            {
                Email = request.Email, FirstName = request.FirstName,LastName = request.LastName
            }, request.Password);


            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [EnableCors("AllowAll")]
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Email,request.Password);


            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [EnableCors("AllowAll")]
        [HttpGet("api/me")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUser(string token)
        {
            var response = await _authRepo.GetUserByToken(token);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }



    }
}
