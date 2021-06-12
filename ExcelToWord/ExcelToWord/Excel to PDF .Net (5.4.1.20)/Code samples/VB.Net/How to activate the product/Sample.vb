Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Steps to activate the component:

        ' 1. Open your project in Visual Studio.
        ' 2. Remove the reference to the "SautinSoft.ExcelToPdf.dll".
        ' 3. Replace the old file "SautinSoft.ExcelToPdf.dll" by the new "SautinSoft.ExcelToPdf.dll".
        '    (You can find the new "SautinSoft.ExcelToPdf.dll" inside "Bin" in "exceltopdf_net.zip").
        ' 4. Add new reference to the new file "SautinSoft.ExcelToPdf.dll".
        ' 5. Fill the property 'Serial' by your serial (Activation key):

        Dim myKey As String = "1234567890"

        ' Convert Excel file to PDF file
        Dim x As New ExcelToPdf()

        x.Serial = myKey

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim pdfFile As String = Path.ChangeExtension(excelFile, ".pdf")

        Try
            x.ConvertFile(excelFile, pdfFile)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Module
