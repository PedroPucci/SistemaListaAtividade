using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Tests.Entities
{
    public class PersonTests
    {
        [Fact]
        public void Person_Properties_Empty()
        {
            // Arrange
            var person = new Person();
            person.FullName = string.Empty;
            person.FirstName = string.Empty;
            person.LastName = string.Empty;
            person.Email = string.Empty;

            // Assert
            Assert.Empty(person.FullName);
            Assert.Empty(person.FirstName);
            Assert.Empty(person.LastName);
            Assert.Empty(person.Email);            
        }

        [Fact]
        public void Person_Properties_Return_True()
        {
            // Arrange
            var person = new Person();

            // Act
            person.FullName = "Pedro Ighor";
            person.FirstName = "Pedro";
            person.LastName = "Ighor";
            person.Email = "pedro@teste.com.br";
            person.Practices = new List<Practice>();

            // Assert
            Assert.Equal("Pedro Ighor", person.FullName);
            Assert.Equal("Pedro", person.FirstName);
            Assert.Equal("Ighor", person.LastName);
            Assert.Equal("pedro@teste.com.br", person.Email);
            Assert.NotNull(person.Practices);
            Assert.Empty(person.Practices);
        }
    }
}