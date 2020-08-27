using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostListAllDto
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostSlug { get; set; }
        public string PostExcerpt { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

        // public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        //   public List<CategoryBlogs> CategoryBlogs { get; set; }
    }
}