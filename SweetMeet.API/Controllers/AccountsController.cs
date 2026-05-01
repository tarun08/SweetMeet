using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetMeet.API.DTO;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Services.Interfaces;
using System.Text;

namespace SweetMeet.API.Controllers
{
    public class AccountsController(IAccountsService accountsService) : BaseApiController
    {

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register([FromBody] RegisterUserDto registerUser)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            AppUser appUser = new()
            {
                DisplayName = registerUser.DisplayName,
                Email = registerUser.Email.Trim(),
                PasswordHash = passwordHash,
            };

            appUser = await accountsService.Register(appUser);

            return Ok(appUser);
        }


        [HttpPost("login")]
        public async Task<ActionResult<AppUser?>> Login(LoginDto loginDto)
        {
            return await accountsService.Login(loginDto.Email, loginDto.Password);
        }
    }
}
