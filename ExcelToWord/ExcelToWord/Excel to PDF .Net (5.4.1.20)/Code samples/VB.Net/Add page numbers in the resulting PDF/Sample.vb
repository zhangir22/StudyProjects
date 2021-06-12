Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Add page numbers in the resulting PDF.
        Dim x As New ExcelToPdf()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        ' Set page numbers in format "Page 1 of N" formatted by Arial, 14 pt.
        x.PageStyle.PageNumFormat.Text = "Page {page} of {numPages}"
        x.PageStyle.PageNumFormat.FontFace = "Arial"
        x.PageStyle.PageNumFormat.FontSize = 14

        Dim excelFile As String = Path.GetFullPath("..\test.xlsx")
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
