Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Merge two PDF files.
        ' 1. Let's get a PDF from .xlsx.
        ' 2. Let's merge this PDF with itself.
        Dim x As New ExcelToPdf()
        x.PageStyle.PageSize.Letter()
        x.PageStyle.PageMarginTop.mm(5)

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        ' Let's convert only 3rd page.
        x.Sheets.Custom(New Integer() {3})

        Dim excelFile As String = Path.GetFullPath("..\test.xlsx")
        Dim pdfFile As New FileInfo(Path.ChangeExtension(excelFile, ".pdf"))
        Dim singlePdf As String = Path.Combine(pdfFile.Directory.FullName, "Single.pdf")

        Try
            ' 1. Convert Excel to PDF.
            x.ConvertFile(excelFile, pdfFile.FullName)

            ' 2. Merge the PDF file with itself.
            x.MergePDFFileArrayToPDFFile(New String() {pdfFile.FullName, pdfFile.FullName}, singlePdf)

            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(singlePdf) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Module
