using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.DAL.Enteties
{
    public class Record
    {
        public Record()
        {
            id = new Guid();
        }
        [Key]
        public Guid id { get;  set; }
        public Guid RoomId { get;  set; }
        [ForeignKey("RoomId")]
        public Room Room { get;  set; }
        public Guid UserId { get;  set; }
        [ForeignKey("UserId")]
        public User User { get;  set; }
        public DateTime CheckIn { get;  set; }
        public DateTime CheckOut { get;  set; }
    }
}
