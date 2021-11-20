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
                    Description = " (1) Some description"
                },
                new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Description = " (2) Another description"
                },
                new Category() 
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Description = " (3) Very another description"
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
                    Description = " (1) room", 
                    Category = new Category()
                    {
                        id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Description = " (1) Some description"
                    },
                    
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Number = 2,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Description = " (2) room"
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Number = 3,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Description = " (3) room"
                },
                new Room()
                {
                    id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a04"),
                    Number = 4,
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Description = " (4) room"
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
                    Id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Name = "Artem Arshava",
                    PhoneNumber = "098158888",
                    Email = "artem.arshava@nure.ua"
                },
                new User()
                {
                    Id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Name = "Anton Antonov",
                    PhoneNumber = "0970461479",
                    Email = "anton.antonov@nure.ua"
                },
                new User()
                {
                    Id = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Name = "Daniel Obushko",
                    PhoneNumber = "0684387777",
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
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a05"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Price = 100m,
                    Name ="Default price",
                    StartDate = new DateTime(2020,02,16),
                    EndDate = new DateTime(2021,10,31),
                    Category =                 new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Description = " (1) Some description"
                }
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Price = 120m,
                    Name ="Prewinter holiday price",
                    StartDate = new DateTime(2021,11,1),
                    EndDate = new DateTime(2021,12,1),
                    Category =                 new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Description = " (1) Some description"
                }
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Price = 150m,
                    Name = "Winter holiday price",
                    StartDate = new DateTime(2021,12,2),
                    EndDate = new DateTime(2022,2,15),
                    Category =                 new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Description = " (1) Some description"
                }
                },
                new PriceforCategory()
                {
                    id = new Guid("ddc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Price = 300m,
                    Category =                 new Category()
                {
                    id = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Description = " (3) Very another description"
                },
                    StartDate = new DateTime(2020,1,1),
                    EndDate = new DateTime(2021,1,1)
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
                    CheckIn = new DateTime(2021,11, 21),
                    CheckOut = new DateTime(2021,12,1),
                    Room = new Room()
                    {
                        id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Number = 1,
                        CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Description = " (1) room"
                    }
                },
                new Record()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CheckIn = new DateTime(2021,12,2),
                    CheckOut = new DateTime(2021,12,21),
                    Room = new Room()
                    {
                        id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Number = 1,
                        CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Description = " (1) room"
                    }
                },
                new Record()
                {
                    id = new Guid("edc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    UserId = new Guid("cdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    RoomId = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    CheckIn = new DateTime(2021,12,22),
                    CheckOut = new DateTime(2022,1,5),
                    Room = new Room()
                    {
                        id = new Guid("bdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Number = 1,
                        CategoryId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                        Description = " (1) room"
                    }
                }
            };

            return records;
        }


        
    }
}
