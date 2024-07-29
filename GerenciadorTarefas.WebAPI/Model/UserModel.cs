namespace GerenciadorTarefas.WebAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PrimeiroNome { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public virtual List<TarefaModel> Tarefas { get; set; }
    }
}
