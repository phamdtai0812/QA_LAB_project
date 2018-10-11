<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H30.aspx.cs" Inherits="QA_LAB_project.H30" %>

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
<%--        <div>
            <table class="table">
                <asp:Repeater ID="tableRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("name") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

        </div>
        <div>--%>
        <div class="col-md-2" id="divPrint">
            <asp:Button ID="btnPrint" Text="Print Report" Style="width: 120px; margin-left: 200px" runat="server" OnClientClick="printReport();" class="btn btn-secondary" />
        </div>

      
        <div id="disp">
            <div class="panel panel-default" style="width: 800px; margin-left: 50px">
                <div class="panel panel-default" style="width: 400px; margin-left: 200px">
                    <p style="text-align: center; line-height: .5"><b>HYDRATED ALUMINA QUALITY REPORT H-30</b></p>
                    <p style="text-align: center; line-height: .5">Noranda Alumina</p>
                    <p style="text-align: center; line-height: .5">P.O. Box 3370, Gramercy, LA 70052-3370</p>


                    <p style="text-align: center; line-height: .5">
                        <input type="text" runat="server" id="report_date" style="border: none; font-weight: 400; text-align: center" value="" />
                    </p>
                </div>

                <div class="table-responsive" style="margin-left: 100px; float: left">

                    <asp:GridView ID="gv_reportH30" runat="server" Height="16px" Width="260px"
                        Style="overflow-x: scroll; border-radius: 3px"
                        AutoGenerateColumns="False"
                        GridLines="Horizontal"
                        BorderStyle="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Test" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30name" runat="server" Text='<%# Eval("name") %>' Width="150px" BorderStyle="None" Style="text-align: left"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Results" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30val" runat="server" Text='<%# Eval("value", "{0:.###}") %>' Width="100px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="table-responsive" style="float: left; padding-left: 10px">

                    <asp:GridView ID="gv_reportH30_2" runat="server" Height="16px" Width="260px"
                        Style="overflow-x: scroll; border-radius: 3px"
                        AutoGenerateColumns="False"
                        GridLines="Horizontal"
                        BorderStyle="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Test" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30name" runat="server" Text='<%# Eval("name") %>' Width="180px" BorderStyle="None"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Results" ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30val" runat="server" Text='<%# Eval("value", "{0:.###}") %>' Width="150px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

                <div class="table-responsive" style="float: left; margin-left: 200px; background-color: white">
                    <br />
                    <br />
                    <asp:GridView ID="gv_reportH30_3" runat="server" Height="16px" Width="250px"
                        CssClass="table  table-bordered  table-hover"
                        Border-Style="none"
                        Border="none"
                        GridLines="Horizontal"
                        OnRowDataBound="gv_OnRowDataBound"
                        AutoGenerateColumns="False"
                        EditRowStyle-Width="20px">
                        <EditRowStyle CssClass="GridViewEditRow" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="50" HeaderText="Truck/Railcar No." HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30_1" Style="padding: 0;" runat="server" Text='<%# Eval("name") %>' Width="140px" BorderStyle="None"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="% Refelectance" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30_2" runat="server" Text='<%# Eval("reflectance") %>' Width="120px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="% Leachable" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:TextBox ID="h30_3" runat="server" Text='<%# Eval("lsoda") %>' Width="120px" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="White" />
                    </asp:GridView>
                </div>





         <div class="table-responsive" style="float: left; margin-left: 50px; background-color: white">
                    <br />
                    <p style="white-space: nowrap;">This material meets all customer specifications.______________________________</p>
                    <p style="white-space: nowrap; margin-left: 330px;">Quality Control Approval</p>
                </div>
             
            </div>
                  
      
            </div>

    

    

    </form>
</body>
        <script type="text/javascript">




            //$("disp *").disable();
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
