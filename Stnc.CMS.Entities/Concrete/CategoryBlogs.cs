using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.Entities.Concrete
{
    public class CategoryBlogs : ITablo
    {
        public int Id { get; set; }
        public int PostID { get; set; }
        public Posts Posts { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
