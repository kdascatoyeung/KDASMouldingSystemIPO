using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using iTextSharp.text;
using System.Data.SqlClient;
using Mould_System.services;
using Mould_System.checking;
using System.IO;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace Mould_System.file.pdf
{
    public class ExportPdfUtil
    {
        public static void ExportFixedAssetCode(DataTable table)
        {
            try
            {
                Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);

                string thismonth = DateTime.Today.ToString("yy/MM");

                int id;

                string query = "select top 1 dr_seqid from tb_downloadRecord where dr_yymm = '" + thismonth + "' order by dr_id desc";
                SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
                SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);

                if (!reader.HasRows)
                {
                    reader.Close();
                    id = 0;
                }
                else
                {
                    reader.Close();
                    id = (int)command.ExecuteScalar();
                }

                string year = string.Format("{0:yy}", DateTime.Today);
                string month = string.Format("{0:MM}", DateTime.Today);
                int newId = id + 1;

                string strId = newId.ToString("D3");

                string path = @"\\kdthk-dm1\MOSS$\CM\FixedAssets\FA" + year + month + "_" + strId + ".pdf";
                //string path = @"\\kmhk-dcmain\MOSS$\CM\Backup\FA" + year + month + "_" + strId + ".pdf";
                //string path = @"M:\Portal\FixedAssets\FA" + year + month + "_" + strId + ".pdf";

                string filename = "FA" + year + month + "_" + strId + ".pdf";
                string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                //string datetime = "2013.11.01 11:20:57";
                string title = "FA" + year + month + "_" + strId;
                //string title = "FA1311_001";

                //string directory = DataChecking.getDirectory();
                //directory = directory + @"\FA Files\" + DateTime.Today.ToString("yyyy-MM-dd") + @"\FA" + year + month + "_" + strId + ".pdf";

                //if (!Directory.Exists(directory))
                //Directory.CreateDirectory(directory);

                string insertText = string.Format("insert into tb_downloadRecord (dr_filename, dr_datetime, dr_yymm, dr_seqId) values ('{0}', '{1}', '{2}', '{3}')", filename, datetime, thismonth, newId);
                DataService.GetInstance().ExecuteNonQuery(insertText);

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

                    string updateText = string.Format("update tb_betamould set tm_pdfid = '{0}', tm_st_code = 'A' where tm_chaseno = '{1}'", title, chaseno);
                    DataService.GetInstance().ExecuteNonQuery(updateText);
                }
                doc.Add(pdfTable);
                doc.Close();
                Clipboard.SetText(title);
                MessageBox.Show("Record exported. Reference Id: " + title + " copied.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
    }
}
