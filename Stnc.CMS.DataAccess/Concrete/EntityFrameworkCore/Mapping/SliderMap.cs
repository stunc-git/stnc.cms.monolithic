using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SliderMap : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Caption).HasMaxLength(250).IsRequired();
            builder.Property(I => I.Excerpt).HasColumnType("ntext");
            builder.Property(I => I.MenuOrder).HasMaxLength(255).HasDefaultValue(1);
            builder.Property(I => I.Picture).HasColumnType("ntext");
            builder.Property(I => I.UrlType).HasColumnType("smallint");
        }
    }
}