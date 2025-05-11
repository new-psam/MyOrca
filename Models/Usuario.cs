namespace MyOrca.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Celular { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Slug { get; set; }

    public IList<ContaFinanceira>? ContaFinanceiras { get; set; }
    public IList<Role>? Roles { get; set; }
}