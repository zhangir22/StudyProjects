using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Merge two PDF files.
            // 1. Let's get a PDF from .xlsx.
            // 2. Let's merge this PDF with itself.
            ExcelToPdf x = new ExcelToPdf();
            x.PageStyle.PageSize.Letter();
            x.PageStyle.PageMarginTop.mm(5);

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            // Let's convert only 3rd page.
            x.Sheets.Custom(new int[]{3});

            string excelFile = Path.GetFullPath(@"..\..\test.xlsx");
            FileInfo pdfFile = new FileInfo(Path.ChangeExtension(excelFile, ".pdf"));
            string singlePdf = Path.Combine(pdfFile.Directory.FullName, "Single.pdf");

            try
            {
                // 1. Convert Excel to PDF.
                x.ConvertFile(excelFile, pdfFile.FullName);
                
                // 2. Merge the PDF file with itself.
                x.MergePDFFileArrayToPDFFile(new string[] { pdfFile.FullName, pdfFile.FullName },
                    singlePdf);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(singlePdf) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
