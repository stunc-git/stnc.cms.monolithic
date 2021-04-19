using AutoMapper;

using Stnc.CMS.DTO.DTOs.AppUserDtos;

using Stnc.CMS.DTO.DTOs.SiparislerDtos;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;

using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
      

            #region AppUser-AppUserDto

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();

            #endregion AppUser-AppUserDto

       










            #region Siparisler-SiparislerDtos

            CreateMap<Siparisler, SiparislerListDto>();
            CreateMap<SiparislerListDto, Siparisler>();

            CreateMap<SiparislerCreateDto, Siparisler>();
            CreateMap<Siparisler, SiparislerCreateDto>();

            CreateMap<SiparislerUpdateDto, Siparisler>();
            CreateMap<Siparisler, SiparislerUpdateDto>();

            #endregion Siparisler-SiparislerDtos



            #region DekamProjeDeneyHayvaniIrkFiyat-DeneyHayvaniIrkFiyatDtos

            CreateMap<DekamProjeDeneyHayvaniIrkFiyat, DeneyHayvaniIrkFiyatListAllDto>();
            CreateMap<DeneyHayvaniIrkFiyatListAllDto, DekamProjeDeneyHayvaniIrkFiyat>();

            CreateMap<DeneyHayvaniIrkFiyatCreateDto, DekamProjeDeneyHayvaniIrkFiyat>();
            CreateMap<DekamProjeDeneyHayvaniIrkFiyat, DeneyHayvaniIrkFiyatCreateDto>();

            CreateMap<DeneyHayvaniIrkFiyatUpdateDto, DekamProjeDeneyHayvaniIrkFiyat>();
            CreateMap<DekamProjeDeneyHayvaniIrkFiyat, DeneyHayvaniIrkFiyatUpdateDto>();

            #endregion DekamProjeDeneyHayvaniIrkFiyat-DeneyHayvaniIrkFiyatDtos
        }
    }
}