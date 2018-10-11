<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiscReport.aspx.cs" Inherits="QA_LAB_project.MiscReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <style>

  #disp {
    pointer-events:none;
}

    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="col-md-2" id="divPrint">
            <asp:Button ID="btnPrint" Text="Print Report" Style="width: 120px; margin-left: 200px" runat="server" OnClientClick="printReport();" class="btn btn-secondary" />
        </div>

      
        <div id="disp">

            <div class="panel panel-default" style="width: 800px; margin-left: 50px">
          
                <div class="row clearfix">
                    <br />
                    <div class="table-responsive" style="margin-left: 100px; float: left">
                        Page Misc    &nbsp&nbsp&nbsp&nbsp <b>Gramercy Daily Lab Report </b>
                        <input type="text" runat="server" id="report_date" style="border: none; font-weight: 400; text-align: center" value="" />
                    <br />
                    <br />
                        <asp:GridView ID="gv_reportMisc" runat="server" Height="16px" Width="260px"
                            Style="overflow-x: scroll; border-radius: 3px"
                            AutoGenerateColumns="False"
                            GridLines="Horizontal"
                            BorderStyle="None">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="MiscName" runat="server" Text='<%# Eval("MMISCDESCR") %>' Width="300px" BorderStyle="None" Style="text-align: left"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="250px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="MiscValue1" runat="server" Text='<%# Eval("MMISCQTY", "{0:0.000}") %>' Width="50px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="MiscValue2" runat="server" Text='<%# Eval("MMISCSIZE", "{0:0.000}") %>' Width="50px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                    </div>
             
                   
                </div>


            </div>

      
   
        </div>

    

    </form>
</body>
        <script type="text/javascript">




           // $("disp *").disable();
            function printReport() {
               
                document.getElementById('divPrint').style.display = "none";
           
                window.print();

            }


            //$(document).ready(function () {
            //    $("#form1 :input").prop("readonly", true);

            //    $("#parent-selector :input").prop("disabled", true);
            
            //    //var allInputs = $(':text:visible');

            //    //allInputs.css("background-color", "#ffffff");
            //});


            //document.getElementById("form1").onclick = function () { return false; }
            //$(function () {
            //    $('#example').DataTable({
            //        responsive: {
            //            details: {
            //                display: $.fn.dataTable.Responsive.display.modal({
            //                    header: function (row) {
            //                        var data = row.data();
            //                        return 'Details for ' + data[0] + ' ' + data[1];
            //                    }
            //                }),
            //                renderer: $.fn.dataTable.Responsive.renderer.tableAll({
            //                    tableClass: 'ui table'
            //                })
            //            }
            //        }
            //    });
            //});
            //function Print() {
            //    var a = window.open('', '', 'width=450,height=300,resizable=1');
            //    a.document.write('<html><head></head><body>');
            //    a.document.write(document.getElementById('DIV_ID').innerHTML);
            //    a.document.write('</body></html>');
            //    a.document.close();
            //    a.print();
            //}
    </script>
</html>