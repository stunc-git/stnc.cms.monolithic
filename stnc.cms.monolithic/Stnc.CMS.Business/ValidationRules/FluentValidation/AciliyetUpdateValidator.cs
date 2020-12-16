using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DTO.DTOs.AciliyetDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class AciliyetUpdateValidator : AbstractValidator<AciliyetUpdateDto>
    {
        public AciliyetUpdateValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
