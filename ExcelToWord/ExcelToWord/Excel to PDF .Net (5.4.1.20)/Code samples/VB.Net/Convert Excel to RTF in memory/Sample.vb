Imports System
Imports System.IO
Imports SautinSoft

Module Sample

    Sub Main()
        ConvertExcelAsByteArray()
        'ConvertExcelAsMemoryStream()
    End Sub

    Public Sub ConvertExcelAsByteArray()
        ' Convert Excel to RTF in memory
        Dim x As New ExcelToPdf()

        ' Set RTF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf

        ' Let's create trace file.
        x.CreateTraceFile = True
        x.TraceFilePath = Path.GetFullPath("..\trace.txt")

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim rtfFile As String = Path.ChangeExtension(excelFile, ".rtf")

        Dim excelBytes() As Byte = File.ReadAllBytes(excelFile)
        Dim rtfBytes() As Byte = Nothing

        Try
            rtfBytes = x.ConvertBytes(excelBytes)

            ' Save rtfBytes to a file for demonstration purposes.
            File.WriteAllBytes(rtfFile, rtfBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(rtfFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub

    Public Sub ConvertExcelAsMemoryStream()
        ' Convert Excel to RTF in memory
        Dim x As New ExcelToPdf()

        ' Set RTF as output format.
        x.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Rtf

        ' Let's create trace file.
        x.CreateTraceFile = True
        x.TraceFilePath = Path.GetFullPath("..\trace.txt")

        Dim excelFile As String = Path.GetFullPath("..\test.xls")
        Dim rtfFile As String = Path.ChangeExtension(excelFile, ".rtf")
        Dim rtfBytes() As Byte = Nothing

        Try
            ' Let us say, we have a memory stream with Excel data.
            Using ms As New MemoryStream(File.ReadAllBytes(excelFile))
                rtfBytes = x.ConvertBytes(ms.ToArray())
            End Using
            ' Save rtfBytes to a file for demonstration purposes.
            File.WriteAllBytes(rtfFile, rtfBytes)
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(rtfFile) With {.UseShellExecute = True})
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Module
