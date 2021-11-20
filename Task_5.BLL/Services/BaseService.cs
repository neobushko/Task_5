using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace Task_5.BLL.Services
{
    public class BaseService : IBaseService
    {
        private IUnitOfWork _unit;
        IMapper mapper;
        
        public BaseService(IUnitOfWork _unit)
        {
            this._unit = _unit;

            mapper = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Record, RecordDTO>().ReverseMap();
                cfg.CreateMap<Room, RoomDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<PriceforCategory, PriceforCategoryDTO>().ReverseMap();
            }).CreateMapper();
        }

        public BenefitPeriod BenefitForPeriod(DateTime startPeriod, DateTime endPeriod)
        {

            if (startPeriod > endPeriod)
                throw new ArgumentException("start time can't be after end time");
            //получаем все необходимые данные из бд
            var records = mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());
            var prices = mapper.Map<IEnumerable<PriceforCategory>, IEnumerable<PriceforCategoryDTO>>(_unit.PriceforCategories.GetAll());
            decimal benefitMain = default(Decimal);
            decimal benefitRecord = default(Decimal);
            foreach (var record in records)
            {
                //point of start into our periodStart
                IEnumerable<PriceforCategoryDTO> pricesRecord;
                try
                {
                    bool s;
                    foreach(var p in prices)
                    {
                        s = p.CategoryId == record.Room.CategoryId && this.InInterval(record.CheckIn, record.CheckOut, p.StartDate, p.EndDate);

                    }
                    pricesRecord = prices.Where(p => p.CategoryId == record.Room.CategoryId && this.InInterval(record.CheckIn, record.CheckOut, p.StartDate, p.EndDate));
                }
                catch
                {
                    throw new ArgumentException();
                }
                //start benefit to 0.0!
                benefitRecord = default(Decimal);
                foreach(var price in pricesRecord)
                {

                    benefitRecord += (price.Price * (LowestData(record.CheckOut, price.EndDate, endPeriod) - BiggestData(record.CheckIn, price.StartDate, startPeriod)).Days);
                }
                benefitMain += benefitRecord;
            }
            return new BenefitPeriod() { Benefit = benefitMain, Records = records, StartPeriod = startPeriod, EndPeriod = endPeriod };
        }
        public DateTime LowestData(DateTime first, DateTime second, DateTime third)
        {
            DateTime lowest = new DateTime();
            if (first <= second && first <= third)
                lowest = first;
            else if (second <= first && second <= third)
                lowest = second;
            else 
                lowest = third;
            return lowest;
        }
        public DateTime BiggestData(DateTime first, DateTime second, DateTime third)
        {
            DateTime biggest = new DateTime();
            if (first >= second && first >= third)
                biggest = first;
            else if (second >= first && second >= third)
                biggest = second;
            else
                biggest = third;
            return biggest;
        }
        public IEnumerable<RoomDTO> FreeRoomsForDate(DateTime checkIn, DateTime checkOut)
        {
            IEnumerable<RoomDTO> rooms = mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(_unit.Rooms.GetAll());
            List<RoomDTO> freeRooms = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                if (IsFreeRoom(room.id, checkIn, checkOut))
                    freeRooms.Add(room);
            }
            return freeRooms;
        }


        public bool IsFreeRoom(Guid roomId, DateTime checkIn, DateTime checkOut)
        {
            IEnumerable<RecordDTO> free;
            IEnumerable<RecordDTO> records = mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(_unit.Records.GetAll());

            free = records.Where(c => c.RoomId == roomId && InInterval(c.CheckIn, c.CheckOut, checkIn, checkOut));
            return !free.Any();
        }
        private bool InInterval(DateTime mainStart, DateTime mainEnd, DateTime outerStart, DateTime outerEnd)
        {
            bool inInterval = false;
            if (   (outerEnd >= mainStart && outerEnd <= mainEnd)
                || (outerStart >= mainStart && outerStart <= mainEnd)
                || (outerStart <= mainStart && outerEnd >= mainEnd))
                inInterval = true;
            return inInterval;
        }

    }
}
