using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TournamentAdmin.Models;

namespace TournamentAdministration.Data
{
    public class TournamentAdminContext : IdentityDbContext
    {
        public TournamentAdminContext(DbContextOptions<TournamentAdminContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Player> Player { get; set; }
    }
}
