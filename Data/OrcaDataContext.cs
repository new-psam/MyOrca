using Microsoft.EntityFrameworkCore;
using MyOrca.Data.Mappings;
using MyOrca.Models;

namespace MyOrca.Data;

public class OrcaDataContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<ContaFinanceira> ContaFinanceiras { get; set; }
    public DbSet<SubCategoria> SubCategorias { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=localhost, 1433; Database=MyOrca; User Id=sa; Password=1q2w3e4r@#$;
                            Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new ContaFinanceiraMap());
        modelBuilder.ApplyConfiguration(new SubCategoriaMap());
        modelBuilder.ApplyConfiguration(new TransacaoMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
    }
}