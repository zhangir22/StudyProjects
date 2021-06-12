Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Convert a password protected workbook
        Dim x As New ExcelToPdf()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        'Set the password for protected workbook.
        x.Password = "qwerty"

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
