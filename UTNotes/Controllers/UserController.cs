using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UTNotes.Context;
using UTNotes.Dtos.Account;
using UTNotes.Dtos.UserInput;
using UTNotes.Interfaces;
using UTNotes.Models;

namespace UTNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UTDbContext _context;

        public UserController(IUserService userService, UTDbContext context) 
        {
            _userService = userService;
            _context = context;

        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequestDto registrationRequestDto)
        {
            var user = await _userService.Registration(registrationRequestDto);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userService.Login(loginRequestDto);
            if (user == null) 
            {
                return NotFound("Email or PassWord is incorrect");
            }
            return Ok(user);
        }
    }
}
