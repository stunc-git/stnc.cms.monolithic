using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Stnc.CMS.Entities.Concrete
{
    public class Comments : ITablo
    {
        public long Id { get; set; }
        public long PostID { get; set; }
        public long? ParentCommentId { get; set; }

        public long UserId { get; set; }
        public string CommentContent { get; set; }
        public string CommentAuthor { get; set; }
        public string CommentAuthorEmail { get; set; }
        public string CommentAuthorUrl { get; set; }
        public string CommentAuthorIP { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public DateTime? CommentDateGmt { get; set; } = DateTime.Now;

        public string CommentApproved { get; set; }
        public string CommentAgent { get; set; }
        public string CommentType { get; set; }
        public long CommentParent { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

        public Comments ParentComment { get; set; }
        public List<Comments> SubComments { get; set; }
        public DekamProjeTakip Posts { get; set; }
    }
}