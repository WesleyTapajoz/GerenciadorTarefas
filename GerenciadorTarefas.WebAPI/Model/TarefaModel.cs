using GerenciadorTarefas.Domain.Identity;

namespace GerenciadorTarefas.WebAPI.Model
{
    public class TarefaModel
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
        public virtual UserModel User { get; set; }
    }
}
