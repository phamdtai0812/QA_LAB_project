<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"
    Inherits="QA_LAB_project.WebForm1" EnableEventValidation="false" %>

<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI Datepicker - Restrict date range</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#datepicker" ).datepicker({ minDate: -20, maxDate: "+1M +10D" });
  } );
  </script>
</head>
<body>
    <form runat="server">
        <asp:GridView ID="GridView1" HeaderStyle-BackColor="#666666" HeaderStyle-ForeColor="White"
            RowStyle-BackColor="#E4E4E4" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Customer Id" ItemStyle-Width="100px" />
                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="120px" />
                <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120px" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lbDownloadFile" name="lbDownloadFile" Text="Click me" runat="server" CausesValidation="false"
            OnClick="lbDownloadFile_Click" />
    </form>
</body>
   
</html>
