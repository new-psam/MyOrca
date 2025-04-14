using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrca.Models;

namespace MyOrca.Data.Mappings;

public class TransacaoMap : IEntityTypeConfiguration<Transacao>
{
   
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.ToTable("Transacao");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x=>x.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("varchar")
            .HasMaxLength(200);
        builder.Property(x => x.Tipo)
            .IsRequired()
            .HasColumnName("Tipo")
            .HasColumnType("char")
            .HasMaxLength(2);
        builder.Property(x => x.Data)
            .IsRequired()
            .HasColumnName("Data")
            .HasColumnType("datetime")
            //.HasDefaultValue(DateTime.Now.ToUniversalTime());
            .HasDefaultValueSql("getdate()");
        builder.Property(x => x.Valor)
            .IsRequired()
            .HasColumnName("Valor")
            .HasColumnType("decimal(14,2)");
       // Relacionamentos
       builder.HasOne(x=>x.ContaFinanceira)
           .WithMany(x=>x.Transacoes)
           .HasConstraintName("FK_ContaFinanceira_Transacao")
           .OnDelete(DeleteBehavior.Cascade);
       builder.HasOne(x=>x.SubCategoria)
           .WithMany(x=>x.Transacoes)
           .HasConstraintName("FK_SubCategoria_Transacao")
           .OnDelete(DeleteBehavior.Cascade);


    }
}
