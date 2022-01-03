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
                
        private async Task GetModelData()
        {
            Venues = await database.Venue.ToListAsync();
            Games = await database.Game.ToListAsync();
        }        

        public async Task<IActionResult> OnPostAsync(Tournament tournament)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Tournament = new Tournament
            {
                UserID = accessControl.LoggedInUserID,
                TournamentName = tournament.TournamentName,
                EventTime = tournament.EventTime,
                Game = tournament.Game,
                Venue = tournament.Venue
            };


            await database.Tournament.AddAsync(Tournament);
            await database.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetModelData();
            return Page();
        }
    }
}
