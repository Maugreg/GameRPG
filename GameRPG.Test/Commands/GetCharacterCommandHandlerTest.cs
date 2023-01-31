using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameRPG.Test.Commands
{
    public class GetCharacterCommandHandlerTest
    {
        private MockRepository mockRepository;

        private Mock<ICharacterRepository> mockCharacterRepository;

        public GetCharacterCommandHandlerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCharacterRepository = this.mockRepository.Create<ICharacterRepository>();
        }

        private GetCharacterCommandHandler CreateGetCharacterCommandHandler()
        {
            return new GetCharacterCommandHandler(
                this.mockCharacterRepository.Object);
        }

        [Fact]
        public async Task GetCharacterCommandHandler_Should_Return_True()
        {
            var commandHandler = this.CreateGetCharacterCommandHandler();
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            var list = new List<Character>();
            list.Add(Scenario.character);

            this.mockCharacterRepository.Setup(x => x.GetAllCharacter()).ReturnsAsync(list);

            var result = await commandHandler.Handle(
            new GetCharacterCommand(),
               cancellationToken);

            // Assert
            Assert.True(result.Any());
            this.mockRepository.VerifyAll();
        }
    }
}
