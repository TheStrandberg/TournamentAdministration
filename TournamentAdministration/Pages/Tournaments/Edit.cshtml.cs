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
        //public Player Player { get; private set; }


        private async Task GetModelData()
        {
            Venues = await database.Venue.ToListAsync();
            Games = await database.Game.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id, Tournament tournament, Game game, Venue venue)
        {
            // Error handling/validation might not be needed for this page?
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Tournament = await database.Tournament.FindAsync(id);

            if (!accessControl.UserCanAccess(Tournament))
            {
                return Forbid();
            }

            var result = database.Tournament.FirstOrDefault(t => t.TournamentName == tournament.TournamentName);

            if (result != null)
            {
                ViewData["Message"] = "Tournament name already exists";
                await GetModelData();
                return Page();
            }
            else if (tournament.EventTime < DateTime.Today)
            {
                ViewData["Message"] = "Tournament date cant be earlier than today";
                await GetModelData();
                return Page();
            }
            else
            {
                Tournament.TournamentName = tournament.TournamentName;
                Tournament.EventTime = tournament.EventTime;
                Tournament.Game = await database.Game.Where(g => g.ID == game.ID).SingleAsync();
                Tournament.Venue = await database.Venue.Where(v => v.ID == venue.ID).SingleAsync();

                await database.SaveChangesAsync();
                return RedirectToPage("/Index");
            }

        }

        //public async Task<IActionResult> OnPostPlayerAsync(int id, Player player)
        //{
        //    Tournament = await database.Tournament.FindAsync(id);

        //    if (!accessControl.UserCanAccess(Tournament))
        //    {
        //        return Forbid();
        //    }

        //    Tournament.Players.Add(player);
        //    await database.SaveChangesAsync();

        //    return RedirectToPage("/Index");
        //}

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
