using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Inconsistent namespace because we copied the model classes from a previous attempt at this project
namespace TournamentAdmin.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
    }
}
