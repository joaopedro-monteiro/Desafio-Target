using System.Text.Json.Serialization;

namespace Desafio_Target.Desafio1.Model;

public class Venda
{
    [JsonPropertyName("vendas")]
    public List<Vendedor> Vendas { get; set; } = [];
}
