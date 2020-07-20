using Stnc.CMS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stnc.CMS.Entities.Concrete
{
  public class CategoryBlog : ITablo
    {
        public int Id { get; set; }
        public long PostID { get; set; }
        public Posts Posts { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
