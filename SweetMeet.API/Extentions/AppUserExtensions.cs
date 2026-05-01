using SweetMeet.API.Dto;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Services.Interfaces;

namespace SweetMeet.API.Extensions
{
    public static class AppUserExtensions
    {

        public static UserDto ToUserDto(this AppUser appUser, ITokenService tokenService)
        {
            return new UserDto
            { 
                PublicId = appUser.PublicId,
                DisplayName = appUser.DisplayName,
                Email = appUser.DisplayName,
                Token = tokenService.CreateToken(appUser)
            };
        }
    }
}
