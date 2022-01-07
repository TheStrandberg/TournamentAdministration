using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TournamentAdmin.Models;
using TournamentAdministration.Data;

namespace TournamentAdministration.Pages.Players
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

        public Player Player { get; set; }
        public List<Player> Players { get; set; }

        private async Task GetModelData()
        {
            Players = await database.Player.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Player player)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Player = new Player
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                GameHandle = player.GameHandle,
                CountryOfOrigin = player.CountryOfOrigin,
                HomeTown = player.HomeTown,
            };

            await database.Player.AddAsync(Player);
            await database.SaveChangesAsync();
            return RedirectToPage("/Tournaments/AddPlayers");
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var player = await database.Player.FindAsync(id);

            database.Player.Remove(player);
            await database.SaveChangesAsync();
            await GetModelData();
            return Page();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetModelData();
            return Page();
        }
    }
}
