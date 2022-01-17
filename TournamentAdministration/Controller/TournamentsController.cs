﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentAdmin.Models;
using TournamentAdministration.Data;
using System.Device.Location;

namespace TournamentAdministration.Controller
{
    //[Route("/api/Tournaments")]
    //[ApiController]
    //public class TournamentsController : ControllerBase
    //{
    //    private readonly TournamentAdminContext database;

    //    public TournamentsController(TournamentAdminContext database)
    //    {
    //        this.database = database;
    //    }

    //    // GET: api/Tournaments
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
    //    {
    //        return await database.Tournament.AsNoTracking().OrderBy(t => t.EventTime).ToListAsync();
    //    }

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

    ////GET: api/Tournaments/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<Tournament>> GetTournament(int id)
    //{
    //    var tournament = await database.Tournament.FindAsync(id);

    //    if (tournament == null)
    //    {
    //        return NotFound();
    //    }

    //    return tournament;
    //}

    // GET: api/Tournaments/Near
    //[HttpGet("near")]
    //public async Task<ActionResult<IEnumerable<Tournament>>> GetTournamentNear(double latitude, double longitude)
    //{
    //    var tournamentsInRange = new List<Tournament>();
    //    var userCoordinate = new GeoCoordinate(latitude, longitude);

    //    foreach (var tournament in database.Tournament.Include(t => t.Venue))
    //    {
    //        var venueCoordinate = new GeoCoordinate(tournament.Venue.Coordinate.Latitude, tournament.Venue.Coordinate.Longitude);
    //        var distance = userCoordinate.GetDistanceTo(venueCoordinate);

    //        if (distance < 100000)
    //        {
    //            tournamentsInRange.Add(tournament);
    //        }                
    //    }

    //    return tournamentsInRange;
    //}

    //PUT: api/Tournaments/5
    //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("api/Tournaments/{id}")]
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

    //private bool TournamentExists(int id)
    //{
    //    return database.Tournament.Any(e => e.ID == id);
    //}
    //    }
}
