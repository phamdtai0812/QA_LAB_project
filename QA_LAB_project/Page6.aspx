<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page6.aspx.cs" Inherits="QA_LAB_project.Page6" %>

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
             <%-- <asp:Button ID="btnPrint" Text="Print Report" Style="width: 120px; margin-left: 200px" runat="server" OnClientClick="printReport();" class="btn btn-secondary" />--%>
        </div>
        <div id="disp">
           <div class="panel panel-default" style="width: 98%; padding: 2px; margin: 2px" id="8">
                            <div style="margin-left: 5px">Page 6 Hydrate Shipments/Product Quality</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="Text1" name="reportMonthYear" runat="server" />
                            </div>
                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 98%; margin-left: 2px;">
                                    <div style="overflow-x: auto; width: 100%">
                                      <%--  <asp:GridView ID="gv_page6" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="X-Small" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="70px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p53" runat="server" style="text-align: center" Text='<%# Eval("P100","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p54" runat="server" Text='<%# Eval("P200","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p55" runat="server" Text='<%# Eval("P325","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Si" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p57" runat="server" Text='<%# Eval("SI","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p58" runat="server" Text='<%# Eval("FE","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p59" runat="server" Text='<%# Eval("NA","{0:0.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Zn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p60" runat="server" Text='<%# Eval("ZN","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p61" runat="server" Text='<%# Eval("MN","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ca" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p62" runat="server" Text='<%# Eval("CA","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ti" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p63" runat="server" Text='<%# Eval("TI","{0:0.0000}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ai" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p64" runat="server" style="text-align: center" Text='<%# Eval("AI","{0:00.00}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="FM" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p65" runat="server" Text='<%# Eval("FREEMOIST","{0:0.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SiO₂" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p66" runat="server" Text='<%# Eval("SiO₂","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe₂O₃" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p67" runat="server" Text='<%# Eval("Fe₂O₃","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na₂O" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p68" runat="server" Text='<%# Eval("Na₂O","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="C-SEDS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p69" runat="server" style="text-align: center"  Text='<%# Eval("CSEDS","{0:0.00}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INSOLS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p70" runat="server" style="text-align: center" Text='<%# Eval("INSOLS","{0:0.000}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Bulk Dens" ItemStyle-Width="50" ItemStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p71" runat="server" style="text-align: center" Text='<%# Eval("BULKDENS","{0:0.0}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="L" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p72" runat="server" Text='<%# Eval("HUNTERL","{0:.00}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p73" runat="server" Text='<%# Eval("HUNTERA","{0:.00}") %>' Width="37px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="B" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p74" runat="server" Text='<%# Eval("HUNTERB","{0:.00}") %>' Width="37px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                            <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                        </asp:GridView>--%>


                                           <asp:GridView ID="gv_page6" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px; border:none"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller"
                                        
                                         >
   <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="70px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p53" runat="server" style="text-align: center" Text='<%# Eval("P100","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p54" runat="server" Text='<%# Eval("P200","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p55" runat="server" Text='<%# Eval("P325","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Si" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p57" runat="server" Text='<%# Eval("SI","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p58" runat="server" Text='<%# Eval("FE","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p59" runat="server" Text='<%# Eval("NA","{0:0.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Zn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p60" runat="server" Text='<%# Eval("ZN","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p61" runat="server" Text='<%# Eval("MN","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ca" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p62" runat="server" Text='<%# Eval("CA","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ti" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p63" runat="server" Text='<%# Eval("TI","{0:0.0000}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ai" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p64" runat="server" style="text-align: center" Text='<%# Eval("AI","{0:00.00}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="FM" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p65" runat="server" Text='<%# Eval("FREEMOIST","{0:0.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SiO₂" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p66" runat="server" Text='<%# Eval("SiO₂","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe₂O₃" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p67" runat="server" Text='<%# Eval("Fe₂O₃","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na₂O" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p68" runat="server" Text='<%# Eval("Na₂O","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="C-SEDS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p69" runat="server" style="text-align: center"  Text='<%# Eval("CSEDS","{0:0.00}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INSOLS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p70" runat="server" style="text-align: center" Text='<%# Eval("INSOLS","{0:0.000}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Bulk Dens" ItemStyle-Width="50" ItemStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p71" runat="server" style="text-align: center" Text='<%# Eval("BULKDENS","{0:0.0}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="L" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p72" runat="server" Text='<%# Eval("HUNTERL","{0:.00}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p73" runat="server" Text='<%# Eval("HUNTERA","{0:.00}") %>' Width="37px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="B" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p74" runat="server" Text='<%# Eval("HUNTERB","{0:.00}") %>' Width="37px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
        </div>
    </form>
</body>
<script type="text/javascript">
    function printReport() {

        document.getElementById('divPrint').style.display = "none";

        window.print();

    }
</script>
</html>
