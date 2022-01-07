using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentAdmin.Models;

namespace TournamentAdministration.Data
{
    public class Dbinitializer
    {
        public static void Initialize(TournamentAdminContext database)
        {
            if (database.Tournament.Any())
            {
                return;
            }

            var player = new Player();
            player.FirstName = "Brad";
            player.LastName = "Pitt";
            player.GameHandle = "The Pittmeister";
            player.CountryOfOrigin = "USA";
            player.HomeTown = "LA";
            database.Player.Add(player);

            var player2 = new Player();
            player2.FirstName = "Will";
            player2.LastName = "Smith";
            player2.GameHandle = "Woll Smoth";
            player2.CountryOfOrigin = "USA";
            player2.HomeTown = "LA";
            database.Player.Add(player2);

            var venue = new Venue();
            venue.VenueName = "Globen";
            Coordinate coordinate = new Coordinate();
            coordinate.Latitude = 59.293602;
            coordinate.Longitude = 18.083185;
            venue.Coordinate = coordinate;
            database.Venue.Add(venue);

            var venue2 = new Venue();
            venue2.VenueName = "Scandinavium";
            Coordinate coordinate2 = new Coordinate();
            coordinate2.Latitude = 57.699378;
            coordinate2.Longitude = 11.98765;
            venue2.Coordinate = coordinate2;
            database.Venue.Add(venue2);

            Game game = new Game();
            game.Title = "Hearthstone";
            database.Game.Add(game);

            Game game2 = new Game();
            game2.Title = "Metroid Prime";
            database.Game.Add(game2);

            var tournament = new Tournament();
            tournament.UserID = "60b81ff7-4235-49fc-88d7-67ef0821ae61";
            tournament.TournamentName = "Blizz Con";
            tournament.EventTime = DateTime.Now;
            tournament.Description = "100$ tourney";
            tournament.Game = game;
            tournament.Venue = venue;
            database.Tournament.Add(tournament);

            var tournament2 = new Tournament();
            tournament2.UserID = "60b81ff7-4235-49fc-88d7-67ef0821ae61";
            tournament2.TournamentName = "Dreamhack";
            tournament2.Description = "100$ tourney";
            tournament2.EventTime = DateTime.Now;
            tournament2.Game = game2;
            tournament2.Venue = venue2;
            database.Tournament.Add(tournament2);

            database.SaveChanges();
        }       
    }
}
