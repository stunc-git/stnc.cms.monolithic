using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
    class Links : ITablo
    {

    
        public long ID { get; set; }


        public string LinkUrl { get; set; }


        public string LinkName { get; set; }

        public string LinkImage { get; set; }


        public string LinkTarget { get; set; }


        public string LinkDescription { get; set; }


        public string LinkVisible { get; set; }

        public long LinkOwner { get; set; }

        public int LinkRating { get; set; }


        public DateTime LinkUpdated { get; set; }


        public string LinkRel { get; set; }

        public string LinkNotes { get; set; }


        public string LinkRss { get; set; }


        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }


        public DateTime? DeletedAt { get; set; }
    }
}
