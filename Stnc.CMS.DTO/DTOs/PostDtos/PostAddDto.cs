using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostAddDto
    {
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public string PostSlug { get; set; }
        public string Picture { get; set; }
        public int MenuOrder { get; set; } = 1;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public CategoryBlogs CategoryBlogs { get; set; }

    }
}
