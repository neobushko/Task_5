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
    public class RecordService : IService<RecordDTO>
    {
        private IUnitOfWork _unit;
        IMapper mapper;
        private IBaseService BaseService;
        public RecordService(IUnitOfWork unit, IBaseService BaseService)
        {
            mapper = new MapperConfiguration(
    cfg => {
        cfg.CreateMap<Record, RecordDTO>().ReverseMap();
        cfg.CreateMap<Room, RoomDTO>().ReverseMap();
        cfg.CreateMap<User, UserDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    ).CreateMapper();

            this._unit = unit;
            this.BaseService = BaseService;
        }
        public void Create(RecordDTO item)
        {
            if(this.BaseService.IsFreeRoom(item.RoomId, item.CheckIn, item.CheckOut) && !IsExistsId(item.id))
            {
                _unit.Records.Create(mapper.Map<RecordDTO, Record>(item));
                _unit.Save();
            }
        }

        public void Delete(Guid id)
        {
            if (IsExistsId(id))
            {
                _unit.Records.Delete(id);
                _unit.Save();
            }
        }

        public RecordDTO Get(Guid id)
        {
            if (IsExistsId(id))
            {
                return mapper.Map<Record, RecordDTO>(_unit.Records.Get(id));
            }
            else throw new ArgumentException();
        }

        public IEnumerable<RecordDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());
        }

        public bool IsExistsId(Guid id)
        {
            bool IsExist = false;
            var price = mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());
            if (price.Any(c => c.id == id))
                IsExist = true;
            return IsExist;
        }

        public void Update(RecordDTO item)
        {
            if (IsExistsId(item.id))
            {
                _unit.Records.Update(mapper.Map<RecordDTO, Record>(item));
                _unit.Save();
            }
        }
    }
}
