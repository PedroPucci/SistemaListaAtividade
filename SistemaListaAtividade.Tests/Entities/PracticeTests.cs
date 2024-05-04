using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Tests.Entities
{
    public class PracticeTests
    {
        [Fact]
        public void Practice_Properties_Return_False()
        {
            // Arrange
            var practice = new Practice();

            // Assert
            Assert.Null(practice.Name);
            Assert.Null(practice.Description);
            Assert.Null(practice.Type);
        }

        [Fact]
        public void Practice_Properties_Return_True()
        {
            // Arrange
            var practice = new Practice();

            // Act
            practice.Name = "Comprar";
            practice.Description = "comprar frutas";
            practice.Type = "Compras no supermercado";

            // Assert
            Assert.Equal("Comprar", practice.Name);
            Assert.Equal("comprar frutas", practice.Description);
            Assert.Equal("Compras no supermercado", practice.Type);
        }
    }
}