using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.DataAccess.ShoppingCartLib;
using Stnc.CMS.DTO.DTOs.ShopCartDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Stnc.CMS.Business.Concrete
{
    public class DosyaManager : IDosyaService
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IShopDal _shopService;
        private readonly IDekamProjeTakipService _dekamProjeTakipService;

        public DosyaManager(ShoppingCart shoppingCart, IShopDal shopService, IDekamProjeTakipService dekamProjeTakipService)
        {
            _dekamProjeTakipService = dekamProjeTakipService;
            _shopService = shopService;
            _shoppingCart = shoppingCart;
        }

        public byte[] AktarExcel<T>(List<T> list) where T : class, new()
        {
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Calisma1");

            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);

            return excelPackage.GetAsByteArray();
        }

        public string AktarPdf<T>(List<T> list) where T : class, new()
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL);

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfPTable = new PdfPTable(dataTable.Columns.Count);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfPTable.AddCell(new Phrase(dataTable.Columns[i].ColumnName, font));
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(new Phrase(dataTable.Rows[i][j].ToString(), font));
                }
            }

            document.Add(pdfPTable);
            document.Close();

            return returnPath;
        }

        public string FaturaPDfCreate(int dekamProjeTakipID)
        {
    


            var cartItemsDataCollection = _shopService.GetCartDekamProjeTakipIDList(dekamProjeTakipID);
            cartItemsDataCollection.Wait();
            List<ShopCartAjaxListDto> cartItemsDataCollectionData = cartItemsDataCollection.Result;



            var toplamUcret = _shopService.ToplamUcretDekamProjeTakipID(dekamProjeTakipID);
            var dekamProjeTakipData = _dekamProjeTakipService.GetirIdile(dekamProjeTakipID);

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            string calibriTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "calibri.ttf");

            BaseFont baseFont = BaseFont.CreateFont(calibriTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontBold = new Font(baseFont, 11, Font.BOLD); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontMiniSmall = new Font(baseFont, 7, Font.NORMAL, BaseColor.Black);
            Font fontMiniSmallBlue = new Font(baseFont, 7, Font.NORMAL, BaseColor.Blue);
            Font fontMiniBold = new Font(baseFont, 7, Font.BOLD, BaseColor.Black); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Document document = new Document(PageSize.Letter, 50f, 0, 0, 0);
            document.SetMargins(0, 0, 0, 0);
            PdfWriter.GetInstance(document, stream);

            //****** footer text  **** ////
            Chunk chkFooter = new Chunk("sayfa numarası yazacak", fontMiniSmallBlue);
            Phrase fo = new Phrase(chkFooter);
            HeaderFooter footer = new HeaderFooter(fo, true);
            footer.Border = Rectangle.NO_BORDER;
            footer.Alignment = 1;
            footer.Top = 0;
            footer.Bottom = 50f;
            //******  footer text **** ////

            document.Footer = footer;

            document.Open();

            //****** Header Image **** ////
            Image imageHeaderLogo = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/logo.jpg"));
            var scalePercent = (((document.PageSize.Width / imageHeaderLogo.Width) * 80) - 5);
            imageHeaderLogo.ScalePercent(scalePercent);
            imageHeaderLogo.Alignment = 1;
            imageHeaderLogo.SpacingBefore = 50f;
            imageHeaderLogo.SpacingAfter = 50f;
            //resmi tam ortaya al
            //image2.SetAbsolutePosition((PageSize.A4.Width - image2.ScaledWidth) / 2, (PageSize.A4.Height - image2.ScaledHeight) / 2);
            //image2.IndentationLeft = 25;
            //image2.IndentationRight = 25;
            //****** end  Header Image **** ////

            //****** Fatura Baslık Bilgisi  **** ////
            PdfPTable FaturaBaslikTable = new PdfPTable(2);
            PdfPCell FaturaBaslikTableCell = new PdfPCell(new Phrase(dekamProjeTakipData.ProjeYurutukurumu, fontBold));
            FaturaBaslikTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            FaturaBaslikTableCell.PaddingTop = 10;
            FaturaBaslikTableCell.PaddingBottom = 10;
            FaturaBaslikTable.AddCell(FaturaBaslikTableCell);

            FaturaBaslikTableCell = new PdfPCell(new Phrase("22.12.2019-tarihi sor?", fontBold));
            FaturaBaslikTableCell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            FaturaBaslikTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikTableCell.PaddingTop = 10;
            FaturaBaslikTableCell.PaddingBottom = 10;
            FaturaBaslikTable.AddCell(FaturaBaslikTableCell);

            PdfPTable FaturaBaslikBolumTable = new PdfPTable(1);
            PdfPCell FaturaBaslikBolumTableCell = new PdfPCell(new Phrase(dekamProjeTakipData.ProjeYurutukurumu, fontBold));
            FaturaBaslikBolumTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            FaturaBaslikBolumTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikBolumTableCell.PaddingTop = 10;
            FaturaBaslikBolumTableCell.PaddingBottom = 10;
            FaturaBaslikBolumTable.AddCell(FaturaBaslikBolumTableCell);

            var mainFaturaText = new Paragraph(16, "Proforma Fatura", fontBold);
            mainFaturaText.Alignment = Element.ALIGN_CENTER;
            //****** Fatura Baslık Bilgisi end **** ////

            string otenaziDurumu = ""
; foreach (var cartItemsData in cartItemsDataCollectionData)
            {
                //****** fatura detay Tablo **** ////
                PdfPTable faturaDetayTable = new PdfPTable(5);
                faturaDetayTable.WidthPercentage = 80;
                faturaDetayTable.SpacingBefore = 10f;
                faturaDetayTable.SpacingAfter = 2.5f;
                PdfPCell faturaDetayTablecell = new PdfPCell(new Phrase("Hayvan Türü -  Yaşı", fontBold));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);
                faturaDetayTable.WidthPercentage = 90;
                faturaDetayTablecell = new PdfPCell(new Phrase("Fiyat", fontBold));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase("İstenen Hayvan Sayısı", fontBold));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase("Destek istenen Hayvan Sayısı", fontBold));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase("Bakım Desteği Gün sayısı", fontBold));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(cartItemsData.HayvanAdi + '/' + cartItemsData.HayvanIrkFiyatTipYasBilgisi, font));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(cartItemsData.HayvanFiyati + "  ₺", font));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(cartItemsData.IstenenHayvanSayisi+"", font));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(cartItemsData.DestekIstenenHayvanSayisi+"", font));
                faturaDetayTablecell.HorizontalAlignment = Element.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(cartItemsData.BakimDestegiGunSayisi+"", font));
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                if (cartItemsData.Otenazi == 1)
                {
                    otenaziDurumu = "Ötenazi[1 TL]: Evet" + cartItemsData.OtenaziUcreti * cartItemsData.IstenenHayvanSayisi;
                }

                faturaDetayTablecell = new PdfPCell(new Phrase("Ağırlık: " + cartItemsData.HayvanAgirlik + " | Cinsiyet: " + cartItemsData.DeneyHayvaniCinsiyet + " | " + otenaziDurumu, font));
                faturaDetayTablecell.Colspan = 5;
                faturaDetayTablecell.PaddingTop = 5;
                faturaDetayTablecell.PaddingBottom = 5;
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase(" Destek Talep Türü Seçenekleri   ", fontBold));
                faturaDetayTablecell.Colspan = 5;
                faturaDetayTablecell.PaddingTop = 5;
                faturaDetayTablecell.PaddingBottom = 5;
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTable.AddCell(faturaDetayTablecell);

               foreach (var destekTalepTurleriJsonData in cartItemsData.DestekTalepTurleriJson)
                {



                    faturaDetayTablecell = new PdfPCell(new Phrase(destekTalepTurleriJsonData .+"  / Fiyat 10 ₺   ", font));
                    faturaDetayTablecell.Colspan = 5;
                    faturaDetayTablecell.PaddingTop = 5;
                    faturaDetayTablecell.PaddingBottom = 5;
                    faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                    faturaDetayTable.AddCell(faturaDetayTablecell);

                }

                faturaDetayTablecell = new PdfPCell(new Phrase("Birim Toplamı  ", font));
                faturaDetayTablecell.Colspan = 4;
                faturaDetayTablecell.PaddingTop = 5;
                faturaDetayTablecell.PaddingBottom = 5;
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTable.AddCell(faturaDetayTablecell);

                faturaDetayTablecell = new PdfPCell(new Phrase("5 ₺", font));
                faturaDetayTablecell.Colspan = 1;
                faturaDetayTablecell.PaddingTop = 5;
                faturaDetayTablecell.PaddingBottom = 5;
                faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                faturaDetayTable.AddCell(faturaDetayTablecell);
                //****** fatura detay Tablo --end **** ////
                document.Add(faturaDetayTable);
            }

            //****** fatura detay genel toplam Tablo **** ////
            PdfPTable faturaDetayGenelToplamTable = new PdfPTable(2);
            PdfPCell faturaDetayGenelToplamTableCell = new PdfPCell(new Phrase("Genel Toplam", fontBold));
            faturaDetayGenelToplamTable.WidthPercentage = 90;
            faturaDetayGenelToplamTableCell.PaddingTop = 5;
            faturaDetayGenelToplamTableCell.PaddingBottom = 5;
            faturaDetayGenelToplamTableCell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayGenelToplamTable.AddCell(faturaDetayGenelToplamTableCell);

            faturaDetayGenelToplamTableCell = new PdfPCell(new Phrase(toplamUcret + " ₺", font));
            faturaDetayGenelToplamTableCell.PaddingTop = 5;
            faturaDetayGenelToplamTableCell.PaddingBottom = 5;
            faturaDetayGenelToplamTableCell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayGenelToplamTable.AddCell(faturaDetayGenelToplamTableCell);
            //****** fatura detay genel toplam Tablo --end **** ////

            //****** fatura mini bilgi Tablo  **** ////

            string infoText = @"
* Fiyatlar, Erciyes Üniversitesi’ne mensup araştırmacılar için ve kurum dışı taleplerde fiyatlar geçerlidir.
** Diyabet projeleri kapsamında takip edilecek hayvanlar için % 50 daha fazla günlük bakım ücreti alınır.
*** Ötenazi ve özel cerrahi operasyonlar hariç; post operatif bakım, anestezi, enjeksiyon, kan alma, hayvan tutma,  hayvan tartma ve gavaj uygulaması gibi desteklerden oluşmaktadır.
**** Ötenazi için gerekli kimyasal maddeler araştırmacı tarafından temin edilir. ";

            PdfPTable faturaDetayMiniInfoTable = new PdfPTable(1);
            PdfPCell faturaDetayMiniInfoTableCell = new PdfPCell(new Paragraph(12, infoText, fontMiniSmall));
            faturaDetayMiniInfoTableCell.PaddingTop = 5;
            faturaDetayMiniInfoTableCell.PaddingBottom = 5;
            faturaDetayMiniInfoTableCell.Border = Rectangle.NO_BORDER;
            faturaDetayMiniInfoTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaDetayMiniInfoTable.AddCell(faturaDetayMiniInfoTableCell);
            //****** fatura mini bilgi Tablo --end  **** ////

            //****** fatura islak İmza Tablo   **** ////
            Image imzaImg = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/imza.jpg"));
            imzaImg.ScaleAbsolute(120f, 120f);

            PdfPTable faturaIslakImzaTable = new PdfPTable(2);
            PdfPCell faturaIslakImzaTableCell1 = new PdfPCell(new Phrase("", font));
            faturaIslakImzaTableCell1.PaddingTop = 5;
            faturaIslakImzaTableCell1.PaddingBottom = 5;
            faturaIslakImzaTableCell1.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaIslakImzaTableCell1.Border = Rectangle.NO_BORDER;
            faturaIslakImzaTable.AddCell(faturaIslakImzaTableCell1);

            PdfPCell faturaIslakImzaTableCell2 = new PdfPCell(imzaImg);
            faturaIslakImzaTableCell2.Border = 0;
            faturaIslakImzaTableCell2.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            faturaIslakImzaTable.AddCell(faturaIslakImzaTableCell2);
            faturaIslakImzaTable.SpacingBefore = 50f;
            faturaIslakImzaTable.SpacingAfter = 50f;
            //****** fatura islak İmza Tablo  --end **** ////

            //****** fatura  footer text   **** ////
            Chunk faturaFooterTablebegin = new Chunk("Adres: ", fontMiniBold);
            Phrase faturaFooterTablebeginPh = new Phrase(faturaFooterTablebegin);
            Chunk c1 = new Chunk("DEKAM / Erciyes Üniversitesi Deneysel Araştırmalar Uygulama ve Araştırma Merkezi Merkez Kampüs Melikgazi / KAYSERİ ", fontMiniSmall);
            Phrase faturaFooterTablebeginPh2 = new Phrase();
            faturaFooterTablebeginPh2.Add(c1);
            Paragraph faturaFooterTablebeginP1 = new Paragraph();
            faturaFooterTablebeginP1.Add(faturaFooterTablebeginPh);
            faturaFooterTablebeginP1.Add(faturaFooterTablebeginPh2);

            //burada table oluşuyor
            PdfPTable faturaFooterTable = new PdfPTable(1);
            PdfPCell faturaFooterTableCell = new PdfPCell(faturaFooterTablebeginP1);
            faturaFooterTableCell.Border = Rectangle.NO_BORDER;
            faturaFooterTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaFooterTable.AddCell(faturaFooterTableCell);

            Chunk telefon = new Chunk("Telefon : ", fontMiniBold);
            Phrase telefonp1 = new Phrase(telefon);
            Chunk telefonTel = new Chunk("+90 352 207 66 66 / 24 400", fontMiniSmall);
            Chunk telefonEpostaTitle = new Chunk(" E-Posta : ", fontMiniBold);
            Chunk telefonEposta = new Chunk("dekam@erciyes.edu.tr", fontMiniSmallBlue);
            telefonEposta.SetAnchor("mailto:dekam@erciyes.edu.tr");

            Phrase telefonPH = new Phrase();
            telefonPH.Add(telefonTel);
            telefonPH.Add(telefonEpostaTitle);
            telefonPH.Add(telefonEposta);
            Paragraph telefonpes = new Paragraph();
            telefonpes.Add(telefonp1);
            telefonpes.Add(telefonPH);

            faturaFooterTableCell = new PdfPCell(telefonpes);
            faturaFooterTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaFooterTableCell.Border = Rectangle.NO_BORDER;
            faturaFooterTable.SpacingBefore = 100f;
            faturaFooterTable.SpacingAfter = 10f;
            faturaFooterTable.AddCell(faturaFooterTableCell);

            //****** fatura  footer text  --end **** ////

            document.Add(imageHeaderLogo); //logo
            document.Add(FaturaBaslikTable); //bolum ve saat yazan
            document.Add(FaturaBaslikBolumTable);
            document.Add(mainFaturaText);

            document.Add(faturaDetayGenelToplamTable);
            document.Add(faturaDetayMiniInfoTable);
            document.Add(faturaIslakImzaTable);
            document.Add(faturaFooterTable);

            // metadata
            document.AddCreator("erciyes.edu.tr");
            document.AddKeywords("Erciyes üniversitesi Bilgi İşlem Daire Başkanlığı");
            document.AddAuthor("@stnc https://github.com/stnc");
            document.AddSubject("Proforma Fatura Oluşturucu");
            document.AddTitle("Proforma Fatura");

            document.Close();

            return returnPath;
        }

        //https://github.com/jonbride/strengthreport/blob/master/Backup/StrengthReport/Reporting/ReportFormat/ReportPdf.cs  bolumlere ayırmak için kullan
        //https://csharp.hotexamples.com/examples/iTextSharp.text/HeaderFooter/-/php-headerfooter-class-examples.html
        //https://coderanch.com/t/675056/open-source/iText-Page-content-overlapping-footer
        //https://www.nilthakkar.com/2013/11/itextsharpadd-headerfooter-to-pdf.html bu çok onemli sayfalama mantığı burada var
        //https://www.c-sharpcorner.com/blogs/create-table-in-pdf-using-c-sharp-and-itextsharp
        //https://www.mikesdotnetting.com/article/87/itextsharp-working-with-images
        //https://www.mikesdotnetting.com/article/82/itextsharp-adding-text-with-chunks-phrases-and-paragraphs
        public string AktarMockup()
        {
            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            string calibriTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "calibri.ttf");

            BaseFont baseFont = BaseFont.CreateFont(calibriTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontBold = new Font(baseFont, 11, Font.BOLD); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontMiniSmall = new Font(baseFont, 7, Font.NORMAL, BaseColor.Black);
            Font fontMiniSmallBlue = new Font(baseFont, 7, Font.NORMAL, BaseColor.Blue);
            Font fontMiniBold = new Font(baseFont, 7, Font.BOLD, BaseColor.Black); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Document document = new Document(PageSize.Letter, 50f, 0, 0, 0);
            document.SetMargins(0, 0, 0, 0);
            PdfWriter.GetInstance(document, stream);

            //****** footer text  **** ////
            Chunk chkFooter = new Chunk("son", fontMiniSmallBlue);
            Phrase fo = new Phrase(chkFooter);
            HeaderFooter footer = new HeaderFooter(fo, true);
            footer.Border = Rectangle.NO_BORDER;
            footer.Alignment = 1;
            footer.Top = 50f;
            footer.Bottom = 50f;
            //******  footer text **** ////

            document.Footer = footer;

            document.Open();

            //****** Header Image **** ////
            Image imageHeaderLogo = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/logo.jpg"));
            var scalePercent = (((document.PageSize.Width / imageHeaderLogo.Width) * 80) - 5);
            imageHeaderLogo.ScalePercent(scalePercent);
            imageHeaderLogo.Alignment = 1;
            imageHeaderLogo.SpacingBefore = 50f;
            imageHeaderLogo.SpacingAfter = 50f;
            //resmi tam ortaya al
            //image2.SetAbsolutePosition((PageSize.A4.Width - image2.ScaledWidth) / 2, (PageSize.A4.Height - image2.ScaledHeight) / 2);
            //image2.IndentationLeft = 25;
            //image2.IndentationRight = 25;
            //****** end  Header Image **** ////

            //****** Fatura Baslık Bilgisi  **** ////
            PdfPTable FaturaBaslikTable = new PdfPTable(2);
            PdfPCell FaturaBaslikTableCell = new PdfPCell(new Phrase("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ", fontBold));
            FaturaBaslikTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            FaturaBaslikTableCell.PaddingTop = 10;
            FaturaBaslikTableCell.PaddingBottom = 10;
            FaturaBaslikTable.AddCell(FaturaBaslikTableCell);

            FaturaBaslikTableCell = new PdfPCell(new Phrase("11.12.2019", fontBold));
            FaturaBaslikTableCell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            FaturaBaslikTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikTableCell.PaddingTop = 10;
            FaturaBaslikTableCell.PaddingBottom = 10;
            FaturaBaslikTable.AddCell(FaturaBaslikTableCell);

            PdfPTable FaturaBaslikBolumTable = new PdfPTable(1);
            PdfPCell FaturaBaslikBolumTableCell = new PdfPCell(new Phrase("PLASTİK REKONSTRÜKTİF VE ESTETİK CERRAHİ ANABİLİM DALI BAŞKANLIĞI", fontBold));
            FaturaBaslikBolumTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            FaturaBaslikBolumTableCell.Border = Rectangle.NO_BORDER;
            FaturaBaslikBolumTableCell.PaddingTop = 10;
            FaturaBaslikBolumTableCell.PaddingBottom = 10;
            FaturaBaslikBolumTable.AddCell(FaturaBaslikBolumTableCell);

            var mainFaturaText = new Paragraph(16, "Proforma Fatura", fontBold);
            mainFaturaText.Alignment = Element.ALIGN_CENTER;
            //****** Fatura Baslık Bilgisi end **** ////

            //****** fatura detay Tablo **** ////
            PdfPTable faturaDetayTable = new PdfPTable(5);
            faturaDetayTable.WidthPercentage = 80;
            faturaDetayTable.SpacingBefore = 10f;
            faturaDetayTable.SpacingAfter = 2.5f;
            PdfPCell faturaDetayTablecell = new PdfPCell(new Phrase("Hayvan Türü -  Yaşı", fontBold));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);
            faturaDetayTable.WidthPercentage = 90;
            faturaDetayTablecell = new PdfPCell(new Phrase("Fiyat", fontBold));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("İstenen Hayvan Sayısı", fontBold));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("Destek istenen Hayvan Sayısı", fontBold));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("Bakım Desteği Gün sayısı", fontBold));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase(" Fare (Balb-C) / 8 Haftalık Yaşa Kadar ", font));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("5 TL", font));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("10", font));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("5", font));
            faturaDetayTablecell.HorizontalAlignment = Element.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("10", font));
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTablecell.VerticalAlignment = Element.ALIGN_MIDDLE;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("Ağırlık: 420 gr | Cinsiyet: Erkek | Ötenazi [1 TL]: Evet", font));
            faturaDetayTablecell.Colspan = 5;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase(" Destek Talep Türü Seçenekleri   ", fontBold));
            faturaDetayTablecell.Colspan = 5;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("MADDE UYGULAMA (ENJEKSİYON, GAVAJ v.s.)  / Fiyat 10 ₺   ", font));
            faturaDetayTablecell.Colspan = 5;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("KAN ALMA (İNTRAKARDİYOK, İNTRAVENÜZ v.s.)  / Fiyat 5 ₺  ", font));
            faturaDetayTablecell.Colspan = 5;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("Birim Toplamı  ", font));
            faturaDetayTablecell.Colspan = 4;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);

            faturaDetayTablecell = new PdfPCell(new Phrase("5 ₺", font));
            faturaDetayTablecell.Colspan = 1;
            faturaDetayTablecell.PaddingTop = 5;
            faturaDetayTablecell.PaddingBottom = 5;
            faturaDetayTablecell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayTable.AddCell(faturaDetayTablecell);
            //****** fatura detay Tablo --end **** ////

            //****** fatura detay genel toplam Tablo **** ////
            PdfPTable faturaDetayGenelToplamTable = new PdfPTable(2);
            PdfPCell faturaDetayGenelToplamTableCell = new PdfPCell(new Phrase("Genel Toplam", fontBold));
            faturaDetayGenelToplamTable.WidthPercentage = 90;
            faturaDetayGenelToplamTableCell.PaddingTop = 5;
            faturaDetayGenelToplamTableCell.PaddingBottom = 5;
            faturaDetayGenelToplamTableCell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayGenelToplamTable.AddCell(faturaDetayGenelToplamTableCell);

            faturaDetayGenelToplamTableCell = new PdfPCell(new Phrase("5 ₺", font));
            faturaDetayGenelToplamTableCell.PaddingTop = 5;
            faturaDetayGenelToplamTableCell.PaddingBottom = 5;
            faturaDetayGenelToplamTableCell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaDetayGenelToplamTable.AddCell(faturaDetayGenelToplamTableCell);
            //****** fatura detay genel toplam Tablo --end **** ////

            //****** fatura mini bilgi Tablo  **** ////
            string infoText = @"
* Fiyatlar, Erciyes Üniversitesi’ne mensup araştırmacılar için ve kurum dışı taleplerde fiyatlar geçerlidir.
** Diyabet projeleri kapsamında takip edilecek hayvanlar için % 50 daha fazla günlük bakım ücreti alınır.
*** Ötenazi ve özel cerrahi operasyonlar hariç; post operatif bakım, anestezi, enjeksiyon, kan alma, hayvan tutma,  hayvan tartma ve gavaj uygulaması gibi desteklerden oluşmaktadır.
**** Ötenazi için gerekli kimyasal maddeler araştırmacı tarafından temin edilir. ";

            PdfPTable faturaDetayMiniInfoTable = new PdfPTable(1);
            PdfPCell faturaDetayMiniInfoTableCell = new PdfPCell(new Paragraph(12, infoText, fontMiniSmall));
            faturaDetayMiniInfoTableCell.PaddingTop = 5;
            faturaDetayMiniInfoTableCell.PaddingBottom = 5;
            faturaDetayMiniInfoTableCell.Border = Rectangle.NO_BORDER;
            faturaDetayMiniInfoTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaDetayMiniInfoTable.AddCell(faturaDetayMiniInfoTableCell);
            //****** fatura mini bilgi Tablo --end  **** ////

            //****** fatura islak İmza Tablo   **** ////
            Image imzaImg = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/imza.jpg"));
            imzaImg.ScaleAbsolute(120f, 120f);

            PdfPTable faturaIslakImzaTable = new PdfPTable(2);
            PdfPCell faturaIslakImzaTableCell1 = new PdfPCell(new Phrase("", font));
            faturaIslakImzaTableCell1.PaddingTop = 5;
            faturaIslakImzaTableCell1.PaddingBottom = 5;
            faturaIslakImzaTableCell1.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            faturaIslakImzaTableCell1.Border = Rectangle.NO_BORDER;
            faturaIslakImzaTable.AddCell(faturaIslakImzaTableCell1);

            PdfPCell faturaIslakImzaTableCell2 = new PdfPCell(imzaImg);
            faturaIslakImzaTableCell2.Border = 0;
            faturaIslakImzaTableCell2.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            faturaIslakImzaTable.AddCell(faturaIslakImzaTableCell2);
            faturaIslakImzaTable.SpacingBefore = 50f;
            faturaIslakImzaTable.SpacingAfter = 50f;
            //****** fatura islak İmza Tablo  --end **** ////

            //****** fatura  footer text   **** ////
            Chunk faturaFooterTablebegin = new Chunk("Adres: ", fontMiniBold);
            Phrase faturaFooterTablebeginPh = new Phrase(faturaFooterTablebegin);
            Chunk c1 = new Chunk("DEKAM / Erciyes Üniversitesi Deneysel Araştırmalar Uygulama ve Araştırma Merkezi Merkez Kampüs Melikgazi / KAYSERİ ", fontMiniSmall);
            Phrase faturaFooterTablebeginPh2 = new Phrase();
            faturaFooterTablebeginPh2.Add(c1);
            Paragraph faturaFooterTablebeginP1 = new Paragraph();
            faturaFooterTablebeginP1.Add(faturaFooterTablebeginPh);
            faturaFooterTablebeginP1.Add(faturaFooterTablebeginPh2);

            //burada table oluşuyor
            PdfPTable faturaFooterTable = new PdfPTable(1);
            PdfPCell faturaFooterTableCell = new PdfPCell(faturaFooterTablebeginP1);
            faturaFooterTableCell.Border = Rectangle.NO_BORDER;
            faturaFooterTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaFooterTable.AddCell(faturaFooterTableCell);

            Chunk telefon = new Chunk("Telefon : ", fontMiniBold);
            Phrase telefonp1 = new Phrase(telefon);
            Chunk telefonTel = new Chunk("+90 352 207 66 66 / 24 400", fontMiniSmall);
            Chunk telefonEpostaTitle = new Chunk(" E-Posta : ", fontMiniBold);
            Chunk telefonEposta = new Chunk("dekam@erciyes.edu.tr", fontMiniSmallBlue);
            telefonEposta.SetAnchor("mailto:dekam@erciyes.edu.tr");

            Phrase telefonPH = new Phrase();
            telefonPH.Add(telefonTel);
            telefonPH.Add(telefonEpostaTitle);
            telefonPH.Add(telefonEposta);
            Paragraph telefonpes = new Paragraph();
            telefonpes.Add(telefonp1);
            telefonpes.Add(telefonPH);

            faturaFooterTableCell = new PdfPCell(telefonpes);
            faturaFooterTableCell.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            faturaFooterTableCell.Border = Rectangle.NO_BORDER;
            faturaFooterTable.SpacingBefore = 100f;
            faturaFooterTable.SpacingAfter = 10f;
            faturaFooterTable.AddCell(faturaFooterTableCell);

            //****** fatura  footer text  --end **** ////

            document.Add(imageHeaderLogo); //logo
            document.Add(FaturaBaslikTable); //bolum ve saat yazan
            document.Add(FaturaBaslikBolumTable);
            document.Add(mainFaturaText);
            document.Add(faturaDetayTable);
            document.Add(faturaDetayGenelToplamTable);
            document.Add(faturaDetayMiniInfoTable);
            document.Add(faturaIslakImzaTable);
            document.Add(faturaFooterTable);

            // metadata
            document.AddCreator("erciyes.edu.tr");
            document.AddKeywords("Erciyes üniversitesi Bilgi İşlem Daire Başkanlığı");
            document.AddAuthor("@stnc https://github.com/stnc");
            document.AddSubject("Proforma Fatura Oluşturucu");
            document.AddTitle("Proforma Fatura");

            document.Close();

            return returnPath;
        }

        public void PDFfooterTEst()
        {
            Document doc = new Document(PageSize.A4.Rotate());

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                PageEventHelper pageEventHelper = new PageEventHelper();
                writer.PageEvent = pageEventHelper;
            }
        }
    }

    public class PageEventHelper : PdfPageEventHelper
    {
        private PdfContentByte cb;
        private PdfTemplate template;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            int pageN = writer.PageNumber;
            String text = "Page " + pageN.ToString() + " of ";

            string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL);

            float len = 50;

            iTextSharp.text.Rectangle pageSize = document.PageSize;

            cb.BeginText();
            cb.SetFontAndSize(baseFont, 14);
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
            cb.ShowText(text);

            cb.EndText();

            cb.AddTemplate(template, document.LeftMargin + len, pageSize.GetBottom(document.BottomMargin));
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            template.BeginText();
            template.SetFontAndSize(baseFont, 12);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}