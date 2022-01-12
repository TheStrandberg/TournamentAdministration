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
using Windows.Devices.Geolocation;

namespace TournamentAdministration.Pages.Tournaments
{
    public class AllTournamentsModel : PageModel
    {
        private readonly TournamentAdminContext database;
        private readonly AccessControl accessControl;

        public AllTournamentsModel(TournamentAdminContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Tournament> Tournaments { get; set; }
        public List<IdentityUser> Users { get; set; }
        public Tournament Tournament { get; set; }
        public string TournamentName { get; set; }
        public string VenueName { get; set; }
        public string Admin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Distance { get; set; }

        private async Task<List<Tournament>> GetModelData()
        {
            Tournaments = await database.Tournament
                .Include(t => t.Players)
                .Include(t => t.Venue)
                .Include(t => t.Game)
                .Include(t => t.User).ToListAsync();

            return Tournaments;
        }

        public async Task OnGetAsync()
        {
            Tournaments = await GetModelData();
            Users = database.Users.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string tournamentName, string venueName, 
            string admin, DateTime startDate, DateTime endDate, int? distance)
        {
            var tournaments = await GetModelData();
            Users = database.Users.ToList();
            string date = "0001-01-01";
            var dateAsString = startDate.ToShortDateString();

            if (tournamentName == null && venueName == null && admin == null && dateAsString == date)
            {
                tournaments = await GetModelData();
            }

            if (distance != null)
            {
                GeolocationAccessStatus accessStatus = await Geolocator.RequestAccessAsync();
                // The variable `position` now contains the latitude and longitude.
                Geoposition position = await new Geolocator().GetGeopositionAsync();
            }

            if (startDate <= endDate && dateAsString != date)
            {
                tournaments = tournaments.Where(t => t.EventTime >= startDate)
                    .Where(t => t.EventTime <= endDate)
                    .ToList();
            }

            if (!(tournamentName == null || tournamentName == ""))
            {
                tournaments = tournaments.Where(t => t.TournamentName.Contains(tournamentName)).ToList();
            }

            if (!(venueName == null || venueName == ""))
            {
                tournaments = tournaments.Where(t => t.Venue.VenueName.Contains(venueName)).ToList();
            }

            if (!(admin == null || admin == ""))
            {
                tournaments = tournaments.Where(t => t.User.Id == admin).ToList();
            }

            Tournaments = tournaments;
            return Page();
        }
    }
}
