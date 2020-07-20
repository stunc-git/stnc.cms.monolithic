using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class PostsMap : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {

            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.PostTitle).HasMaxLength(250).IsRequired();
            builder.Property(I => I.PostExcerpt).HasColumnType("ntext");
            builder.Property(I => I.PostContent).HasColumnType("ntext");
            builder.Property(I => I.PostStatus).HasMaxLength(1).IsRequired();
            builder.Property(I => I.CommentStatus).HasMaxLength(1);
            builder.Property(I => I.PostPassword).HasMaxLength(255);
            builder.Property(I => I.PostSlug).HasMaxLength(255);
            builder.Property(I => I.MenuOrder).HasMaxLength(255);
            builder.Property(I => I.PostType).HasDefaultValue(1); 
            builder.Property(I => I.CommentCount).HasDefaultValue(0); 
         

           //builder.HasMany(I => I.Comments).WithOne(I => I.Posts).HasForeignKey(I => I.PostID);

            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Posts).HasForeignKey(I => I.PostID);

        }
    }
}
