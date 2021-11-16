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
        public IEnumerable<Category> Categories { get; private set; }
        public FakeData()
        {
            Categories = CategoryInit();
        }
        private IEnumerable<Category> CategoryInit()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    id = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (1) Some description"
                },
                new Category()
                {
                    id = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Decription = " (2) Another description"
                },
                new Category() 
                {
                    id = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
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
                    id = new Guid("rdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Number = 1,
                    CategoryId = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (1) room"
                },
                new Room()
                {
                    id = new Guid("rdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Number = 2,
                    CategoryId = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a01"),
                    Decription = " (2) room"
                },
                new Room()
                {
                    id = new Guid("rdc0d03a-2d43-42f6-9062-4bf9ccdb5a03"),
                    Number = 3,
                    CategoryId = new Guid("fdc0d03a-2d43-42f6-9062-4bf9ccdb5a02"),
                    Decription = " (3) room"
                }
                new Room()
                {

                }
            };
            return rooms;
        }
    }
}
