using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
    }
}
