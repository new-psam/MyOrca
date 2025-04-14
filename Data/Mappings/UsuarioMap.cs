using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrca.Models;

namespace MyOrca.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(100);
        builder.Property(x => x.Senha)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(10);
        builder.Property(x=>x.Cpf)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(20);
        builder.Property(x=>x.Celular)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(20);
        builder.Property(x=>x.Username)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(100);
        builder.HasIndex(x=>x.Username, "IX_USUARIO_Username")
            .IsUnique();
        
        
    }
}