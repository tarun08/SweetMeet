using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMeet.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public required string DisplayName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
