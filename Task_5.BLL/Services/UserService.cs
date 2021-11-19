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
            _unit.Users.Create(mapper.Map<UserDTO, User>(item));
            _unit.Save();
        }

        public void Delete(Guid id)
        {
            _unit.Users.Delete(id);
            _unit.Save();
        }

        public UserDTO Get(Guid id)
        {
            return mapper.Map<User, UserDTO>(_unit.Users.Get(id));
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_unit.Users.GetAll());
        }

        public void Update(UserDTO item)
        {
            _unit.Users.Update(mapper.Map<UserDTO, User>(item));
            _unit.Save();
        }
    }
}
