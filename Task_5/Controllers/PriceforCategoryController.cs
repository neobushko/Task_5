using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceforCategoryController : ControllerBase
    {
        IService<PriceforCategoryDTO> priceforService;
        public PriceforCategoryController(IService<PriceforCategoryDTO> priceforService)
        {
            this.priceforService = priceforService;
        }

        // GET: api/<PriceforCategoryController>
        [HttpGet]
        public IEnumerable<PriceforCategoryDTO> Get()
        {
            return priceforService.GetAll();
        }

        // GET api/<PriceforCategoryController>/5
        [HttpGet("{id}")]
        public PriceforCategoryDTO Get(Guid id)
        {
            return priceforService.Get(id);
        }

        // POST api/<PriceforCategoryController>
        [HttpPost]
        public void Post([FromBody] PriceforCategoryDTO item)
        {
            priceforService.Create(item);
        }

        // PUT api/<PriceforCategoryController>/5
        [HttpPut]
        public void Put( [FromBody] PriceforCategoryDTO item)
        {
            priceforService.Update(item);
        }

        // DELETE api/<PriceforCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            priceforService.Delete(id);
        }
    }
}
