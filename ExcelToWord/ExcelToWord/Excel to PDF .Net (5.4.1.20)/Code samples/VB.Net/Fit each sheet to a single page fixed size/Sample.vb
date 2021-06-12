Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()

        ' Fit each sheet to a single page fixed size.
        Dim x As New ExcelToPdf()

        'Fit each sheet to single PDF page, A4 format.
        x.PageStyle.PageSize.A4()
        x.PageStyle.PageScale.Auto()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

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
