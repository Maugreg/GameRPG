using GameRPG.Application.Commands.ProfessionCommands;
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
using GameRPG.Application.Commands.CharacterCommand;

namespace GameRPG.Test.Controllers
{
    public class CharacterControllerTest
    {
        private MockRepository mockRepository;

        private Mock<IMediator> mockMediator;

        public CharacterControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMediator = this.mockRepository.Create<IMediator>();
        }

        private CharacterController CreateCharacterController()
        {
            return new CharacterController(
                this.mockMediator.Object);
        }

        [Fact]
        public async Task GetCharacter_Should_Return_OK()
        {
            // Arrange
            var characterController = this.CreateCharacterController();

            var list = new List<Character>();
            list.Add(Scenario.character);

            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<GetCharacterCommand>(), cancellationToken)).ReturnsAsync(list);

            // Act
            var result = await characterController.GetCharacter();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task GetCharacter_Should_Return_Not_Found()
        {
            // Arrange
            var professionController = this.CreateCharacterController();


            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<GetCharacterCommand>(), cancellationToken)).ReturnsAsync(new List<Character>());

            // Act
            var result = await professionController.GetCharacter();

            // Assert
            Assert.IsType<NotFoundResult>(result);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task CreateCharacter_Should_Return_OK()
        {
            // Arrange
            var characterController = this.CreateCharacterController();


            CancellationToken cancellationToken = default;
            mockMediator.Setup(x => x.Send(It.IsAny<CreateCharacterCommand>(), cancellationToken)).ReturnsAsync(1);

            // Act
            var result = await characterController.CreateCharacter(new CreateCharacterCommand());

            // Assert
            Assert.IsType<OkObjectResult>(result);
            this.mockRepository.VerifyAll();
        }
    }
}
