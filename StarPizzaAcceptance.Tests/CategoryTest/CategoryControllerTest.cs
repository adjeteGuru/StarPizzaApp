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
        public void ReturnViewTypeChecked_ForIndex()
        {    
          
            ActionResult result = _controller.Index();

            Assert.IsType<ViewResult>(result);
        }
       

        [Fact]
        public void ReturnAllCategories_ListExists()
        {          

            var categoryList = new List<Category>
           {
               new Category{Id = 1, Name="Pizza"},
               new Category{Id = 2, Name ="BBQ"}
           };

            _mockRepo.Setup(x => x.GetCategories()).Returns(categoryList);
            
            var result = Assert.IsType<ViewResult>(_controller.Index());

            var model = Assert.IsType<List<Category>>(result.Model);

            Assert.Equal(2, model.Count());                    

        }        


        [Fact]
        public void ReturnSingle_CategoryById()
        {
            _mockRepo.Setup(x => x.GetCategoryById(It.IsAny<int>())).Returns(
              new Category { Id = 1, Name = "Pizza" });

            var result = _controller.Details(1);

            ViewResult expected = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<Category>(expected.Model);

            Assert.NotNull(model);
           
            Assert.Equal("Pizza", model.Name);            
        }


        [Fact]
        public void ReturnView_WhenModelStateInValid()
        {
            _controller.ModelState.AddModelError("test", "test Error");

            var category = new Category
            {
                Name = "Pizza",
            };
            
            IActionResult result = _controller.Create(category);
            
            var viewResult = Assert.IsType<ViewResult>(result);
           
            var model = Assert.IsType<Category>(viewResult.Model);
           
            Assert.Equal(category.Name, model.Name);
        }


        [Fact]
        public void ReturnRedirectToViewForIndex_WhenCategoryAdded()
        {

            var category = new Category
            {
                Name = "Pizza"
            };           

            var result = _controller.Create(category);            

            Assert.IsAssignableFrom<RedirectToActionResult>(result);

            _mockRepo.Verify(x => x.CreateCategory(It.IsAny<Category>()), Times.Once());
        }


        [Fact]
        public void NotSaveCategory_WhenModelErrorOccured()
        {
            _controller.ModelState.AddModelError("test", "Test error");

            var category = new Category();

            _controller.Create(category);

            //here we check if the added category is called to verify if it is Any Category 
            _mockRepo.Verify(x => x.CreateCategory(It.IsAny<Category>()), Times.Never);
        }

    }
}

