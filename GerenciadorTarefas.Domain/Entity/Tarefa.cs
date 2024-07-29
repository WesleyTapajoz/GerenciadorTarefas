using GerenciadorTarefas.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Domain.Entity
{
    [Table("Tarefa")]
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
