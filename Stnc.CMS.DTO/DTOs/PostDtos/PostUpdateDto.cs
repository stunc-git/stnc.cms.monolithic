﻿using System;

namespace Stnc.CMS.DTO.DTOs.PostDtos
{
    public class PostUpdateDto
    {
        public long Id { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostExcerpt { get; set; }
        //public bool PostStatus { get; set; } = true;
        //public bool CommentStatus { get; set; } = false;
        //public string PostPassword { get; set; } = "0";
        public string PostSlug { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
