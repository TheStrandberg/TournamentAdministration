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
    public class PlayersModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public PlayersModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public Tournament Tournament { get; set; }
        public Player Player { get; private set; }
        public List<Player> Players { get; private set; }

        private async Task GetModelData()
        {
            Players = await database.Player.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id, Tournament tournament, Player player)
        {
            tournament = await database.Tournament.FindAsync(id);

            if (!accessControl.UserCanAccess(tournament))
            {
                return Forbid();
            }

            tournament.Players.Add(player);
            await database.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Tournament = await database.Tournament.FindAsync(id);

            // Check that the tournament actually belongs to the logged-in user.
            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            await GetModelData();
            return Page();
        }
    }
}