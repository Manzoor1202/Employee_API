﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Library.Model;
using Shared_Library.Service.Auth;
using System.Threading.Tasks;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccount _userAccount;

        public AccountController(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var response = await _userAccount.CreateAccount(userDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await _userAccount.LoginAccount(loginDTO);
            return Ok(response);
        }
    }
}
