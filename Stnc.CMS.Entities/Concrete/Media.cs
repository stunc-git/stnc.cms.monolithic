using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    internal class Media : ITablo
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string OrginalFilename { get; set; }
        public string Description { get; set; }
        public DateTime AddTime { get; set; } = DateTime.Now;
        public int BlogId { get; set; }
    }
}