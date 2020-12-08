using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using Stnc.CMS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace Stnc.CMS.Business.Concrete
{
    public class DosyaManager : IDosyaService
    {
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

        public string AktarPdf2()
        {

            //https://www.c-sharpcorner.com/blogs/create-table-in-pdf-using-c-sharp-and-itextsharp 
            //https://www.mikesdotnetting.com/article/87/itextsharp-working-with-images

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            string calibriTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "calibri.ttf");

            BaseFont baseFont = BaseFont.CreateFont(calibriTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontBold = new Font(baseFont, 11, Font.BOLD); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontMiniSmall = new Font(baseFont,7, Font.NORMAL, BaseColor.Black); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Font fontMiniBold = new Font(baseFont, 7, Font.BOLD, BaseColor.Black); //FontFactory.GetFont("Arial", 10, BaseColor.Black
            Document document = new Document(PageSize.Letter, 50f, 0,0,0);
            document.SetMargins(0,0,0,0);

  
            PdfWriter.GetInstance(document, stream);
            document.Open();



           /// document.Add(new Paragraph("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ"));

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 80;
            Image image = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/logo.jpg"));

            var scalePercent = (((document.PageSize.Width / image.Width) * 80) - 5);
            image.ScalePercent(scalePercent);

            image.Alignment = 1;

            image.SpacingBefore = 50f;
            image.SpacingAfter = 50f;
            //resmi tam ortaya al

            //image2.SetAbsolutePosition((PageSize.A4.Width - image2.ScaledWidth) / 2, (PageSize.A4.Height - image2.ScaledHeight) / 2);


            //image2.IndentationLeft = 25;
            //image2.IndentationRight = 25;

            table.SpacingBefore = 10f;
            table.SpacingAfter = 2.5f;

         
     

          // 
        //    p2.IndentationRight = 100;
           
          

            PdfPTable table2 = new PdfPTable(2);
            PdfPCell cell2 = new PdfPCell(new Phrase("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ", fontBold));
            cell2.Border = Rectangle.NO_BORDER;
            cell2.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            cell2.PaddingTop = 10;
            cell2.PaddingBottom = 10;
            table2.AddCell(cell2);


            cell2 = new PdfPCell(new Phrase("11.12.2019", fontBold));
            cell2.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell2.Border = Rectangle.NO_BORDER;
            cell2.PaddingTop = 10;
            cell2.PaddingBottom = 10;
            table2.AddCell(cell2);


            PdfPTable table4 = new PdfPTable(1);
            PdfPCell cell3= new PdfPCell(new Phrase("PLASTİK REKONSTRÜKTİF VE ESTETİK CERRAHİ ANABİLİM DALI BAŞKANLIĞI", fontBold));
            cell3.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            cell3.Border = Rectangle.NO_BORDER;
            cell2.PaddingTop = 10;
            cell2.PaddingBottom = 10;
            table4.AddCell(cell3);



            var p2 = new Paragraph(16, "Proforma Fatura", fontBold);
            cell2.PaddingTop = 10;
            cell2.PaddingBottom = 10;
            p2.Alignment = Element.ALIGN_CENTER;

            /// ****** HEADER *******//// 
            PdfPCell cell = new PdfPCell(new Phrase("Hayvan Türü -  Yaşı", fontBold));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);
            table.WidthPercentage = 90;
            cell = new PdfPCell(new Phrase("Fiyat", fontBold));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("İstenen Hayvan Sayısı", fontBold));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Destek istenen Hayvan Sayısı", fontBold));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Bakım Desteği Gün sayısı", fontBold));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);
            /// ****** HEADER end*******//// 


            /// ****** içerik *******//// 
            cell = new PdfPCell(new Phrase(" Fare (Balb-C) / 8 Haftalık Yaşa Kadar ", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5 TL", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);
            /// ****** HEADER end*******//// 

   




            cell = new PdfPCell(new Phrase("Ağırlık: 420 gr | Cinsiyet: Erkek | Ötenazi [1 TL]: Evet", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" Destek Talep Türü Seçenekleri   ", fontBold));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("MADDE UYGULAMA (ENJEKSİYON, GAVAJ v.s.)  / Fiyat 10 ₺   ", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("KAN ALMA (İNTRAKARDİYOK, İNTRAVENÜZ v.s.)  / Fiyat 5 ₺  ", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Birim Toplamı  ", font));
            cell.Colspan = 4;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("5 ₺", font));
            cell.Colspan = 1;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            PdfPTable table5 = new PdfPTable(2);
            PdfPCell cell4 = new PdfPCell(new Phrase("Genel Toplam", fontBold));
            table5.WidthPercentage = 90;
            cell4.PaddingTop = 5;
            cell4.PaddingBottom = 5;
            cell4.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table5.AddCell(cell4);


            cell4 = new PdfPCell(new Phrase("5 ₺", font));
          //  cell4.Colspan = 1;
            cell4.PaddingTop = 5;
            cell4.PaddingBottom = 5;
            cell4.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table5.AddCell(cell4);


            string text = @"
                    * Fiyatlar, Erciyes Üniversitesi’ne mensup araştırmacılar için ve kurum dışı taleplerde fiyatlar geçerlidir.
                    ** Diyabet projeleri kapsamında takip edilecek hayvanlar için % 50 daha fazla günlük bakım ücreti alınır.
                    *** Ötenazi ve özel cerrahi operasyonlar hariç; post operatif bakım, anestezi, enjeksiyon, kan alma, hayvan tutma,  hayvan tartma ve gavaj uygulaması gibi desteklerden oluşmaktadır.
                    **** Ötenazi için gerekli kimyasal maddeler araştırmacı tarafından temin edilir. ";
      

            PdfPTable table6 = new PdfPTable(1);
            PdfPCell cell5 = new PdfPCell(new Paragraph(12, text, fontMiniSmall));
            cell5.PaddingTop = 5;
            cell5.PaddingBottom = 5;
            cell5.Border = Rectangle.NO_BORDER;
            cell5.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            table6.AddCell(cell5);

            Image imzaImg = Image.GetInstance(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf/imza.jpg"));

            imzaImg.ScaleAbsolute(120f, 120f);



            PdfPTable table6Img = new PdfPTable(2);
            PdfPCell cell66 = new PdfPCell(new Phrase("", font));
            cell66.PaddingTop = 5;
            cell66.PaddingBottom = 5;
            cell66.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell66.Border = Rectangle.NO_BORDER;
            table6Img.AddCell(cell66);


            PdfPCell imageCell = new PdfPCell(imzaImg);
            imageCell.Border = 0;
            imageCell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            table6Img.AddCell(imageCell);

            table6Img.SpacingBefore = 50f;
            table6Img.SpacingAfter = 50f;






            // var ImzatextAdres = new Paragraph(12, " ", fontMiniBold);
            // var ImzatextAdresFull = new Paragraph(12, "", fontMiniSmall);

            //https://www.mikesdotnetting.com/article/82/itextsharp-adding-text-with-chunks-phrases-and-paragraphs

            Chunk beginning = new Chunk("Adres:", fontMiniBold);

            Phrase p1 = new Phrase(beginning);

            Chunk c1 = new Chunk("DEKAM / Erciyes Üniversitesi Deneysel Araştırmalar Uygulama ve Araştırma Merkezi Merkez Kampüs Melikgazi / KAYSERİ \"", fontMiniSmall);

            PdfPTable son = new PdfPTable(1);
            PdfPCell cell66 = new PdfPCell(new Phrase("", font));
            cell66.PaddingTop = 5;
            cell66.PaddingBottom = 5;
            cell66.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            cell66.Border = Rectangle.NO_BORDER;
            table6Img.AddCell(cell66);

            p1.Add(c1);







            // metadata
            document.AddCreator("erciyes.edu.tr");
            document.AddKeywords("Erciyes üniversitesi Bilgi İşlem Daire Başkanlığı");
            document.AddAuthor("@stnc https://github.com/stnc");
            document.AddSubject("Proforma Fatura Oluşturucu");
            document.AddTitle("Proforma Fatura");
          
            document.Add(image); //logo 
   
            document.Add(table2); //bolum ve saat yazan 
            document.Add(table4);
            document.Add(p2);


            document.Add(table);
            document.Add(table5);
            document.Add(table6);
            document.Add(table6Img);

            document.Close();

            return returnPath;
        }

    }
}