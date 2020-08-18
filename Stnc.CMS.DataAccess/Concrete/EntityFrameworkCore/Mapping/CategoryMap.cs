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
            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Category).HasForeignKey(I => I.CategoryID);
            /*
            builder.HasData(
                  new Category
                  {
                      Id = 1,//Guid.NewGuid(),
                      Name = "Genel",
                  },
                  new Category
                  {
                      Id = 2,
                      Name = "Kurumsal",
                  }, new Category
                  {
                      Id = 3,
                      Name = "Yönetim",
                  }, new Category
                  {
                      Id = 4,
                      Name = "Belge Bilgi",
                  }, new Category
                  {
                      Id = 5,
                      Name = "Galeri",
                  }, new Category
                  {
                      Id = 6,
                      Name = "İletişim",
                  }, new Category
                  {
                      Id = 7,
                      Name = "Duyurular",
                  }
          );*/
        }
    }
}