using System;
namespace Stnc.CMS.DTO.DTOs.SliderDtos
{
    public class SliderListAllDto
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public bool Status { get; set; } = true;
        public string Picture { get; set; } = "default.jpg";
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}