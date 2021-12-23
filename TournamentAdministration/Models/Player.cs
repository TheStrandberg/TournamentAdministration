using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GameHandle { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}
