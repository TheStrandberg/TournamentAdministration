using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Venue
    {
        public int ID { get; set; }
        [Column("Venue"), MaxLength(100)]
        public string VenueName { get; set; }
        public Coordinate Coordinate { get; set; }
    }
    [Owned]
    public class Coordinate
    {
        [Column("CoordinateID")]
        public int ID { get; set; }
        [Required, Column("Latitude")]
        public double Latitude { get; set; }
        [Required, Column("Longitude")]
        public double Longitude { get; set; }
    }
}
