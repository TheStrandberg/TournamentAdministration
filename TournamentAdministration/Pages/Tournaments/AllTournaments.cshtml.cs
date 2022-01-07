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

        public string TournamentName { get; set; }
        public string Admin { get; set; }

        private async Task<List<Tournament>> GetModelData()
        {
            Tournaments = await database.Tournament
                .Include(t => t.Players)
                .Include(t => t.Venue)
                .Include(t => t.Game)
                .Include(t => t.User).ToListAsync();

            return Tournaments;
        }

        public async Task OnGetAsync()
        {
            Tournaments = await GetModelData();
            Users = database.Users.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string tournamentName, string admin)
        {
            var tournaments = await GetModelData();
            Users = database.Users.ToList();

            if (!(tournamentName == null || tournamentName == ""))
            {
                tournaments = tournaments.Where(t => t.TournamentName.Contains(tournamentName)).ToList();
            }

            if (!(admin == null || admin == ""))
            {
                tournaments = tournaments.Where(t => t.User.Id == admin).ToList();
            }
            Tournaments = tournaments;
            return Page();
        }
    }
}
