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
        [Required, Column("Venue"), MaxLength(100)]
        public string VenueName { get; set; }
        [Required]
        public Coordinate Coordinate { get; set; }
        [Required]
        public Address Address { get; set; }
    }

    [Owned]
    public class Coordinate
    {
        [Column("Latitude")]
        public double Latitude { get; set; }
        [Column("Longitude")]
        public double Longitude { get; set; }
    }

    [Owned]
    public class Address
    {
        [Required, MaxLength(50), Column("Street")]
        public string Street { get; set; }
        [Column("Postcode")]
        public int Postcode { get; set; }
        [Required, MaxLength(100), Column("City")]
        public string City { get; set; }
        [Required, MaxLength(100), Column("Country")]
        public string Country { get; set; }
    }
}
