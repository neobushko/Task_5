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
        public CategoryController(IService<CategoryDTO> categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            var temp = categoryService.GetAll();
            return temp;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(Guid id)
        {
            return categoryService.Get(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDTO item)
        {
            categoryService.Create(item);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put([FromBody] CategoryDTO item)
        {
            categoryService.Update(item);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            categoryService.Delete(id);
        }
    }
}
