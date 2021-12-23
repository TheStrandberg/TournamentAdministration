using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Venue
    {
        public int ID { get; set; }
        [Column("Venue")]
        public string VenueName { get; set; }
        public Coordinate Coordinate { get; set; }
    }
    [Owned]
    public class Coordinate
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
