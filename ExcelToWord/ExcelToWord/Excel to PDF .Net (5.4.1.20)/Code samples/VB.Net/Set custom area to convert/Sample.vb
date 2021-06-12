Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Set custom area to convert.
        Dim x As New ExcelToPdf()
        x.PageStyle.PageSize.Letter()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        ' Let's convert only rectangle from "B6" to "C9" on sheet 1.            
        x.Sheets.PrintArea.Add("B6", "C9", New Integer() {1})

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
