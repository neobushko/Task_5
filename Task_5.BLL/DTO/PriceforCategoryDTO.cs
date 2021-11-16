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
        public Guid CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
