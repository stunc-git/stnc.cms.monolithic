using FluentValidation;
using Stnc.CMS.DTO.DTOs.CategoryDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori Başlığı gereklidir");
        }
    }
}