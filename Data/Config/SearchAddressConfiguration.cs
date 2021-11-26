using Locations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locations.Data.Config
{
    public class SearchAddressConfiguration : IEntityTypeConfiguration<SearchAddress>
    {
        public void Configure(EntityTypeBuilder<SearchAddress> builder)
        {
            builder.ToTable("basecep_integrada");

            builder.HasKey(x => x.CEP);
            builder.Property(x => x.CEP).HasMaxLength(8).IsRequired();
            builder.HasIndex(x => x.CEP);
            builder.Property(x => x.CHAVE).HasMaxLength(8).HasDefaultValue(null);
            builder.Property(x => x.UF).HasMaxLength(2).HasDefaultValue(null);
            builder.HasIndex(x => x.UF);
            builder.Property(x => x.Tipo_Oficial).HasMaxLength(50).HasDefaultValue(null);
            builder.Property(x => x.Tipo_Acento).HasMaxLength(50).HasDefaultValue(null);
            builder.HasIndex(x => x.Tipo_Acento);
            builder.Property(x => x.Nome_Oficial).HasMaxLength(100).HasDefaultValue(null);
            builder.Property(x => x.Nome_Acento).HasMaxLength(100).HasDefaultValue(null);
            builder.HasIndex(x => x.Nome_Acento);
            builder.Property(x => x.Bairro1_Oficial).HasMaxLength(72).HasDefaultValue(null);
            builder.Property(x => x.Bairro1_Acento).HasMaxLength(72).HasDefaultValue(null);
            builder.Property(x => x.Cidade_Oficial).HasMaxLength(80).HasDefaultValue(null);
            builder.Property(x => x.Cidade_Acento).HasMaxLength(80).HasDefaultValue(null);
            builder.Property(x => x.Cod_Mun).HasMaxLength(7).HasDefaultValue(null);
            builder.Property(x => x.LIMINFPAR).HasDefaultValue(null);
            builder.Property(x => x.LIMINFIMPA).HasDefaultValue(null);
            builder.Property(x => x.LIMSUPPAR).HasDefaultValue(null);
            builder.Property(x => x.LIMSUPIMPA).HasDefaultValue(null);
            builder.Property(x => x.FLAGS).HasDefaultValue(null);
            builder.Property(x => x.LADOS).HasDefaultValue(null);
            builder.Property(x => x.latitude).HasMaxLength(15).HasDefaultValue(null);
            builder.Property(x => x.longitude).HasMaxLength(15).HasDefaultValue(null);
            builder.Property(x => x.log_complemento).HasMaxLength(100).HasDefaultValue(null);
            builder.Property(x => x.nome_cep_esp).HasMaxLength(80).HasDefaultValue(null);
            builder.Property(x => x.DDD).HasMaxLength(3).HasDefaultValue(null);
        }
    }
}
