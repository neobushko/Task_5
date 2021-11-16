using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.BLL.DTO
{
    public class RecordDTO
    {
        public Guid id { get; set; }
        public Guid RoomId { get; set; }
        public RoomDTO Room { get; set; }
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
