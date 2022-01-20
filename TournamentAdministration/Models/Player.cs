using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TournamentAdmin.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string GameHandle { get; set; }
        [Required, MaxLength(50)]
        public string CountryOfOrigin { get; set; }
        [Required, MaxLength(85)]
        public string HomeTown { get; set; }
        [JsonIgnore] // This is to avoid circular reference in JSON in API calls.
        public List<Tournament> Tournaments { get; set; }
    }
}
