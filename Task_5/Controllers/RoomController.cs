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
    public class RoomController : ControllerBase
    {
        IService<RoomDTO> roomController;
        public RoomController(IService<RoomDTO> roomController)
        {
            this.roomController = roomController;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IEnumerable<RoomDTO> Get()
        {
            return roomController.GetAll();
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public RoomDTO Get(Guid id)
        {
            return roomController.Get(id);
        }

        // POST api/<RoomController>
        [HttpPost]
        public void Post([FromBody] RoomDTO item)
        {
            roomController.Create(item);
        }

        // PUT api/<RoomController>/5
        [HttpPut]
        public void Put( [FromBody] RoomDTO item)
        {
            roomController.Update(item);
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            roomController.Delete(id);
        }
    }
}
