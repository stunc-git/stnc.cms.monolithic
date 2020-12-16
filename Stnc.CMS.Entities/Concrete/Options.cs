using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class Options : ITablo
    {
        public long Id { get; set; }

        public string OptionName { get; set; }

        public string OptionValue { get; set; }
        public string DefaultValue { get; set; }

        public string Autoload { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}