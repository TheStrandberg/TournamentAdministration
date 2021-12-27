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

namespace TournamentAdministration.Pages.Venues
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

        //public List<Venue> Venues { get; set; }
        //public List<Game> Games { get; set; }
        //public Tournament Tournament { get; set; }
        public Venue Venue { get; private set; }

        private void CreateEmptyVenue()
        {
            Venue = new Venue
            {

            };
        }

        public async Task<IActionResult> OnPostAsync(Venue venue)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Venue.VenueName = venue.VenueName;
            Venue.Coordinate.Longitude = venue.Coordinate.Longitude;
            venue.Coordinate.Latitude = venue.Coordinate.Latitude;


            await database.Venue.AddAsync(Venue);
            await database.SaveChangesAsync();
            return RedirectToPage("./Details", new { venue = venue.ID });
        }

        public void OnGet()
        {
            CreateEmptyVenue();
        }
    }
}
