using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Specify page size and margins.
            ExcelToPdf x = new ExcelToPdf();

            //Fit each sheet to single PDF page, A3 format.
            x.PageStyle.PageSize.A3();
            x.PageStyle.PageScale.Auto();
            x.PageStyle.PageOrientation.Landscape();
            x.PageStyle.PageMarginTop.mm(0);            

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

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
