using FluentValidation;
using Stnc.CMS.DTO.DTOs.CategoryDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori Başlığı gereklidir");
            RuleFor(I => I.Slug).NotNull().WithMessage("Kısa İsim gereklidir");
        }
    }
}