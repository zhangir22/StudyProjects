using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Set custom area to convert.
            ExcelToPdf x = new ExcelToPdf();
            x.PageStyle.PageSize.Letter();

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            // Let's convert only rectangle from "B6" to "C9" on sheet 1.            
            x.Sheets.PrintArea.Add("B6", "C9", new int[]{1});

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
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
