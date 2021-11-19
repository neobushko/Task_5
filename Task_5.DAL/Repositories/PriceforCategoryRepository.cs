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
    class PriceforCategoryRepository : IRepository<PriceforCategory>
    {
        private HotelContext _hotelContext;

        public PriceforCategoryRepository(HotelContext hotelContext)
        {
            this._hotelContext = hotelContext;
        }

        public void Create(PriceforCategory item)
        {
            if (_hotelContext.Prices.Find(item.id) != null)
                throw new ArgumentException();
            _hotelContext.Prices.Add(item);
        }

        public void Delete(Guid id)
        {
            _hotelContext.Prices.Remove(Get(id));
        }

        public PriceforCategory Get(Guid id)
        {
            var price = _hotelContext.Prices.Single(c => c.id == id);
            if (price == null)
                throw new ArgumentException();
            return price;
        }

        public IEnumerable<PriceforCategory> GetAll()
        {
            return _hotelContext.Prices.ToList();
        }

        public void Update(PriceforCategory item)
        {
            var price = Get(item.id);
            price.id = item.id;
            if (_hotelContext.Categories.Find(item.CategoryId) != null)
            {
                price.Category = item.Category;
                price.CategoryId = item.CategoryId;
            }
            price.StartDate = item.StartDate;
            price.EndDate = item.EndDate;
            price.Price = item.Price;
            price.Name = item.Name ?? price.Name;
        }
    }
}
