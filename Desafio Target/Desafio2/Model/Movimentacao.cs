namespace Desafio_Target.Desafio2.Model;

public class Movimentacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Descricao { get; set; } = string.Empty;
}
