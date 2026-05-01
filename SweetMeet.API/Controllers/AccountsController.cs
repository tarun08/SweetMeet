using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetMeet.API.Dto;
using SweetMeet.API.DTO;
using SweetMeet.API.Extensions;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Services.Interfaces;
using System.Text;

namespace SweetMeet.API.Controllers
{
    public class AccountsController(IAccountsService accountsService, ITokenService tokenService) : BaseApiController
    {

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUserDto registerUser)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            AppUser appUser = new()
            {
                DisplayName = registerUser.DisplayName,
                Email = registerUser.Email.Trim(),
                PasswordHash = passwordHash,
            };

            appUser = await accountsService.Register(appUser);

            UserDto userDto = appUser.ToUserDto(tokenService);

            return Ok(userDto);
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto?>> Login(LoginDto loginDto)
        {
            AppUser? appUser = await accountsService.LoginAsync(loginDto.Email, loginDto.Password);

            if(appUser == null)
            {
                throw new UnauthorizedAccessException("Invalid Access");
            }

            var token = tokenService.CreateToken(appUser);

            UserDto userDto = appUser.ToUserDto(tokenService);

            return Ok(userDto);
        }
    }
}
