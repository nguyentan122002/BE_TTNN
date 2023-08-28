using Microsoft.AspNetCore.Mvc;
using UTNotes.Dtos;
using UTNotes.Dtos.Account;
using UTNotes.Dtos.UserInput;
using UTNotes.Models;

namespace UTNotes.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(LoginRequestDto loginRequestDto);

        Task<User> Registration(RegistrationRequestDto registrationRequestDto);       
    }
}
