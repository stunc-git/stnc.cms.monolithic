using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DekamProjeDeneyHayvaniTurMap : IEntityTypeConfiguration<DekamProjeDeneyHayvaniTur>
    {
        public void Configure(EntityTypeBuilder<DekamProjeDeneyHayvaniTur> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(500).IsRequired();

            //builder
            //    .HasOne(I => I.DeneyHayvaniTurID)
            //    .WithOne(I => I.DekamProjeTeknikDestekTalepTur)
            //    .HasForeignKey(I => I.AciliyetId);

            //https://www.learnentityframeworkcore.com/configuration/one-to-one-relationship-configuration
            //burada kaldım
            // builder.HasOne(I => I.Aciliyet).WithMany(I => I.Gorevler).HasForeignKey(I => I.AciliyetId);

            builder.HasMany(I => I.DekamProjeTakip).WithOne(I => I.DekamProjeDeneyHayvaniTur).HasForeignKey(I => I.DeneyHayvaniTurID).OnDelete(DeleteBehavior.SetNull);
          //  builder.HasMany(I => I.Posts).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}