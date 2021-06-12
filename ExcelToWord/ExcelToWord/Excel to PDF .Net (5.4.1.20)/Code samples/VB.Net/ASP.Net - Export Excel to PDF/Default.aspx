<%@ Page Language="VB" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css" media="all"/>
</head>
<body>
    <div class="container flex-grow">
    <div class="col-12">
   <form id="form1" runat="server" class="border p-4">
     <div class="row">
         <div class="col-12 text-center">
              <h1 class="h1 text-muted">Excel to PDF .Net</h1>
              <hr style="width:200px; background-color:dodgerblue;"/>
         </div>
     </div>
     <div class="row">
         <div class="col-lg-4 col-sm-12">
             <div class="text-center py-4">
                 <a href="http://www.sautinsoft.com/products/excel-to-pdf/order.php">
                 <img alt="100% C# assembly to export Excel into PDF" height="160" src="e.png" class="img-fluid" border="0"/></a>
                 <div class="pt-4">
                     <a href="https://www.sautinsoft.com/products/excel-to-pdf/order.php" target="_blank">Purchase Excel to PDF .Net online!</a>
                 </div>
             </div>
          </div>
          <div class="col-lg-8 col-sm-12">
              <p>Excel to PDF .Net is a standalone C# library to convert Excel spreadsheets and workbooks to PDF, Word, RTF, DOCX.</p>
              <p>This sample shows how to export Excel workbook to PDF in memory.</p>
              <div class="form-row">
                  <h2 class="p-2">Please select any Excel file (*.xls, *.xlsx):</h2>
                  <div class="form-group col-lg-8 col-md-6 col-sm-12">
                      <div class="input-group mb-3" lang="en">
                         <div class="custom-file">
                             <asp:FileUpload ID="FileUpload1" type="file" CssClass="custom-file-input custom-file-input-lg" accept=".xls, .xlsx" runat="server"/>
                             <label class="custom-file-label" for="FileUpload1">Select Excel file...</label>
                         </div>
                     </div>
                  </div>
                  <div class="form-group col-lg-4 col-md-6 col-sm-12">
                      <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" OnClick="Button1_Click" Text="Export to PDF"/>
                      <asp:Label ID="Result" runat="server"></asp:Label>
                  </div>
              </div>
          </div>
     </div>
   </form>
  </div>
</div>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
<script type="text/javascript">
    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').addClass("selected").html(fileName);});
</script>
</body>
</html>
