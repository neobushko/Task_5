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
        ICategoryService categoryService;
        IMapper mapper;
        public CategoryController(ICategoryService categoryService)
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
        [HttpGet("GetById")]
        public CategoryModel Get(Guid id)
        {
            try
            {
                var category = mapper.Map<CategoryDTO, CategoryModel>(categoryService.Get(id));
                return category;
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new CategoryModel() { Name = "No such category", id = new Guid() };
            }

        }

        [HttpGet("GetByName")]
        public IEnumerable<CategoryModel> GetByName(string Name)
        {
            try
            {
                var category = mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryModel>>(categoryService.GetAllByPartName(Name));
                return category;
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new List<CategoryModel>();
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryModel item)
        {
            try
            {
                categoryService.Create(mapper.Map<CategoryModel, CategoryDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put([FromBody] CategoryModel item)
        {
            try
            {
                categoryService.Update(mapper.Map<CategoryModel, CategoryDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                categoryService.Delete(id);
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}