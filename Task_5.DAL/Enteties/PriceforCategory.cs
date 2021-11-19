using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.DAL.Enteties
{
    public class PriceforCategory
    {
        public PriceforCategory()
        {
            id = Guid.NewGuid();
        }
        private decimal _price;
        [Key]
        public Guid id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is PriceforCategory)
            {
                var thatObject = obj as PriceforCategory;
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
