﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Hackathon_MV.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingleUser(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(
            AddUserDto newUser
        )
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> UpdateUser(
            UpdateUserDto updateCharacter
        )
        {
            var response = await _userService.UpdateUser(updateCharacter);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
