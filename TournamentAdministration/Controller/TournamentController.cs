using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentAdmin.Models;
using TournamentAdministration.Data;
using System.Device.Location;

namespace TournamentAdministration.Controller
{
    [Route("/api/Tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentAdminContext database;

        public TournamentController(TournamentAdminContext database)
        {
            this.database = database;
        }        

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournamentsFiltered(string name, string game, string venue,
            string country, string city, int? distance, double latitude, double longitude, string fromDate, string toDate)
        {
            var tournaments = await database.Tournament.Include(t => t.Game).Include(t => t.Venue).Include(t => t.Players)
                .AsNoTracking().OrderBy(t => t.EventTime).ToListAsync();

            if (name != null)
            {
                tournaments = tournaments.Where(t => t.TournamentName.ToLower().Contains(name.ToLower())).ToList();
            }

            if (game != null)
            {
                tournaments = tournaments.Where(t => t.Game.Title.ToLower().Contains(game.ToLower())).ToList();
            }

            if (venue != null)
            {
                tournaments = tournaments.Where(t => t.Venue.VenueName.ToLower().Contains(venue.ToLower())).ToList();
            }

            if (country != null)
            {
                tournaments = tournaments.Where(t => t.Venue.Address.Country.ToLower().Contains(country.ToLower())).ToList();
            }

            if (city != null)
            {
                tournaments = tournaments.Where(t => t.Venue.Address.City.ToLower().Contains(city.ToLower())).ToList();
            }

            if (distance != null)
            {
                var tournamentsInRange = new List<Tournament>();
                var userCoordinate = new GeoCoordinate(latitude, longitude);

                foreach (var tournament in tournaments)
                {
                    var venueCoordinate = new GeoCoordinate(tournament.Venue.Coordinate.Latitude, tournament.Venue.Coordinate.Longitude);
                    var actualDistance = userCoordinate.GetDistanceTo(venueCoordinate);

                    if (actualDistance < distance * 1000)
                    {
                        tournamentsInRange.Add(tournament);
                    }
                }
                tournaments = tournamentsInRange;
            }

            if (fromDate != null || toDate != null)
            {
                var formattedFromDate = DateTime.Today;

                if (fromDate != null)
                {
                    formattedFromDate = DateTime.Parse(fromDate);
                }

                if (toDate != null)
                {
                    var formattedToDate = DateTime.Parse(toDate);
                    tournaments = tournaments.Where(t => t.EventTime >= formattedFromDate && t.EventTime <= formattedToDate).ToList();
                }
                else
                {
                    tournaments = tournaments.Where(t => t.EventTime >= formattedFromDate).ToList();
                }
            }
            return tournaments;
        }

        [HttpGet("/api/Tournaments/{id}"), AllowAnonymous]
        public async Task<ActionResult<Tournament>> GetTournamentById(int id)
        {
            return await database.Tournament.Include(t => t.Game).Include(t => t.Venue).Include(t => t.Players)
                .AsNoTracking().Where(t => t.ID == id).SingleAsync();
        }
    }
}
