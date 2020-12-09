using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OptionsMap : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.OptionName).HasMaxLength(200);
            builder.Property(I => I.OptionValue).HasColumnType("ntext");
            builder.Property(I => I.DefaultValue).HasColumnType("ntext");
            builder.Property(I => I.Autoload).HasMaxLength(20);

            builder.HasData(new Options
            {
                Id = 1,
                OptionName = "front-menu",
                OptionValue = "[{\"text\":\"Anasayfa\",\"href\":\"/\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"Anasayfa\"},{\"text\":\"Kurumsal\",\"href\":\"#\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Tarihçe\",\"href\":\"/icerik/tarihce\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" İnsan Kaynağı \",\"href\":\"/icerik/insan-kaynagi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" Arastirma Bölümleri \",\"href\":\"/icerik/arastirma-bolumleri\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Misyon Vizyon\",\"href\":\"/icerik/misyon-vizyon\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" Hayvan Ünitesi \",\"href\":\"/icerik/hayvan-unitesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Araştırma\",\"href\":\"/icerik/arastirma\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Faaliyet Alanları\",\"href\":\"/icerik/faaliyet-alanlari\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"Yönetim\",\"href\":\"#\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Yönetim\",\"href\":\"/icerik/yonetim\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Komisyon Üyeleri\",\"href\":\"/icerik/komisyon-uyeleri\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Personel\",\"href\":\"/icerik/personel\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Yönetmelikler\",\"href\":\"/icerik/yonetmelikler\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Belge & Bilgi \",\"href\":\"/icerik/calisma-izin-belgesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" İş Akış Şeması \",\"href\":\"/icerik/is-akis-semasi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"İstatistikler\",\"href\":\"/icerik/istatistikler\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Fiyat Listesi\",\"href\":\"/icerik/fiyat-listesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Formlar\",\"href\":\"/icerik/formlar\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"Galeriler\",\"icon\":\"\",\"href\":\"#\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Resim Galerisi\",\"icon\":\"empty\",\"href\":\"/galeri\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Video Galeri\",\"icon\":\"empty\",\"href\":\"/video-galeri\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"İletişim\",\"icon\":\"empty\",\"href\":\"/iletisim\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"İletişim\",\"icon\":\"empty\",\"href\":\"/iletisim\",\"target\":\"_self\",\"title\":\"\"}]}]",
            },

            new Options
            {
                Id = 2,
                OptionName = "front-menu-default",
                OptionValue = "[{\"text\":\"Anasayfa\",\"href\":\"/\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"Anasayfa\"},{\"text\":\"Kurumsal\",\"href\":\"#\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Tarihçe\",\"href\":\"/icerik/tarihce\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" İnsan Kaynağı \",\"href\":\"/icerik/insan-kaynagi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" Arastirma Bölümleri \",\"href\":\"/icerik/arastirma-bolumleri\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Misyon Vizyon\",\"href\":\"/icerik/misyon-vizyon\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" Hayvan Ünitesi \",\"href\":\"/icerik/hayvan-unitesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Araştırma\",\"href\":\"/icerik/arastirma\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Faaliyet Alanları\",\"href\":\"/icerik/faaliyet-alanlari\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"Yönetim\",\"href\":\"#\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Yönetim\",\"href\":\"/icerik/yonetim\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Komisyon Üyeleri\",\"href\":\"/icerik/komisyon-uyeleri\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Personel\",\"href\":\"/icerik/personel\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Yönetmelikler\",\"href\":\"/icerik/yonetmelikler\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Belge & Bilgi \",\"href\":\"/icerik/calisma-izin-belgesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\" İş Akış Şeması \",\"href\":\"/icerik/is-akis-semasi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"İstatistikler\",\"href\":\"/icerik/istatistikler\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Fiyat Listesi\",\"href\":\"/icerik/fiyat-listesi\",\"icon\":\"empty\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Formlar\",\"href\":\"/icerik/formlar\",\"icon\":\"\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"Galeriler\",\"icon\":\"\",\"href\":\"#\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"Resim Galerisi\",\"icon\":\"empty\",\"href\":\"/galeri\",\"target\":\"_self\",\"title\":\"\"},{\"text\":\"Video Galeri\",\"icon\":\"empty\",\"href\":\"/video-galeri\",\"target\":\"_self\",\"title\":\"\"}]},{\"text\":\"İletişim\",\"icon\":\"empty\",\"href\":\"/iletisim\",\"target\":\"_self\",\"title\":\"\",\"children\":[{\"text\":\"İletişim\",\"icon\":\"empty\",\"href\":\"/iletisim\",\"target\":\"_self\",\"title\":\"\"}]}]",
            }
       
            ); 
        }
    }
}