using BCrypt.Net;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Repositories.Interfaces;
using SweetMeet.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMeet.Domain.Services
{
    public class AccountsService(IUserRepository userRepository) : IAccountsService
    {
        public async Task<AppUser> Register(AppUser appUser)
        {
            return await userRepository.Add(appUser);
        }

        public async Task<AppUser?> LoginAsync(string email, string password)
        {
            AppUser? user = await userRepository.GetByEmail(email);

            if(user == null)
            {
                throw new UnauthorizedAccessException();
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (isValid)
            {
                return user;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
