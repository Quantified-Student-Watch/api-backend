using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Data.Repository
{
    interface IUserRepository
    {
        public Task<User> GetUserAsync(Guid id);

        public User CreatUser(string name, string email);
    }
    
    
    public class UserRepository: IUserRepository
    {
        private QsContext _context;
        public UserRepository(QsContext context)
        {
            _context = context;
        }

        public Task<User> GetUserAsync(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstAsync();
        }

        public User CreatUser(string name, string email)
        {
            EntityEntry<User> user =  _context.Add(new User()
            {
                Name = name,
                Email = email
            });

            _context.SaveChanges();

            return user.Entity;
        }
    }
}