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
        public string FullName { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public virtual List<Tarefa> Tarefas { get; set; }


    }
}
