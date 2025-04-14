using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrca.Models;

namespace MyOrca.Data.Mappings;

public class ContaFinanceiraMap : IEntityTypeConfiguration<ContaFinanceira>
{
    public void Configure(EntityTypeBuilder<ContaFinanceira> builder)
    {
        builder.ToTable("ContaFinanceira");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar")
            .HasMaxLength(100);
        builder.Property(x=>x.Banco)
            .IsRequired()
            .HasColumnName("Banco")
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x=>x.Numero)
            .IsRequired()
            .HasColumnName("Numero")
            .HasColumnType("varchar")
            .HasMaxLength(30);
        builder.Property(x=>x.Tipo)
            .IsRequired()
            .HasColumnName("Tipo")
            .HasColumnType("char")
            .HasMaxLength(2);
        builder.Property(x => x.Saldo)
            .IsRequired()
            .HasColumnName("Saldo")
            .HasColumnType("decimal(14,2)")
            .HasDefaultValue(0.00);
        //index
        builder.HasIndex(x=>x.Nome, "IX_ContaFinanceira_Nome")
            .IsUnique();
        // Realcionamentos
        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.ContaFinanceiras)
            .HasConstraintName("FK_ContaFinanceira_Usuario")
            .OnDelete(DeleteBehavior.Cascade);
        
        
        

    }
}