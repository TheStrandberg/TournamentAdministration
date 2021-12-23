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
            database.Add(player);

            var player2 = new Player();
            player2.FirstName = "Will";
            player2.LastName = "Smith";
            player2.GameHandle = "Woll Smoth";
            database.Add(player2);

            var venue = new Venue();
            venue.VenueName = "Globen";
            Coordinate coordinate = new Coordinate();
            coordinate.Latitude = 59.293602;
            coordinate.Longitude = 18.083185;
            venue.Coordinate = coordinate;
            database.Add(venue);

            var venue2 = new Venue();
            venue2.VenueName = "Scandinavium";
            Coordinate coordinate2 = new Coordinate();
            coordinate2.Latitude = 57.699378;
            coordinate2.Longitude = 11.98765;
            venue2.Coordinate = coordinate2;
            database.Add(venue2);

            Game game = new Game();
            game.Title = "Hearthstone";
            database.Add(game);

            Game game2 = new Game();
            game2.Title = "Metroid Prime";
            database.Add(game2);

            var tournament = new Tournament();
            tournament.TournamentName = "Blizz Con";
            tournament.EventTime = DateTime.Now;
            tournament.Game = game;
            tournament.Venue = venue;
            database.Add(tournament);

            var tournament2 = new Tournament();
            tournament2.TournamentName = "Dreamhack";
            tournament2.EventTime = DateTime.Now;
            tournament2.Game = game2;
            tournament2.Venue = venue2;
            database.Add(tournament2);

            database.SaveChanges();
        }       
    }
}
