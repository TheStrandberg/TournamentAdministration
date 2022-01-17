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
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            return await database.Tournament.Include(g => g.Game).Include(v => v.Venue).AsNoTracking().OrderBy(t => t.EventTime).ToListAsync();
        }

        [HttpGet("/api/games/{title}"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tournament>>> FilterByGames(string title)
        {
            var games = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).Where(g => g.Game.Title.ToLower().Contains(title.ToLower())).ToListAsync();

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        [HttpGet("/api/venues/{venue}"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tournament>>> FilterByCitites(string venue)
        {
            var venues = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).Where(v => v.Venue.VenueName.ToLower().Contains(venue.ToLower())).ToListAsync();

            if (venues == null)
            {
                return NotFound();
            }

            return venues;
        }

        [HttpGet("/api/Tournaments/{tournamentName}"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tournament>>> FilterByTournamentName(string tournamentName)
        {
            var countries = await database.Tournament.Include(g => g.Game).Include(v => v.Venue).Where(t => t.TournamentName.ToLower().Contains(tournamentName.ToLower())).ToListAsync();

            if (countries == null)
            {
                return NotFound();
            }

            return countries;
        }
    }
}
