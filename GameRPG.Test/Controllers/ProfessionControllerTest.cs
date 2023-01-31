using GameRPG.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using GameRPG.Application.Commands.ProfessionCommands;
using GameRPG.Domain.Entities;

namespace GameRPG.Test.Controllers
{
    public class ProfessionControllerTest
    {
        private MockRepository mockRepository;

        private Mock<IMediator> mockMediator;

        public ProfessionControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMediator = this.mockRepository.Create<IMediator>();
        }

        private ProfessionController CreateProfessionController()
        {
            return new ProfessionController(
                this.mockMediator.Object);
        }

        [Fact]
        public async Task GetProfession_Should_Return_OK()
        {
            // Arrange
            var professionController = this.CreateProfessionController();

            var list = new List<Profession>();
            list.Add(Scenario.profession);

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<GetProfessionCommand>(), cancellationToken)).ReturnsAsync(list);

            // Act
            var result = await professionController.GetProfession();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task GetProfession_Should_Return_Not_Found()
        {
            // Arrange
            var professionController = this.CreateProfessionController();


            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<GetProfessionCommand>(), cancellationToken)).ReturnsAsync(new List<Profession>());

            // Act
            var result = await professionController.GetProfession();

            // Assert
            Assert.IsType<NotFoundResult>(result);
            this.mockRepository.VerifyAll();
        }
    }
}
