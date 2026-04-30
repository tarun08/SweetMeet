using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetMeet.Data.Context;
using SweetMeet.Domain.Entities;

namespace SweetMeet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await appDbContext.Users.ToListAsync();
            return members;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser?>> GetMember(string id)
        {
            AppUser? member = await appDbContext.Users.FirstOrDefaultAsync(x => x.PublicId == Guid.Parse(id));
            return member;
        }
    }
}
