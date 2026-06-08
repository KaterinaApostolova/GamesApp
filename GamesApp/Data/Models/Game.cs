using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Data.Models
{
    public class Game
    {
        [Key]
        public int gameId { get; set; }

        [Required]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
