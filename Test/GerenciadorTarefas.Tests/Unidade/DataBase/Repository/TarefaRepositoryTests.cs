using Xunit;
using GerenciadorTarefas.Repository.Data;
using GerenciadorTarefas.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Domain.Entity;

namespace GerenciadorTarefas.Testes.Unidade.Controllers
{
    public class TarefaRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly TarefaRepository _repository;

        public TarefaRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;
            _context = new DataContext(_options);
            _repository = new TarefaRepository(_context);
        }

        [Fact]
        public void Adicionar_DeveChamarAddNoContexto()
        {
            // Arrange
            var entidade = new Tarefa(); 

            // Act
            _repository.Add(entidade);

            // Assert
            var entityInContext = _context.Set<Tarefa>().Find(entidade.TarefaId);
            Assert.NotNull(entityInContext);
        }

        [Fact]
        public void Excluir_DeveChamarRemoveNoContexto()
        {
            // Arrange
            var entidade = new Tarefa();
            entidade.Descricao = "Descricao fake";
            entidade.Titulo = "Titulo fake";

            _context.Set<Tarefa>().Add(entidade);
            _context.SaveChanges();

            // Act
            _repository.Delete(entidade);

            // Assert
            var entityInContext = _context.Set<Tarefa>().Find(entidade.TarefaId);
            Assert.NotNull(entityInContext);
        }

        [Fact]
        public void ExcluirVarios_DeveChamarRemoveRangeNoContexto()
        {
            // Arrange

            var entidade1 = new Tarefa();
            entidade1.Descricao = "Descricao fake 1";
            entidade1.Titulo = "Titulo fake 1";

            var entidade2 = new Tarefa();
            entidade2.Descricao = "Descricao fake 2";
            entidade2.Titulo = "Titulo fake 2";

            var entidades = new[] { entidade1, entidade2 }; 
            _context.Set<Tarefa>().AddRange(entidades);
            _context.SaveChanges();

            // Act
            _repository.DeleteRange(entidades);

            // Assert
            foreach (var entidade in entidades)
            {
                var entityInContext = _context.Set<Tarefa>().Find(entidade.TarefaId);
                Assert.NotNull(entityInContext);
            }
        }

        [Fact]
        public async Task ObterTodosAsync_DeveRetornarArray()
        {
            // Arrange
            var entidade1 = new Tarefa();
            entidade1.Descricao = "Descricao fake 1";
            entidade1.Titulo = "Titulo fake 1";

            var entidade2 = new Tarefa();
            entidade2.Descricao = "Descricao fake 2";
            entidade2.Titulo = "Titulo fake 2";

            var entidades = new[] { entidade1, entidade2 };
            _context.Set<Tarefa>().AddRange(entidades);
            _context.SaveChanges();

            // Act
            var resultado = await _repository.GetAllAsync<Tarefa>();

            // Assert
            Assert.Equal(entidades.Length, resultado.Length);
        }

        [Fact]
        public async Task ObterPorId_DeveRetornarEntidade()
        {
            // Arrange
            var entidade = new Tarefa();
            entidade.Descricao = "Descricao fake 1";
            entidade.Titulo = "Titulo fake 1";

            _context.Set<Tarefa>().Add(entidade);
            _context.SaveChanges();

            // Act
            var resultado = await _repository.GetById<Tarefa>(entidade.TarefaId);

            // Assert
            Assert.Equal(entidade, resultado);
        }
    }

}
