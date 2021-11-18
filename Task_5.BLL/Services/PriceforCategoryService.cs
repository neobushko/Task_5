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
    public class PriceforCategoryService : IService<PriceforCategoryDTO>
    {
        private IUnitOfWork _unit;
        IMapper mapper;

        public PriceforCategoryService(IUnitOfWork unit)
        {
            mapper = new MapperConfiguration(
                 cfg => {
                     cfg.CreateMap<PriceforCategory, PriceforCategoryDTO>().ReverseMap();
                     cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                 }
                ).CreateMapper();

            this._unit = unit;
        }
        public void Create(PriceforCategoryDTO item)
        {
            if (!IsExistsId(item.id))
            {
                _unit.PriceforCategories.Create(mapper.Map<PriceforCategoryDTO, PriceforCategory>(item));
                _unit.Save();
            }
        }

        public void Delete(Guid id)
        {
            if (IsExistsId(id))
            {
                _unit.PriceforCategories.Delete(id);
                _unit.Save();
            }
        }

        public PriceforCategoryDTO Get(Guid id)
        {
            if (IsExistsId(id))
            {
                return mapper.Map<PriceforCategory, PriceforCategoryDTO>(_unit.PriceforCategories.Get(id));
            }
            else throw new ArgumentException("there is no such id");
        }

        public IEnumerable<PriceforCategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PriceforCategory>, IEnumerable<PriceforCategoryDTO>>(_unit.PriceforCategories.GetAll());
        }

        public bool IsExistsId(Guid id)
        {
            bool IsExist = false;
            var price = mapper.Map<IEnumerable<PriceforCategory>, IEnumerable<PriceforCategoryDTO>>(_unit.PriceforCategories.GetAll());
            if (price.Any(c => c.id == id))
                IsExist = true;
            return IsExist;
        }

        public void Update(PriceforCategoryDTO item)
        {
            if (IsExistsId(item.id))
            {
                _unit.PriceforCategories.Update(mapper.Map<PriceforCategoryDTO, PriceforCategory>(item));
                _unit.Save();
            }
        }
    }
}
