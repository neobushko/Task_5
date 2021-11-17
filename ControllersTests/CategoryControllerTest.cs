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
using System.Linq;

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
            cfg =>cfg.CreateMap<CategoryModel, CategoryDTO>()
            ).CreateMapper();

            mockCategoryService = new Mock<IService<CategoryDTO>>();
            categoryController = new CategoryController(mockCategoryService.Object);
            fakeData = new FakeDataForApi();
        }
        //Type tests
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
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01", typeof(CategoryModel))]
        public void Get_WithGuid_CategoryModel_ReturnType(string guid, Type ExpectedResult)
        {
            //Arrange
            var CategoryId = new Guid(guid);
            mockCategoryService.Setup(s => s.Get(CategoryId)).
                Returns(fakeData.Categories.SingleOrDefault(s => s.id == CategoryId));
            //Act
            var ActualResult = categoryController.Get(CategoryId);
            //Assert
            Assert.IsInstanceOf(ExpectedResult, ActualResult);
        }
        [TestCase("737a6171-09f6-4883-8f04-0216b7edfef8", "some description")]
        public void Post_EvokeCategoryService_Create(string id, string description)
        {
            //Arrange
            var categoryModel = new CategoryModel() { id = new Guid(id), Description = description };
            mockCategoryService.Setup(s => s.Create(mapper.Map<CategoryModel, CategoryDTO>(categoryModel)));
            //Act
            categoryController.Post(categoryModel);
            //Assert
            mockCategoryService.Verify(s => s.Create(mapper.Map<CategoryModel, CategoryDTO>(categoryModel)));
        }

    }
}