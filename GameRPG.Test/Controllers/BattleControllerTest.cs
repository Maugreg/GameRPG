using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Controllers;
using GameRPG.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using GameRPG.Application.Commands.BattleCommands;

namespace GameRPG.Test.Controllers
{
    public class BattleControllerTest
    {
        private MockRepository mockRepository;

        private Mock<IMediator> mockMediator;

        public BattleControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMediator = this.mockRepository.Create<IMediator>();
        }

        private BattleController CreateBattleController()
        {
            return new BattleController(
                this.mockMediator.Object);
        }

        [Fact]
        public async Task Battle_Should_Return_OK()
        {
            // Arrange
            var battleController = this.CreateBattleController();

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<BattleCommand>(), cancellationToken)).ReturnsAsync(new List<string>());

            // Act
            var result = await battleController.Battle(new BattleCommand());

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.mockRepository.VerifyAll();
        }
    }
}
