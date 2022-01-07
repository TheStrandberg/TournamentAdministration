using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentAdmin.Models;
using TournamentAdministration.Data;

namespace TournamentAdministration.Controller
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentAdminContext database;

        public TournamentsController(TournamentAdminContext database)
        {
            this.database = database;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            return await database.Tournament.AsNoTracking().OrderBy(t => t.EventTime).ToListAsync();
        }

        //[HttpGet("/filter/games")]
        //public async Task<ActionResult<Tournament>> FilterByTournamentGames()
        //{
        //    var games = await database.Tournament.OrderBy(g => g.Game.Title).ToListAsync();

        //    if (games == null)
        //    {
        //        return NotFound();
        //    }

        //    return games;
        //}

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await database.Tournament.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        //{
        //    if (id != tournament.ID)
        //    {
        //        return BadRequest();
        //    }

        //    database.Entry(tournament).State = EntityState.Modified;

        //    try
        //    {
        //        await database.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TournamentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        //{
        //    database.Tournament.Add(tournament);
        //    await database.SaveChangesAsync();

        //    return CreatedAtAction("GetTournament", new { id = tournament.ID }, tournament);
        //}

        // DELETE: api/Tournaments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTournament(int id)
        //{
        //    var tournament = await database.Tournament.FindAsync(id);
        //    if (tournament == null)
        //    {
        //        return NotFound();
        //    }

        //    database.Tournament.Remove(tournament);
        //    await database.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool TournamentExists(int id)
        {
            return database.Tournament.Any(e => e.ID == id);
        }
    }
}
