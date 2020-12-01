using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using Stnc.CMS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

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
            Font fontMiniSmall = new Font(baseFont, 5, Font.NORMAL, BaseColor.Blue); //FontFactory.GetFont("Arial", 10, BaseColor.Black

            Document document = new Document(PageSize.Letter, 50f, 10f, 10f, 0f);



            document.SetMargins(10f, 10f, 10f, 0f);

   

            PdfWriter.GetInstance(document, stream);
            document.Open();



           /// document.Add(new Paragraph("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ"));

            PdfPTable table = new PdfPTable(5);

            Image image = Image.GetInstance("D:\\logo2.png");

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
            PdfPCell cell2 = new PdfPCell(new Phrase("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ", font));
            cell2.Border = Rectangle.NO_BORDER;
            cell2.HorizontalAlignment = PdfCell.ALIGN_LEFT;
            table2.AddCell(cell2);


            cell2 = new PdfPCell(new Phrase("11.12.2019", font));
            cell2.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
            cell2.Border = Rectangle.NO_BORDER;
            table2.AddCell(cell2);

            var p = new Paragraph(16, "PLASTİK REKONSTRÜKTİF VE ESTETİK CERRAHİ ANABİLİM DALI BAŞKANLIĞI", font);
            p.Alignment = Element.ALIGN_LEFT; // p.IndentationLeft = 100;

            var p2 = new Paragraph(16, "Proforma Fatura", font);
            p2.Alignment = Element.ALIGN_CENTER;

            /// ****** HEADER *******//// 
            PdfPCell cell = new PdfPCell(new Phrase("Hayvan Türü -  Yaşı", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Fiyat", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("İstenen Hayvan Sayısı", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Destek istenen Hayvan Sayısı", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Bakım Desteği Gün sayısı", font));
            table.AddCell(cell);
            /// ****** HEADER end*******//// 


            /// ****** içerik *******//// 
            cell = new PdfPCell(new Phrase(" Fare (Balb-C) / 8 Haftalık Yaşa Kadar ", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5 TL", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5", font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);
            /// ****** HEADER end*******//// 

            /*
            cell = new PdfPCell(new Phrase("agirlik:420 gr / Cinsiyet: Erkek / Ötenazi[1 TL]: Evet  ", font));
            cell.Colspan = 5;
            cell.Border = Rectangle.NO_BORDER;
            cell.PaddingTop = -7;
            table.AddCell(cell);
            */


            


                   string text = @"
                    *Fiyatlar, Erciyes Üniversitesi’ne mensup araştırmacılar için ve kurum dışı taleplerde fiyatlar geçerlidir.
                    **Diyabet projeleri kapsamında takip edilecek hayvanlar için % 50 daha fazla günlük bakım ücreti alınır.
                    ***Ötenazi ve özel cerrahi operasyonlar hariç; post operatif bakım, anestezi, enjeksiyon, kan alma, hayvan tutma, hayvan tartma ve gavaj uygulaması gibi desteklerden oluşmaktadır.
                     ****Ötenazi için gerekli kimyasal maddeler araştırmacı tarafından temin edilir. ";
            var p3 = new Paragraph(12, text, fontMiniSmall);
            p3.IndentationRight = 50f;

            cell = new PdfPCell(new Phrase("Ağırlık: 420 gr | Cinsiyet: Erkek | Ötenazi [1 TL]: Evet", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" Destek Talep Türü Seçenekleri   ",font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("MADDE UYGULAMA (ENJEKSİYON, GAVAJ v.s.) ÜCRETİ / Fiyat 10 ₺   ", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase("KAN ALMA (İNTRAKARDİYOK, İNTRAVENÜZ v.s.) ÜCRETİ / Fiyat 5 ₺  ", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Toplam  ", font));
            cell.Colspan = 4;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("5", font));
            cell.Colspan = 1;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            // metadata
            document.AddCreator("EstimatorX.com");
            document.AddKeywords("estimation");
            document.AddAuthor("ww");
            document.AddSubject("ee");
            document.AddTitle("eee");


          
            document.Add(image); //logo 
   
            document.Add(table2); //bolum ve saat yazan 
            document.Add(p);
            document.Add(p2);


            document.Add(table);

            document.Add(p3);
            document.Close();

            return returnPath;
        }

    }
}