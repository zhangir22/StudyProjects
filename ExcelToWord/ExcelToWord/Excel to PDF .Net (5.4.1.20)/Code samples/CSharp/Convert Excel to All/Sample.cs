using SautinSoft;
using System.IO;

namespace Sample
{
    internal class Sample
    {

        private static void Main(string[] args)
        {
            //Prepare variables with path.
            string excelFile = Path.GetFullPath(@"..\..\test.xlsx");
            string docxFile = Path.ChangeExtension(excelFile, ".docx"); ;
            string rtfFile = Path.ChangeExtension(excelFile, ".rtf"); ;
            string pdfFile = Path.ChangeExtension(excelFile, ".pdf"); ;

            ExcelToPdf x = new ExcelToPdf();

            // Set DOCX as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx;
            x.ConvertFile(excelFile, docxFile);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docxFile) { UseShellExecute = true });

            // Set RTF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf;
            x.ConvertFile(excelFile, rtfFile);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rtfFile) { UseShellExecute = true });

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;
            x.ConvertFile(excelFile, pdfFile);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfFile) { UseShellExecute = true });
        }
    }
}
