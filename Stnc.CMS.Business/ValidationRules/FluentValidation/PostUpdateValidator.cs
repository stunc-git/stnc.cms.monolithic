using FluentValidation;
using Stnc.CMS.DTO.DTOs.PostDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class PostUpdateValidator : AbstractValidator<PostUpdateDto>
    {
        public PostUpdateValidator()
        {
            RuleFor(I => I.PostTitle).NotNull().WithMessage("İçerik Başlığı gereklidir");
            RuleFor(I => I.PostContent).NotNull().WithMessage("içerik boş geçilemez");
            RuleFor(I => I.CategoryId).NotNull().WithMessage("kategori boş geçilemez");

        }
    }
}