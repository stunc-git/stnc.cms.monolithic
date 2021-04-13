using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SiparislerMap : IEntityTypeConfiguration<Siparisler>
    {
        public void Configure(EntityTypeBuilder<Siparisler> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.ProjeYurutucusu).HasMaxLength(500).IsRequired();
            builder.Property(I => I.ProjeYurutukurumu).HasMaxLength(500).IsRequired();
            builder.Property(I => I.ProjeYurutuTelefon).HasMaxLength(500).IsRequired();
            builder.Property(I => I.SorumluArastirmaci).HasMaxLength(500).IsRequired();
            builder.Property(I => I.SorumluArastirmaciTelefon).HasMaxLength(500).IsRequired();
            builder.Property(I => I.EtikKurulOnayNumarasi).HasMaxLength(500).IsRequired();
            //builder.Property(I => I.DeneyHayvaniSayisi).HasColumnType("smallint");
            //builder.Property(I => I.DeneyHayvaniCinsiyet).HasColumnType("smallint");
            //
            //builder.Property(I => I.DeneyHayvaniYasi).HasColumnType("smallint");
            //builder.Property(I => I.DeneyHayvaniAgirligi).HasColumnType("smallint");

            builder.HasOne(I => I.DekamProjeLaboratuvarlar).WithMany(x => x.Siparisler).HasForeignKey(I => I.LaboratuvarID);
   

            //https://www.learnentityframeworkcore.com/configuration/one-to-one-relationship-configuration
            //burada kaldım
            //     builder.HasOne(I => I.Aciliyet).WithMany(I => I.Gorevler).HasForeignKey(I => I.AciliyetId);

            //    builder.HasOne(I => I.DekamProjeDeneyHayvaniTur).WithMany(I => I.DekamProjeTakip).HasForeignKey(I => I.DeneyHayvaniTurID);
        }
    }
}