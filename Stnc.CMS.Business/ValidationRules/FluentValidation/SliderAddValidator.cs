using FluentValidation;
using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.DTO.DTOs.SliderDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class SliderAddValidator : AbstractValidator<SliderAddDto>
    {
        public SliderAddValidator()
        {
            RuleFor(I => I.Picture).NotNull().WithMessage("Lütfen resim Ekleyiniz");

        }
    }
}