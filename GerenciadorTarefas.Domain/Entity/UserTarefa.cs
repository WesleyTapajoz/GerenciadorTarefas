using GerenciadorTarefas.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Domain.Entity
{
    public class UserTarefa
    {
        public int TarefaId { get; set; }
        public Tarefa tarefa { get; set; }
        public int Id { get; set; }
        public User User { get; set; }

    }
}
