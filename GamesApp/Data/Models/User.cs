using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string FullName { get; set; }

        [Range(10,80)]
        public int Age { get; set; }

        [Required,StringLength(20,MinimumLength =3)]
        public string Username { get; set; }

        [Required,StringLength(20,MinimumLength=6)]
        public string Password { get; set;}

        [Required,StringLength(20)]
        public string Email { get; set; }

        public List<Game> Games { get; set; } = new List<Game>();
    }
}
