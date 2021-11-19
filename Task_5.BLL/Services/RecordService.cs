﻿using AutoMapper;
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
         IBaseService BaseService;
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
            if (this.BaseService.IsFreeRoom(item.RoomId, item.CheckIn, item.CheckOut))
            {
                _unit.Records.Create(mapper.Map<RecordDTO, Record>(item));
                _unit.Save();
            }
            else throw new ArgumentException();
        }

        public void Delete(Guid id)
        {
            _unit.Records.Delete(id);
            _unit.Save();
        }

        public RecordDTO Get(Guid id)
        {
            return mapper.Map<Record, RecordDTO>(_unit.Records.Get(id));
        }

        public IEnumerable<RecordDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());
        }

        public void Update(RecordDTO item)
        {
            if (this.BaseService.IsFreeRoom(item.RoomId, item.CheckIn, item.CheckOut))
            {
                _unit.Records.Update(mapper.Map<RecordDTO, Record>(item));
                _unit.Save();
            }
            else throw new ArgumentException();
        }
    }
}
