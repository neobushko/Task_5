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
    public class UserService : IService<UserDTO>
    {
        private IUnitOfWork _unit;
        IMapper mapper;
        public UserService(IUnitOfWork unit)
        {
            this._unit = unit;
            mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<User, UserDTO>().ReverseMap()  )
                .CreateMapper();
        }
        public void Create(UserDTO item)
        {
            if (!IsExistsId(item.id))
            {
                _unit.Users.Create(mapper.Map<UserDTO, User>(item));
                _unit.Save();
            }
        }

        public void Delete(Guid id)
        {
            if (IsExistsId(id))
            {
                _unit.Users.Delete(id);
                _unit.Save();
            }
        }

        public UserDTO Get(Guid id)
        {
            if (IsExistsId(id))
            {
                return mapper.Map<User, UserDTO>(_unit.Users.Get(id));
            }
            else throw new ArgumentException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_unit.Users.GetAll());
        }

        public void Update(UserDTO item)
        {
            if (IsExistsId(item.id))
            {
                _unit.Users.Update(mapper.Map<UserDTO, User>(item));
                _unit.Save();
            }
        }
        public bool IsExistsId(Guid id)
        {
            bool IsExist = false;
            var price = mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_unit.Users.GetAll());
            if (price.Any(c => c.id == id))
                IsExist = true;
            return IsExist;
        }
    }
}
