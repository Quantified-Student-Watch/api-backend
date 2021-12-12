using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    interface IUserRepository
    {
        public Task<User> GetUserAsync(Guid id);
    }
    
    
    public class UserRepository: IUserRepository
    {
        private DbSet<User> _users;
        public UserRepository(IQsContext context)
        {
            _users = context.Users;
        }

        public Task<User> GetUserAsync(Guid id)
        {
            return _users.Where(x => x.Id == id).FirstAsync();
        }
    }
}