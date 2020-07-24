using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostAddDto
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        public bool PostStatus { get; set; }
        public bool CommentStatus { get; set; }
        public string PostPassword { get; set; }
        public string PostSlug { get; set; }
        public int MenuOrder { get; set; }
        public long CommentCount { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

    }
}
