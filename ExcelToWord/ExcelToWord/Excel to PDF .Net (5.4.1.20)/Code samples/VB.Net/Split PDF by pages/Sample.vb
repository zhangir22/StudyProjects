Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ' Split PDF by pages.
        ' 1. Let's get a PDF with 3 pages from .xlsx.
        ' 2. Let's split it by 3 PDF files and show them.
        Dim x As New ExcelToPdf()
        x.PageStyle.PageSize.Letter()
        x.PageStyle.PageMarginTop.mm(5)

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        Dim excelFile As String = Path.GetFullPath("..\test.xlsx")
        Dim pdfFile As New FileInfo(Path.ChangeExtension(excelFile, ".pdf"))

        Try
            ' 1. Let's get a PDF with 3 pages from .xlsx.
            x.ConvertFile(excelFile, pdfFile.FullName)

            ' 2. Let's split it by 3 PDF files and show them.
            ' Create a directory for storing separate PDFs.
            Dim pdfDir As DirectoryInfo = pdfFile.Directory.CreateSubdirectory("My Pages")
            x.SplitPDFFileToPDFFolder(pdfFile.FullName, pdfDir.FullName)

            ' Show result
            Dim pageFiles() As FileInfo = pdfDir.GetFiles("*.pdf")
            Console.WriteLine("Resulting PDF files:" & ControlChars.Lf)
            For Each pageFile As FileInfo In pageFiles
                Console.WriteLine(pageFile.Name)
            Next pageFile

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.ReadLine()

    End Sub
End Module
