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
                    Decription = " (1) Some description"
                },
                new CategoryDTO()
                {
                    Decription = " (2) Another description"
                },
                new CategoryDTO()
                {
                    Decription = " (3) Very another description"
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
                    Number = 1,
                    Decription = " (1) room"
                },
                new RoomDTO()
                {
                    Number = 2,
                    Decription = " (2) room"
                },
                new RoomDTO()
                {
                    Number = 3,
                    Decription = " (3) room"
                },
                new RoomDTO()
                {
                    Number = 4,
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
                    Name = "Artem Arshava",
                    ContactPhone = "098158888",
                    Email = "artem.arshava@nure.ua"
                },
                new UserDTO()
                {
                    Name = "Anton Antonov",
                    ContactPhone = "0970461479",
                    Email = "anton.antonov@nure.ua"
                },
                new UserDTO()
                {
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
                    Price = 100m
                },
                new PriceforCategoryDTO()
                {
                    Price = 150m
                },
                new PriceforCategoryDTO()
                {
                    Price = 300m
                },
                new PriceforCategoryDTO()
                {
                    Price = 125m
                }
            };

            return prices;
        }


        private IEnumerable<RecordDTO> RecordsInit()
        {
            var records = new List<RecordDTO>()
            {
                new RecordDTO()
                {
                    CheckIn = new DateTime(2021,11, 10),
                    CheckOut = new DateTime(2021,11,20),
                },
                new RecordDTO()
                {
                    CheckIn = new DateTime(2021,11,1),
                    CheckOut = new DateTime(2021,11,10),
                },
                new RecordDTO()
                {
                    CheckIn = new DateTime(2021,11,20),
                    CheckOut = new DateTime(2021,12,1),
                }
            };

            return records;
        }



    }
}
