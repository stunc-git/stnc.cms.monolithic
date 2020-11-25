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

            string arialTtf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

            BaseFont baseFont = BaseFont.CreateFont(arialTtf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Font font = new Font(baseFont, 12, Font.NORMAL);

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            document.Open();



            document.Add(new Paragraph("ERCİYES ÜNİVERSİTESİ TIP FAKÜLTESİ"));

            PdfPTable table = new PdfPTable(5);

            Image image2 = Image.GetInstance("D:\\logo.png");

            /// ****** HEADER *******//// 
            PdfPCell cell = new PdfPCell(new Phrase("Hayvan Türü-  Yaşı", font));
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
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5 TL", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("5", font));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("10", font));
            table.AddCell(cell);
            /// ****** HEADER end*******//// 

            /*
            cell = new PdfPCell(new Phrase("agirlik:420 gr / Cinsiyet: Erkek / Ötenazi[1 TL]: Evet  ", font));
            cell.Colspan = 5;
            cell.Border = Rectangle.NO_BORDER;
            cell.PaddingTop = -7;
            table.AddCell(cell);
            */
        

            cell = new PdfPCell(new Phrase("agirlik:420 gr / Cinsiyet: Erkek / Ötenazi[1 TL]: Evet  ", font));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" Destek Talep Türü Seçenekleri   ", FontFactory.GetFont("Arial", 10,  BaseColor.Black)));
            cell.Colspan = 5;
            cell.PaddingTop = 5;
            cell.PaddingBottom = 5;
            cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
            table.AddCell(cell);


            document.Add(image2);
            document.Add(table);
            document.Close();

            return returnPath;
        }

    }
}