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
            player.HomeTown = "Los Angeles";
            database.Player.Add(player);

            var player2 = new Player();
            player2.FirstName = "Will";
            player2.LastName = "Smith";
            player2.GameHandle = "Woll Smoth";
            player2.CountryOfOrigin = "USA";
            player2.HomeTown = "Los Angeles";
            database.Player.Add(player2);

            var player3 = new Player();
            player3.FirstName = "Ernst";
            player3.LastName = "Kirchsteiger";
            player3.GameHandle = "The Destroyer";
            player3.CountryOfOrigin = "Sweden";
            player3.HomeTown = "Degerfors";
            database.Player.Add(player3);

            var player4 = new Player();
            player4.FirstName = "Henry";
            player4.LastName = "Cavill";
            player4.GameHandle = "The Witcher";
            player4.CountryOfOrigin = "England";
            player4.HomeTown = "London";
            database.Player.Add(player4);

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

            var venue3 = new Venue();
            venue3.VenueName = "Elmia";
            Coordinate coordinate3 = new Coordinate();
            coordinate3.Latitude = 57.788732;
            coordinate3.Longitude = 14.229022;
            venue3.Coordinate = coordinate3;
            database.Venue.Add(venue3);

            var venue4 = new Venue();
            venue4.VenueName = "Turning Torso";
            Coordinate coordinate4 = new Coordinate();
            coordinate4.Latitude = 55.613293;
            coordinate4.Longitude = 12.976356;
            venue4.Coordinate = coordinate4;
            database.Venue.Add(venue4);

            Game game = new Game();
            game.Title = "Hearthstone";
            database.Game.Add(game);

            Game game2 = new Game();
            game2.Title = "Dark Souls";
            database.Game.Add(game2);

            Game game3 = new Game();
            game3.Title = "Diablo II";
            database.Game.Add(game3);

            Game game4 = new Game();
            game4.Title = "World of Warcarft";
            database.Game.Add(game4);

            Game game5 = new Game();
            game5.Title = "League of Legends";
            database.Game.Add(game5);

            var tournament = new Tournament();
            tournament.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament.TournamentName = "Blizz Con Summer";
            tournament.EventTime = new DateTime(2022, 07, 01);
            tournament.Description = "Test your Hearthstone skills against some of the top players in the world";
            tournament.Game = game;
            tournament.Venue = venue;
            database.Tournament.Add(tournament);

            var tournament2 = new Tournament();
            tournament2.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament2.TournamentName = "Blizz Con Winter";
            tournament2.Description = "Try and succeed at beating Dark Souls without jumping out the window";
            tournament2.EventTime = new DateTime(2022, 10, 15);
            tournament2.Game = game2;
            tournament2.Venue = venue2;
            database.Tournament.Add(tournament2);

            var tournament3 = new Tournament();
            tournament3.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament3.TournamentName = "League of Legends, Dreamhack edition";
            tournament3.Description = "50 teams battle it out for the top prize of 100$";
            tournament3.EventTime = new DateTime(2022, 08, 12);
            tournament3.Game = game3;
            tournament3.Venue = venue3;
            database.Tournament.Add(tournament3);

            var tournament4 = new Tournament();
            tournament4.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament4.TournamentName = "Southern Swedens Gaming Extravaganza";
            tournament4.Description = "2v2 PvP Tournament. Winner Takes all!";
            tournament4.EventTime = new DateTime(2022, 05, 20);
            tournament4.Game = game4;
            tournament4.Venue = venue4;
            database.Tournament.Add(tournament4);

            var tournament5 = new Tournament();
            tournament5.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament5.TournamentName = "Diablo Resurrection Speed Run";
            tournament5.Description = "Come and join some of the most mediocre speedrunners we could find, trying to break the game we all love";
            tournament5.EventTime = new DateTime(2022, 03, 30);
            tournament5.Game = game5;
            tournament5.Venue = venue;
            database.Tournament.Add(tournament5);

            var tournament6 = new Tournament();
            tournament6.UserID = "018a734f-a04a-4886-a1c8-8eb99177b0b5";
            tournament6.TournamentName = "Hearthstone Champions League";
            tournament6.Description = "Battleground Tournament";
            tournament6.EventTime = new DateTime(2022, 12, 12);
            tournament6.Game = game;
            tournament6.Venue = venue2;
            database.Tournament.Add(tournament6);

            database.SaveChanges();
        }       
    }
}
