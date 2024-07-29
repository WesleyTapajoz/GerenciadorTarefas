using AutoMapper;
using GerenciadorTarefas.Domain.Entity;
using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.Repository.Interfaces;
using GerenciadorTarefas.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorTarefas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IRepository _repo;

        public UserController(IConfiguration config,
                              IUserRepository userRepository,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IRepository repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _userRepository = userRepository;
            _repo = repo;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLogin)
        {
            try
            {
                var user = _mapper.Map<User>(userLogin);

                var ret = await _userRepository.GetUserByUserNameAsync(user.UserName);
                if (ret == null) return Unauthorized("Usuário ou Senha está errado");

                var result = await _userRepository.CheckUserPasswordAsync(user, userLogin.Password);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        userName = ret.UserName,
                        primeiroNome = ret.PrimeiroNome,
                        token = _userRepository.CreateToken(ret).Result,
                    });
                }

                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repo.GetAllAsync<User>();
                var results = _mapper.Map<UserLoginModel[]>(users);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserAdd userModel)
        {
            try
            {
                if (await _userRepository.UserExists(userModel.UserName))
                    return BadRequest("Usuário já existe");

                var user = _mapper.Map<User>(userModel);

                var result = await _userRepository.CreateAccountAsync(user, userModel.Role.ToString());
                if (result != null)
                    return Ok(new
                    {
                        userName = result.UserName,
                        token = _userRepository.CreateToken(user).Result
                    });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Registrar Usuário. Erro: {ex.Message}");
            }
        }

        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);


            }
            catch (System.Exception ex)
            {
                return $"Banco Dados Falhou {ex.Message}";
            }
        }
    }
}
