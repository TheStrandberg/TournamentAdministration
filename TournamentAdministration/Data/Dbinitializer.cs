using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace TournamentAdministration.Data
{
    public class Dbinitializer
    {
        public static async Task InitializeAsync(TournamentAdminContext database, UserManager<IdentityUser> userManager)
        {
            if (database.Tournament.Any())
            {
                return;
            }

            if (!database.Users.Any())
            {
                var testEmail = "test.user@example.com";
                var testUser = new IdentityUser(testEmail);
                testUser.Email = testEmail;
                testUser.EmailConfirmed = true;
                await userManager.CreateAsync(testUser, "Test123!");
            }

            var players = new List<Player>();

            var player = new Player();
            player.FirstName = "Brad";
            player.LastName = "Pitt";
            player.GameHandle = "The Pittmeister";
            player.CountryOfOrigin = "USA";
            player.HomeTown = "Los Angeles";
            players.Add(player);
            database.Player.Add(player);

            var player2 = new Player();
            player2.FirstName = "Will";
            player2.LastName = "Smith";
            player2.GameHandle = "Woll Smoth";
            player2.CountryOfOrigin = "USA";
            player2.HomeTown = "Los Angeles";
            players.Add(player2);
            database.Player.Add(player2);

            var player3 = new Player();
            player3.FirstName = "Ernst";
            player3.LastName = "Kirchsteiger";
            player3.GameHandle = "The Destroyer";
            player3.CountryOfOrigin = "Sweden";
            player3.HomeTown = "Degerfors";
            players.Add(player3);
            database.Player.Add(player3);

            var player4 = new Player();
            player4.FirstName = "Henry";
            player4.LastName = "Cavill";
            player4.GameHandle = "The Witcher";
            player4.CountryOfOrigin = "England";
            player4.HomeTown = "London";
            players.Add(player4);
            database.Player.Add(player4);

            var venue = new Venue();
            venue.VenueName = "Globen";
            Coordinate coordinate = new Coordinate();
            coordinate.Latitude = 59.293602;
            coordinate.Longitude = 18.083185;
            venue.Coordinate = coordinate;
            Address address = new Address();
            address.Street = "Globenområdet";
            address.Postcode = 12177;
            address.City = "Stockholm";
            address.Country = "Sweden";
            venue.Address = address;
            database.Venue.Add(venue);

            var venue2 = new Venue();
            venue2.VenueName = "Scandinavium";
            Coordinate coordinate2 = new Coordinate();
            coordinate2.Latitude = 57.699378;
            coordinate2.Longitude = 11.98765;
            venue2.Coordinate = coordinate2;
            Address address2 = new Address();
            address2.Street = "Valhallagatan 1";
            address2.Postcode = 41251;
            address2.City = "Gothenburg";
            address2.Country = "Sweden";
            venue2.Address = address2;
            database.Venue.Add(venue2);

            var venue3 = new Venue();
            venue3.VenueName = "Elmia";
            Coordinate coordinate3 = new Coordinate();
            coordinate3.Latitude = 57.788732;
            coordinate3.Longitude = 14.229022;
            venue3.Coordinate = coordinate3;
            Address address3 = new Address();
            address3.Street = "Elmiavägen 15";
            address3.Postcode = 55454;
            address3.City = "Jönköping";
            address3.Country = "Sweden";
            venue3.Address = address3;
            database.Venue.Add(venue3);

            var venue4 = new Venue();
            venue4.VenueName = "Turning Torso";
            Coordinate coordinate4 = new Coordinate();
            coordinate4.Latitude = 55.613293;
            coordinate4.Longitude = 12.976356;
            venue4.Coordinate = coordinate4;
            Address address4 = new Address();
            address4.Street = "Lilla Varvsgatan 14";
            address4.Postcode = 21115;
            address4.City = "Malmö";
            address4.Country = "Sweden";
            venue4.Address = address4;
            database.Venue.Add(venue4);

            Game game = new Game();
            game.Title = "Hearthstone";
            database.Game.Add(game);

            Game game2 = new Game();
            game2.Title = "Dark Souls";
            database.Game.Add(game2);

            Game game3 = new Game();
            game3.Title = "DOTA";
            database.Game.Add(game3);

            Game game4 = new Game();
            game4.Title = "World of Warcraft";
            database.Game.Add(game4);

            Game game5 = new Game();
            game5.Title = "League of Legends";
            database.Game.Add(game5);

            Game game6 = new Game();
            game6.Title = "Diablo II Resurrected";
            database.Game.Add(game6);

            var tournament = new Tournament();
            tournament.UserID = database.Users.First().Id;
            tournament.TournamentName = "Blizz Con Summer";
            tournament.EventTime = new DateTime(2022, 07, 01);
            tournament.Description = "Test your Hearthstone skills against some of the top players in the world";
            tournament.Game = game;
            tournament.Venue = venue;
            database.Tournament.Add(tournament);

            var tournament2 = new Tournament();
            tournament2.UserID = database.Users.First().Id;
            tournament2.TournamentName = "Blizz Con Winter";
            tournament2.Description = "Try and succeed at beating Dark Souls without jumping out the window";
            tournament2.EventTime = new DateTime(2022, 10, 15);
            tournament2.Game = game2;
            tournament2.Venue = venue2;
            database.Tournament.Add(tournament2);

            var tournament3 = new Tournament();
            tournament3.UserID = database.Users.First().Id;
            tournament3.TournamentName = "DOTA World Championship";
            tournament3.Description = "Teams from all over the world see which is best";
            tournament3.EventTime = new DateTime(2022, 08, 12);
            tournament3.Game = game3;
            tournament3.Venue = venue3;
            database.Tournament.Add(tournament3);

            var tournament4 = new Tournament();
            tournament4.UserID = database.Users.First().Id;
            tournament4.TournamentName = "Southern Swedens Gaming Extravaganza";
            tournament4.Description = "2v2 PvP Tournament. Winner Takes all!";
            tournament4.EventTime = new DateTime(2022, 05, 20);
            tournament4.Game = game4;
            tournament4.Venue = venue4;
            database.Tournament.Add(tournament4);

            var tournament5 = new Tournament();
            tournament5.UserID = database.Users.First().Id;
            tournament5.TournamentName = "Diablo Resurrection Speed Run";
            tournament5.Description = "Come and join some of the most mediocre speedrunners we could find, trying to break the game we all love";
            tournament5.EventTime = new DateTime(2022, 03, 30);
            tournament5.Game = game6;
            tournament5.Venue = venue;
            database.Tournament.Add(tournament5);

            var tournament6 = new Tournament();
            tournament6.UserID = database.Users.First().Id;
            tournament6.TournamentName = "Hearthstone Champions League";
            tournament6.Description = "Battleground Tournament";
            tournament6.EventTime = new DateTime(2022, 12, 12);
            tournament6.Game = game;
            tournament6.Venue = venue2;
            database.Tournament.Add(tournament6);

            var tournament7 = new Tournament();
            tournament7.UserID = database.Users.First().Id;
            tournament7.TournamentName = "League of Legends, Dreamhack edition";
            tournament7.Description = "50 teams battle it out for the top prize of 100$";
            tournament7.EventTime = new DateTime(2022, 08, 12);
            tournament7.Game = game5;
            tournament7.Venue = venue4;
            database.Tournament.Add(tournament7);

            await database.SaveChangesAsync();

            var tournaments = await database.Tournament.Include(t => t.Players).ToListAsync();
            var rand = new Random();
            foreach (var t in tournaments)
            {
                // Randomize list order to not always pick same players from list
                players = players.OrderBy(i => Guid.NewGuid()).ToList();
                for (int i = 0; i <= rand.Next(5); i++)
                {
                    t.Players.Add(players[i]);
                }
            }

            await database.SaveChangesAsync();
        }       
    }
}
