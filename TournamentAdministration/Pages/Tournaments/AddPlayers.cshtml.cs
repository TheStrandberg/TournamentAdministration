using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentAdmin.Models;
using TournamentAdministration.Data;

namespace TournamentAdministration.Pages.Tournaments
{
    public class AddPlayersModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public AddPlayersModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public Player Player { get; set; }

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
            return RedirectToPage("/Index");
        }
    }
}
