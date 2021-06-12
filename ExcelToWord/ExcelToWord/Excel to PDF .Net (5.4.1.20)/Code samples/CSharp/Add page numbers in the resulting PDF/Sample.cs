using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Add page numbers in the resulting PDF.
            ExcelToPdf x = new ExcelToPdf();

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            // Set page numbers in format "Page 1 of N" formatted by Arial, 14 pt.
            x.PageStyle.PageNumFormat.Text = "Page {page} of {numPages}";
            x.PageStyle.PageNumFormat.FontFace = "Arial";
            x.PageStyle.PageNumFormat.FontSize = 14;

            string excelFile = Path.GetFullPath(@"..\..\test.xlsx");
            string pdfFile = Path.ChangeExtension(excelFile, ".pdf"); ;

            try
            {
                x.ConvertFile(excelFile, pdfFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
