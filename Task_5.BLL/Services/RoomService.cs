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
    public class RoomService : IService<RoomDTO>
    {
            
        private IUnitOfWork _unit;
        IMapper mapper;
        public RoomService(IUnitOfWork unit)
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Room, RoomDTO>().ReverseMap();
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
            }).CreateMapper();
            this._unit = unit;
        }
        public void Create(RoomDTO item)
        {
            _unit.Rooms.Create(mapper.Map<RoomDTO, Room>(item));
            _unit.Save();
        }

        public void Delete(Guid id)
        {
            _unit.Rooms.Delete(id);
            _unit.Save();
        }

        public RoomDTO Get(Guid id)
        {
            return mapper.Map<Room, RoomDTO>(_unit.Rooms.Get(id));
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(_unit.Rooms.GetAll());
        }

        public void Update(RoomDTO item)
        {
                _unit.Rooms.Update(mapper.Map<RoomDTO, Room>(item));
                _unit.Save();
        }
    }
}
