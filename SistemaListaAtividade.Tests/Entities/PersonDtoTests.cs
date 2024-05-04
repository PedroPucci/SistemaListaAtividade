using SistemaListaAtividade.Domain.Entities.Dto;

namespace SistemaListaAtividade.Tests.Entities
{
    public class PersonDtoTests
    {
        [Fact]
        public void PersonDto_Return_False()
        {
            // Arrange
            var personDto = new PersonDto();

            // Assert
            Assert.Null(personDto.FirstName);
            Assert.Null(personDto.Email);
        }

        [Fact]
        public void PersonDto_Return_True()
        {
            // Arrange
            var personDto = new PersonDto();

            // Act
            personDto.FirstName = "Pedro";
            personDto.Email = "pedro@testes.com.br";

            // Assert
            Assert.Equal("Pedro", personDto.FirstName);
            Assert.Equal("pedro@testes.com.br", personDto.Email);
        }
    }
}