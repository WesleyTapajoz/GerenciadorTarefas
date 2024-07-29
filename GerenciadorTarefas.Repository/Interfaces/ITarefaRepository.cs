using GerenciadorTarefas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Repository.Interfaces
{
    public interface ITarefaRepository : IRepository
    {
        public IEnumerable<Tarefa> GetByIdAndUserId(int id);
        public bool PermissaoUsuario(int id);
    }
}
