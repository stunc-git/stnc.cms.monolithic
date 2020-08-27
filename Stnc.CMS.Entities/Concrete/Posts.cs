using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class Posts : ITablo
    {
        public int Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public bool PostStatus { get; set; } = true;
        public bool CommentStatus { get; set; } = false;
        public string PostPassword { get; set; }
        public string PostSlug { get; set; }
        public int MenuOrder { get; set; } = 1;
        public int ?PostType { get; set; }
        public long CommentCount { get; set; }
        public string Picture { get; set; } = "default.jpg";
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        //public List<CategoryBlogs> CategoryBlogs { get; set; }
        //  public List<Comments> Comments { get; set; }
    }
}
