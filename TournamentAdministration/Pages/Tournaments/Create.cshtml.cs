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

namespace TournamentAdministration.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public CreateModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Venue> Venues { get; set; }
        public List<Game> Games { get; set; }
        public Tournament Tournament { get; set; }

        private void CreateEmptyTournament()
        {
            Tournament = new Tournament
            {
                UserID = accessControl.LoggedInUserID
            };
        }

        private async Task GetVenues()
        {
            Venues = await database.Venue.ToListAsync();
        }

        private async Task GetGames()
        {
            Games = await database.Game.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Tournament tournament)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Tournament.TournamentName = tournament.TournamentName;
            Tournament.EventTime = tournament.EventTime;
            Tournament.Game = tournament.Game;
            //Tournament.Players = tournament.Players;
            Tournament.UserID = tournament.UserID;
            tournament.Venue = tournament.Venue;

            await database.Tournament.AddAsync(Tournament);
            await database.SaveChangesAsync();
            return RedirectToPage("./Details", new { id = Tournament.ID });
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CreateEmptyTournament();
            await GetVenues();
            await GetGames();
            return Page();
        }
    }
}
