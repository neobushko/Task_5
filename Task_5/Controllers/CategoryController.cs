using AutoMapper;
using Hotel_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        private ICategoryService categoryService;
        private IMapper mapper;
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
                Log.Information("User caused Get_Category");
                var category = mapper.Map<CategoryDTO, CategoryModel>(categoryService.Get(id));
                Log.Information("User get category successfully");
                return category;
            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 404;
                Log.Warning("Program didn't find Category {0}", id, e);
                return new CategoryModel() { Name = "No such category", id = new Guid() };
            }

        }

        [HttpGet("GetByName")]
        public IEnumerable<CategoryModel> GetByName(string Name)
        {
            try
            {
                Log.Information("User caused GetByName_Category");
                var category = mapper.Map<IEnumerable<CategoryDTO>, IEnumerable<CategoryModel>>(categoryService.GetAllByPartName(Name));
                Log.Information("Sucess with GetByName Category");
                return category;
            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 404;
                Log.Warning("Program didn't find Category {0}", Name, e);
                return new List<CategoryModel>();
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] CategoryModel item)
        {
            try
            {
                Log.Information("User caused Post Category");
                categoryService.Create(mapper.Map<CategoryModel, CategoryDTO>(item));
                Log.Information("Success with Post Category");
            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 400;
                Log.Warning("Program can't create such Category", e);
            }
        }

        // PUT api/<CategoryController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void Put([FromBody] CategoryModel item)
        {
            try
            {
                Log.Information("User caused Put Category");
                categoryService.Update(mapper.Map<CategoryModel, CategoryDTO>(item));
                Log.Information("Success with Post Category");
            }
            catch (Exception e)
            {
                Log.Warning("Program can't update such Category", e);
                HttpContext.Response.StatusCode = 400;
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                Log.Information("User caused Delete Category");
                categoryService.Delete(id);
                Log.Information("Success with Delete Category");
            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 400;
                Log.Warning("Program can't delete such Category", id, e);
            }
        }
    }
}