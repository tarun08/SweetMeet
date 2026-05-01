using SweetMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMeet.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> Add(AppUser user);

        Task<AppUser?> GetByEmail(string email);
    }
}
