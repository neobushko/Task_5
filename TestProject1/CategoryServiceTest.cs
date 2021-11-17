using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Services;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace TestProject1
{

    class CategoryServiceTest
    {
        private static Mock<IUnitOfWork> mockWorkUnit = new Mock<IUnitOfWork>();
        private IMapper map = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
                }
                ).CreateMapper();
        private FakeData fakeData = new FakeData();
        private readonly CategoryService categoryService = new CategoryService(mockWorkUnit.Object);

        [TestCase(1, typeof(CategoryDTO))]
        [TestCase(2, typeof(CategoryDTO))]
        [TestCase(3, typeof(CategoryDTO))]
        public void Get_Method_TypeTest(int numb, Type ExpectedResult)
        {
            Guid CatId = new Guid("adc0d03a-2d43-42f6-9062-4bf9ccdb5a0" + numb.ToString());
            mockWorkUnit.Setup(s => s.Categories.Get(CatId)).Returns(fakeData.Categories.SingleOrDefault(c => c.id == CatId));

            var ActualResult = categoryService.Get(CatId);

            Assert.IsInstanceOf(ExpectedResult, ActualResult);
        }
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5a00")]
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5eee")]
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5e04")]
        public void Get_Method_ThrowExceptionTest(string numb)
        {
            Guid CatId = new Guid(numb);
            mockWorkUnit.Setup(s => s.Categories.Get(CatId)).Returns(fakeData.Categories.SingleOrDefault(c => c.id == CatId));

            Assert.Throws<ArgumentException>(() => categoryService.Get(CatId));
        }
        [TestCase(typeof(IEnumerable<CategoryDTO>))]
        public void GetAll_Method_TypeTest(Type ExpectedResult)
        {
            //Arrange
            mockWorkUnit.Setup(s => s.Categories.GetAll()).Returns(fakeData.Categories);
            //Act
            var ActualResult = categoryService.GetAll();
            //Assert
            Assert.IsInstanceOf(ExpectedResult, ActualResult);
        }
        [TestCase("some text", "adc0d03a-2d43-42f6-9062-4bf9ccdb5a00")]
        [TestCase("some text (2)", "e5765d4a-ed05-4d91-b428-f7b3a20e7f76")]
        public void Create_Method_Success_AddingNewCategoryTest(string description, string id)
        {
            //Arrange
            CategoryDTO categoryDTO = new CategoryDTO() { Decription = description, id = new Guid(id) };
            mockWorkUnit.Setup(s => s.Categories.Create(map.Map<CategoryDTO, Category>(categoryDTO)));
            mockWorkUnit.Setup(s => s.Categories.GetAll()).Returns(fakeData.Categories);
            //Act
            categoryService.Create(categoryDTO);
            //Assert
            mockWorkUnit.Verify(x => x.Categories.Create(map.Map<CategoryDTO, Category>(categoryDTO)));
        }
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01")]
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5a02")]
        public void Create_ThrowArgumentException_WhenCategoryExist(string id)
        {
            //Arrange
            var categoryId = new Guid(id);
            mockWorkUnit.Setup(x => x.Categories.Get(categoryId)).
                Returns(fakeData.Categories.SingleOrDefault(s => s.id == categoryId));
            //Act and Assert
            Assert.Throws<ArgumentException>(() => categoryService.Create(new CategoryDTO() { id = categoryId, Decription = "" }));
        }
        [TestCase("adc0d03a-2d43-42f6-9062-4bf9ccdb5a01")]
        public void Delete_DeleteCategory_WhenCategoryExsists(string id)
        {
            //Arrange
            var categoryId = new Guid(id);
            mockWorkUnit.Setup(x => x.Categories.Delete(categoryId));
            mockWorkUnit.Setup(x => x.Categories.Get(categoryId)).Returns(fakeData.Categories.SingleOrDefault(c => c.id == categoryId));
            //Act
            categoryService.Delete(categoryId);
            //Assert
            mockWorkUnit.Verify(x => x.Categories.Delete(categoryId));
        }

    }
}
