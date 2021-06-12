using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            //ConvertExcelAsByteArray();
            ConvertExcelAsMemoryStream();
        }
        public static void ConvertExcelAsByteArray()
        {
            // Convert Excel to PDF in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string pdfFile = Path.ChangeExtension(excelFile, ".pdf"); ;

            byte[] excelBytes = File.ReadAllBytes(excelFile);
            byte[] pdfBytes = null;

            try
            {
                pdfBytes = x.ConvertBytes(excelBytes);

                // Save pdfBytes to a file for demonstration purposes.
                File.WriteAllBytes(pdfFile, pdfBytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfFile) { UseShellExecute = true });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void ConvertExcelAsMemoryStream()
        {
            // Convert Excel to PDF in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string pdfFile = Path.ChangeExtension(excelFile, ".pdf");
            byte[] pdfBytes = null;

            try
            {
                // Let us say, we have a memory stream with Excel data.
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(excelFile)))
                {
                    pdfBytes = x.ConvertBytes(ms.ToArray());
                }
                // Save pdfBytes to a file for demonstration purposes.
                File.WriteAllBytes(pdfFile, pdfBytes);
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
