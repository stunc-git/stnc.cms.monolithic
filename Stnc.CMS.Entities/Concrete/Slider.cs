﻿using Stnc.CMS.Entities.Interfaces;
using System;

namespace Stnc.CMS.Entities.Concrete
{
    public class Slider : ITablo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string UrlAddress { get; set; }
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
    }


}