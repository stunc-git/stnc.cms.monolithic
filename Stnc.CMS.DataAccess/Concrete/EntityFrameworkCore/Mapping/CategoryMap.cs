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
            //builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Category).HasForeignKey(I => I.CategoryID);

            /*
            builder.HasData(
                  new Category
                  {
                      Name = "Genel",
                  },
                  new Category
                  {
                      Name = "Kurumsal",
                  }, new Category
                  {
                      Name = "Yönetim",
                  }, new Category
                  {
                      Name = "Belge Bilgi",
                  }, new Category
                  {
                      Name = "Galeri",
                  }, new Category
                  {
                      Name = "İletişim",
                  }, new Category
                  {
                      Name = "Duyurular",
                  }
          );*/
        }
    }
}