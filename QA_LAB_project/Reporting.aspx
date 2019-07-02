<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="QA_LAB_project.Reporting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <script src="Scripts/jquery-3.1.0.js"></script>
<%--  
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>--%>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" rel="stylesheet"/>





     <style>

           .btn-outline-secondary {
            font-size: small;
            height: 40px;
             opacity: 0.6;
  transition: 0.3s;
  font-weight: 600;
        }
        .btn-outline-secondary:hover {opacity: 1}

          .centerPanel {
             border: 1px solid white;
            z-index: 1;
            position: relative;
            margin: 0 auto;
            top: 10px;
            width: 600px;
            height: 310px;
        
        }
        Body{

background: #DCDCDC; /* will apply color */

}
       .panel > .panel-heading {
    background-color: DimGray;
}

      .btn-secondary{
              background-color: #DDDDDD;
       }
      .addnew {
  font: bold 11px Arial;
  text-decoration: none;
  background-color: #EEEEEE;
  color: #333333;
  padding: 2px 6px 2px 6px;
  border-top: 1px solid #CCCCCC;
  border-right: 1px solid #333333;
  border-bottom: 1px solid #333333;
  border-left: 1px solid #CCCCCC;
}
      
.table-responsive {
  background-color: white; 
  font-family: Arial; 
  font-size: medium;
  font-weight:400;
  border: none;
   
 }
style1
{
background-color: cornflowerblue;
font-size: medium;
font-weight: bold;
color: white;
}
        @media print {
#printable{
     display:flex;
     justify-content:center;
     align-items:center;
     height:100%;
     }
    html, body{
      height:100%;
      width:100%;
    }
}
         .gvstyling th {
            background-color: #FFFF99 ;
            font-size: 12px;
        }
.panel{
  border:none;
  padding:0;
}
.panel-heading{
  border:1px solid #ccc;
  padding:10px;
  margin:0;
}
.panel-body{
  border:1px solid #ccc;
  padding:10px;
  border-top:0;
}
  #disp {
    pointer-events:none;
}
  .header2{
      background-color:#FFFF99;

  }




    </style>
    <br />
 

     <div class="panel panel-default" style="width: 800px; margin: auto">
            <div class="panel-heading">
              <p style="color:white">Gramercy Daily Laboratory Reporting</p>
            </div>
            <div class="panel-body">
                <div id="divPrint">
                    <div class="row">
                        <div class="panel" style="width: 98%; height: 60px; padding: 10px; margin: 10px" id="20">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <div class='input-group date datepicker'>
                                        <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker"  />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar" id="calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1">
                            </div>

                            <div class="col-md-2">

                                <asp:DropDownList Style="width: 190px" ID="ddlReport" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged" EnableViewState="true" AutoPostBack="true">
                                    <asp:ListItem Text="-- Select Report --" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Page 1A Daily Lab Report" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Page 1B Daily Lab Report" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Page 2A Daily Lab Report" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Page 2B Daily Lab Report" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Page 3 Daily Lab Report" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Page 4 Daily Lab Report" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Page 5 Daily Lab Report" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Page 6 Daily Lab Report" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="Page 7 Daily Lab Report" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="Page 9 Daily Lab Report" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="H30 Report" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="WH30 Report" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="C70 Report" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="Misc Report" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="All Reports" Value="15" ></asp:ListItem>
                                    <asp:ListItem Text="Production" Value="16"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnPrint" Text="Print Report" Style="width: 120px; margin-left: 100px" runat="server" OnClientClick="printReport();" class="btn btn-secondary" />
                            </div>
                             <div class="col-md-2">
                              <%--  <asp:Button ID="btnSendEmail" Text="Email as Pdf" Style="width: 120px; margin-left: 120px" runat="server" 
                                    class="btn btn-secondary"  OnClick="SendPDF_Click" OnClientClick="return confirmation();"/>--%>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <div id="disp">
                    <br />
                    <br />

                    <div style="float: left; margin-left: 10px"><input type="text" runat="server" id="report_date" style="border: none; font-weight: 400;" value="" /></div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="1">
                            <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; width: 92%; margin-left: 20px; border: none">
                                    <b>Page 1A</b>
            
                                  <asp:GridView ID="gv_report1a" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px; border:none"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller"
                                        
                                         BorderColor="Black" BorderStyle="Solid">

                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"></th>
                                                    <tr class="header1" style="border:1px solid black;">
                                                        <th style="width: 0px; background-color: cornflowerblue;"></th>
                                                        <th colspan="1" style="background-color: cornflowerblue; color: white;">Time</th>
                                                        <th colspan="3" style="background-color: cornflowerblue; color: white; text-align: center">Test Tank </th>
                                                        <th colspan="3" style="background-color: cornflowerblue; color: white; text-align: center">THA Digestor</th>
                                                        <th colspan="4" style="background-color: cornflowerblue; color: white; text-align: center">MHA Digestion</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">Digest Disch</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">Settler Feed</th>

                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>

                                                        <th>C/S</th>
                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>
                                                        <th>Aim</th>

                                                        <th>C</th>
                                                        <th>A/C</th>
                                                        <th>Aim</th>
                                                        <th>C/S</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <td>
                                                        <asp:TextBox ID="p4date" runat="server" Text='<%# Eval("CCROUND") %>' Width="80px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox01" runat="server" Text='<%# Eval("TESTTANKCS","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox02" runat="server" Text='<%# Eval("TESTTANKCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox03" runat="server" Text='<%# Eval("TESTTANKAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox04" runat="server" Text='<%# Eval("CTRIDIGESTOR","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ACTRIDIGESTOR","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("TRIDIGESTORAIM","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("CFT5","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("ACFT5","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("FT5AIM","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("FT5CS","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("CDIGDISCH","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("ACDIGDISCH","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("SETTLERFEEDCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("SETTLERFEEDAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>

                                </div>

                            </div>
                            <br />
                            <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; width: 86.5%; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_report1a_" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller">

                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"></th>
                                                    <tr class="header1"  style="border:1px solid black;">
                                                        <th style="width: 0px; background-color: cornflowerblue;"></th>
                                                        <th colspan="1" style="background-color: cornflowerblue; color: white;">Time</th>

                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">Press Feed </th>
                                                        <th colspan="3" style="background-color: cornflowerblue; color: white; text-align: center">LTP</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">Evap Feed</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">Evap Disch</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">WOF</th>
                                                        <th colspan="2" style="background-color: cornflowerblue; color: white; text-align: center">SUF</th>
                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>

                                                        <th>C</th>
                                                        <th>A/C</th>


                                                        <th>C</th>
                                                        <th>Aim</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>




                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <td>
                                                        <asp:TextBox ID="p4date_" runat="server" Text='<%# Eval("CCROUND") %>' Width="80px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox01_" runat="server" Text='<%# Eval("PRESSFEEDCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox02_" runat="server" Text='<%# Eval("PRESSFEEDAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox03_" runat="server" Text='<%# Eval("LTPCAUSTIC","{0:.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox04_" runat="server" Text='<%# Eval("LTPAIM","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox11_" runat="server" Text='<%# Eval("LTPAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox12_" runat="server" Text='<%# Eval("EVAPFEEDCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox13_" runat="server" Text='<%# Eval("EVAPFEEDAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox14_" runat="server" Text='<%# Eval("CEVAPDISCH","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox5_" runat="server" Text='<%# Eval("ACEVAPDISCH","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox6_" runat="server" Text='<%# Eval("WOFCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox7_" runat="server" Text='<%# Eval("WOFAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox8_" runat="server" Text='<%# Eval("SUFCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("SUFAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>






                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>




                            </div>


                            <div class="row">
                                <div class="col-md-2">
                                    <b>Precip yield:  </b><%--<div id="precip_yield" ></div>--%>
                                </div>
                                <div class="col-md-1">
                                    <input id="precip_yield" runat="server" style="border: none" />
                                </div>
                                <div class="col-md-2" style="white-space: nowrap">
                                    <b>TT Free Caustic:</b>
                                </div>
                                <div class="col-md-1">
                                    <input id="free_c" style="border: none;" runat="server" />
                                </div>
                            </div>



                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="2">
                                  <b>Page 1B</b>


                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; width: 57.5%; margin-left: 20px; background-color: #dcdcdc">
                                  
                                    <asp:GridView ID="gv_cpn" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Enabled="False"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                       
                                        Font-Size="smaller">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header2" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Continuous Precipitation - North</b></th>
                                                    <tr class="header1">
                                                        <th style="width: 0px; background-color: #6495ed;"></th>
                                                        <th colspan="1" style="background-color: #FFFF99; color: black;">Time</th>

                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">T1</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">T7</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">A7OFlow Feed</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">B7OFlow</th>
                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>



                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>




                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <td>
                                                        <asp:TextBox ID="p4date_" runat="server" Text='<%# Eval("CCROUND") %>' Width="80px" BackColor="#FFFF99"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox01_" runat="server" Text='<%# Eval("T1CAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox02_" runat="server" Text='<%# Eval("T1AC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox03_" runat="server" Text='<%# Eval("T7CAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="textbox04_" runat="server" Text='<%# Eval("T7AC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox11_" runat="server" Text='<%# Eval("A7OVERFLOWCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox12_" runat="server" Text='<%# Eval("A7OVERFLOWAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="TextBox13_" runat="server" Text='<%# Eval("B7OVERFLOWCAUSTIC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox14_" runat="server" Text='<%# Eval("B7OVERFLOWAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>










                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>




                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; width: 57.5%; margin-left: 20px; background-color: #dcdcdc">
                                 
                                    <asp:GridView ID="gv_cps" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Enabled="False"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller">

                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                      <th class="header2" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Continuous Precipitation - South</b></th>
                                                    <tr class="header1">
                                                        <th style="width: 0px; background-color: #FFFF99;"></th>
                                                        <th colspan="1" style="background-color: #FFFF99; color: black;">Time</th>

                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">AG1</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">AG7</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">Y15OFlow Feed</th>
                                                        <th colspan="2" style="background-color: #FFFF99; color: black; text-align: center">Y16OFlow</th>
                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>

                                                        <th>C</th>
                                                        <th>A/C</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="p4date_" runat="server" Text='<%# Eval("CCROUND") %>' Width="80px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox01_" runat="server" Text='<%# Eval("CAG1","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox02_" runat="server" Text='<%# Eval("ACAG1","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox03_" runat="server" Text='<%# Eval("CAG7","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="textbox04_" runat="server" Text='<%# Eval("ACAG7","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox11_" runat="server" Text='<%# Eval("CY15OVERFLOW","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox12_" runat="server" Text='<%# Eval("ACY15OVERFLOW","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox13_" runat="server" Text='<%# Eval("CY16OVERFLOW","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox14_" runat="server" Text='<%# Eval("ACY16OVERFLOW","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; width: 17%; margin-left: 20px; background-color: #dcdcdc">

                                    <asp:GridView ID="gv_pfmg" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Enabled="False"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller">

                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"></th>
                                                    <tr class="header1">
                                                        <th style="width: 0px; background-color: #6495ed;"></th>
                                                        <th colspan="2" style="background-color: #6495ed; color: black;">Press Filtrate mg/L Solids</th>

                                                    </tr>
                                                    <tr class="header2">


                                                        <th></th>
                                                        <th></th>

                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="pfmg_1" runat="server" Text='<%# Eval("CCROUND") %>' Width="80px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pfmg_2" runat="server" Text='<%# Eval("PFMG","{0:.0}") %>' Width="45px"></asp:TextBox></td>


                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>

                                <div class="table-responsive" style="float: left; width: 37.5%; margin-left: 20px; background-color: #dcdcdc">
                                  
                            <asp:GridView ID="gv_smix" runat="server" Height="16px" Width="100px"
                                Style="overflow-x: scroll; border-radius: 3px"
                                Enabled="False"
                                CssClass="gvstyling"
                                AutoGenerateColumns="false"
                                HeaderStyle-BackColor="#FFFF99"
                                Font-Size="smaller">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                              <th class="header2" colspan="7"  style="background-color: #6495ed; color: black; text-align: center"><b>Slurry Mix</b></th>

                                            <th></th>
                                            <tr class="header2">
                                                <th style="width: 0px"></th>
                                                <th></th>
                                                <th>Ret Tank</th>
                                                <th>#1PDS</th>
                                                <th>#2PDS</th>
                                                <th>#3PDS</th>
                                                <th>#4PDS</th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td>
                                                <asp:TextBox ID="pfmg_1" runat="server" Text='<%# Eval("name") %>' Width="60px" BackColor="#FFFF99"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="pfmg_2" runat="server" Text='<%# Eval("RETTANK","{0:.###}") %>' Width="45px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Eval("CPDS1","{0:.###}") %>' Width="45px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Eval("CPDS2","{0:.###}") %>' Width="45px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Eval("CPDS3","{0:.###}") %>' Width="45px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="TextBox14" runat="server" Text='<%# Eval("CPDS4","{0:.###}") %>' Width="45px"></asp:TextBox></td>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                            </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; width: 31.5%; margin-left: 20px; background-color: #dcdcdc">
                                    <asp:GridView ID="gv_evapcc" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Enabled="False"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="smaller">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"></th>
                                                    <tr class="header1" style="background-color:cornflowerblue">
                                                        <th style="width: 0px;background-color:cornflowerblue"></th>
                                                        <th style="background-color:cornflowerblue"></th>
                                                        <th colspan="2" style="background-color:cornflowerblue">Evap C/C</th>
                                                        <th colspan="2" style="background-color:cornflowerblue">Press C/C</th>
                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>
                                                        <th>C</th>
                                                        <th>A/C</th>
                                                        <th>C</th>
                                                        <th>A/C</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="pfmg_1" runat="server" Text='<%# Eval("name") %>' Width="60px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pfmg_2" runat="server" Text='<%# Eval("EvapC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Eval("EvapAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Eval("PressC","{0:.0}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Eval("PressAC","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="3">
                              <b>Page 2A</b>
                            <div class="row clearfix" style="padding-bottom: 30px">
                                    
                 <%--       <input type="text" runat="server" id="Text5" style="border: none; font-weight: 400; text-align: center" value="" />--%>
                                <div class="table-responsive" style="float: left; margin-left: 10px; padding-right: 0px;">
                              <%--       <p style="background-color: cornflowerblue"><b>Sec II Process Variables</b></p>--%>
                                    <asp:GridView ID="gv_sec2pv" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="False"
                                        Enabled="False"
                                        text-align="Center"
                                   >
                                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                        <Columns>

                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"  style="background-color:cornflowerblue; text-align:center">Sec II Process Variables</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">Time</th>
                                                        <th style="background-color:#FFFF99; text-align:center">OXSET</th>
                                                        <th style="background-color:#FFFF99; text-align:center">WUF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">MTL</th>
                                                        <th style="background-color:#FFFF99; text-align:center">SRT</th>
                                                     
                                                    </tr>
                                                 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                             <asp:TextBox Style="text-align: center" ID="sec21" runat="server" Text='<%# Eval("Time") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="sec22" runat="server" Text='<%# Eval("OXSET","{0:.0}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="sec23" Style="text-align: center" runat="server" Text='<%# Eval("WUF","{0:0.0}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="SEC24" Style="text-align: center" runat="server" Text='<%# Eval("MTL","{0:0.0}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                      <asp:TextBox ID="SEC25" Style="text-align: center" runat="server" Text='<%# Eval("SRT","{0:0.0}") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                          <%--  <asp:TemplateField>
                                                         <HeaderTemplate>
                                                    <th class="header2" colspan="5"  style="background-color: #6495ed; color: black; text-align: center"><b>Sec II Process Variable</b></th>
                                                </HeaderTemplate>
                                            </asp:TemplateField>--%>

                                               
                                 <%--           <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox Style="text-align: center" ID="sec21" runat="server" Text='<%# Eval("Time") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="OXSET" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="sec22" runat="server" Text='<%# Eval("OXSET","{0:.0}") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WUF" ItemStyle-Width="70" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="sec23" Style="text-align: center" runat="server" Text='<%# Eval("WUF","{0:.0}") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MTL" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="SEC24" Style="text-align: center" runat="server" Text='<%# Eval("MTL","{0:.0}") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SRT" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="SEC25" Style="text-align: center" runat="server" Text='<%# Eval("SRT","{0:.0}") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>

                                        <EditRowStyle HorizontalAlign="Center" />

                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>

                                        <RowStyle HorizontalAlign="Center"></RowStyle>
                                    </asp:GridView>
                                </div>

                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 0px;">
                        
                                    <asp:GridView ID="gv_sec3pv" runat="server" Height="100%" Width="180px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>


                                            
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="5"  style="background-color:cornflowerblue; text-align:center">Sec III Process Variables</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">Time</th>
                                                        <th style="background-color:#FFFF99; text-align:center">Na</th>
                                                        <th style="background-color:#FFFF99; text-align:center">Ca</th>
                                                        <th style="background-color:#FFFF99; text-align:center">Zn</th>
                                                        <th style="background-color:#FFFF99; text-align:center">CaO</th>
                                                     
                                                    </tr>
                                                 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                                              <asp:TextBox ID="sec31" runat="server" style="text-align: center" Text='<%# Eval("-") %>' Width="100px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="sec32" runat="server" style="text-align: center" Text='<%# Eval("Na","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="sec33" runat="server" style="text-align: center" Text='<%# Eval("Ca","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                               <asp:TextBox ID="SEC34" runat="server" style="text-align: center" Text='<%# Eval("Zn","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                      <asp:TextBox ID="SEC35" runat="server" style="text-align: center" Text='<%# Eval("CaO","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>








                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                            <br />
                            <br />
                            <div class="row clearfix" style="padding-bottom: 30px">
                                <div class="table-responsive" style="float: left; margin-left: 10px; padding-right: 0px; padding-bottom: 0px">
                                 
                                    <asp:GridView ID="gv_hydratedryer" runat="server" Height="16px" Width="80px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>

                                                                  <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="3"  style="background-color:cornflowerblue; text-align:center">Hydrate Dryer Discharge</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">Time</th>
                                                        <th style="background-color:#FFFF99; text-align:center">L-Soda</th>
                                                        <th style="background-color:#FFFF99; text-align:center">Reflect</th>
                                                 
                                                     
                                                    </tr>
                                                 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                       <asp:TextBox ID="hd1" runat="server" style="text-align: center" Text='<%# Eval("Time") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="hd2" runat="server" style="text-align: center" Text='<%# Eval("L-SODA","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="hd3" runat="server" style="text-align: center" Text='<%# Eval("REFLECT","{0:0}") %>' Width="75px"></asp:TextBox></td>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>










                                        </Columns>
                                    </asp:GridView>

                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 10px; padding-right: 0px;">
                           
                                    <asp:GridView ID="gv_kfm" runat="server" Height="16px" Width="80px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>

                                                               <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="3"  style="background-color:cornflowerblue; text-align:center">Kiln Feed Moisture</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">#1</th>
                                                        <th style="background-color:#FFFF99; text-align:center">#2</th>
                                                        <th style="background-color:#FFFF99; text-align:center">#3</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="kfm1" runat="server" style="text-align: center" Text='<%# Eval("1","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="kfm3" runat="server" style="text-align: center" Text='<%# Eval("2","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="kfm4" runat="server" style="text-align: center" Text='<%# Eval("3","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                       


                                        </Columns>
                                    </asp:GridView>
                                 
                                    <asp:GridView ID="gv_dryerfm" runat="server"
                                         Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Dryer Feed Moisture" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="dfm1" runat="server" style="text-align: center" Text='<%# Eval("dfm","{0:.###}") %>' Width="70px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 10px; padding-right: 0px;">
                            
                                    <asp:GridView ID="gv_lsoda" runat="server" Height="16px" Width="100%"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>

                                                <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="4"  style="background-color:cornflowerblue; text-align:center">Kiln Feed Leach Soda</th>
                                                    <tr class="header2">
                                                          <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">Time</th>
                                                        <th style="background-color:#FFFF99; text-align:center">#1</th>
                                                        <th style="background-color:#FFFF99; text-align:center">#2</th>
                                                        <th style="background-color:#FFFF99; text-align:center">#3</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                      <td>
                                                       <asp:TextBox ID="ls1" runat="server" style="text-align: center" Text='<%# Eval("Time") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                      <asp:TextBox ID="ls2" runat="server" style="text-align: center" Text='<%# Eval("1","{0:0.000}") %>' Width="70px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="ls3" runat="server" style="text-align: center" Text='<%# Eval("2","{0:0.000}") %>' Width="70px"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="ls4" runat="server" style="text-align: center" Text='<%# Eval("3","{0:0.000}") %>' Width="70px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                     


                                        </Columns>
                                    </asp:GridView>

                                </div>

                            </div>
                            <br />
                            <br />
                            <div class="row clearfix" style="padding-bottom: 50px;">

                            <div class="table-responsive" style="float: left; width: 95%; margin-left: 10px;">
                              
                                    <asp:GridView ID="gv_kdischarge" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Enabled="False"
                                        CssClass="gvstyling"
                                        AutoGenerateColumns="false"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Font-Size="small">

                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="13" style="background-color: cornflowerblue; color: black; text-align: center">Kiln Discharge</th>
                                                    <tr class="header1">
                                                      <th style="width:0px;background-color: #FFFF99; color: black"></th>
                                                        <th colspan="1" style="background-color: #FFFF99; color: black; text-align: center">Time</th>
                                                        <th colspan="3" style="background-color: #FFFF99; color: black; text-align: center">KDLOI</th>
                                                        <th colspan="3" style="background-color: #FFFF99; color: black; text-align: center">Ca</th>
                                                        <th colspan="3" style="background-color: #FFFF99; color: black; text-align: center">Na</th>
                                                        <th colspan="3" style="background-color: #FFFF99; color: black; text-align: center">Zn</th>
                                                    </tr>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>
                                                        <th style="background-color: #FFFF99; color: black; text-align: center">#1</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#2</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#3</th>

                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#1</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#2</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#3</th>

                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#1</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#2</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#3</th>

                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#1</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#2</th>
                                                        <th  style="background-color: #FFFF99; color: black; text-align: center">#3</th>



                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <td>
                                                        <asp:TextBox ID="kd1" style="text-align: center" runat="server" Text='<%# Eval("Time") %>' Width="80px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="kd2" style="text-align: center" runat="server" Text='<%# Eval("KDLOI2200_1","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd3" style="text-align: center" runat="server" Text='<%# Eval("KDLOI2200_2","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd4" style="text-align: center" runat="server" Text='<%# Eval("KDLOI2200_3","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="kd5"  style="text-align: center" runat="server" Text='<%# Eval("KDCA2200_1","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd6"  style="text-align: center" runat="server" Text='<%# Eval("KDCA2200_2","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd7" style="text-align: center" runat="server" Text='<%# Eval("KDCA2200_3","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="kd8" style="text-align: center" runat="server" Text='<%# Eval("KDNA2200_1","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd9" style="text-align: center" runat="server" Text='<%# Eval("KDNA2200_2","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd10" style="text-align: center" runat="server" Text='<%# Eval("KDNA2200_3","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="kd11" style="text-align: center" runat="server" Text='<%# Eval("KDZN2200_1","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd12" style="text-align: center" runat="server" Text='<%# Eval("KDZN2200_2","{0:0.000}") %>' Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="kd13" style="text-align: center" runat="server" Text='<%# Eval("KDZN2200_3","{0:0.000}") %>' Width="45px"></asp:TextBox></td>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                          
                          
                            <div class="row clearfix" style="padding-bottom: 10px;">

                                <div class="table-responsive" style="float: left; margin-left: 10px;">
                                     
                                    <asp:GridView ID="gv_mudd" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>



                                             <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="6"  style="background-color:cornflowerblue; text-align:center">Mudd TAA Analysis</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">THA Dig</th>
                                                        <th style="background-color:#FFFF99; text-align:center">5FT</th>
                                                        <th style="background-color:#FFFF99; text-align:center">SF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">SUF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">WUF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">MTL</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                      <td>
                                                        <asp:TextBox ID="ma1" style="text-align: center" runat="server" Text='<%# Eval("THA DIG","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                              <asp:TextBox ID="ma2" style="text-align: center" runat="server" Text='<%# Eval("TAAA4FT","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="ma3" style="text-align: center" runat="server" Text='<%# Eval("TAAASF","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="ls4" runat="server" style="text-align: center" Text='<%# Eval("TAAASUF","{0:0.000}") %>' Width="70px"></asp:TextBox></td>
                                                        <td>
                                                          <asp:TextBox ID="ma5" style="text-align: center" runat="server" Text='<%# Eval("TAAAWUF","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                        <td>
                                                          <asp:TextBox ID="ma6" style="text-align: center" runat="server" Text='<%# Eval("TAAAMTL","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 10px;">
                                     
                                    <asp:GridView ID="gv_psolids" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>

                                                 <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="3"  style="background-color:cornflowerblue; text-align:center">% Solids</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">SUF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">WUF</th>
                                                        <th style="background-color:#FFFF99; text-align:center">MTL</th>
                                                       
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                      <td>
                                                        <asp:TextBox ID="ps1" style="text-align: center" runat="server" Text='<%# Eval("SASUF","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                            <asp:TextBox ID="ps2" style="text-align: center" runat="server" Text='<%# Eval("SAWUF","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="ps3" style="text-align: center" runat="server" Text='<%# Eval("SAMTL","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>




                             <%--               <asp:TemplateField HeaderText="SUF" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="ps1" style="text-align: center" runat="server" Text='<%# Eval("SASUF","{0:.###}") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="WUF" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="ps2" style="text-align: center" runat="server" Text='<%# Eval("SAWUF","{0:.###}") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MTL" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="ps3" style="text-align: center" runat="server" Text='<%# Eval("SAMTL","{0:.###}") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 10px;">
                         
                                    <asp:GridView ID="gv_scaustic" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>


                                            
                                                 <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th colspan="4"  style="background-color:cornflowerblue; text-align:center">Silica Caustic</th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th style="background-color:#FFFF99; text-align:center">TT</th>
                                                        <th style="background-color:#FFFF99; text-align:center">5FT</th>
                                                        <th style="background-color:#FFFF99; text-align:center">SF</th>
                                                          <th style="background-color:#FFFF99; text-align:center">LTP</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                      <td>
                                                        <asp:TextBox ID="SC1" runat="server" style="text-align: center" Text='<%# Eval("SCATESTTANK","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="SC2" runat="server" style="text-align: center" Text='<%# Eval("SCA4FT","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                    <td>
                                                      <asp:TextBox ID="SC3" runat="server"  style="text-align: center" Text='<%# Eval("SCASETTLERFD","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                   <td>
                                                      <asp:TextBox ID="SC4" runat="server" style="text-align: center" Text='<%# Eval("SCALTP","{0:.###}") %>' Width="50px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                          



                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                              <br />
                              <br />
                            <div class="row clearfix" style="padding-bottom:10px;">

                                <div class="table-responsive" style="float: left; margin-left:10px;">
                                    -
                            <asp:GridView ID="gv_soxalate" runat="server" Height="16px" Width="260px"
                                Style="overflow-x: scroll; border-radius: 3px"
                                AlternatingRowStyle-BackColor="White"
                                HeaderStyle-BackColor="#FFFF99"
                                AutoGenerateColumns="false"
                                Enabled="false"
                                Caption="">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ls1" runat="server" style="text-align: center" Text='<%# Eval("name") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Soda" ItemStyle-Width="70">
                                        <ItemTemplate>
                                            <asp:TextBox ID="_soda" runat="server" style="text-align: center" Text='<%# Eval("Soda","{0:.###}") %>' Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oxalate" ItemStyle-Width="70">
                                        <ItemTemplate>
                                            <asp:TextBox ID="_ox" runat="server" style="text-align: center" Text='<%# Eval("Oxalate","{0:.###}") %>' Width="60px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Solids" ItemStyle-Width="70">
                                        <ItemTemplate>
                                            <asp:TextBox ID="_solids" runat="server" style="text-align: center" Text='<%# Eval("Solids","{0:.###}") %>' Width="60px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Na2S" ItemStyle-Width="70">
                                        <ItemTemplate>
                                            <asp:TextBox ID="_nas" runat="server" style="text-align: center" Text='<%# Eval("Na2S","{0:.###}") %>' Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ca" ItemStyle-Width="70">
                                        <ItemTemplate>
                                            <asp:TextBox ID="_ca" runat="server" style="text-align:center" Text='<%# Eval("Ca","{0:.###}") %>' Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"></ItemStyle>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left:10px;">
                                      <p style="background-color: cornflowerblue"><b>Washer Profile (GPL Soda)</b></p>
                                    <asp:GridView ID="gv_wprofile" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <Columns>


                                            <asp:TemplateField HeaderText="0" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp0" runat="server" style="text-align: center" Text='<%# Eval("0","{0:.0}") %>' Width="43px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp1" runat="server" style="text-align: center" Text='<%# Eval("1","{0:.0}") %>' Width="43px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="3" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp2" runat="server" style="text-align: center" Text='<%# Eval("2","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="3" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp3" runat="server" style="text-align: center" Text='<%# Eval("3","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="4" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp4" runat="server" style="text-align: center" Text='<%# Eval("4","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="5" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp5" runat="server" style="text-align: center" Text='<%# Eval("5","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="6" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp6" runat="server" style="text-align: center" Text='<%# Eval("6","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="7" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp7" runat="server" style="text-align: center" Text='<%# Eval("7","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="8" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="wp8" runat="server" style="text-align: center" Text='<%# Eval("8","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>






                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width:98%; padding:10px; margin:10px" id="4">
                                  <b>Page 2B</b>
                        <input type="text" runat="server" id="Text6" style="border: none; font-weight: 400; text-align: center" value="" />
                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left:20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_precnorth" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false"
                                        Enabled="false"
                                        Caption="">
                                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                        <Columns>


                                                   <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Continuous Precipitation North Malvern Analysis</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>
                                                        <th>+150u</th>

                                                        <th>+75u</th>
                                                        <th>+45u</th>

                                                        <th>-20u</th>
                                                        <th>Caus</th>

                                                        <th>A/C</th>
                                                        <th>GplSol</th>

                                                        <th>SA</th>
                                                       
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                         <asp:TextBox ID="precn1" style="text-align: center" runat="server" Text='<%# Eval("TK No") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="precn2" style="text-align: center" runat="server" Text='<%# Eval("+150u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="precn3" style="text-align: center"  runat="server" Text='<%# Eval("+75u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precn4" style="text-align: center" runat="server" Text='<%# Eval("+45u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precn5" style="text-align: center" runat="server" Text='<%# Eval("-20u","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                           <asp:TextBox ID="precn6" style="text-align: center" runat="server" Text='<%# Eval("CAUS") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precn7" style="text-align: center" runat="server" Text='<%# Eval("AC") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="precn8" style="text-align: center" runat="server" Text='<%# Eval("GPLSOL") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="precn9" style="text-align:center" runat="server" Text='<%# Eval("SA") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
<HeaderStyle BackColor="#FFFF99"></HeaderStyle>
                                        <RowStyle HorizontalAlign="Center" />



                                    </asp:GridView>

                                </div>


                            </div>
                            <br />
                             <br />

                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 20px;">

                                    <asp:GridView ID="gv_precsouth" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Enabled="false"
                                        AutoGenerateColumns="false">


                                        <Columns>

                                                                           <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Continuous Precipitation South Malvern Analysis</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>
                                                        <th>+150u</th>

                                                        <th>+75u</th>
                                                        <th>+45u</th>

                                                        <th>-20u</th>
                                                        <th>Caus</th>

                                                        <th>A/C</th>
                                                        <th>GplSol</th>
                                                        <th>SA</th>
                                                       
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                         <asp:TextBox ID="precs1" style="text-align: center" runat="server" Text='<%# Eval("TK No") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="prec22" style="text-align: center" runat="server" Text='<%# Eval("+150u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="precn3" style="text-align: center"  runat="server" Text='<%# Eval("+75u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precs4" style="text-align: center" runat="server" Text='<%# Eval("+45u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precs5" style="text-align: center" runat="server" Text='<%# Eval("-20u","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                           <asp:TextBox ID="precs6" style="text-align: center" runat="server" Text='<%# Eval("CAUS") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="precs7" style="text-align: center" runat="server" Text='<%# Eval("AC") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="precs8" style="text-align: center" runat="server" Text='<%# Eval("GPLSOL") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="precs9" style="text-align:center" runat="server" Text='<%# Eval("SA") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>

                                            </asp:TemplateField>



                                           


                                                    


                                        </Columns>


                                    </asp:GridView>
                                </div>

                            </div>
                            <br />
                             <br />
                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_sttops" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption=""
                                        AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Enabled="false"
                                        AutoGenerateColumns="false">
                                        <Columns>

                                                                                   <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Batch Precip ST Tops Samples  Malvern Analysis</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th></th>
                                                        <th>+150u</th>
                                                        <th>+75u</th>
                                                        <th>+45u</th>
                                                        <th>-20u</th>
                                                        <th>Caus</th>
                                                        <th>A/C</th>
                                                        <th>GplSol</th>
                                                        <th>SA</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                         <asp:TextBox ID="st1" style="text-align: center" runat="server" Text='<%# Eval("TK No") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="st2" style="text-align: center" runat="server" Text='<%# Eval("+150u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="st3" style="text-align: center"  runat="server" Text='<%# Eval("+75u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="st4" style="text-align: center" runat="server" Text='<%# Eval("+45u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="st5" style="text-align: center" runat="server" Text='<%# Eval("-20u","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                           <asp:TextBox ID="st6" style="text-align: center" runat="server" Text='<%# Eval("CAUS","{0:.0}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="st7" style="text-align: center" runat="server" Text='<%# Eval("AC","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="st8" style="text-align: center" runat="server" Text='<%# Eval("GPLSOL") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="st9" style="text-align:center" runat="server" Text='<%# Eval("SA") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>

                                    </asp:GridView>
                                </div>

                            </div>
                            <br />
                            <br />
                            <br />
                             <br />

                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 20px;">

                                    <asp:GridView ID="gv_tttops" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        Enabled="false"
                                        AutoGenerateColumns="false">
                                        <Columns>

                                                                                         <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Batch Precip TT Tops Samples  Malvern Analysis</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th>TK No</th>
                                                        <th>+150u</th>
                                                        <th>+75u</th>
                                                        <th>+45u</th>
                                                        <th>-20u</th>
                                                        <th>Caus</th>
                                                        <th>A/C</th>
                                                        <th>GplSol</th>
                                                        <th>SA</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                         <asp:TextBox ID="tt1" style="text-align: center" runat="server" Text='<%# Eval("TK No") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="tt2" style="text-align: center" runat="server" Text='<%# Eval("+150u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                         <asp:TextBox ID="tt3" style="text-align: center"  runat="server" Text='<%# Eval("+75u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="tt4" style="text-align: center" runat="server" Text='<%# Eval("+45u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="tt5" style="text-align: center" runat="server" Text='<%# Eval("-20u","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                           <asp:TextBox ID="tt6" style="text-align: center" runat="server" Text='<%# Eval("CAUS","{0:.0}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="tt7" style="text-align: center" runat="server" Text='<%# Eval("AC","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="tt8" style="text-align: center" runat="server" Text='<%# Eval("GPLSOL") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                       <asp:TextBox ID="tt9" style="text-align:center" runat="server" Text='<%# Eval("SA") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>






                                        </Columns>

                                    </asp:GridView>
                                </div>

                            </div>
                            <br />
                            <div class="row clearfix" style="padding-bottom: 10px">

                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_pfeed" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false">

                                        <Columns>

                                            
                                            <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9" style="background-color: #6495ed; color: black; text-align: center"><b>Primary Feed/Seed Tanks Malvern Analysis</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th>TK No</th>
                                                        <th>+150u</th>
                                                        <th>+75u</th>
                                                        <th>+45u</th>
                                                        <th>-20u</th>
                                                        <th>Caus</th>
                                                        <th>A/C</th>
                                                        <th>GplSol</th>
                                                        <th>SA</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="pf1" Style="text-align: center" runat="server" Text='<%# Eval("TK No") %>' Width="70px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf2" Style="text-align: center" runat="server" Text='<%# Eval("+150u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf3" Style="text-align: center" runat="server" Text='<%# Eval("+75u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf4" Style="text-align: center" runat="server" Text='<%# Eval("+45u") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf5" Style="text-align: center" runat="server" Text='<%# Eval("-20u","{0:.00}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf6" Style="text-align: center" runat="server" Text='<%# Eval("CAUS") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf7" Style="text-align: center" runat="server" Text='<%# Eval("AC","{0:0.000}") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf8" Style="text-align: center" runat="server" Text='<%# Eval("GPLSOL") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="pf9" Style="text-align: center" runat="server" Text='<%# Eval("SA") %>' Width="65px"></asp:TextBox></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>





                                        </Columns>
                                    </asp:GridView>
                                </div>


                            </div>
                            <br />
                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_cclean" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false">
                                        <Columns>

                                              <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Caustic Clean Tanks</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th>TK No</th>
                                                        <th style="text-align: center">C</th>
                                                        <th style="text-align: center">AC</th>
                                                     
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                          <asp:TextBox ID="cc1" runat="server"  style="text-align: center" Text='<%# Eval("Tank") %>' Width="65px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="cc2" runat="server"  style="text-align: center" Text='<%# Eval("C") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="pf3" runat="server"  style="text-align: center" Text='<%# Eval("A/C") %>' Width="65px"></asp:TextBox></td>
                         
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>

                                    </asp:GridView>
                                </div>


                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_water" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false">
                                        <Columns>

                                             <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="9"  style="background-color: #6495ed; color: black; text-align: center"><b>Fresh H2O</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th>TK No</th>
                                                        <th style="text-align: center">North</th>
                                                        <th style="text-align: center">South</th>
                                                     
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                            <asp:TextBox ID="w1" runat="server"  style="text-align: center" Text='<%# Eval("Tank") %>' Width="65px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                           <asp:TextBox ID="w2" runat="server"  style="text-align: center" Text='<%# Eval("North") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                          <asp:TextBox ID="w3" runat="server"  style="text-align: center" Text='<%# Eval("South") %>' Width="65px"></asp:TextBox></td>
                         
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>

                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_poxalate" runat="server" Height="16px" Width="100px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false">
                                        <Columns>


                                                 <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="2"  style="background-color: #6495ed; color: black; text-align: center"><b>% Oxalate</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                        <th>TK No</th>
                                                        <th style="text-align: center"></th>
                                                      
                                                     
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="po1" runat="server"  style="text-align: center" Text='<%# Eval("name") %>' Width="75px" BackColor="#FFFF99"></asp:TextBox></td>
                                                    <td>
                                                               <asp:TextBox ID="po2" runat="server"   style="text-align: center" Text='<%# Eval("v") %>' Width="65px"></asp:TextBox></td>
                                                 
                         
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix" style="padding-bottom: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <b></b>
                                    <asp:GridView ID="gv_trayo" runat="server" Height="16px" Width="260px"
                                        Style="overflow-x: scroll; border-radius: 3px"
                                        Caption="" AlternatingRowStyle-BackColor="White"
                                        HeaderStyle-BackColor="#FFFF99"
                                        AutoGenerateColumns="false">
                                        <Columns>

                                                <asp:TemplateField ShowHeader="False">
                                                <HeaderTemplate>
                                                    <th class="header" colspan="4"  style="background-color: #6495ed; color: black; text-align: center"><b>Tray O'Flow Solids</b></th>
                                                    <tr class="header2">
                                                        <th></th>
                                                     
                                                        <th style="text-align: center">#1</th>
                                                         <th style="text-align: center">#2</th>
                                                         <th style="text-align: center">#3</th>
                                                         <th style="text-align: center">#4</th>
                                                      
                                                     
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="t4" runat="server"  style="text-align: center" Text='<%# Eval("#1") %>' Width="65px" ></asp:TextBox></td>
                                                    <td>
                                                               <asp:TextBox ID="t3" runat="server"  style="text-align: center" Text='<%# Eval("#2") %>' Width="65px"></asp:TextBox></td>
                                                        <td>
                                                         <asp:TextBox ID="t2" runat="server"  style="text-align: center" Text='<%# Eval("#3") %>' Width="65px"></asp:TextBox></td>
                                                    <td>
                                                               <asp:TextBox ID="t1" runat="server"  style="text-align: center" Text='<%# Eval("#4") %>' Width="65px"></asp:TextBox></td>
                                                 
                         
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        <%--    <asp:TemplateField HeaderText="#1" ItemStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="t4" runat="server"  style="text-align: center" Text='<%# Eval("#1") %>' Width="65px" ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="#2" ItemStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="t3" runat="server"  style="text-align: center" Text='<%# Eval("#2") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="65px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#3" ItemStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="t2" runat="server"  style="text-align: center" Text='<%# Eval("#3") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#4" ItemStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="t1" runat="server"  style="text-align: center" Text='<%# Eval("#4") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:TemplateField>--%>

                                        </Columns>

                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 20px;">
                                    <p>Malvern to Screen Analysis Conversions</p>
                                    <p>+100 mesh = 0.2404(+150u) - 0.5007; R2 = 0.652</p>
                                    <p>+200 mesh = 1.0717(+75u) - 13.729; R2 = 0.94</p>
                                    <p>+325 mesh = 1.0754(+45u) - 10.571; R2 = 0.96</p>
                                    </div>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="5">
                            <div class="col-md-2" style="margin-left: 5px">Page 3</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="P3reportMonthYear" name="reportMonthYear" runat="server" />
                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 96%; margin-left: 20px;">

                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page3report" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            HeaderStyle-BackColor="#FFFF99"
                                            AutoGenerateColumns="False"
                                            Font-Size="x-small">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3date" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Settler" ItemStyle-Width="40">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3sttlr" runat="server" Text='<%# Eval("SETTLR") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="vertical" Height="60px" />
                                                    <ItemStyle Width="40px"></ItemStyle>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Washer" ItemStyle-Width="40">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3wshr" runat="server" Text='<%# Eval("WASHR") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="40px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cytec" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3cytec" runat="server" Text='<%# Eval("CYTEC") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="40px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Plant floc FT/Hr" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3pl" runat="server" Text='<%# Eval("Plant Floc","{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Solids GPL" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3sgpl" runat="server" Text='<%# Eval("Solids GPL","{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="STRCH IND TIME" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3sit" runat="server" Text='<%# Eval("STRCH IND TIME","{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="STRCH SET TIME" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3sst" runat="server" Text='<%# Eval("STRCH SET TIME","{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="TRI DIG" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3tridi" runat="server" Text='<%# Eval("TRI DIG", "{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="FT5" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="P3FT5" runat="server" Text='<%# Eval("FT5", "{0:.##}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Hot Well Ditch" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="P3HWD" runat="server" Text='<%# Eval("Hot Well Ditch", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Plant Drain Ditch" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3PDD" runat="server" Text='<%# Eval("Plant Drain Ditch", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Lift STN. North" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3LST" runat="server" Text='<%# Eval("Lift STN North", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Surge Basin" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3SUB" runat="server" Text='<%# Eval("Surge Basin", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="P205/C TT" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3TT" runat="server" Text='<%# Eval("TT", "{0:.###}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="P205/C SF" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3SF" runat="server" Text='<%# Eval("SF", "{0:.###}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ABS/C TT" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3ABSTT" runat="server" Text='<%# Eval("ABSTT", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ABS/C LTP" ItemStyle-Width="70">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p3ABSLTP" runat="server" Text='<%# Eval("LTP", "{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>

                                            <HeaderStyle BackColor="#FFFF99"></HeaderStyle>

                                        </asp:GridView>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="6">
                            <div class="col-md-2" style="margin-left: 5px">Page 4</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="P4reportMonthYear" name="P4reportMonthYear" runat="server" />
                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 96%; margin-left: 20px;">

                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page4report" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="False"
                                            CssClass="gvstyling"
                                            AutoGenerateColumns="false"
                                            HeaderStyle-BackColor="#FFFF99"
                                            Font-Size="smaller">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <HeaderTemplate>
                                                        <th colspan="5" style="border:1px solid black;"></th>
                                                        <tr class="header1">
                                                            <th style="width: 0px; background-color: #6495ed"></th>
                                                            <th colspan="1" style="background-color: #6495ed"></th>
                                                            <th colspan="1" style="background-color: #6495ed; color: white">River Water RET #002</th>
                                                            <th colspan="2" style="background-color: #6495ed; color: white; text-align: center">East #004 </th>
                                                            <th colspan="2" style="background-color: #6495ed; color: white; text-align: center">Far East #003</th>
                                                            <th colspan="2" style="background-color: #6495ed; color: white; text-align: center">Ditch Samples West #005</th>
                                                            <th colspan="2" style="background-color: #6495ed; color: white; text-align: center">Cane Field #006</th>
                                                            <th colspan="1" style="background-color: #6495ed; color: white; text-align: center">Oxpond</th>
                                                            <th colspan="4" style="background-color: #6495ed; color: white; text-align: center">PH Sewers</th>
                                                            <th colspan="1" style="background-color: #6495ed; color: white; text-align: center">PH Dam #1</th>
                                                        </tr>
                                                        <tr class="header2">
                                                            <th></th>
                                                            <th>Date</th>
                                                            <th>PH</th>

                                                            <th>Flow</th>
                                                            <th>PH</th>

                                                            <th>Flow</th>
                                                            <th>PH</th>

                                                            <th>Flow</th>
                                                            <th>PH</th>

                                                            <th>Flow</th>
                                                            <th>PH</th>

                                                            <th>PH</th>

                                                            <th>#1</th>
                                                            <th>#2</th>
                                                            <th>#3</th>
                                                            <th>#5</th>

                                                            <th>#1</th>

                                                        </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <%--  <td style="width: 40px"><%# Eval("RWRPH") %></td>
                                                <td><%# Eval("EDFLOW")%></td>
                                                <td><%# Eval("EDPH")%></td>
                                                <td><%# Eval("FEDFLOW")%></td>
                                                <td><%# Eval("FEDPH")%></td>--%>
                                                        <td>
                                                            <asp:TextBox ID="p4date" runat="server" Text='<%# Eval("date","{0:MM/dd/yyyy}") %>' Width="80px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="rwrph" runat="server" Text='<%# Eval("RWRPH") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="edflow" runat="server" Text='<%# Eval("EDFLOW") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="edph" runat="server" Text='<%# Eval("EDPH") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="fedflow" runat="server" Text='<%# Eval("FEDFLOW") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="FEDPH" runat="server" Text='<%# Eval("FEDPH") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("WDFLOW") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("WDPH") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("CDFLOW") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("CDPH") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("OXPOND") %>' Width="55px"></asp:TextBox></td>

                                                        <td>
                                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("SEWERPH1","{0:.##}") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("SEWERPH2") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("SEWERPH3") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("SEWERPH5","{0:.##}") %>' Width="40px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("DAMPH1","{0:.##}") %>' Width="40px"></asp:TextBox></td>





                                                    </ItemTemplate>

                                                </asp:TemplateField>




                                                <%--                                        

                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                          
                                            <ItemTemplate>
                                                <asp:TextBox ID="p4date" runat="server" Text='<%# Eval("date","{0:MM/dd/yyyy}") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="85px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText=" " ItemStyle-Width="40" >
                     
                                            <ItemTemplate>

                                                <asp:TextBox ID="rwrph" runat="server" Text='<%# Eval("RWRPH") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="vertical" Height="60px" />
                                            <ItemStyle Width="40px"></ItemStyle>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Flow" ItemStyle-Width="40">
                                   
                                            <ItemTemplate>
                                                <asp:TextBox ID="edflow" runat="server" Text='<%# Eval("EDFLOW") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PH" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="edph" runat="server" Text='<%# Eval("EDPH") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Flow" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="fedflow" runat="server" Text='<%# Eval("FEDFLOW") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PH" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="FEDPH" runat="server" Text='<%# Eval("FEDPH") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Flow" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="WDFLOW" runat="server" Text='<%# Eval("WDFLOW") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PH" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="wdph" runat="server" Text='<%# Eval("WDPH") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Flow" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="cdflow" runat="server" Text='<%# Eval("CDFLOW") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PH" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="cdph" runat="server" Text='<%# Eval("CDPH") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Oxpond PH" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="oxpond" runat="server" Text='<%# Eval("OXPOND") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="#1" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="no1" runat="server" Text='<%# Eval("SEWERPH1") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="#2" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="no2" runat="server" Text='<%# Eval("SEWERPH2") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="#3" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="no3" runat="server" Text='<%# Eval("SEWERPH3") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="#5" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="no5" runat="server" Text='<%# Eval("SEWERPH5") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PH Dam #1" ItemStyle-Width="70">
                                            <ItemTemplate>
                                                <asp:TextBox ID="damph1" runat="server" Text='<%# Eval("DAMPH1") %>' Width="40px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="70px"></ItemStyle>
                                        </asp:TemplateField>--%>
                                            </Columns>

                                            <HeaderStyle BackColor="#FFFF99"></HeaderStyle>

                                        </asp:GridView>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="7">
                            <div style="margin-left: 5px">Page 5  Alumina Shipments/Product Quality</div>
                           <%--<div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="P5reportMonthYear" name="reportMonthYear" runat="server" />
                            </div>--%>
                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 98%; margin-left: 10px;">
                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page5" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="x-small" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="70px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LOI" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p52" runat="server" Text='<%# Eval("LOI","{0:0.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p53" runat="server" Text='<%# Eval("P100","{0:.0}") %>' Width="30px"></asp:TextBox>
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

                                                <asp:TemplateField HeaderText="Bulk Dens" ItemStyle-Width="50" ItemStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p56" runat="server" Text='<%# Eval("BULKDENS","{0:.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Si" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p57" runat="server" Text='<%# Eval("SI","{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p58" runat="server" Text='<%# Eval("FE","{0:0.000}") %>' Width="40px"></asp:TextBox>
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
                                                        <asp:TextBox ID="p60" runat="server" Text='<%# Eval("ZN","{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p61" runat="server" Text='<%# Eval("MN","{0:0.0000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ca" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p62" runat="server" Text='<%# Eval("CA","{0:0.000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ti" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p63" runat="server" Text='<%# Eval("TI","{0:0.0000}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ai" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p64" runat="server" Text='<%# Eval("AI","{0:0.0}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="-20u" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p65" runat="server" Text='<%# Eval("M20","{0:#.###}") %>'  Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SiO₂" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p66" runat="server" Text='<%# Eval("SiO₂","{0:0.000}") %>' Width="40px"></asp:TextBox>
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

                                                <asp:TemplateField HeaderText="ZnO" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p69" runat="server" Text='<%# Eval("ZnO","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CaO" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p70" runat="server" Text='<%# Eval("CaO","{0:0.000}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="MnO" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p71" runat="server" Text='<%# Eval("MnO","{0:0.0000}") %>' Width="45px"></asp:TextBox>
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
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="8">
                            <div style="margin-left: 5px">Page 6 Hydrate Shipments/Product Quality</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="Text1" name="reportMonthYear" runat="server" />
                            </div>
                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 98%; margin-left: 10px;">
                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page6" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="x-small" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p53" runat="server" Text='<%# Eval("P100","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p54" runat="server" Text='<%# Eval("P200","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p55" runat="server" Text='<%# Eval("P325","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Si" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p57" runat="server" Text='<%# Eval("SI","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p58" runat="server" Text='<%# Eval("FE","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p59" runat="server" Text='<%# Eval("NA","{0:.##}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Zn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p60" runat="server" Text='<%# Eval("ZN","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p61" runat="server" Text='<%# Eval("MN","{0:.####}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ca" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p62" runat="server" Text='<%# Eval("CA","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ti" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p63" runat="server" Text='<%# Eval("TI","{0:.####}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ai" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p64" runat="server" style="text-align: center" Text='<%# Eval("AI","{0:.00}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="FM" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p65" runat="server"  Text='<%# Eval("FREEMOIST","{0:.##}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SiO₂" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p66" runat="server" Text='<%# Eval("SiO₂","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe₂O₃" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p67" runat="server" Text='<%# Eval("Fe₂O₃","{0:.###}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na₂O" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p68" runat="server" Text='<%# Eval("Na₂O","{0:.###}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="C-SEDS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p69" runat="server" style="text-align: center" Text='<%# Eval("CSEDS","{0:.###}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INSOLS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p70" runat="server" Text='<%# Eval("INSOLS","{0:.###}") %>' Width="40px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Bulk Dens" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p71" runat="server" Text='<%# Eval("BULKDENS","{0:.##}") %>' Width="45px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="L" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p72" runat="server" Text='<%# Eval("HUNTERL","{0:.##}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p73" runat="server" Text='<%# Eval("HUNTERA","{0:.##}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="B" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p74" runat="server" Text='<%# Eval("HUNTERB","{0:.##}") %>' Width="30px"></asp:TextBox>
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
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="9">
                            <div style="margin-left: 5px">Page 7 Wet Hydrate Shipments/Product Quality</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="Text2" name="reportMonthYear" runat="server" />
                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 79%; margin-left: 100px;">

                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page7" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="x-small" >

                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p53" runat="server" Text='<%# Eval("P100","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p54" runat="server" Text='<%# Eval("P200","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p55" runat="server" Text='<%# Eval("P325","{0:.#}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>



                                                <asp:TemplateField HeaderText="Si" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p57" runat="server" Text='<%# Eval("SI","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p58" runat="server" Text='<%# Eval("FE","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p59" runat="server" Text='<%# Eval("NA","{0:.##}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Zn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p60" runat="server" Text='<%# Eval("ZN","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Mn" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p61" runat="server" Text='<%# Eval("MN","{0:.####}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ca" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p62" runat="server" Text='<%# Eval("CA","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ti" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p63" runat="server" Text='<%# Eval("TI","{0:.####}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SiO₂" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p66" runat="server" Text='<%# Eval("SiO₂","{0:.###}") %>' Width="30px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Fe₂O₃" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p67" runat="server" Text='<%# Eval("Fe₂O₃","{0:.###}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Na₂O" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p68" runat="server" Text='<%# Eval("Na₂O","{0:.###}") %>' Width="35px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="C-SEDS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p69" runat="server" Text='<%# Eval("CSEDS","{0:.###}") %>' Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INSOLS" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p70" runat="server" Text='<%# Eval("INSOLS","{0:.###}") %>' Width="40px"></asp:TextBox>
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
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="10">
                            <div class="col-md-2" style="margin-left: 5px">Page 9</div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="Text3" name="reportMonthYear" runat="server" />
                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 45%; margin-left: 10px;">
                                    <b>Wet Hydrate Cake Production Quality</b>
                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page9_a" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="Small">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sample ID" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_50" runat="server" Text='<%# Eval("CONTAINERID") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="REFL" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_53" runat="server" Text='<%# Eval("REFLECTANCE","{0:.###}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="L-SODA" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_54" runat="server" Text='<%# Eval("LEACHSODA","{0:.###}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="% Solids" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_55" runat="server" Text='<%# Eval("MOISTURE","{0:.###}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                            </Columns>

                                            <HeaderStyle BackColor="#FFFF99"></HeaderStyle>

                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="table-responsive" style="float: left; width: 50%; margin-left: -15px;">
                                    <b>Hydrate Production Quality</b>
                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_page9_b" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="Small">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sample ID" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_50" runat="server" Text='<%# Eval("CONTAINERID") %>' Width="100px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_51" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="REFL" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_53" runat="server" Text='<%# Eval("REFLECTANCE","{0:.###}") %>' Width="60px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="L-SODA" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="p_54" runat="server" Text='<%# Eval("LEACHSODA","{0:.###}") %>' Width="60px"></asp:TextBox>
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
                    <div class="row">
                        <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="11">
                            <div class="col-md-2" style="margin-left: 5px"></div>
                            <div class="col-md-3" style="margin-left: 400px">
                                <input type="text" style="border: none" value="" id="Text4" name="reportMonthYear" runat="server" />
                            </div>

                            <div class="row clearfix" style="padding-bottom: 10px;">
                                <div class="table-responsive" style="float: left; width: 85%; margin-left: 10px;">
                                    <b>Page Misc</b>
                                    <div style="overflow-x: auto; width: 100%">
                                        <asp:GridView ID="gv_misc" runat="server" Height="16px" Width="150px"
                                            Style="overflow-x: scroll; border-radius: 3px"
                                            Enabled="false"
                                            AutoGenerateColumns="False"
                                            Font-Size="Small">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="misc_1" runat="server" Text='<%# Eval("MMISCDESCR") %>' Width="250px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="misc_2" runat="server" Text='<%# Eval("MMISCQTY","{0:0.000}") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="85px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Size" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="misc_3" runat="server" Text='<%# Eval("MMISCSIZE","{0:0.000}") %>' Width="60px"></asp:TextBox>
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
                </div>
            </div>
        </div>


     <input type="hidden" value="" id="panelID" name="panelID" runat="server"/>
     <input type="hidden" runat="server" id="role" value="" />  
     <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
     <input type="hidden" id="dateSave" name="dateSave" value=""/>
     <input type="hidden" id="date_select" name="date_select" value=""/>

     <script>
           
     $('#datepicker').datepicker({
	format: 'dd-mm-yyyy',
  todayHighlight: true
});



         function printReport() {

             document.getElementById('divPrint').style.display = "none";

             window.print();

         }

   $(function () {
             var Val = document.getElementById('MainContent_panelID').value;
             //var array = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
             var array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];


                 {
                     for (var i = 0; i < array.length; i++) {
                         var layer = document.getElementById(array[i]);

                         if (Val == "nothing") {
                             layer.style.display = "none";
                         }
                         else if (Val == array[i]) {
                             layer.style.display = "block";

                         }
                         else if (Val == array[14])
                         {
                            document.getElementById(array[1]).layer.style.display = "block";
                            document.getElementById(array[2]).layer.style.display = "block";
                            document.getElementById(array[3]).layer.style.display = "block";
                            document.getElementById(array[4]).layer.style.display = "block";
                            document.getElementById(array[5]).layer.style.display = "block";
                            document.getElementById(array[6]).layer.style.display = "block";
                            document.getElementById(array[7]).layer.style.display = "block";
                            document.getElementById(array[8]).layer.style.display = "block";
                            document.getElementById(array[9]).layer.style.display = "block";
                             document.getElementById(array[10]).layer.style.display = "block";
                             document.getElementById(array[11]).layer.style.display = "block";

                         }

                         else
                             layer.style.display = "none";

                     }
                 }

             
    });         
        
        
           

         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true  
            
            
         });

         $(document).ready(function () {

             var role = (document.getElementById('MainContent_role').value);
             //role = "ReadOnly";
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSendEmail').style.display = "none";
             }
             $(".dropdown-toggle").dropdown();

                   var date_input=$('input[name="date"]'); //our date input has the name "date"
      var container=$('.bootstrap-iso form').length>0 ? $('.bootstrap-iso form').parent() : "body";
      var options={
        format: 'mm/dd/yyyy',
        container: container,
        todayHighlight: true,
        autoclose: true,
      };
      date_input.datepicker(options);
         });

         var date = new Date(document.getElementById('MainContent_date_max').value);

         $('#datetimepicker').datepicker('setDate', date);

         $("#datetimepicker").datepicker().on('changeDate', function (e) {
             var selectedDate = $('#datetimepicker').datepicker("getDate");
             var data = $('#datetimepicker').datepicker("getDate");
             $.ajax({
                 type: "POST",
                 url: 'Reporting.aspx/callCodeBehind',
                 data: JSON.stringify({ selDate: selectedDate }),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     window.location.reload();

                 },
                 error: function (e) {

                 }
             });



         });

          function confirmation() {
             if (confirm("Have the latest daily reports been saved as a PDF file?") == true)
                 return true;
             else
                 return false;
         }
 
         </script>
</asp:Content>
