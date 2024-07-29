using Xunit;
using GerenciadorTarefas.Repository.Repositories;
using GerenciadorTarefas.Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Microsoft.Extensions.Configuration;

namespace GerenciadorTarefas.Testes.Unidade.Controllers
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<SignInManager<User>> _signInManagerMock;
        private readonly Mock<RoleManager<Role>> _roleManagerMock;
        private readonly Mock<IConfiguration> _configMock;

        public UserRepositoryTests()
        {
            _userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                null, null, null, null, null, null, null, null);

            _signInManagerMock = new Mock<SignInManager<User>>(
                _userManagerMock.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                null, null, null, null);

            _roleManagerMock = new Mock<RoleManager<Role>>(
                new Mock<IRoleStore<Role>>().Object,
                null, null, null, null);

            _configMock = new Mock<IConfiguration>();
            _configMock.Setup(c => c["AppSettings:Token"]).Returns("super_secret_key");

            _userRepository = new UserRepository(
                _configMock.Object,
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _roleManagerMock.Object);
        }

        [Fact]
        public async Task GetUserByUserNameAsync_ReturnsUser_DeveGerarException()
        {
            // Arrange
            var user = new User { UserName = "NovoUsuarioFake" };
            _userManagerMock.Setup(x => x.Users).Returns(new List<User> { user }.AsQueryable());

            //Act && Assert
            await Assert.ThrowsAsync<Exception>(async () =>
             await _userRepository.GetUserByUserNameAsync("NovoUsuarioFake").ConfigureAwait(false));
        }

        [Fact]
        public async Task CheckUserPasswordAsync_DeveGerarException()
        {
            // Arrange
            var user = new User { UserName = "NovoUsuarioFake" };
            _userManagerMock.Setup(x => x.Users).Returns(new List<User> { user }.AsQueryable());
            _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(user, "password", false))
                              .ReturnsAsync(SignInResult.Success);

            //Act && Assert
            await Assert.ThrowsAsync<Exception>(async () =>
             await _userRepository.CheckUserPasswordAsync(user, "password").ConfigureAwait(false));
        }

        [Fact]
        public async Task CreateAccountAsync_CreatesUser_DeveRetornarSucesso()
        {
            // Arrange
            var user = new User { UserName = "NovoUsuarioFake" };
            var role = "User";
            _userManagerMock.Setup(x => x.CreateAsync(user, user.PasswordHash))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userRepository.CreateAccountAsync(user, role);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NovoUsuarioFake", result.UserName);
        }

        [Fact]
        public async Task UserExists_DeveGerarException()
        {
            // Arrange
            var user = new User { UserName = "" };
            _userManagerMock.Setup(x => x.Users).Returns(new List<User> { user }.AsQueryable());

            //Act && Assert
            await Assert.ThrowsAsync<Exception>(async () =>
             await _userRepository.UserExists("").ConfigureAwait(false));
        }

    }

}
