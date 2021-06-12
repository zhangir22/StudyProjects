Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertExcelAsByteArray()
        'ConvertExcelAsMemoryStream()
    End Sub

    Public Sub ConvertExcelAsByteArray()

        ' Convert Excel to DOCX in memory
        Dim x As New ExcelToPdf()

        ' Set DOCX as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim docxFile As String = Path.ChangeExtension(excelFile, ".docx")


        Dim excelBytes() As Byte = File.ReadAllBytes(excelFile)
        Dim docxBytes() As Byte = Nothing

        Try
            docxBytes = x.ConvertBytes(excelBytes)

            ' Save docxBytes to a file for demonstration purposes.
            File.WriteAllBytes(docxFile, docxBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub

    Public Sub ConvertExcelAsMemoryStream()

        ' Convert Excel to DOCX in memory
        Dim x As New ExcelToPdf()

        ' Set DOCX as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Docx

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim docxFile As String = Path.ChangeExtension(excelFile, ".docx")
        Dim docxBytes() As Byte = Nothing

        Try
            ' Let us say, we have a memory stream with Excel data.
            Using ms As New MemoryStream(File.ReadAllBytes(excelFile))
                docxBytes = x.ConvertBytes(ms.ToArray())
            End Using
            ' Save docxBytes to a file for demonstration purposes.
            File.WriteAllBytes(docxFile, docxBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(docxFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Module
