using Desafio_Target.Desafio1.Model;

namespace Desafio_Target.Desafio1;

public static class ComissaoCalculo
{
    public static List<Comissao> Calcular(Venda vendas)
    {
        var vendasPorNome = vendas.Vendas.GroupBy(v => v.VendedorNome).ToList();

        var comissoes = new List<Comissao>();

        foreach (var vendaPorNome in vendasPorNome)
        {
            var comissao = 0m;
            foreach (var venda in vendaPorNome)
            {
                switch (venda.Valor)
                {
                    case >= 100 and < 500:
                        comissao += venda.Valor * 0.01m;
                        break;
                    case >= 500:
                        comissao += venda.Valor * 0.05m;
                        break;
                }
            }
            comissoes.Add(new Comissao
            {
                Vendedor = vendaPorNome.Key,
                ValorComissao = comissao
            });
        }
        
        return comissoes;
    }
}
