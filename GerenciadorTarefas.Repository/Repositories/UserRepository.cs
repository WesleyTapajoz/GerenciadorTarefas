using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public readonly SymmetricSecurityKey _key;

        public UserRepository(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]));
            _roleManager = roleManager;
            _roleManager = roleManager;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
                if (user == null) return null;

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar Usuário por Username. Erro: {ex.Message}");
            }
        }

        public async Task<SignInResult> CheckUserPasswordAsync(User user, string password)
        {
            try
            {
                var ret = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == user.UserName.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(ret, password, false);
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

        public async Task<User> CreateAccountAsync(User user, string role)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                await _userManager.AddToRoleAsync(user, role);

                if (result.Succeeded)
                {
                    return user;
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar Criar Usuário. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users
                                         .AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }
        }

        public async Task<string> CreateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
