using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;

namespace Task_5.BLL.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAll();
        RoomDTO Get(Guid id);
        void Create(RoomDTO item);
        void Update(RoomDTO item);
        void Delete(Guid id);
        IEnumerable<RoomDTO> GetByNumber(int Number);
    }
}
