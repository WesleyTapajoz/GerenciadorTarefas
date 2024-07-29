using GerenciadorTarefas.Domain.Identity;

namespace GerenciadorTarefas.WebAPI.Model
{
    public class TarefaAddModel
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusEnum Status { get; set; } 
    }
}
