using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostListAllDto
    {


        public long Id { get; set; }
  
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;
       // public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
