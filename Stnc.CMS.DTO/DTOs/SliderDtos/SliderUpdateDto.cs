using Stnc.CMS.Entities.Concrete;
using System;

namespace Stnc.CMS.DTO.DTOs.SliderDtos
{
    public class SliderUpdateDto
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string UrlAddress { get; set; }
      //  public UrlAddressOpenType UrlType { get; set; }
        public int UrlType { get; set; }
        public string Excerpt { get; set; }
        public bool Status { get; set; } = true;
        public int MenuOrder { get; set; } = 1;
        public string Picture { get; set; } = "default.jpg";
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public enum UrlAddressOpenType
        {
            _target,
            _blank,
        }
    }
}
