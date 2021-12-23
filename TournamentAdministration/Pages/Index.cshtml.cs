using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentAdmin.Models;
using TournamentAdministration.Data;

namespace TournamentAdministration.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public List<Tournament> Tournaments { get; private set; }

        public IndexModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public async Task OnGetAsync()
        {
            // Start by filtering for only contacts belonging to the logged-in user.
            var query = database.Tournament.Where(c => c.User.Id == accessControl.LoggedInUserID).AsNoTracking();

            //Tournaments = await query.ToListAsync();
        }

        //public void OnGet()
        //{

        //}
    }
}
