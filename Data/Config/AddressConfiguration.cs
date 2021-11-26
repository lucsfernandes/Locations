using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locations.Data.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<Locations.Models.Address>
    {
        public void Configure(EntityTypeBuilder<Locations.Models.Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.id);
            builder.HasIndex(x => x.id);

            builder.Property(x => x.type).HasMaxLength(125).IsRequired();
            builder.Property(x => x.cep).HasMaxLength(8).IsRequired();
            builder.Property(x => x.address).HasMaxLength(200).IsRequired();
            builder.Property(x => x.number).HasMaxLength(25).IsRequired();
            builder.Property(x => x.complement).HasMaxLength(100);
            builder.Property(x => x.neighborhood).HasMaxLength(150).IsRequired();
            builder.Property(x => x.city).HasMaxLength(100).IsRequired();
            builder.Property(x => x.uf).HasMaxLength(2).IsRequired();
            builder.Property(x => x.country).HasMaxLength(50).IsRequired();
            builder.Property(x => x.status).HasMaxLength(5).IsRequired();
            builder.Property(x => x.latitude).HasMaxLength(15).IsRequired();
            builder.Property(x => x.longitude).HasMaxLength(15).IsRequired();
            builder.Property(x => x.professional_id).HasMaxLength(150);
            builder.Property(x => x.patient_id).HasMaxLength(159);
        }
    }
}
