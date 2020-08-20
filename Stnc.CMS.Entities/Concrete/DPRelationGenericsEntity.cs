using System;
using System.Collections.Generic;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Entities.Concrete
{
    public class DPRelationGenericsEntity : ITablo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

