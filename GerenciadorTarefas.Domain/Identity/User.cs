using GerenciadorTarefas.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
