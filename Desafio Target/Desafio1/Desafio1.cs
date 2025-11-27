using Desafio_Target.Desafio1.Model;
using System.Text.Json;

namespace Desafio_Target.Desafio1;

public static class Desafio1
{
    public static void Desafio()
    {
        string projectDir =
        Directory.GetParent(AppContext.BaseDirectory)!
             .Parent!
             .Parent!
             .Parent!.FullName;

        string caminho = Path.Combine(projectDir, "Base", "comissoes.json");

        var json = File.ReadAllText(caminho);

        var vendas = JsonSerializer.Deserialize<Venda>(json);
        var comissoes = ComissaoCalculo.Calcular(vendas!);

        Console.WriteLine("COMISSÃO TOTAL POR VENDEDOR");

        foreach (var comissao in comissoes)
        {
            Console.WriteLine($"Vendedor: {comissao.Vendedor} - Comissão: R$ {comissao.ValorComissao:N2}");
        }
    }
}
