using System.Text.Json.Serialization;

namespace GerenciadorTarefas.WebAPI
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleEnum
    { 
        Administrator,
        User  
    }
}
