using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.DAL.Enteties;

namespace TestProject1
{
    public class FakeData
    {
        public IEnumerable<Category> Categories { get;  set; }
        public IEnumerable<Room> Rooms { get;  set; }
        public IEnumerable<User> Users { get;  set; }
        public IEnumerable<PriceforCategory> Prices { get;  set; }
        public IEnumerable<Record> Records { get;  set; }
        public FakeData()
        {
            Categories = CategoryInit();
            Rooms = RoomInit();
            Users = UserInit();
            Prices = PriceInit();
            Records = RecordsInit();
        }
        private IEnumerable<Category> CategoryInit()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (1) Some description"
                },
                new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Decription = " (2) Another description"
                },
                new Category() 
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Decription = " (3) Very another description"
                }
            };
            return categories;
        }

        private IEnumerable<Room> RoomInit()
        {
            var rooms = new List<Room>()
            {
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Number = 1,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (1) room"
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Number = 2,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (2) room"
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Number = 3,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Decription = " (3) room"
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    Number = 4,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Decription = " (4) room"
                }
            };
            return rooms;
        }
        private IEnumerable<User> UserInit()
        {
            var users = new List<User>()
            {
                new User()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Name = "Artem Arshava",
                    ContactPhone = "098158888",
                    Email = "artem.arshava@nure.ua"
                },
                new User()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Name = "Anton Antonov",
                    ContactPhone = "0970461479",
                    Email = "anton.antonov@nure.ua"
                },
                new User()
                {
                    id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Name = "Daniel Obushko",
                    ContactPhone = "0684387777",
                    Email = "Daniel@gmail.com"
                }

            };
            return users;
           
        }
        private IEnumerable<PriceforCategory> PriceInit()
        {
            var prices = new List<PriceforCategory>()
            {
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Price = 100m
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Price = 150m
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Price = 300m
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    Price = 125m
                }
            };

            return prices;
        }

        
        private IEnumerable<Record> RecordsInit()
        {
            //("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")
            var records = new List<Record>()
            {
                new Record()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CheckIn = new DateTime(2021,11, 10),
                    CheckOut = new DateTime(2021,11,20),
                },
                new Record()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    CheckIn = new DateTime(2021,11,1),
                    CheckOut = new DateTime(2021,11,10),
                },
                new Record()
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
