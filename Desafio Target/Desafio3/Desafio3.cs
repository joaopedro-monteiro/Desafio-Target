namespace Desafio_Target.Desafio3;

public static class Desafio3
{
    public static void Desafio()
    {
        Console.WriteLine("=== CÁLCULO DE JUROS ===");        
        decimal valor;
        while (true)
        {
            Console.Write("DIGITE O VALOR: ");
            var inputValor = Console.ReadLine();

            if (decimal.TryParse(inputValor, out valor))
                break;

            Console.WriteLine("VALOR INVÁLIDO. TENTE NOVAMENTE.");
        }        
        DateTime dataVencimento;
        while (true)
        {
            Console.Write("DIGITE A DATA DE VENCIMENTO (dd/MM/yyyy): ");
            var inputData = Console.ReadLine();

            if (DateTime.TryParse(inputData, out dataVencimento))
                break;

            Console.WriteLine("DATA INVÁLIDA. TENTE NOVAMENTE.");
        }        
        DateTime hoje = DateTime.Today;
        int diasAtraso = (hoje - dataVencimento).Days;

        if (diasAtraso <= 0)
        {
            Console.WriteLine("PAGAMENTO EM DIA. NENHUM JURO APLICADO.");
            Console.WriteLine($"VALOR FINAL: R$ {valor:F2}");
            return;
        }        
        decimal multaPorDia = 0.025m;
        decimal juros = valor * multaPorDia * diasAtraso;

        decimal valorFinal = valor + juros;        
        Console.WriteLine("=== RESULTADO ===");
        Console.WriteLine($"DIAS EM ATRASO: {diasAtraso}");
        Console.WriteLine($"JUROS TOTAL: R$ {juros:F2}");
        Console.WriteLine($"VALOR FINAL A PAGAR: R$ {valorFinal:F2}");
    }
}
