using FluentValidation;
using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.DTO.DTOs.SliderDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class SliderUpdateValidator : AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateValidator()
        {
            RuleFor(I => I.Picture).NotNull().WithMessage("Lütfen resim Ekleyiniz");

        }
    }
}