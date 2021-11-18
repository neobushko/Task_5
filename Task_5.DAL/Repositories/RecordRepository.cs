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
            context.Records.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Records.Remove(Get(id));
        }

        public Record Get(Guid id)
        {
            return context.Records.Include(u => u.User).Include(u => u.Room).ThenInclude(b => b.Category).Single(c => c.id == id);
        }

        public IEnumerable<Record> GetAll()
        {
            return context.Records.Include(u => u.User).Include(u => u.Room).ThenInclude(b => b.Category).ToList();
        }

        public void Update(Record item)
        {
            var record = Get(item.id);
            record.id = item.id;
            record.RoomId = item.RoomId;
            record.Room = item.Room;
            record.UserId = item.UserId;
            record.User = item.User;
            record.CheckIn = item.CheckIn;
            record.CheckOut = item.CheckOut;
        }
    }
}
