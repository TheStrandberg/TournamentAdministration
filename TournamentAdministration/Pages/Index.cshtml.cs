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
        //private readonly UserManager<IdentityUser> userManager;

        public IndexModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
            //this.userManager = userManager;
        }

        public List<Tournament> UserTournaments { get; private set; }

        public async Task OnGetAsync()
        {
            //Dbinitializer.InitializeAsync(database, userManager);

            UserTournaments = await database.Tournament
                .Where(t => t.User.Id == accessControl.LoggedInUserID)
                .Include(t => t.Venue)
                .Include(t => t.Game)
                .OrderBy(t => t.EventTime).AsNoTracking().ToListAsync();
        }
    }
}
