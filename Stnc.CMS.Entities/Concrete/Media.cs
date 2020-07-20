using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    class Media : ITablo
    {

        public int Id { get; set; }
        public string Filename { get; set; }
        public string OrginalFilename { get; set; }
        public string Description { get; set; }
        public DateTime AddTime { get; set; } = DateTime.Now;
        public int BlogId { get; set; }

    }
}
