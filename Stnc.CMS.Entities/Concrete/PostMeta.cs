using System;

namespace Stnc.CMS.Entities.Concrete
{
    internal class PostMeta
    {
        public long Id { get; set; }

        public long PostID { get; set; }

        public string MetaKey { get; set; }

        public string MetaValue { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}