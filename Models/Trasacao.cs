namespace MyOrca.Models;

public class Trasacao
{
    public int Id { get; set; }
    
    //public int IdSubCategoria { get; set; }
    public SubCategoria? SubCategoria { get; set; }
    //public int IdCFinanceira { get; set; }
    public ContaFinanceira? ContaFinanceira { get; set; }
    
    public string? Descricao { get; set; }
    public bool Tipo { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
}