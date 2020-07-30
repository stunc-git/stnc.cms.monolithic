using AutoMapper;
using Stnc.CMS.DTO.DTOs.AciliyetDtos;
using Stnc.CMS.DTO.DTOs.AppUserDtos;
using Stnc.CMS.DTO.DTOs.BildirimDtos;
using Stnc.CMS.DTO.DTOs.GorevDtos;
using Stnc.CMS.DTO.DTOs.RaporDtos;
using Stnc.CMS.DTO.DTOs.PostDtos;

using Stnc.CMS.Entities.Concrete;
using Stnc.CMS.DTO.DTOs.CategoryDtos;

namespace Stnc.CMS.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Aciliyet-AciliyetDto
            CreateMap<AciliyetAddDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetAddDto>();
            CreateMap<AciliyetListDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetListDto>();
            CreateMap<AciliyetUpdateDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Bildirim-BildirimDto
            CreateMap<BildirimListDto, Bildirim>();
            CreateMap<Bildirim, BildirimListDto>();
            #endregion

            #region Gorev-GorevDto
            CreateMap<GorevAddDto, Gorev>();
            CreateMap<Gorev, GorevAddDto>();
            CreateMap<GorevListDto, Gorev>();
            CreateMap<Gorev, GorevListDto>();
            CreateMap<GorevUpdateDto, Gorev>();
            CreateMap<Gorev, GorevUpdateDto>();
            CreateMap<GorevListAllDto, Gorev>();
            CreateMap<Gorev, GorevListAllDto>();
            #endregion

            #region Rapor-RaporDto
            CreateMap<RaporAddDto, Rapor>();
            CreateMap<Rapor, RaporAddDto>();
            CreateMap<RaporUpdateDto, Rapor>();
            CreateMap<Rapor, RaporUpdateDto>();
            CreateMap<RaporDosyaDto, Rapor>();
            CreateMap<Rapor, RaporDosyaDto>();
            #endregion

            #region Post-PostDto
            CreateMap<Posts, PostListAllDto>();
            CreateMap<PostListAllDto, Posts>();
            CreateMap<PostAddDto, Posts>();
            CreateMap<Posts, PostAddDto> ();
            CreateMap<PostUpdateDto, Posts>();
            CreateMap<Posts, PostUpdateDto> ();
            #endregion


            #region Category-CategoryDto
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryListDto, Category>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();
           
            #endregion
        }
    }
}
