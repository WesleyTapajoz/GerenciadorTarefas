using GerenciadorTarefas.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string username);
        Task<User> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(User user, string password);
        Task<User> CreateAccountAsync(User user, string role);
        Task<string> CreateToken(User userUpdateDto);
    }
}
