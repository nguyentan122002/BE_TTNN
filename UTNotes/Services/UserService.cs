using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UTNotes.Context;
using UTNotes.Dtos;
using UTNotes.Dtos.Account;
using UTNotes.Dtos.Note;
using UTNotes.Dtos.UserInput;
using UTNotes.Interfaces;
using UTNotes.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UTNotes.Services
{
    
    public class UserService : IUserService
    {
        private readonly UTDbContext _context;

        public UserService(UTDbContext context) 
        {
            _context = context;
        }

        public async Task<User> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Email == loginRequestDto.Email &&  p.Password == loginRequestDto.PassWord);
            if (user == null)
            {
                return null;
            }
            return user;

        }


        public async Task<User> Registration(RegistrationRequestDto registrationRequestDto)
        {
            var mail = _context.Users.SingleOrDefault(m => m.Email == registrationRequestDto.Email);
            if (mail != null)
            {
                throw new Exception($"Email {registrationRequestDto.Email} Already");
            }
            if (registrationRequestDto.Password != registrationRequestDto.ComfirmPassword)
            {
                throw new Exception("Password Incorrect");
            }           
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = registrationRequestDto.Email,
                Password = registrationRequestDto.Password,
            };
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }


    }
    
}
