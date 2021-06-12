using System;
using System.IO;
using SautinSoft;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Steps to activate the component:

            // 1. Open your project in Visual Studio.
            // 2. Remove the reference to the "SautinSoft.ExcelToPdf.dll".
            // 3. Replace the old file "SautinSoft.ExcelToPdf.dll" by the new "SautinSoft.ExcelToPdf.dll".
            //    (You can find the new "SautinSoft.ExcelToPdf.dll" inside "Bin" in "exceltopdf_net.zip").
            // 4. Add new reference to the new file "SautinSoft.ExcelToPdf.dll".
            // 5. Fill the property 'Serial' by your serial (Activation key):

            string myKey = "1234567890";
            
            // Convert Excel file to PDF file
            ExcelToPdf x = new ExcelToPdf();

            x.Serial = myKey;

            // Set PDF as output format.
            x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

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
