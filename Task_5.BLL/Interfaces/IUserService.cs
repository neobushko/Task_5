using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;

namespace Task_5.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(Guid id);
        void Create(UserDTO item);
        void Update(UserDTO item);
        void Delete(Guid id);
        IEnumerable<UserDTO> GetByPartName(string part);
    }
}
