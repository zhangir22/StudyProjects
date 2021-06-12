Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertExcelAsByteArray()
        'ConvertExcelAsMemoryStream()
    End Sub

    Public Sub ConvertExcelAsByteArray()
        ' Convert Excel to PDF in memory
        Dim x As New ExcelToPdf()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim pdfFile As String = Path.ChangeExtension(excelFile, ".pdf")


        Dim excelBytes() As Byte = File.ReadAllBytes(excelFile)
        Dim pdfBytes() As Byte = Nothing

        Try
            pdfBytes = x.ConvertBytes(excelBytes)

            ' Save pdfBytes to a file for demonstration purposes.
            File.WriteAllBytes(pdfFile, pdfBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try

    End Sub

    Public Sub ConvertExcelAsMemoryStream()
        ' Convert Excel to PDF in memory
        Dim x As New ExcelToPdf()

        ' Set PDF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim pdfFile As String = Path.ChangeExtension(excelFile, ".pdf")
        Dim pdfBytes() As Byte = Nothing

        Try
            ' Let us say, we have a memory stream with Excel data.
            Using ms As New MemoryStream(File.ReadAllBytes(excelFile))
                pdfBytes = x.ConvertBytes(ms.ToArray())
            End Using
            ' Save pdfBytes to a file for demonstration purposes.
            File.WriteAllBytes(pdfFile, pdfBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(pdfFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Module
