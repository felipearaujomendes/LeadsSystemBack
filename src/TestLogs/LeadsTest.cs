using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLogs
{
    public class LeadsApplicationTests
    {
        [Fact]
        public void Accpted_ShouldApplyDiscountAndCallRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var leadsApplication = new LeadsApplication(repositoryMock.Object);

            var leads = new Leads
            {
                Price = 600, // Example price greater than 500
                // Set other necessary properties
            };

            // Act
            leadsApplication.Accpted(leads);

            // Assert
            // Check that the repository method was called with the correct leads object
            repositoryMock.Verify(repo => repo.Accepted(leads), Times.Once);

            // Check that the price has been discounted
            Xunit.Assert.Equal(540, leads.Price); // 10% discount on 600
        }

        [Fact]
        public void Accpted_ShouldNotApplyDiscountForLowPrice()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var leadsApplication = new LeadsApplication(repositoryMock.Object);

            var leads = new Leads
            {
                Price = 400, // Example price less than 500
                // Set other necessary properties
            };

            // Act
            leadsApplication.Accpted(leads);

            // Assert
            // Check that the repository method was called with the correct leads object
            repositoryMock.Verify(repo => repo.Accepted(leads), Times.Once);

            // Check that the price has not been discounted
            Xunit.Assert.Equal(400, leads.Price);
        }
    }
}
