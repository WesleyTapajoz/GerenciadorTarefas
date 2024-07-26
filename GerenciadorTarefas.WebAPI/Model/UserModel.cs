namespace GerenciadorTarefas.WebAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
