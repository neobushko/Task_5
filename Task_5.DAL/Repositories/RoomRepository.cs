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
            if (context.Rooms.Find(item.id) != null)
                throw new ArgumentException($"there is already Room with such id: {item.id}");
            if (context.Rooms.Find(item.CategoryId) == null)
                throw new ArgumentException($"there is no Category with id: {item.CategoryId}");
            context.Rooms.Add(item);
        }

        public void Delete(Guid id)
        {
            if (context.Rooms.Find(id) != null)
                throw new ArgumentException($"there is already Room with such id: {id}");
            context.Rooms.Remove(Get(id));
        }

        public Room Get(Guid id)
        {
            var room = context.Rooms.Include(u => u.Category).Single(c => c.id == id);
            if (room == null)
                throw new ArgumentException();
            return room;
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
            if(context.Categories.Find(item.CategoryId) != null)
            {
                room.CategoryId = item.CategoryId;
                room.Category = context.Categories.Find(item.CategoryId);
            }
            room.Description = item.Description ?? room.Description;
        }
    }
}
