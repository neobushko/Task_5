using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.DAL.Enteties;

namespace TestProject1
{
    public class FakeDataForApi
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<RoomDTO> Rooms { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
        public IEnumerable<PriceforCategoryDTO> Prices { get; set; }
        public IEnumerable<RecordDTO> Records { get; set; }
        public FakeDataForApi()
        {
            Categories = CategoryInit();
            Rooms = RoomInit();
            Users = UserInit();
            Prices = PriceInit();
            Records = RecordsInit();
        }
        private IEnumerable<CategoryDTO> CategoryInit()
        {
            var categories = new List<CategoryDTO>()
            {
                new CategoryDTO()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Description = " (1) Some description"
                },
                new CategoryDTO()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Description = " (2) Another description"
                },
                new CategoryDTO()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Description = " (3) Very another description"
                }
            };
            return categories;
        }

        private IEnumerable<RoomDTO> RoomInit()
        {
            var rooms = new List<RoomDTO>()
            {
                new RoomDTO()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Number = 1,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (1) room"
                },
                new RoomDTO()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Number = 2,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (2) room"
                },
                new RoomDTO()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Number = 3,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Decription = " (3) room"
                },
                new RoomDTO()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    Number = 4,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Decription = " (4) room"
                }
            };
            return rooms;
        }
        private IEnumerable<UserDTO> UserInit()
        {
            var users = new List<UserDTO>()
            {
                new UserDTO()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Name = "Artem Arshava",
                    ContactPhone = "098158888",
                    Email = "artem.arshava@nure.ua"
                },
                new UserDTO()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Name = "Anton Antonov",
                    ContactPhone = "0970461479",
                    Email = "anton.antonov@nure.ua"
                },
                new UserDTO()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Name = "Daniel Obushko",
                    ContactPhone = "0684387777",
                    Email = "Daniel@gmail.com"
                }

            };
            return users;

        }
        private IEnumerable<PriceforCategoryDTO> PriceInit()
        {
            var prices = new List<PriceforCategoryDTO>()
            {
                new PriceforCategoryDTO()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Price = 100m
                },
                new PriceforCategoryDTO()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Price = 150m
                },
                new PriceforCategoryDTO()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Price = 300m
                },
                new PriceforCategoryDTO()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    Price = 125m
                }
            };

            return prices;
        }


        private IEnumerable<RecordDTO> RecordsInit()
        {
            //("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")
            var records = new List<RecordDTO>()
            {
                new RecordDTO()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CheckIn = new DateTime(2021,11, 10),
                    CheckOut = new DateTime(2021,11,20),
                },
                new RecordDTO()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    CheckIn = new DateTime(2021,11,1),
                    CheckOut = new DateTime(2021,11,10),
                },
                new RecordDTO()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    CheckIn = new DateTime(2021,11,20),
                    CheckOut = new DateTime(2021,12,1),
                }
            };

            return records;
        }



    }
}
