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
    public class DeleteModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public DeleteModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }
   
        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var tournament = await database.Tournament.FindAsync(id);

            // Check that the contact actually belongs to the logged-in user.
            if (!accessControl.UserCanAccess(tournament))
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var tournament = await database.Tournament.FindAsync(id);

            // Check that the tournament actually belongs to the logged-in user.
            if (!accessControl.UserCanAccess(tournament))
            {
                return Forbid();
            }

            database.Tournament.Remove(tournament);
            await database.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
