using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Task_5.BLL.DTO;
using Task_5.DAL.Interfaces;

namespace TestProject1
{
    public class Tests
    {
        private List<RecordDTO> records = new List<RecordDTO>();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(s => s.Records.GetAll()).Returns()
        }
    }
}