using Microsoft.EntityFrameworkCore;
using SweetMeet.Data.Context;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Repositories.Interfaces;

namespace SweetMeet.Data.Repositories
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        public async Task<AppUser> Add(AppUser user)
        {
            if(await appDbContext.Users.AnyAsync(x => x.Email.Trim().ToLower() == user.Email))
            {
                throw new Exception("Email already exists.");
            }

            appDbContext.Users.Add(user);

            await appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<AppUser?> GetByEmail(string email)
        {
            return await appDbContext.Users.SingleOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
        }
    }
}
