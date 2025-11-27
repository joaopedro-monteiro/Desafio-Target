using Desafio_Target.Desafio2.Model;
using System.Text.Json;

namespace Desafio_Target.Desafio2;

public class Desafio2
{
    public static void Desafio()
    {
        string projectDir =
        Directory.GetParent(AppContext.BaseDirectory)!
             .Parent!
             .Parent!
             .Parent!.FullName;

        string caminho = Path.Combine(projectDir, "Base", "estoque.json");

        var json = File.ReadAllText(caminho);

        var estoque = JsonSerializer.Deserialize<Estoque>(json);

        MovimentacaoEstoque.MovimentarEstoque(estoque!);

        Console.ReadLine();
    }
}
