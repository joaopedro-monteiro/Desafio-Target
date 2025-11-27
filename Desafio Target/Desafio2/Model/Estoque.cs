using System.Text.Json.Serialization;

namespace Desafio_Target.Desafio2.Model;

public class Estoque
{
    [JsonPropertyName("estoque")]
    public List<Produto> Estoques { get; set; } = [];
}
