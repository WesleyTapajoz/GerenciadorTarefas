using GerenciadorTarefas.Domain.Entity;
using Xunit;

namespace GerenciadorTarefas.Tests.Unidade.Domain
{
    public class TarefaTests
    {
        [Fact]
        public void DefinirEObterTarefaId()
        {
            // Arrange
            var tarefa = new Tarefa();

            // Act
            tarefa.TarefaId = 1;

            // Assert
            Assert.Equal(1, tarefa.TarefaId);
        }

        [Fact]
        public void DefinirEObterTitulo()
        {
            // Arrange
            var tarefa = new Tarefa();
            string titulo = "Título da Tarefa";

            // Act
            tarefa.Titulo = titulo;

            // Assert
            Assert.Equal(titulo, tarefa.Titulo);
        }

        [Fact]
        public void DefinirEObterDescricao()
        {
            // Arrange
            var tarefa = new Tarefa();
            string descricao = "Descrição da Tarefa";

            // Act
            tarefa.Descricao = descricao;

            // Assert
            Assert.Equal(descricao, tarefa.Descricao);
        }

        [Fact]
        public void DefinirEObterData()
        {
            // Arrange
            var tarefa = new Tarefa();
            DateTime data = DateTime.Now;

            // Act
            tarefa.Data = data;

            // Assert
            Assert.Equal(data, tarefa.Data);
        }

        [Fact]
        public void DefinirEObterStatus()
        {
            // Arrange
            var tarefa = new Tarefa();
            int status = 2;

            // Act
            tarefa.Status = status;

            // Assert
            Assert.Equal(status, tarefa.Status);
        }

        [Fact]
        public void DefinirEObterUserId()
        {
            // Arrange
            var tarefa = new Tarefa();
            int userId = 123;

            // Act
            tarefa.UserId = userId;

            // Assert
            Assert.Equal(userId, tarefa.UserId);
        }

    }

}
