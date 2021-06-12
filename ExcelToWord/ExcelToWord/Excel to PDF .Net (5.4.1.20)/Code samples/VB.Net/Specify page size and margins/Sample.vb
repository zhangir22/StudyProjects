Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Specify page size and margins.
        Dim x As New ExcelToPdf()

        'Fit each sheet to single PDF page, A3 format.
        x.PageStyle.PageSize.A3()
        x.PageStyle.PageScale.Auto()
        x.PageStyle.PageOrientation.Landscape()
        x.PageStyle.PageMarginTop.mm(0)

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
