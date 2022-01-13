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
        public Player Player { get; set; }
        public List<Player> Players { get; private set; }
        public List<Tournament> Tournaments { get; private set; }
        public List<Player> Participants { get; private set; }
        //public int TournamentID { get; private set; }

        private async Task GetModelData(int id)
        {
            Tournament = await database.Tournament.FindAsync(id);
            Players = await database.Player.Include(p => p.Tournaments).ToListAsync();
            Tournaments = await database.Tournament.Include(t => t.Players).ToListAsync();
            Participants = await database.Player.Where(p => p.Tournaments.Contains(Tournament)).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id, Player player)
        {
            await GetModelData(id);
            player = await database.Player.FindAsync(player.ID);

            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            Tournament.Players.Add(player);
            await database.SaveChangesAsync();
            // Need to fetch data again to display participant list on page properly
            Participants = await database.Player.Where(p => p.Tournaments.Contains(Tournament)).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int id, int playerID)
        {
            var player = await database.Player.FindAsync(playerID);
            await GetModelData(id);

            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            Tournament.Players.Remove(player);
            await database.SaveChangesAsync();
            // Need to fetch data again to display participant list on page properly
            Participants = await database.Player.Where(p => p.Tournaments.Contains(Tournament)).ToListAsync();
            //return RedirectToPage("/Tournaments/Players", new { TournamentID = tournamentID });
            return Page();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await GetModelData(id);
            //TournamentID = id;

            // Check that the tournament actually belongs to the logged-in user.
            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            return Page();
        }
    }
}