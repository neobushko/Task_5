using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.DAL.Enteties
{
    public class Category
    {
        public Category()
        {
            id = Guid.NewGuid();
        }
        [Key]
        public Guid id { get;  set; }
        public string Decription { get;  set; }
        public IEnumerable<Room> Rooms { get;  set; }
        public IEnumerable<PriceforCategory> Prices { get; set; }
    }
}
