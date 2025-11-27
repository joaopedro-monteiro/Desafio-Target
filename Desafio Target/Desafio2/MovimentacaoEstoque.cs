using Desafio_Target.Desafio2.Model;

namespace Desafio_Target.Desafio2;

public static class MovimentacaoEstoque
{
    public static void MovimentarEstoque(Estoque estoque)
    {        
        ImprimirEstoque(estoque);
        LancaoMovimentacao(estoque);


        Console.WriteLine("DESEJA FAZER OUTRA MOVIMENTAÇÃO?");
        Console.WriteLine("1 - SIM");
        Console.WriteLine("2 - NÃO (Sair do Programa)");
        var novaOpcao = Console.ReadLine();
        while (novaOpcao != "1" && novaOpcao != "2")
        {
            Console.WriteLine("OPÇÃO INVÁLIDA! DIGITE 1 OU 2:");
            novaOpcao = Console.ReadLine();
        }
        if (novaOpcao == "1")
        {
            MovimentarEstoque(estoque);
        }
        if(novaOpcao == "2")
        {
            Console.WriteLine("Encerrando...");
            Environment.Exit(0);
        }
    }

    public static void LancaoMovimentacao(Estoque estoque)
    {
        var estoques = estoque.Estoques;

        Console.WriteLine("QUAL MOVIMENTAÇÃO DESEJA FAZER?");
        Console.WriteLine("1 - ENTRADA");
        Console.WriteLine("2 - SAÍDA");
        var opcao = Console.ReadLine();

        while ((opcao != "1" && opcao != "2"))
        {
            Console.WriteLine("OPÇÃO INVÁLIDA! DIGITE 1 OU 2:");
            opcao = Console.ReadLine();
        }

        int codigoProduto;
        while (true)
        {
            Console.WriteLine("DIGITE O CÓDIGO DO PRODUTO:");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out codigoProduto))
            {
                Console.WriteLine("CÓDIGO INVÁLIDO! DIGITE UM NÚMERO.");
                continue;
            }
            var produtoExiste = estoques.Any(e => e.CodigoProduto == codigoProduto);

            if (!produtoExiste)
            {
                Console.WriteLine("PRODUTO NÃO ENCONTRADO NO ESTOQUE! DIGITE UM CÓDIGO EXISTENTE.");
                continue;
            }
            break;
        }


        Console.WriteLine($"DIGITE A QUANTIDADE QUE DESEJA DAR {(opcao == "1" ? "ENTRADA" : "SAÍDA")}:");
        var quantidade = Console.ReadLine();
        while (!int.TryParse(quantidade, out var quantidadeInt) || quantidadeInt <= 0)
        {
            Console.WriteLine("QUANTIDADE INVÁLIDA! DIGITE UM NÚMERO VÁLIDO:");
            quantidade = Console.ReadLine();
        }

        var produtoSelecionado = estoques.First(e => e.CodigoProduto == codigoProduto);

        while (int.Parse(quantidade) > produtoSelecionado.Estoque && opcao == "2")
        {
            Console.WriteLine("QUANTIDADE MAIOR QUE O ESTOQUE ATUAL! DIGITE UMA QUANTIDADE VÁLIDA");
            Console.WriteLine($"ESTOQUE ATUAL DO PRODUTO {produtoSelecionado.DescricaoProduto}: {produtoSelecionado.Estoque}");
            Console.WriteLine($"DIGITE A QUANTIDADE QUE DESEJA DAR {(opcao == "1" ? "ENTRADA" : "SAÍDA")}:");
            quantidade = Console.ReadLine();
            while (!int.TryParse(quantidade, out var quantidadeInt) || quantidadeInt <= 0)
            {
                Console.WriteLine("QUANTIDADE INVÁLIDA! DIGITE UM NÚMERO VÁLIDO:");
                quantidade = Console.ReadLine();
            }
        }

        estoque.Estoques.Find(e => e.CodigoProduto == codigoProduto)!.Estoque += opcao == "1" ? int.Parse(quantidade) : -int.Parse(quantidade);
        produtoSelecionado = estoques.First(e => e.CodigoProduto == codigoProduto);



        Console.WriteLine("DIGITE A DESCRIÇÃO DA MOVIMENTAÇÃO");
        var descricaoMovimentacao = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(descricaoMovimentacao))
        {
            Console.WriteLine("DESCRIÇÃO INVÁLIDA! DIGITE UMA DESCRIÇÃO VÁLIDA:");
            descricaoMovimentacao = Console.ReadLine();
        }

        var movimentacao = new Movimentacao { Descricao = descricaoMovimentacao };
        Console.WriteLine();
        Console.WriteLine("DETALHES DA MOVIMENTAÇÃO:");
        Console.WriteLine($"ID: {movimentacao.Id}");
        Console.WriteLine($"DESCRIÇÃO: {movimentacao.Descricao}");
        Console.WriteLine();
        Console.WriteLine("PRODUTO MOVIMENTADO:");
        Console.WriteLine($"CÓDIGO: {produtoSelecionado.CodigoProduto}");
        Console.WriteLine($"DESCRIÇÃO: {produtoSelecionado.DescricaoProduto}");
        Console.WriteLine($"ESTOQUE ATUAL: {produtoSelecionado.Estoque}");
        Console.WriteLine();
    }

    public static void ImprimirEstoque(Estoque estoque)
    {
        foreach (var produto in estoque.Estoques)
        {
            Console.WriteLine($"Código: {produto.CodigoProduto}, Descrição: {produto.DescricaoProduto}, Estoque: {produto.Estoque}");
        }
    }
}
