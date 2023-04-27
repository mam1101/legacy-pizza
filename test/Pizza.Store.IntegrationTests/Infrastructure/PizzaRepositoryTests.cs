using Microsoft.EntityFrameworkCore;

namespace Pizza.Store.IntegrationTests.Infrastructure;

using Moq;
using Pizza.Store.Infrastructure.Data.Repositories;
using Migrations;
using Pizza = Pizza.Store.Core.Models.Pizza;

public class PizzaRepositoryTests
{
    [Fact]
    public void pizza_repository_adds_new_pizza()
    {
        //Arrange
        var mockSet = new Mock<DbSet<Pizza>>();
        var mockContext = new Mock<PizzaContext>();
        mockContext.Setup(pizzaContext => pizzaContext.Pizzas).Returns(mockSet.Object);
        mockContext.Setup(pizzaContext => pizzaContext.Set<Pizza>()).Returns(mockSet.Object);
        var repository = new PizzaRepository(mockContext.Object);

        //Add 
        repository.Add(new Pizza()
        {
            Name = "Test 1",
            Description = "Test Pizza 1"
        });

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<Pizza>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}