using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Data.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(20)]
        public string GenreGame { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
