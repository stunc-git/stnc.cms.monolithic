﻿using Microsoft.EntityFrameworkCore;
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

        }
    }
}