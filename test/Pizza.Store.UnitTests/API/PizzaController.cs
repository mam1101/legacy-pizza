namespace Pizza.Store.UnitTests.API;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Pizza.Store.API.Controllers;
using Pizza.Store.Core.Interfaces;
using Pizza.Store.Infrastructure.Data.Repositories;
using Pizza = Pizza.Store.Core.Models.Pizza;


public class PizzaControllerTests
{

    private List<Pizza> GetTestPizzas()
    {
        var pizzas = new List<Pizza>();
        pizzas.Add(new Pizza()
        {
            Name = "Test 1",
            Description = "Test pizza 1"
        });
        pizzas.Add(new Pizza()
        {
            Name = "Test 2",
            Description = "Test pizza 2"
        });
        return pizzas;
    }

    [Fact]
    public async void pizza_controller_list_returns_list()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<Pizza>>();
        mockRepo.Setup(repo => repo.List()).Returns(GetTestPizzas());
        var controller = new PizzaController(mockRepo.Object);
        
        //Act
        var result = await controller.List();

        //Assert
        var assertResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Pizza>>(
            assertResult.Value);
        Assert.Equal(2, model.Count());
        Assert.Equal(200, assertResult.StatusCode);
    }
    
    [Fact]
    public async void pizza_controller_get_returns_single_entry()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<Pizza>>();
        mockRepo.Setup(repo => repo.GetById(0)).Returns(new Pizza()
        {
            Name = "Test 1",
            Description = "Test Pizza 1"
        });
        
        var controller = new PizzaController(mockRepo.Object);
        
        //Act
        var result = await controller.Get(0);

        //Assert
        var assertResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<Pizza>(
            assertResult.Value);
        Assert.Equal(0, model.Id);
        Assert.Equal(200, assertResult.StatusCode);
    }
    
    [Fact]
    public async void pizza_controller_create_returns_creates_single_pizza()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<Pizza>>();
        var controller = new PizzaController(mockRepo.Object);
        
        //Act
        var result = await controller.Create(new Pizza()
        {
            Name = "Test 1",
            Description = "Test Pizza 1"
        });

        //Assert
        var assertResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<Pizza>(
            assertResult.Value);
        Assert.Equal(0, model.Id);
        Assert.Equal(200, assertResult.StatusCode);
    }
}