﻿using Microsoft.AspNetCore.Identity;
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

        // We probably could add more configuration here to protect against edge cases.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Venue>()
                .HasIndex(v => v.VenueName)
                .IsUnique();

            builder.Entity<Tournament>()
                .HasIndex(n => n.TournamentName)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
