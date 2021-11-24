using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;

namespace Task_5.BLL.Interfaces
{
    public interface ICheckRooms
    {
        public bool IsFreeRoom(Guid roomId, DateTime checkIn, DateTime checkOut);
        public IEnumerable<RoomDTO> FreeRoomsForDate(DateTime checkIn, DateTime checkOut);
    }
}
