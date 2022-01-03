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
    public class EditModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public EditModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Venue> Venues { get; set; }
        public List<Game> Games { get; set; }
        public Tournament Tournament { get; set; }
        public Game Game { get; private set; }
        public Venue Venue { get; private set; }

        private async Task GetModelData()
        {
            Venues = await database.Venue.ToListAsync();
            Games = await database.Game.ToListAsync();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Tournament = await database.Tournament.FindAsync(id);

            // Check that the contact actually belongs to the logged-in user.
            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            await GetModelData();
            return Page();
        }
    }
}
