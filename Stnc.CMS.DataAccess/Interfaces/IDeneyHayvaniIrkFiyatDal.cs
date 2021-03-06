﻿using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IDeneyHayvaniIrkFiyatDal : IGenericDal<DekamProjeDeneyHayvaniIrkFiyat>
    {
        List<DeneyHayvaniIrkFiyatListAllDto> DeneyHayvaniIrkFiyatListesi();
        List<DeneyHayvaniIrkFiyatAjaxListDto> DeneyHayvaniIrkFiyatListesiID(int ID);

        List<DeneyHayvaniIrkFiyatAjaxListDto> DeneyHayvaniIrkFiyatListesiTurID(int TurID);

        List<DeneyHayvaniIrkFiyatAjaxListDto> DeneyHayvaniIrkFiyatListesiIrkID(int IrkID);

        DeneyHayvaniIrkFiyatAjaxListDto GetDeneyHayvaniIrkFiyatID(int ID);

        ///shop cart ozellikleri 
        ///




    }
}