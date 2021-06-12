using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertExcelAsByteArray();
            //ConvertExcelAsMemoryStream();
        }
        public static void ConvertExcelAsByteArray()
        {
            // Convert Excel to DOCX in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set DOCX as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string docxFile = Path.ChangeExtension(excelFile, ".docx"); ;

            byte[] excelBytes = File.ReadAllBytes(excelFile);
            byte[] docxBytes = null;

            try
            {
                docxBytes = x.ConvertBytes(excelBytes);

                // Save docxBytes to a file for demonstration purposes.
                File.WriteAllBytes(docxFile, docxBytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docxFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void ConvertExcelAsMemoryStream()
        {
            // Convert Excel to DOCX in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set DOCX as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx;

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string docxFile = Path.ChangeExtension(excelFile, ".docx");
            byte[] docxBytes = null;

            try
            {
                // Let us say, we have a memory stream with Excel data.
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(excelFile)))
                {
                    docxBytes = x.ConvertBytes(ms.ToArray());
                }
                // Save docxBytes to a file for demonstration purposes.
                File.WriteAllBytes(docxFile, docxBytes);
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
