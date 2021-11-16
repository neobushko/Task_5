using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;

namespace Task_5.Controllers
{
    public class BaseController : Controller
    {
        IBaseService baseService;
        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        

        public bool IsFreeRoom(RecordDTO item)
        {
            return baseService.IsFreeRoom(item.RoomId, item.CheckIn, item.CheckOut);
        }

        public IEnumerable<RoomDTO> FreeRoomsForDate(DateTime checkIn, DateTime checkOut)
        {
            return baseService.FreeRoomsForDate(checkIn, checkOut);
        }
    }
}
