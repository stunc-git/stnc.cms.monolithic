using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{

    public class CategoryPostsMap : IEntityTypeConfiguration<CategoryBlogs>
        {
            public void Configure(EntityTypeBuilder<CategoryBlogs> builder)
            {
                builder.HasKey(I => I.Id);
                builder.Property(I => I.Id).UseIdentityColumn();
                builder.HasIndex(I => new { I.PostID, I.CategoryID }).IsUnique();

        }
    }
}
