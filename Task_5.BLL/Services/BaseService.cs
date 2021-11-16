using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace Task_5.BLL.Services
{
    public class BaseService : IBaseService
    {
        private IUnitOfWork _unit;
        IMapper mapper;
        
        public BaseService(IUnitOfWork _unit)
        {
            this._unit = _unit;

            mapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Record, RecordDTO>().ReverseMap();
                cfg.CreateMap<Room, RoomDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            }).CreateMapper();
        }

        public IEnumerable<RoomDTO> FreeRoomsForDate(DateTime checkIn, DateTime checkOut)
        {
            IEnumerable<RoomDTO> rooms = mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(_unit.Rooms.GetAll());
            List<RoomDTO> freeRooms = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                if (IsFreeRoom(room.id, checkIn, checkOut))
                    freeRooms.Add(room);
            }
            return freeRooms;
        }


        public bool IsFreeRoom(Guid roomId, DateTime checkIn, DateTime checkOut)
        {
            IEnumerable<RecordDTO> free;
            IEnumerable<RecordDTO> records = mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());

            free = records.Where(c => c.RoomId == roomId &&
            (!(checkOut < c.CheckIn) ||
            checkOut <= c.CheckOut ||
            checkIn <= c.CheckOut));

            return !free.Any();
        }

    }
}
