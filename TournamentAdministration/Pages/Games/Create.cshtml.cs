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

namespace TournamentAdministration.Pages.Games
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

        public Game Game { get; set; }
        public List<Game> Games { get; set; }

        private async Task GetModelData()
        {
            Games = await database.Game.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Game game)
        {
            var result = await database.Game.FirstOrDefaultAsync(g => g.Title == game.Title);

            if (result == null)
            {
                Game = new Game
                {
                    Title = game.Title
                };

                await database.Game.AddAsync(Game);
                await database.SaveChangesAsync();
            }
            else
            {
                ViewData["Message"] = "Game name already exists";
            }
            await GetModelData();
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var game = await database.Game.FindAsync(id);

            try
            {
                database.Game.Remove(game);
                await database.SaveChangesAsync();
            }
            catch 
            {
                ViewData["Message"] = "Game is linked to a tournament. Delete the tournament before deleting the game.";
                await GetModelData();
                return Page();
            }

            await GetModelData();
            return RedirectToPage("/Games/Create");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetModelData();
            return Page();
        }
    }
}
