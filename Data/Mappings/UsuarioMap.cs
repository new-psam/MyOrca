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
            .HasColumnName("Senha")
            .HasColumnType("varchar")
            .HasMaxLength(255);
        
        builder.Property(x=>x.Cpf)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(20);
        
        builder.Property(x=>x.Celular)
            .IsRequired(false)
            .HasColumnName("Celular")
            .HasColumnType("varchar")
            .HasMaxLength(20);
        
        builder.Property(x=>x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar")
            .HasMaxLength(160);
        
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
       
        // Indices
        builder
            .HasIndex(x=>x.Slug, "IX_USUARIO_Username")
            .IsUnique();
        
        //Relacionamentos
        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Usuarios)
            .UsingEntity<Dictionary<string, object>>(
                "UsuarioRole",
                role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UsuarioRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                usuario => usuario
                    .HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey("UsuarioId")
                    .HasConstraintName("FK_UsuarioRole_UsuarioId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}