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
        IService<RecordDTO> recordService;
        
        public RecordController(IService<RecordDTO> recordService)
        {
            this.recordService = recordService;
            
            
        }

        // GET: api/<RecordController>
        [HttpGet]
        public IEnumerable<RecordDTO> Get()
        {
            return recordService.GetAll();
        }

        // GET api/<RecordController>/5
        [HttpGet("{id}")]
        public RecordDTO Get(Guid id)
        {
            return recordService.Get(id);
        }

        // POST api/<RecordController>
        [HttpPost]
        public void Post([FromBody] RecordDTO item)
        {
                recordService.Create(item);
        }

        // PUT api/<RecordController>/5
        [HttpPut]
        public void Put( [FromBody] RecordDTO item)
        {
            recordService.Update(item);
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            recordService.Delete(id);
        }
    }
}
