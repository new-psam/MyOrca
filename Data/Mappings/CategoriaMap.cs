using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrca.Models;

namespace MyOrca.Data.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(100);
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(100);
        builder.HasIndex(x => x.Slug, "IX_Categoria_Slug")
            .IsUnique();
        
            
    }
}