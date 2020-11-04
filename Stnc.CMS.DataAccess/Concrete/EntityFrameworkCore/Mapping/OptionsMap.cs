using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OptionsMap : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.OptionName).HasMaxLength(200);
            builder.Property(I => I.OptionValue).HasColumnType("ntext");
            builder.Property(I => I.DefaultValue).HasColumnType("ntext");
            builder.Property(I => I.Autoload).HasMaxLength(20);

            builder.HasData(new Options
            {
                Id = 1,
                OptionName = "front-menu",
                OptionValue = "",
            }); ;
        }
    }
}