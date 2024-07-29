using GerenciadorTarefas.Domain.Identity;

namespace GerenciadorTarefas.WebAPI.Model
{
    public class UserAdd
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrimeiroNome { get; set; }
        public RoleEnum Role { get; set; }

    }
}
