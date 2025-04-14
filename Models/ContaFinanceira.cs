namespace MyOrca.Models;

public class ContaFinanceira
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Banco { get; set; }
    public string? Numero { get; set; }
    public decimal Saldo { get; set; }
    public char Tipo { get; set; }
    //public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }

    public List<Transacao>? Transacoes { get; set; }
}