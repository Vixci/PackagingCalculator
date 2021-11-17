using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using PackagingCalculator.Repositories;
using PackagingCalculator.Entities;
using PackagingCalculator.Controllers;
using Microsoft.Extensions.Logging;
using PackagingCalculator.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OrderControllerTests
{
    public class OrderControllerTests
    {

        Order testOrder = new Order
        {
            OrderId = 1,
            Items = new List<Item> {
                    new Item {
                        ItemId = 1,
                        OrderId = 1,
                        Type = ProductType.mug,
                        Quantity = 9
                    }
                },
            RequiredBinWidth = 282
        };

        [Fact]
        public async void GetSingleOrderTest()
        {
            //Arrange
            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockLogger = new Mock<ILogger<OrderController>>();
            var mockBinWidthCalculator = new Mock<IBinWidthCalculator>();

            OrderController packagingCalculatorController = new OrderController(mockLogger.Object, mockOrderRepository.Object, mockBinWidthCalculator.Object);

            mockOrderRepository.Setup(repo => repo.GetSingle(It.IsAny<long>())).ReturnsAsync(testOrder);

            //Act
            var result = await packagingCalculatorController.GetSingleOrder(It.IsAny<long>());

            //Assert
            var actual = result.Result as OkObjectResult;
            Assert.Equal(testOrder, actual.Value);
        }

        [Fact]
        public async void CheckIfAddOrderIsNullTest()
        {
            //Arrange
            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockLogger = new Mock<ILogger<OrderController>>();
            var mockBinWidthCalculator = new Mock<IBinWidthCalculator>();

            OrderController orderController = new OrderController(mockLogger.Object, mockOrderRepository.Object, mockBinWidthCalculator.Object);

            //Act
            var result = await orderController.AddOrder(null);

            //Assert
            //TODO: use constants
            (result.Result as StatusCodeResult).StatusCode.Equals(HttpStatusCode.BadRequest);
        }
    }
}
