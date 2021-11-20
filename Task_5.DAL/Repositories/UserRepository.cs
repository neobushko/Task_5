using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.DAL.EF;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace Task_5.DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private HotelContext context;

        public UserRepository(HotelContext context)
        {
            this.context = context;            
        }

        public void Create(User item)
        {
            if (context.Users.Find(item.Id) != null)
                throw new ArgumentException();
            context.Users.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Users.Remove(Get(id));
        }

        public User Get(Guid id)
        {
            var user = context.Users.Single(c => c.Id == id);
            if (user == null)
                throw new ArgumentException();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User item)
        {
            var user = Get(item.Id);
            user.Id = item.Id;
            user.Name = item.Name ?? user.Name;
            user.PhoneNumber = item.PhoneNumber ?? user.PhoneNumber;
            user.Email = item.Email ?? user.Email;
        }
    }
}
