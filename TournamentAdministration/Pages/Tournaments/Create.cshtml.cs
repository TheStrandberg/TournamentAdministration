using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentAdministration.Data;
using TournamentAdmin.Models;
using Microsoft.AspNetCore.Identity;

namespace TournamentAdministration.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly TournamentAdminContext database;
        //private readonly AccessControl accessControl;

        public CreateModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            //this.accessControl = accessControl;
        }

        public void OnGet()
        {
        }
    }
}
