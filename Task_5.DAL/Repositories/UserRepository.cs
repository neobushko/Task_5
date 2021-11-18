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
            context.Users.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Users.Remove(Get(id));
        }

        public User Get(Guid id)
        {
            return context.Users.Single(c => c.id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User item)
        {
            var user = Get(item.id);
            user.id = item.id;
            user.Name = item.Name;
            user.ContactPhone = item.ContactPhone;
            user.Email = item.Email;
        }
    }
}
