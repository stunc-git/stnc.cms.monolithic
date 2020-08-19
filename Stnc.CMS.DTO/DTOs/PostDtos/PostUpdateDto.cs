using System;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostUpdateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public string Picture { get; set; }

        public string PostSlug { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
