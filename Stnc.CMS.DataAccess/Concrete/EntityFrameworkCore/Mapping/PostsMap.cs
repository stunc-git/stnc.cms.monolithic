using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.PostTitle).HasMaxLength(250).IsRequired();
            builder.Property(I => I.PostExcerpt).HasColumnType("ntext");
            builder.Property(I => I.PostContent).HasColumnType("ntext");

            builder.Property(I => I.PostPassword).HasMaxLength(255);
            builder.Property(I => I.PostType).HasColumnType("smallint").HasDefaultValue(1);
            builder.Property(I => I.PostSlug).HasMaxLength(255);
            builder.Property(I => I.MenuOrder).HasMaxLength(255).HasDefaultValue(1);
            builder.Property(I => I.CommentCount).HasDefaultValue(1);
            builder.Property(I => I.Picture).HasColumnType("ntext");
            builder.HasOne(I => I.Category)
                .WithMany(I => I.Posts)
                .HasForeignKey(I => I.CategoryId);

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

            //builder.HasMany(I => I.Comments).WithOne(I => I.Posts).HasForeignKey(I => I.PostID);
            //   builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Posts).HasForeignKey(I => I.PostID);

            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();

            builder.HasData(new Posts
            {
                Id = i,
                CategoryId = 1,
                PostTitle = "HAKKIMIZDA",
                PostContent = "<p>Erciyes Üniversitesi Tıp Fakültesine bağlı bir merkez olarak; Hakan ÇETİNSAYA’nın (1976-1996) anısına, amcası hayırsever işadamı Sayın Süleyman ÇETİNSAYA tarafından yaptırılan merkez 1997 tarihinde hizmete açılmıştır. </ p >< p >< img src = \"/upload/file/tarihce-res1.jpg\" >< br ></ p >< p >•Hakan Çetinsaya Deneysel ve Klinik Araştırma Merkez'inde kurulduğu günden itibaren çok sayıda deneysel çalışmalar yapılmış ve bu çalışmalar ulusal ve uluslar arası dergilerde yayınlanmış, kongrelerde sunulmuş ve çeşitli ödüller almıştır.•21 Haziran 2013 tarihli ve 28684 sayılı Resmi Gazete’de yayımlanan Yönetmelik kapsamında Erciyes Üniversitesi \"Deneysel Araştırmalar Uygulama ve Araştırma Merkezi - DEKAM\" olarak isimlendirildi. </ p > ",
                PostStatus = true,
                CommentStatus = false,
                PostSlug = "hakkimizda",
                MenuOrder = 1,
                AppUserId=1,
            }); 
        }
    }
}