using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GerenciadorTarefas.WebAPI
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Em Progresso")]
        EmProgresso = 1,
        [Description("Concluído")]
        Concluido = 2
    }
}
