using FluentValidation;
using Stnc.CMS.DTO.DTOs.SiparislerDtos;

namespace Stnc.CMS.Business.ValidationRules.FluentValidation
{
    public class SiparislerCreateValidator : AbstractValidator<SiparislerCreateDto>
    {
        public SiparislerCreateValidator()
        {
            RuleFor(I => I.ProjeYurutucusu).NotNull().WithMessage("Lütfen Proje Yöneticisi ismini giriniz");
            RuleFor(I => I.ProjeYurutukurumu).NotNull().WithMessage("Lütfen Kurum İsmini  giriniz");
            RuleFor(I => I.ProjeYurutuTelefon).NotNull().WithMessage("Lütfen proje yürütücüsünün telefon bilgisini giriniz");
            RuleFor(I => I.SorumluArastirmaci).NotNull().WithMessage("Lütfen sorumlu araştırmacı bilgisini giriniz");
            RuleFor(I => I.SorumluArastirmaciTelefon).NotNull().WithMessage("Lütfen sorumlu araştırmacı telefon bilgisini giriniz");
            RuleFor(I => I.EtikKurulOnayNumarasi).NotNull().WithMessage("Lütfen etik kurul onay numarası giriniz");
            RuleFor(I => I.EtikKurulOnayTarihi).NotNull().WithMessage("Lütfen etik kurul onay tarihini giriniz");
            RuleFor(I => I.ProjeBaslangicTarihi).NotNull().WithMessage("Lütfen proje başlangıç tarihini giriniz");
            RuleFor(I => I.ProjeBitisTarihi).NotNull().WithMessage("Lütfen proje bitiş tarihini giriniz");
            RuleFor(I => I.DeneyHayvaniCinsiyet).NotNull().WithMessage("Lütfen deney hayvanı cinsiyetini giriniz");
          //  RuleFor(I => I.DeneyHayvaniSayisi).NotNull().WithMessage("Lütfen deney hayvanı sayısını giriniz");
            RuleFor(I => I.DeneyHayvaniAgirligi).NotNull().WithMessage("Lütfen deney hayvanı ağırlığını giriniz");
            RuleFor(I => I.TeknikDestekSuresiID).NotNull().WithMessage("Lütfen teknik destek süresini giriniz");
            RuleFor(I => I.TeknikDestekTuruID).NotNull().WithMessage("Lütfen teknik destek türünü giriniz");
            RuleFor(I => I.TeknikHayvanSayisiID).NotNull().WithMessage("Lütfen hayvan sayısını giriniz");
            RuleFor(I => I.LaboratuvarID).NotNull().WithMessage("Lütfen laboratuvar seçiniz");
            RuleFor(I => I.LaboratuvarID).NotNull().WithMessage("Lütfen laboratuvar seçiniz");
            RuleFor(I => I.LaboratuvarBaslangicTarihi).NotNull().WithMessage("Lütfen laboratuvar başlangıç tarihini giriniz");
            RuleFor(I => I.LaboratuvarBitisTarihi).NotNull().WithMessage("Lütfen laboratuvar bitiş tarihini giriniz");
            RuleFor(I => I.DeneyHayvaniIrkID).NotNull().WithMessage("Lütfen ırk seçiniz");
            RuleFor(I => I.DeneyHayvaniTurID).NotNull().WithMessage("Lütfen türü seçiniz");
        }
    }
}