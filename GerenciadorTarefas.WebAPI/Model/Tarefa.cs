namespace GerenciadorTarefas.WebAPI.Model
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioID { get; set; }
    }
}
