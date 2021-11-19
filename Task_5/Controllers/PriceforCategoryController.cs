using AutoMapper;
using Hotel_Api.Models;
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
        IPriceforCategoryService priceforService;
        IMapper mapper;
        public PriceforCategoryController(IPriceforCategoryService priceforService)
        {
            this.priceforService = priceforService;
            mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<PriceforCategoryDTO, PriceForCategoryModel>().ReverseMap();
                    cfg.CreateMap<CategoryDTO, CategoryModel>().ReverseMap();
                }).CreateMapper();
        }

        // GET: api/<PriceforCategoryController>
        [HttpGet]
        public IEnumerable<PriceForCategoryModel> Get()
        {
            return mapper.Map<IEnumerable<PriceforCategoryDTO>, IEnumerable<PriceForCategoryModel>>(priceforService.GetAll());
        }

        // GET api/<PriceforCategoryController>/5
        [HttpGet("{id}")]
        public PriceForCategoryModel Get(Guid id)
        {
            try
            {
                return mapper.Map<PriceforCategoryDTO, PriceForCategoryModel>(priceforService.Get(id)); ;
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new PriceForCategoryModel() {id = new Guid() };
            }
        }
        [HttpGet("Name")]
        public IEnumerable<PriceForCategoryModel> GetByName(string Name)
        {
            try
            {
                return mapper.Map<IEnumerable<PriceforCategoryDTO>, IEnumerable<PriceForCategoryModel>>(priceforService.GetAllByPartName(Name)); 
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new List<PriceForCategoryModel>();
            }
        }

        // POST api/<PriceforCategoryController>
        [HttpPost]
        public void Post([FromBody] PriceForCategoryModel item)
        {
            try
            {
                priceforService.Create(mapper.Map<PriceForCategoryModel, PriceforCategoryDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT api/<PriceforCategoryController>/5
        [HttpPut]
        public void Put( [FromBody] PriceForCategoryModel item)
        {
            try
            {
                priceforService.Update(mapper.Map<PriceForCategoryModel, PriceforCategoryDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // DELETE api/<PriceforCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                priceforService.Delete(id);
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
