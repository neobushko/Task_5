using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.DAL.Enteties
{
    public class Room
    {
        public Room()
        {
            id = new Guid();
            
        }
        [Key]
        public Guid id { get;  set; }
        public int Number { get;  set; }
        public Guid CategoryId { get;  set; }
        [ForeignKey("CategoryId")]
        public Category Category { get;  set; } 
        public string Decription { get;  set; }

        public IEnumerable<Record> Records { get;  set; }
    }
}
