using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zawodnicy.core.Domain;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SkiJumper> SkiJumper { get; set; }

        public DbSet<Trainer> Trainer { get; set; }
    }
}