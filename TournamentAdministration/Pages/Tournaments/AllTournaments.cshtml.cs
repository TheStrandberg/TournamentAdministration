using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentAdministration.Data;
using TournamentAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Windows.Devices.Geolocation;

namespace TournamentAdministration.Pages.Tournaments
{
    public class AllTournamentsModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public AllTournamentsModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Tournament> Tournaments { get; set; }
        public List<IdentityUser> Users { get; set; }
        public List<Player> Players { get; set; }
        public Tournament Tournament { get; set; }
        public int PlayerOne { get; set; }
        public int PlayerTwo { get; set; }
        public string TournamentName { get; set; }
        public string VenueName { get; set; }
        public string Admin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Game { get; set; }

        private async Task<List<Tournament>> GetModelData()
        {
            Tournaments = await database.Tournament
                .Include(t => t.Players)
                .Include(t => t.Venue)
                .Include(t => t.Game)
                .Include(t => t.User)
                .OrderBy(t => t.EventTime).ToListAsync();

            return Tournaments;
        }

        public async Task OnGetAsync()
        {
            Tournaments = await GetModelData();
            Users = database.Users.ToList();
            Players = database.Player.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string tournamentName, string venueName, 
            string admin, DateTime startDate, DateTime endDate, string game, int? playerOne, int? playerTwo)
        {
            var tournaments = await GetModelData();
            Users = database.Users.ToList();
            Players = database.Player.ToList();
            string date = "0001-01-01";
            var startDateAsString = startDate.ToShortDateString();
            var endDateAsString = endDate.ToShortDateString();

            if (!(tournamentName == null || tournamentName == ""))
            {
                tournaments = tournaments.Where(t => t.TournamentName.ToLower().Contains(tournamentName.ToLower())).ToList();
            }

            if (!(venueName == null || venueName == ""))
            {
                tournaments = tournaments.Where(t => t.Venue.VenueName.ToLower().Contains(venueName.ToLower())).ToList();
            }

            if (startDateAsString != date || endDateAsString != date)
            {
                if (endDateAsString != date)
                {
                    tournaments = tournaments.Where(t => t.EventTime >= startDate && t.EventTime <= endDate).ToList();
                }
                else
                {
                    tournaments = tournaments.Where(t => t.EventTime >= startDate).ToList();
                }
            }

            if (!(game == null || game == ""))
            {
                tournaments = tournaments.Where(t => t.Game.Title.ToLower().Contains(game.ToLower())).ToList();
            }

            if (!(admin == null || admin == ""))
            {
                tournaments = tournaments.Where(t => t.User.Id == admin).ToList();
            }

            if (playerOne != null || playerTwo != null)
            {
                if (playerOne != null)
                {                    
                    var player = database.Player.First(p => p.ID == playerOne);
                    tournaments = tournaments.Where(t => t.Players.Contains(player)).ToList();
                }
                if (playerTwo != null)
                {
                    var player = database.Player.First(p => p.ID == playerTwo);
                    tournaments = tournaments.Where(t => t.Players.Contains(player)).ToList();
                }
            }

            Tournaments = tournaments;
            return Page();
        }
    }
}
