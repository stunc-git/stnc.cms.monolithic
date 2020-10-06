using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DekamProjeDeneyHayvaniIrkFiyatMap : IEntityTypeConfiguration<DekamProjeDeneyHayvaniIrkFiyat>
    {
        public void Configure(EntityTypeBuilder<DekamProjeDeneyHayvaniIrkFiyat> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Fiyat).HasColumnType("decimal(6,2)");
        }
    }
}