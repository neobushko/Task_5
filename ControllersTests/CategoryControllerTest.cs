using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Task_5.Controllers;
using Task_5.DAL.Enteties;
using System.Collections.Generic;
using System;
using Hotel_Api.Models;
using TestProject1;

namespace ControllersTests
{
    public class CategoryControllerTest
    {

        private CategoryController categoryController;
        IMapper mapper;
        Mock<IService<CategoryDTO>> mockCategoryService;
        FakeDataForApi fakeData;

        [SetUp]
        public void Setup()
        {
            mapper = new MapperConfiguration(
            cfg =>cfg.CreateMap<Category, CategoryDTO>()
            ).CreateMapper();

            mockCategoryService = new Mock<IService<CategoryDTO>>();
            categoryController = new CategoryController(mockCategoryService.Object);
            fakeData = new FakeDataForApi();
        }

        [TestCase(typeof(IEnumerable<CategoryModel>))]
        public void Get_IEnumerable_ReturnType(Type ExpectedResult)
        {
            //Arrange
            mockCategoryService.Setup(s => s.GetAll()).Returns(fakeData.Categories);
            //Act
            var ActualResult = categoryController.Get();
            //Assert
            Assert.IsInstanceOf(ExpectedResult,ActualResult);
        }
        [TestCase("")]
        public void Get_WithGuid_CategoryModel_ReturnType()
        {
            //Arrange
            mockCategoryService.Setup(s => s.Get())
        }
    }
}