using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DekamProjeDeneyHayvanSayisiMap : IEntityTypeConfiguration<DekamProjeDeneyHayvanSayisi>
    {
        public void Configure(EntityTypeBuilder<DekamProjeDeneyHayvanSayisi> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(500).IsRequired();
        }
    }
}