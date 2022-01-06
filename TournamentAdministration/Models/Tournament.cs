using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string TournamentName { get; set; }
        [Required, MaxLength(150)]
        public string Description { get; set; }
        [Required, Column(TypeName="date")]
        public DateTime EventTime { get; set; }
        public List<Player> Players { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public Venue Venue {get;set;}
        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
