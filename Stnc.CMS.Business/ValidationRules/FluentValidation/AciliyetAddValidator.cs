using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.DTO.DTOs.AciliyetDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class AciliyetAddValidator : AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
