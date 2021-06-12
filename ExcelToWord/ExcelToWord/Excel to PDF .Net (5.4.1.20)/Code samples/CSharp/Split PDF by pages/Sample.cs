using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Split PDF by pages.
            // 1. Let's get a PDF with 3 pages from .xlsx.
            // 2. Let's split it by 3 PDF files and show them.
            ExcelToPdf x = new ExcelToPdf();
            x.PageStyle.PageSize.Letter();
            x.PageStyle.PageMarginTop.mm(5);

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            string excelFile = Path.GetFullPath(@"..\..\test.xlsx");
            FileInfo pdfFile = new FileInfo(Path.ChangeExtension(excelFile, ".pdf"));

            try
            {
                // 1. Let's get a PDF with 3 pages from .xlsx.
                x.ConvertFile(excelFile, pdfFile.FullName);

                // 2. Let's split it by 3 PDF files and show them.
                // Create a directory for storing separate PDFs.
                DirectoryInfo pdfDir = pdfFile.Directory.CreateSubdirectory("My Pages");
                x.SplitPDFFileToPDFFolder(pdfFile.FullName, pdfDir.FullName);

                // Show result
                FileInfo[] pageFiles = pdfDir.GetFiles("*.pdf");
                Console.WriteLine("Resulting PDF files:\n");
                foreach (FileInfo pageFile in pageFiles)
                {
                    Console.WriteLine(pageFile.Name);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.ReadLine();
        }
    }
}
