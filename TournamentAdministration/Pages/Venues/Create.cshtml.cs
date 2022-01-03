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

        public Venue Venue { get; private set; }
        public Coordinate Coordinate { get; private set; }

        public async Task<IActionResult> OnPostAsync(Venue venue, Coordinate coordinate)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            Coordinate = new Coordinate
            {
                Longitude = coordinate.Longitude,
                Latitude = coordinate.Latitude
            };

            Venue = new Venue
            {
                VenueName = venue.VenueName,
                Coordinate = Coordinate
            };            

            //Venue.Coordinate.Latitude = Coordinate.Latitude;
            //Venue.Coordinate.Longitude = Coordinate.Longitude;

            await database.Venue.AddAsync(Venue);
            await database.SaveChangesAsync();
            return RedirectToPage("/Tournaments/Create", new { venue = venue.ID });
        }
    }
}
