using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.CommentContent).HasColumnType("ntext");
            builder.Property(I => I.CommentAuthor).HasMaxLength(100).IsRequired();
            builder.Property(I => I.CommentAuthorEmail).HasMaxLength(100).IsRequired();
            builder.Property(I => I.CommentAuthorUrl).HasMaxLength(255).IsRequired();
            builder.Property(I => I.CommentAuthorIP).HasMaxLength(255).IsRequired();
            builder.Property(I => I.CommentApproved).HasMaxLength(1).HasDefaultValue(0);
            builder.Property(I => I.CommentAgent).HasMaxLength(255).IsRequired();
            builder.Property(I => I.CommentType).HasMaxLength(255).IsRequired();
            builder.Property(I => I.CommentParent).HasMaxLength(255).IsRequired();

            builder.HasMany(I => I.SubComments).WithOne(I => I.ParentComment).HasForeignKey(I => I.ParentCommentId);
        }
    }
}