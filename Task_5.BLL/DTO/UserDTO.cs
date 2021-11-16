using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.BLL.DTO
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
    }
}
