using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentAdmin.Models;
using TournamentAdministration.Data;

namespace TournamentAdministration.Pages.Games
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

        public Game Game{ get; set; }

        public async Task<IActionResult> OnPostAsync(int id, Game game)
        {
            Game = await database.Game.FindAsync(id);

            var result = database.Game.FirstOrDefault(g => g.Title == game.Title);

            if (result == null)
            {
                Game.Title = game.Title;
                await database.SaveChangesAsync();
                return RedirectToPage("/Games/Create");
            }
            else
            {
                ViewData["Message"] = "Game name already exists";
                return Page();
            }
            
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Game = await database.Game.FindAsync(id);
            return Page();
        }
    }
}
