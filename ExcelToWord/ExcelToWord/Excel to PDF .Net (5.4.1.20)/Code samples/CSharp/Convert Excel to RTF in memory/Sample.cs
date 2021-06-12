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
            // Convert Excel to RTF in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set RTF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf;

            // Let's create trace file.
            x.CreateTraceFile = true;
            x.TraceFilePath = Path.GetFullPath(@"..\..\trace.txt");

            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string rtfFile = Path.ChangeExtension(excelFile, ".rtf"); ;

            byte[] excelBytes = File.ReadAllBytes(excelFile);
            byte[] rtfBytes = null;

            try
            {
                rtfBytes = x.ConvertBytes(excelBytes);

                // Save rtfBytes to a file for demonstration purposes.
                File.WriteAllBytes(rtfFile, rtfBytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rtfFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public static void ConvertExcelAsMemoryStream()
        {
            // Convert Excel to RTF in memory
            ExcelToPdf x = new ExcelToPdf();

            // Set RTF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf;

			// Let's create trace file.
            x.CreateTraceFile = true;
            x.TraceFilePath = Path.GetFullPath(@"..\..\trace.txt");
			
            string excelFile = Path.GetFullPath(@"..\..\test.xls");
            string rtfFile = Path.ChangeExtension(excelFile, ".rtf");
            byte[] rtfBytes = null;

            try
            {
                // Let us say, we have a memory stream with Excel data.
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(excelFile)))
                {
                    rtfBytes = x.ConvertBytes(ms.ToArray());
                }
                // Save rtfBytes to a file for demonstration purposes.
                File.WriteAllBytes(rtfFile, rtfBytes);
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
