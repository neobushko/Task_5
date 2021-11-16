using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.BLL.DTO
{
    public class RoomDTO
    {
        public Guid id { get; set; }
        public int Number { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public string Decription { get; set; }
    }
}
