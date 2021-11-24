using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Hotel_Api.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;
        public UserController(IUserService userService)
        {
            this.userService = userService;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>().ReverseMap()).CreateMapper();
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(userService.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserModel Get(Guid id)
        {
            try
            {
                return mapper.Map<UserDTO, UserModel>(userService.Get(id)); ;
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
                return new UserModel() {id = new Guid() };
            }
        }
        [HttpGet("GetByPartName")]
        public IEnumerable<UserModel> GetByPartName(string part)
        {
            return mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(userService.GetByPartName(part));
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] UserModel item)
        {
            try
            {
                userService.Create(mapper.Map<UserModel,UserDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put( [FromBody] UserModel item)
        {
            try
            {
                userService.Update(mapper.Map<UserModel, UserDTO>(item));
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(Guid id)
        {
            try
            {
                userService.Delete(id);
            }
            catch
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
