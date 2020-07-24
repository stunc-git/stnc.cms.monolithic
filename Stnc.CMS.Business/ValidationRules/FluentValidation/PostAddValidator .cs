using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DTO.DTOs.GorevDtos;
using Stnc.CMS.DTO.DTOs.PostDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class PostAddValidator : AbstractValidator<PostAddDto>
{

    public PostAddValidator()
    {
        RuleFor(I => I.PostTitle).NotNull().WithMessage("İçerik Başlığı gereklidir");
        RuleFor(I => I.PostContent).NotNull().WithMessage("içerik boş geçilemez");
        }
}
}
