<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionDay.aspx.cs" Inherits="QA_LAB_project.ProductionDay" %>
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
<%--<div>
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
        <div id="disp" style="font-size: medium">
            <div class="panel panel-default" style="width: 800px; margin-left: 50px">
                <div class="panel panel-default" style="width: 400px; margin-left: 200px">
                    <p style="text-align: center; line-height: .5">
                       Production Day -  <input type="text" runat="server" id="report_date" style="border: none; font-weight: 400; text-align: center" value="" />
                    </p>
                </div>
                <div class="table-responsive" style="margin-left: 100px">
                    <br />
                    <br />
                    <div class="row">
                        1. Laboratory Daily Reports - Metals - 1
                        <asp:GridView ID="Production_Day1" runat="server" Height="16px" Width="260px"
                            Style="overflow-x: scroll; border-radius: 3px"
                            AutoGenerateColumns="False"
                            BorderStyle="None">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:TextBox ID="prodday_a" runat="server" Text='<%# Eval("a") %>' Width="170px" BorderStyle="None"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:TextBox ID="prodday_b" runat="server" Text='<%# Eval("b","{0:0.###}") %>' Width="100px" BorderStyle="None"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="Production_Day2" runat="server" Height="16px" Width="260px"
                            Style="overflow-x: scroll; border-radius: 3px"
                            AutoGenerateColumns="False"
                            BorderStyle="None">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:TextBox ID="prodday_2a" runat="server" Text='<%# Eval("a") %>' Width="150px" BorderStyle="None"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:TextBox ID="prodday_2b" runat="server" Text='<%# Eval("b","{0:0.###}") %>' Width="100px" BorderStyle="None"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <br />
                    </div>
                    <div class="row">
                     <div> 2. Miscellaneous 1</div>
                        <br />
                        <div class="table-responsive" style="float: left">
                            <asp:GridView ID="Production_Day3"
                                runat="server" Caption="SUF (Boot/Cone)">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day4" Caption="GPL Soda      "
                                runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="margin-left: 60px">
                            <asp:GridView ID="Production_Day5" Caption="Tray O'Flow Solids(GPL)"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <br />
                        <br />
                        <div class="table-responsive" style="float: left">
                            <asp:GridView ID="Production_Day6" Caption="Press Filtration"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="margin-left: 30px; float: left">
                            <asp:GridView ID="Production_Day7" Caption="Mud TAA Analysis"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="margin-left: 30px; float: left">
                            <asp:GridView ID="Production_Day8" Caption="Hot Well Ditches"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="table-responsive" style="margin-left: 30px; float: left">
                            <asp:GridView ID="Production_Day9" Caption="Silica/Caustic"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="margin-left: 30px; float: left">
                            <asp:GridView ID="Production_Day10"
                                runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="margin-left: 30px; float: left">
                            <asp:GridView ID="Production_Day11" Caption=""
                                runat="server">
                            </asp:GridView>
                        </div>
                    </div>
                     <br />
                     <br />
                     <br />
                     <br />
                     <br />
                     <br />
                     <br />
                    <div class="row">
                        <div>3. Miscellaneous 2</div>
                        <br />
                        <div class="table-responsive" style="float: left">
                            <asp:GridView ID="Production_Day12" Caption="Evap Feed" runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day13" Caption="Evap Discharge" runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day14" Caption="Washer Overflow" runat="server">
                            </asp:GridView>
                        </div>
                        <br />
                    
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day15" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day16" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                         <br />
                        <br />
                       
                        <div class="row">
                            <div class="table-responsive" style="float: left">
                                <asp:GridView ID="Production_Day17" Caption="" runat="server">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="row">
                            <div>4. Laborator Daily Reports-Metals-3</div>
                         <div class="table-responsive" style="float: left;">
                            <asp:GridView ID="Production_Day18" Caption="Primary Feed/Seed Tanks" runat="server">
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="row">
                        <div>5. Kiln Data</div>
                        <div class="table-responsive" style="float: left;">
                            <asp:GridView ID="Production_Day19" Caption="Kiln Feed Moisture" runat="server">
                            </asp:GridView>
                            </div>
                         <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day20" Caption="Kiln Feed Leachable Soda" runat="server">
                            </asp:GridView>
                            </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="table-responsive" style="float: left">
                            <asp:GridView ID="Production_Day21" Caption="Kiln Discharge LOI, %" runat="server">
                            </asp:GridView>
                        </div>
                          
                        <div class="table-responsive" style="float: left; margin-left: 20px">
                            <asp:GridView ID="Production_Day22" Caption="Kiln Discharge Analyses" runat="server">
                            </asp:GridView>
                        </div>

                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div>6. Alumina Shipments &nbsp&nbsp&nbsp&nbsp&nbsp 7. Hydrate Shipments&nbsp&nbsp&nbsp&nbsp&nbsp 8. Hydrate Shipments</div>
                     <div class="table-responsive" style="float: left;">
                            <asp:GridView ID="Production_Day23" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                     <div class="table-responsive" style="float: left; margin-left: 70px">
                            <asp:GridView ID="Production_Day24" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                     <div class="table-responsive" style="float: left; margin-left: 80px">
                            <asp:GridView ID="Production_Day25" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div>9. Continuous Precipitation Lab Data</div>  
                    <div class="table-responsive" style="float: left;">
                        <asp:GridView ID="Production_Day26" Caption="" runat="server">
                        </asp:GridView>
                    </div>
                    <div class="table-responsive" style="float: left; margin-left: 20px">
                        <asp:GridView ID="Production_Day27" Caption="" runat="server">
                        </asp:GridView>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                   <br />
                    <br />
                    <br />
                    <br />
                    <div class="row">
                        <div class="table-responsive" style="float: left">
                            <asp:GridView ID="Production_Day28" Caption="" runat="server">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                    <br />
                    <br />
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
