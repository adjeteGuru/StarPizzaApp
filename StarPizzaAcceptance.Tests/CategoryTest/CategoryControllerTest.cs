using Microsoft.AspNetCore.Mvc;
using Moq;
using StarPizzaShop.Controllers;
using StarPizzaShop.DataAccess;
using StarPizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StarPizzaAcceptance.Tests
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategoryRepo> _mockRepo;
        private readonly CategoryController _controller;
        public CategoryControllerTest()
        {
            //create a mock Icategory repository
            _mockRepo = new Mock<ICategoryRepo>();

            //create system under test and pass in the mock repo
            _controller = new CategoryController(_mockRepo.Object);
        }

        [Fact]
        public void ReturnViewForIndex()
        {     

            //declare a local variable 'result' of type IActionResult 
            //and set it to the return value to our controller Index method
            ActionResult result = _controller.Index();

            //with the result we can make an assert on it
            //here it is IsType and we are going to provide a generic type parameter here 
            //here it is a ViewResult so we re going to pass in the result.
            //So if it is a viewResult it is going to pass, if not then it will fail
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ReturnView_WhenInvalidModelState()
        {
            _controller.ModelState.AddModelError("x", "test Error");


            //bcos we are testing new category created
            var category = new Category
            {
                Name = "Pizza",
            };

            //here we need to provide a new category that we re creating
            IActionResult result = _controller.Create(category);

            //here as we know it is a type ViewResult next
            var viewResult = Assert.IsType<ViewResult>(result);

            //since we know it is a type ViewResult then we want to provide the new instance of category            
            //into this 'model' as we want to know if the model is a type Category model when providing viewmodel
            var model = Assert.IsType<Category>(viewResult.Model);

            //now we want to check that we get the same category we sent in is the same as model we get back
            Assert.Equal(category.Name, model.Name);
        }

        [Fact]
        public void NotSaveCategory_WhenModelErrorOccured()
        {
            _controller.ModelState.AddModelError("x", "Test error");

            var category = new Category();

            _controller.Create(category);

            //here we check if the added category is called to verify if it is Any Category 
            _mockRepo.Verify(x => x.CreateCategory(It.IsAny<Category>()), Times.Never);
        }

        [Fact]
        public void ReturnAllCategories_ToListExists()
        {          

            var categoryList = new List<Category>
           {
               new Category{Id = 1, Name="Pizza"},
               new Category{Id = 2, Name ="BBQ"}
           };

            var expected = _mockRepo.Setup(x => x.GetCategories()).Returns(categoryList);

            //act
            var result = _controller.Index();

            //assert
            Assert.IsAssignableFrom<ViewResult>(result);            
          
        }

        [Fact]
        public void ReturnAllCategories_NoFound()
        {
            var categoryList = new List<Category>()
            {
                new Category { Id = 1, Name = "Pizza" },
               new Category { Id = 2, Name = "BBQ" }
            };

            var expected = _mockRepo.Setup(x => x.GetCategories()).Returns(categoryList);

            var result = _controller.Index();

            Assert.IsAssignableFrom<ViewResult>(result);
        }


        [Fact]
        public void Return_CategoryById()
        {                           
                       
            var expected =_mockRepo.Setup(x => x.GetCategoryById(It.IsAny<int>())).Returns(new Category { Id = 1 });

            var result = _controller.Details(1);

            Assert.IsAssignableFrom<ViewResult>(result);
            
        }

    }
}

