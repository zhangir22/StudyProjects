using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Convert Excel file to DOCX file
            ExcelToPdf x = new ExcelToPdf();

            // Set DOCX as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string docxFile = Path.ChangeExtension(excelFile, ".docx"); ;

            try
            {
                x.ConvertFile(excelFile, docxFile);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docxFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
