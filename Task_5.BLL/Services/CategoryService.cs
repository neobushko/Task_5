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
    public class CategoryService : IService<CategoryDTO>
    {
        private IUnitOfWork _unit;
        IMapper mapper; 

        public CategoryService(IUnitOfWork unit)
        {
            mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<Category, CategoryDTO>().ReverseMap()
                ).CreateMapper();

            this._unit = unit;
        }
        public void Create(CategoryDTO item)
        {
            if (_unit.Categories.Get(item.id) is not null)
                throw new ArgumentException($"there is already such category with id: {item.id.ToString()}");
            _unit.Categories.Create(mapper.Map<CategoryDTO,Category>(item));
            _unit.Save();
        }

        public void Delete(Guid id)
        {
            _unit.Categories.Delete(id);
            _unit.Save();
        }

        public CategoryDTO Get(Guid id)
        {
            var category = mapper.Map<Category, CategoryDTO>(_unit.Categories.Get(id));
            if (category == null)
                throw new ArgumentException($"there is no category with current id ({id})");
            return category;


        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_unit.Categories.GetAll());
            
        }

        public void Update(CategoryDTO item)
        {
            _unit.Categories.Update(mapper.Map<CategoryDTO, Category>(item));
            _unit.Save();
        }
    }
}
