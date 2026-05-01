using SweetMeet.Domain.Entities;

namespace SweetMeet.Domain.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<AppUser> Register(AppUser appUser);

        Task<AppUser?> LoginAsync(string email, string password);
    }
}
