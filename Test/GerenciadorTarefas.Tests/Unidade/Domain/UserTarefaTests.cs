using GerenciadorTarefas.Domain.Entity;
using Xunit;

namespace GerenciadorTarefas.Tests.Unidade.Domain
{
    public class UserTarefaTests
    {
        [Fact]
        public void DefinirEObterTarefaId()
        {
            // Arrange
            var userTarefa = new UserTarefa();

            // Act
            userTarefa.TarefaId = 1;

            // Assert
            Assert.Equal(1, userTarefa.TarefaId);
        }

        [Fact]
        public void DefinirEObterTarefa()
        {
            // Arrange
            var userTarefa = new UserTarefa();
            var tarefa = new Tarefa { TarefaId = 1, Titulo = "Título da Tarefa" };

            // Act
            userTarefa.tarefa = tarefa;

            // Assert
            Assert.Equal(tarefa, userTarefa.tarefa);
            Assert.Equal(1, userTarefa.tarefa.TarefaId);
            Assert.Equal("Título da Tarefa", userTarefa.tarefa.Titulo);
        }

        [Fact]
        public void DefinirEObterId()
        {
            // Arrange
            var userTarefa = new UserTarefa();

            // Act
            userTarefa.Id = 123;

            // Assert
            Assert.Equal(123, userTarefa.Id);
        }
    }

}
