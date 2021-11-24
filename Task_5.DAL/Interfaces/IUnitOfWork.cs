using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.DAL.Enteties;

namespace Task_5.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Room> Rooms { get; }
        IRepository<User> Users { get; }
        IRepository<Record> Records { get; }
        IRepository<PriceforCategory> PriceforCategories { get; }

        void Save();
    }
}
