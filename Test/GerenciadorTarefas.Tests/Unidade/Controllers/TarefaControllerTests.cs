using AutoMapper;
using FluentAssertions;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Repository.Interfaces;
using GerenciadorTarefas.WebAPI.Controllers;
using GerenciadorTarefas.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace GerenciadorTarefas.Testes.Unidade.Controllers
{
    public class TarefaControllerTests
    {
        private readonly Mock<ITarefaRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TarefaController _controller;

        public TarefaControllerTests()
        {
            _mockRepo = new Mock<ITarefaRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new TarefaController(_mockRepo.Object, _mockMapper.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var tarefaList = new List<Tarefa> { new Tarefa { TarefaId = 1, UserId = 1 } };
            _mockRepo.Setup(repo => repo.GetByIdAndUserId(It.IsAny<int>()))
                .Returns(tarefaList.AsQueryable());

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            var returnValue = okResult.Value as List<Tarefa>;
            returnValue.Should().BeEquivalentTo(tarefaList);
        }

        [Fact]
        public async Task Adicionar_ReturnsOk_Quando_ModelIsValid()
        {
            // Arrange
            var model = new TarefaAddModel { };
            var tarefa = new Tarefa { UserId = 1 };
            _mockMapper.Setup(m => m.Map<Tarefa>(model)).Returns(tarefa);
            _mockRepo.Setup(repo => repo.Add(tarefa));
            _mockRepo.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            // Act
            var result = await _controller.Adicionar(model);

            // Assert
            var okResult = result as OkResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Editar_ReturnsBadRequest_QuandoUsuario_NaoTemPermissao_Alterar()
        {
            // Arrange
            var model = new TarefaAlterarModel { TarefaId = 1 };
            _mockRepo.Setup(repo => repo.PermissaoUsuario(It.IsAny<int>())).Returns(false);

            // Act
            var result = await _controller.Editar(model);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Should().NotBeNull();
            badRequestResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
            badRequestResult.Value.Should().Be("Usuário não tem permissão para alterar!");
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_QuandoUsuario_NaoTemPermissao_Deletar()
        {
            // Arrange
            int tarefaId = 1;
            _mockRepo.Setup(repo => repo.PermissaoUsuario(It.IsAny<int>())).Returns(false);

            // Act
            var result = await _controller.Delete(tarefaId);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Should().NotBeNull();
            badRequestResult.Value.Should().Be("Usuário não tem permissão para deletar!");
        }
    }
}
