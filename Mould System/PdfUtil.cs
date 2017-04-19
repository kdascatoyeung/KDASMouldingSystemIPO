using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Data;

namespace Mould_System
{
    class PdfUtil
    {
        public static void ApplyFixedAssetPdf(DataTable table, string title, int mouldCount, int jigCount)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);

            string path = @"\\kdthk-dm1\MOSS$\CM\FixedAssets\" + title + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            System.Drawing.Bitmap bitmap = System.Drawing.Image.FromHbitmap(Properties.Resources.img_kyocera.GetHbitmap());

            var converter = new System.Drawing.ImageConverter();
            Image image = Image.GetInstance((byte[])converter.ConvertTo(bitmap, typeof(byte[])));
            image.SetAbsolutePosition(0, doc.PageSize.Height - image.Height);
            doc.Add(image);

            PdfPTable pdfTable = null;
            Font headerFont = FontFactory.GetFont("Calibri", 13);
            Font cellFont = FontFactory.GetFont("Calibri", 10);

            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            PdfPCell chTitle = new PdfPCell(new Phrase("FaNo: " + title + "\nDownload Datetime: " + datetime, headerFont));
            PdfPCell chChaseNo = new PdfPCell(new Phrase("Chase No.", headerFont));
            PdfPCell chItemText = new PdfPCell(new Phrase("Item Text", headerFont));
            PdfPCell chItemCode = new PdfPCell(new Phrase("Item Code", headerFont));
            PdfPCell chRingi = new PdfPCell(new Phrase("Ringi No.", headerFont));
            PdfPCell chVendor = new PdfPCell(new Phrase("Vendor", headerFont));

            pdfTable = new PdfPTable(5);
            pdfTable.SpacingBefore = 0;

            float width = PageSize.A4.Rotate().Width / 5;
            float[] headerWidths = { width - 50, width + 50, width - 50, width - 50, width + 100 };
            pdfTable.SetWidths(headerWidths);
            pdfTable.WidthPercentage = 100;

            chTitle.HorizontalAlignment = Element.ALIGN_LEFT;
            chTitle.Colspan = 5;
            chTitle.Border = iTextSharp.text.Rectangle.NO_BORDER;

            pdfTable.DefaultCell.BorderWidth = 2;
            pdfTable.DefaultCell.HorizontalAlignment = 1;

            chChaseNo.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            chItemText.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            chItemCode.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            chRingi.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            chVendor.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

            pdfTable.AddCell(chTitle);
            pdfTable.AddCell(chChaseNo);
            pdfTable.AddCell(chItemText);
            pdfTable.AddCell(chItemCode);
            pdfTable.AddCell(chRingi);
            pdfTable.AddCell(chVendor);

            foreach (DataRow row in table.Rows)
            {
                string chaseno = row.ItemArray[0].ToString();

                PdfPCell crChaseNo = new PdfPCell(new Phrase(row.ItemArray[0].ToString(), cellFont));
                PdfPCell crItemText = new PdfPCell(new Phrase(row.ItemArray[1].ToString(), cellFont));
                PdfPCell crItemCode = new PdfPCell(new Phrase(row.ItemArray[2].ToString(), cellFont));
                PdfPCell crRingi = new PdfPCell(new Phrase(row.ItemArray[3].ToString(), cellFont));
                PdfPCell crVendor = new PdfPCell(new Phrase(row.ItemArray[4].ToString(), cellFont));

                pdfTable.AddCell(crChaseNo);
                pdfTable.AddCell(crItemText);
                pdfTable.AddCell(crItemCode);
                pdfTable.AddCell(crRingi);
                pdfTable.AddCell(crVendor);
            }

            PdfPCell footerCell = new PdfPCell(new Phrase("\nMould: " + mouldCount + "    Jigs: " + jigCount + "\nTotal: " + (mouldCount + jigCount)));
            footerCell.HorizontalAlignment = Element.ALIGN_LEFT;
            footerCell.Colspan = 5;
            footerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            pdfTable.AddCell(footerCell);

            doc.Add(pdfTable);
            doc.Close();
        }
    }
}
