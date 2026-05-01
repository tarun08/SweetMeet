using SweetMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMeet.Domain.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
