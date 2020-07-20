using System;
using System.Collections.Generic;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Entities.Concrete
{
    public class Posts : ITablo
    {
        public long Id { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDateGmt { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public string PostExcerpt { get; set; }
        public string PostStatus { get; set; }
        public string CommentStatus { get; set; }
        public string PostPassword { get; set; }
        public string PostSlug { get; set; }
        public int MenuOrder { get; set; }
        public string PostType { get; set; }
      
        public long CommentCount { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }

        public List<Comments> Comments { get; set; }



    }
}
