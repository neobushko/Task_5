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
    class RecordRepository : IRepository<Record>
    {
        private HotelContext context;

        public RecordRepository(HotelContext context)
        {
            this.context = context;
        }

        public void Create(Record item)
        {
            if (context.Records.Find(item.id) != null)
                throw new ArgumentException();
            context.Records.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Records.Remove(Get(id));
        }

        public Record Get(Guid id)
        {
            var record = context.Records.Include(u => u.User).Include(u => u.Room).ThenInclude(b => b.Category).Single(c => c.id == id);
            if (record == null)
                throw new ArgumentException();
            return record;
        }

        public IEnumerable<Record> GetAll()
        {
            return context.Records.Include(u => u.User).Include(u => u.Room).ThenInclude(b => b.Category).ToList();
        }

        public void Update(Record item)
        {
            var record = context.Records.SingleOrDefault(s => s.id == item.id);
            if (record != null)
            {
                record.id = item.id;
                if (context.Rooms.Find(item.RoomId) != null)
                {
                    record.RoomId = item.RoomId;
                    record.Room = context.Rooms.Find(item.RoomId);
                }
                if (context.Users.Find(item.UserId) != null)
                {
                    record.UserId = item.UserId;
                    record.User = context.Users.Find(item.UserId);
                }
                record.CheckIn = item.CheckIn.Date;
                record.CheckOut = item.CheckOut.Date;
            }
        }
    }
}
