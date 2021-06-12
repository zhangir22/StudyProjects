Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()

        ' Prepare variables with path.
        Dim excelFile As String = Path.GetFullPath("..\test.xlsx")
        Dim docxFile As String = Path.ChangeExtension(excelFile, ".docx")
        Dim rtfFile As String = Path.ChangeExtension(excelFile, ".rtf")
        Dim pdfFile As String = Path.ChangeExtension(excelFile, ".pdf")

        Dim x As New ExcelToPdf()

        ' Set DOCX as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx
        x.ConvertFile(excelFile, docxFile)
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxFile) With {.UseShellExecute = True})

        ' Set RTF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf
        x.ConvertFile(excelFile, rtfFile)
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(rtfFile) With {.UseShellExecute = True})

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf
        x.ConvertFile(excelFile, pdfFile)
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfFile) With {.UseShellExecute = True})
    End Sub
End Module
