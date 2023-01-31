using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameRPG.Test.Commands
{
    public class CreateCharacterCommandHandleTest
    {
        private MockRepository mockRepository;

        private Mock<ICharacterRepository> mockCharacterRepository;
        private Mock<IProfessionRepository> mockProfessionRepository;
        private Mock<ILogger> mockLogger;

        public CreateCharacterCommandHandleTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockCharacterRepository = this.mockRepository.Create<ICharacterRepository>();
            this.mockProfessionRepository = this.mockRepository.Create<IProfessionRepository>();
            this.mockLogger = new Mock<ILogger>();
        }


        private CreateCharacterCommandHandler CreateCharacterCommandHandler()
        {
            return new CreateCharacterCommandHandler(
                this.mockCharacterRepository.Object,
                this.mockProfessionRepository.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task CreateCharacterCommandHandler_Should_Return_True()
        {

            var commandHandler = this.CreateCharacterCommandHandler();

            CreateCharacterCommand command = new CreateCharacterCommand() { Name = "Teste", ProfessionId = 1 };
            this.mockProfessionRepository.Setup(x => x.GetById(command.ProfessionId)).ReturnsAsync(Scenario.profession);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            var list = new List<Character>();
            list.Add(Scenario.character);
            this.mockCharacterRepository.Setup(x => x.GetAllCharacter()).ReturnsAsync(list);

            this.mockCharacterRepository.Setup(x => x.CreateCharacter(It.IsAny<List<Character>>()));


            this.mockLogger.Setup(x => x.Information(It.IsAny<string>()));


            var result = await commandHandler.Handle(
            command,
            cancellationToken);

            // Assert
            Assert.True(result.Equals(2));
            this.mockRepository.VerifyAll();

        }
    }
}
