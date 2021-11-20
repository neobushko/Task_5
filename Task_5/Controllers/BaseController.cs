using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        
        IBaseService baseService;

        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        [HttpGet("Get")]
        public BenefitPeriod Get(DateTime startPeriod, DateTime endPeriod)
        {
            return baseService.BenefitForPeriod(startPeriod, endPeriod);
        }

        //[HttpGet("IsFreeRoom")]
        //public bool IsFreeRoom(RecordDTO item)
        //{
        //    return baseService.IsFreeRoom(item.RoomId, item.CheckIn, item.CheckOut);
        //}

        [HttpGet("FreeRoomsForDate")]
        public IEnumerable<RoomDTO> FreeRoomsForDate(DateTime checkIn, DateTime checkOut)
        {
            return baseService.FreeRoomsForDate(checkIn, checkOut);
        }
    }
}
