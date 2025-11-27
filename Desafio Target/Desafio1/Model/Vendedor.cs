using System.Text.Json.Serialization;

namespace Desafio_Target.Desafio1.Model;

public class Vendedor
{
    [JsonPropertyName("vendedor")]
    public string VendedorNome { get; set; } = string.Empty;
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}
