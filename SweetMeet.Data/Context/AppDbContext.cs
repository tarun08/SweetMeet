using Microsoft.EntityFrameworkCore;
using SweetMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetMeet.Data.Context
{
    public class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<AppUser> Users { get; set; }
    }
}
