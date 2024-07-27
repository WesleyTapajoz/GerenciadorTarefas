namespace GerenciadorTarefas.WebAPI.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual List<TarefaModel> Tarefas { get; set; }
    }
}
