using AutoMapper;
using Hotel_Api.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class RecordController : ControllerBase
    {
        private IRecordService recordService;
        private IMapper mapper;
        public RecordController(IRecordService recordService)
        {
            this.recordService = recordService;
            mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<RecordDTO, RecordModel>().ReverseMap();
                    cfg.CreateMap<UserDTO, UserModel>().ReverseMap();
                    cfg.CreateMap<RoomDTO, RoomModel>().ReverseMap();
                    cfg.CreateMap<CategoryDTO, CategoryModel>().ReverseMap();
                }).CreateMapper();
        }

        // GET: api/<RecordController>
        [HttpGet]
        public IEnumerable<RecordModel> Get()
        {
            return mapper.Map<IEnumerable<RecordDTO>, IEnumerable<RecordModel>>(recordService.GetAll());
        }

        // GET api/<RecordController>/5
        [HttpGet("{id}")]
        public RecordModel Get(Guid id)
        {
            try
            {
                return mapper.Map<RecordDTO, RecordModel>(recordService.Get(id));
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new RecordModel() {id = new Guid() };
            }
        }

        // POST api/<RecordController>
        [HttpPost]
        public void Post([FromBody] RecordModel item)
        {
            try
            {
                recordService.Create(mapper.Map<RecordModel,RecordDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT api/<RecordController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put( [FromBody] RecordModel item)
        {
            try
            {
                recordService.Update(mapper.Map<RecordModel, RecordDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(Guid id)
        {
            try
            {
                recordService.Delete(id);
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
