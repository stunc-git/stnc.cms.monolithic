using FluentValidation;
using Stnc.CMS.DTO.DTOs.DeneyHayvaniIrkFiyatDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class DeneyHayvaniIrkFiyatUpdateValidator : AbstractValidator<DeneyHayvaniIrkFiyatUpdateDto>
    {
        public DeneyHayvaniIrkFiyatUpdateValidator()
        {
            RuleFor(I => I.Isım).NotNull().WithMessage("Lütfen isim alanını doldurunuz");
            RuleFor(I => I.DeneyHayvaniTurID).NotNull().WithMessage("Lütfen deney hayvanı türünü seçiniz");
            RuleFor(I => I.DeneyHayvaniIrkID).NotNull().WithMessage("Lütfen deney hayvanı ırkını seçiniz");
            RuleFor(I => I.Fiyat).NotNull().WithMessage("Lütfen deney hayvanı fiyatını doldurunuz lütfen");
            //http://www.borakasmer.com/blazorda-fluentvalidation/
            //https://www.code4it.dev/blog/fluentvalidation

        }
    }
}