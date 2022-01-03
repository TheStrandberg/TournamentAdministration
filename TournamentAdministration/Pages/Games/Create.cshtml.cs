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

        private void CreateEmptyGame()
        {
            Game = new Game
            {

            };
        }

        public async Task<IActionResult> OnPostAsync(Game game)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Game.Title = game.Title;

            await database.Game.AddAsync(Game);
            await database.SaveChangesAsync();
            return RedirectToPage("./Tournaments/Create", new { game = game.ID });
        }

        public void OnGet()
        {
            CreateEmptyGame();
            
        }
    }
}
