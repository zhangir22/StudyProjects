Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Result.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		If FileUpload1.PostedFile.FileName.Length = 0 OrElse FileUpload1.FileBytes.Length=0 Then
            Result.Text = "Please select an Excel document for conversion!"
			Return
		End If
		Result.Text = "Converting ..."

        Dim x As New SautinSoft.ExcelToPdf()
        x.PageStyle.PageSize.Letter()


        Dim pdfBytes() As Byte = Nothing

        Try
            pdfBytes = x.ConvertBytes(FileUpload1.FileBytes)
        Catch

        End Try


        'show PDF
        If pdfBytes IsNot Nothing Then
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = "application/PDF"
            Response.BinaryWrite(pdfBytes)
            Response.Flush()
            Response.End()
        Else
            Result.Text = "Converting failed!"
        End If
    End Sub
End Class
