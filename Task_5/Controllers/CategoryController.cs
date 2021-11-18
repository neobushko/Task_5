using AutoMapper;
using Hotel_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Task_5.BLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IService<CategoryDTO> categoryService;
        IMapper mapper;
        public CategoryController(IService<CategoryDTO> categoryService)
        {
            this.categoryService = categoryService;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryModel>().ReverseMap()).CreateMapper();
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            return mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryModel>>(categoryService.GetAll());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{item}")]
        public CategoryModel Get(Guid item)
        {
            try
            {
                var category = mapper.Map<CategoryDTO, CategoryModel>(categoryService.Get(item));
                return category;
            }
            catch
            {
                return new CategoryModel() { Name = "No such category" };
            }
            
        }

/*        [HttpGet("{item}")]
        public CategoryModel Get(string item)
        {
            return mapper.Map<CategoryDTO, CategoryModel>(categoryService.Get(item));
        }*/

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryModel item)
        {
            categoryService.Create(mapper.Map<CategoryModel,CategoryDTO>(item));
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put([FromBody] CategoryModel item)
        {
            categoryService.Update(mapper.Map<CategoryModel, CategoryDTO>(item));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            categoryService.Delete(id);
        }
    }
}
