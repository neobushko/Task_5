using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.DAL.Enteties
{
    public class User
    {
        public User()
        {
            id = Guid.NewGuid();
        }
        [Key]
        public Guid id { get;  set; }
        public string Name { get;  set; }
        public string ContactPhone { get;  set; }
        public string Email { get;  set; }

        public IEnumerable<Record> Records { get;  set; }
        public override bool Equals(object obj)
        {
            if(obj is User)
            {
                var thatObj = obj as User;
                return this.id == thatObj.id
                    && this.Name == thatObj.Name
                    && this.ContactPhone == thatObj.ContactPhone
                    && this.Email == thatObj.Email;
            }
            else return base.Equals(obj);
        }
    }
}
