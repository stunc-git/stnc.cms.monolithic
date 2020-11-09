using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DekamProjeTeknikDestekTalepTurMap : IEntityTypeConfiguration<DekamProjeTeknikDestekTalepTur>
    {
        public void Configure(EntityTypeBuilder<DekamProjeTeknikDestekTalepTur> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(500).IsRequired();

            builder.HasData(new DekamProjeTeknikDestekTalepTur
            {
              Id = 1,
              Name= "MADDE UYGULAMA (ENJEKSİYON, GAVAJ v.s.) ÜCRETİ",
              Price=1
            });

        }
    }
}