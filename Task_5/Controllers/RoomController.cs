using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Hotel_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IService<RoomDTO> roomController;
        IMapper mapper;
        public RoomController(IService<RoomDTO> roomController)
        {
            this.roomController = roomController;
            mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<RoomDTO, RoomModel>().ReverseMap();
                    cfg.CreateMap<CategoryDTO, CategoryModel>().ReverseMap();
                }).CreateMapper();
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IEnumerable<RoomModel> Get()
        {
            return mapper.Map<IEnumerable<RoomDTO>, IEnumerable<RoomModel>>(roomController.GetAll());
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public RoomModel Get(Guid id)
        {
            try
            {
                var room = mapper.Map<RoomDTO, RoomModel>(roomController.Get(id));
                return room;
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new RoomModel() { id = new Guid()};
            }
        }

        // POST api/<RoomController>
        [HttpPost]
        public void Post([FromBody] RoomModel item)
        {
            try
            {
                roomController.Create(mapper.Map<RoomModel, RoomDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        // PUT api/<RoomController>/5
        [HttpPut]
        public void Put( [FromBody] RoomModel item)
        {
            try
            {
                roomController.Update(mapper.Map<RoomModel, RoomDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
            }
}

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                roomController.Delete(id);
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
