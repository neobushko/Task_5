using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.BLL.DTO
{
    public class PriceforCategoryDTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is PriceforCategoryDTO)
            {
                var thatObject = obj as PriceforCategoryDTO;
                return this.id == thatObject.id
                    && this.CategoryId == thatObject.CategoryId
                    && this.Price == thatObject.Price
                    && this.StartDate == thatObject.StartDate
                    && this.EndDate == thatObject.EndDate
                    && this.Name == thatObject.Name;
            }
            else return base.Equals(obj);
        }
    }
}
