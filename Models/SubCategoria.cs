namespace MyOrca.Models;

public class SubCategoria
{
    public int Id { get; set; }
   
    //public int IdCategoria { get; set; }
    public Categoria? Categoria { get; set; }
    
    public string? Nome { get; set; }
    public string? Slug { get; set; }
}