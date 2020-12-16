using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Slug).HasMaxLength(100);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.HasMany(I => I.Posts).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);

            //builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Category).HasForeignKey(I => I.CategoryID);

            builder.HasData(new Category
            {
              Id = 1,
              Name="Genel",
              Slug="genel",
            });

          
        }
    }
}