using System;
using System.Collections.Generic;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Entities.Concrete
{
    public class Posts : ITablo
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public bool PostStatus { get; set; } = true;
        public bool CommentStatus { get; set; } = false;
        public string PostPassword { get; set; }
        public string PostSlug { get; set; }
        public int MenuOrder { get; set; } = 1;
        public long CommentCount { get; set; }
        public string? Picture { get; set; }


        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } 


        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }

      //  public List<Comments> Comments { get; set; }



    }
}
