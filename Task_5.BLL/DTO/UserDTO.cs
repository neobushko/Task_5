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
        public override bool Equals(object obj)
        {
            if (obj is UserDTO)
            {
                var thatObj = obj as UserDTO;
                return this.id == thatObj.id
                    && this.Name == thatObj.Name
                    && this.ContactPhone == thatObj.ContactPhone
                    && this.Email == thatObj.Email;
            }
            else return base.Equals(obj);
        }
    }
}
