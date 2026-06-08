using GamesApp.Data;
using GamesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Controllers
{
    public class GenreController
    {
        private MyContext context;
        public GenreController(MyContext _context)
        {
            context = _context;
        }
        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }
        public Genre GetById(int id)
        {
            return context.Genres.Find(id);
        }
        public void Add(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
        }
        public void Update(Genre newGenre)
        {
            var currentGenre = context.Users.Find(newGenre.GenreId);
            if (currentGenre != null)
            {
                context.Entry(currentGenre).CurrentValues.SetValues(newGenre);
            }
        }
        public void Delete(int id)
        {
            var genre = context.Genres.Find(id);
            if (genre != null)
            {
                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }
    }
}
