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
    class RoomRepository : IRepository<Room>
    {
        private HotelContext context;

        public RoomRepository(HotelContext context)
        {
            this.context = context;
        }

        public void Create(Room item)
        {
            context.Rooms.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Rooms.Remove(Get(id));
        }

        public Room Get(Guid id)
        {
            return context.Rooms.Include(u => u.Category).Single(c => c.id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.Include(u => u.Category).ToList();
        }

        public void Update(Room item)
        {
            var room = Get(item.id);
            room.id = item.id;
            room.Number = item.Number;
            room.CategoryId = item.CategoryId;
            room.Category = item.Category;
            room.Decription = item.Decription;
        }
    }
}
