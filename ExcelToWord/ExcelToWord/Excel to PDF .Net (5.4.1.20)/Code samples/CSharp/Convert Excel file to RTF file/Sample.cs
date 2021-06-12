using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert Excel file to RTF file
            ExcelToPdf x = new ExcelToPdf();

            // Set RTF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string rtfFile = Path.ChangeExtension(excelFile, ".rtf"); ;

            try
            {
                x.ConvertFile(excelFile, rtfFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rtfFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
