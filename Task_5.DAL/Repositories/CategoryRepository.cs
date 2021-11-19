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
    class CategoryRepository : IRepository<Category>
    {

        private HotelContext context;

        public CategoryRepository(HotelContext context)
        {
            this.context = context;
        }
        

        public void Create(Category item)
        {
            if (context.Categories.Find(item.id) != null)
                throw new ArgumentException($"there is already Room with such id: {item.id}");
            context.Categories.Add(item);
        }

        public void Delete(Guid id)
        {
            context.Categories.Remove(Get(id));
        }


        public Category Get(Guid id)
        {
            var category = context.Categories.Single(c => c.id == id);
            if (category == null)
                throw new ArgumentException();
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var temp =  context.Categories.ToList();
            return temp;
        }

        public void Update(Category item)
        {
            var category = Get(item.id);
            category.id = item.id;
            category.Name = item.Name ?? category.Name;
            category.Description = item.Description ?? category.Description;
        }
    }
}
