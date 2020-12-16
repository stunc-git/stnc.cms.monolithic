using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DTO.DTOs.GorevDtos;

namespace Stnc.CMS.DTO.DTOs.AppUserDtos
{
    public class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public GorevListDto Gorev { get; set; }
    }
}
