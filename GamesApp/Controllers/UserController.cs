using GamesApp.Data;
using GamesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApp.Controllers
{
    public class UserController
    {
        private MyContext context;
        public UserController(MyContext _context)
        {
            context = _context;
        }
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }
        public User GetById(int id)
        {
            return context.Users.Find(id);
        }
        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void Update(User newUser)
        {
            var currentUser = context.Users.Find(newUser.Id);
            if(currentUser!=null)
            {
                context.Entry(currentUser).CurrentValues.SetValues(newUser);
            }
        }
        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            if(user!=null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
