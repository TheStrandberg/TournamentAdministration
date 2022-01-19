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

        //[HttpGet, AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        //{
        //    return await database.Tournament.Include(g => g.Game).Include(v => v.Venue).AsNoTracking().OrderBy(t => t.EventTime).ToListAsync();
        //}

        //[HttpGet("/api/games/{title}"), AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<Tournament>>> FilterByGames(string title)
        //{
        //    var games = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).OrderBy(t => t.EventTime).Where(g => g.Game.Title.ToLower().Contains(title.ToLower())).ToListAsync();

        //    if (games == null)
        //    {
        //        return NotFound();
        //    }

        //    return games;
        //}

        //[HttpGet("/api/venues/{venue}"), AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<Tournament>>> FilterByCitites(string venue)
        //{
        //    var venues = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).OrderBy(t => t.EventTime).Where(v => v.Venue.VenueName.ToLower().Contains(venue.ToLower())).ToListAsync();

        //    if (venues == null)
        //    {
        //        return NotFound();
        //    }

        //    return venues;
        //}

        //[HttpGet("/api/Tournaments/{tournamentName}"), AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<Tournament>>> FilterByTournamentName(string tournamentName)
        //{
        //    var countries = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).OrderBy(t => t.EventTime).Where(t => t.TournamentName.ToLower().Contains(tournamentName.ToLower())).ToListAsync();

        //    if (countries == null)
        //    {
        //        return NotFound();
        //    }

        //    return countries;
        //}

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournamentNear(string name, string game, string venue,
            string country, string city, int? distance, double latitude, double longitude)
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

            return tournaments;
        }
    }
}
