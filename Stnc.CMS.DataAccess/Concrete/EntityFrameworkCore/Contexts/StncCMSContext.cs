using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class StncCMSContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=bloggg; user id=sa; password=1;");
            optionsBuilder.UseSqlServer("server=.; database=cmsCore1; integrated security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new GorevMap());
            modelBuilder.ApplyConfiguration(new AciliyetMap());
            modelBuilder.ApplyConfiguration(new RaporMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new PostsMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryPostsMap());
            modelBuilder.ApplyConfiguration(new CommentMap());


            base.OnModelCreating(modelBuilder);
        }

      
        public DbSet<Gorev> Gorevler { get; set; }
   
        public DbSet<Aciliyet> Aciliyetler { get; set; }
        public DbSet<Rapor> Raporlar { get; set; }
        public DbSet<Bildirim> Bildirimler { get; set; }


        public DbSet<Posts> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
