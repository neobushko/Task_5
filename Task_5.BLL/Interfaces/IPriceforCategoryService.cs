using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;

namespace Task_5.BLL.Interfaces
{
    public interface IPriceforCategoryService
    {
        IEnumerable<PriceforCategoryDTO> GetAll();
        PriceforCategoryDTO Get(Guid id);
        void Create(PriceforCategoryDTO item);
        void Update(PriceforCategoryDTO item);
        void Delete(Guid id);
        IEnumerable<PriceforCategoryDTO> GetAllByPartName(string Name);
    }
}
