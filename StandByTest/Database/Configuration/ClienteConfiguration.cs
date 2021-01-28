using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandByTest.Models;

namespace StandByTest.Database.Configuration {
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> {
        public void Configure(EntityTypeBuilder<Cliente> builder) {
            builder.ToTable("Cliente");

            builder.Property(c => c.Id)
                .HasColumnName("ClienteId")
                .IsRequired();

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("razao_social")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(c => c.DataFundacao)
                .HasColumnName("data_fundacao")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.Cnpj)
                .HasColumnName("cnpj")
                .HasColumnType("varchar(max)");

            builder.Property(c => c.Capital)
                .HasColumnName("capital")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(c => c.Quarentena)
                .HasColumnName("quarentena")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnName("status_cliente")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(c => c.Classificacao)
                .HasColumnName("classificacao")
                .HasColumnType("char(1)");
        }
    }
}
