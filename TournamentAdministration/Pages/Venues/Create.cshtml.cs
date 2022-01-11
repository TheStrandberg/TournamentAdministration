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

        public Venue Venue { get; set; }
        public List<Venue> Venues { get; set; }
        public Coordinate Coordinate { get; private set; }

        private async Task GetModelData()
        {
            Venues = await database.Venue.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Venue venue, Coordinate coordinate)
        {
            var result = database.Venue.FirstOrDefault(n => n.VenueName == venue.VenueName);

            if (result == null)
            {
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

                await database.Venue.AddAsync(Venue);
                await database.SaveChangesAsync();
                return RedirectToPage("/Venues/Create");
            }
            else
            {
                ViewData["Message"] = ("Venue name already exists");
                return Page();
            }
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var venue = await database.Venue.FindAsync(id);

            try
            {
                database.Venue.Remove(venue);
                await database.SaveChangesAsync();
            }
            catch
            {
                ViewData["Message"] = "Venue is linked to a tournament. Delete the tournament before deleting the venue.";
                await GetModelData();
                return Page();
            }

            await GetModelData();
            return RedirectToPage("/Venues/Create");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetModelData();
            return Page();
        }
    }
}
