using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SliderMap : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Caption).HasMaxLength(250);
            builder.Property(I => I.Excerpt).HasColumnType("ntext");
            builder.Property(I => I.MenuOrder).HasMaxLength(255).HasDefaultValue(1);
            builder.Property(I => I.Picture).HasColumnType("ntext").IsRequired();
            builder.Property(I => I.UrlType).HasColumnType("smallint");

            //
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();

            builder.HasData(new Slider
            {
                Id = i,
                Caption = "Lorem ipsum laramde loremde ipsumda inmpala",
                Excerpt = "exceprt data loremmmmmm ipsummmmm",
                // UrlType = Convert.ToInt16(1),
                UrlAddress = "",
                Status = true,
            });
        }
    }
}