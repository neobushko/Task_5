using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task_5.BLL.DTO;
using Task_5.BLL.Services;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace TestProject1
{
    public class Tests
    {
        private List<RecordDTO> records = new List<RecordDTO>();
        DateTime start2Month = new DateTime(2021, 11, 1);
        DateTime end2Month = new DateTime(2022, 1, 1);
        private FakeData fakeData = new FakeData();
        private IMapper mapper;
        private static Mock<IUnitOfWork> mockWorkUnit = new Mock<IUnitOfWork>();
        private readonly BaseService baseService = new BaseService(mockWorkUnit.Object);
        [SetUp]
        public void Setup()
        {
            mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Record, RecordDTO>().ReverseMap();
                    cfg.CreateMap<Room, RoomDTO>().ReverseMap();
                    cfg.CreateMap<User, UserDTO>().ReverseMap();
                    cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                    cfg.CreateMap<PriceforCategory, PriceforCategoryDTO>().ReverseMap();
                }
                ).CreateMapper();
        }

        [Test]
        public void BenefitForPeriod_CountFor2Month()
        {
            //Arrange
            mockWorkUnit.Setup(s => s.Records.GetAll()).Returns(fakeData.Records);
            mockWorkUnit.Setup(s => s.PriceforCategories.GetAll()).Returns(fakeData.Prices);
            //Act
            decimal benefit = baseService.BenefitForPeriod(start2Month, end2Month).Benefit;
            //Assert
            Assert.AreEqual(5550m, benefit);
        }
    }
}