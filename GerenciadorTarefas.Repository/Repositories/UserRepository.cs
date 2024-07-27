using GerenciadorTarefas.Domain.Identity;
using GerenciadorTarefas.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User ValidatorCredentials { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
