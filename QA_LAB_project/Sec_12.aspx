<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sec_12.aspx.cs" Inherits="QA_LAB_project.Sec_12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="Scripts/jquery-3.1.0.js"></script>
  
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></scrip>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
     <style>
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
   background-color: #dcdcdc;
 }
     
    </style>
    <br />
   
    <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <p style="color:white"> SEC I/II Data</p>
        </div>
        <div class="panel-body" >
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker" tabindex="-1" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" OnClick="SaveButtonClick" CssClass="btn btn-secondary" />
                </div>
            </div>
            <div class="panel panel-default" style="width: 98%; padding: 10px;" id="panel1">
                <div id="Tabs" role="tabpanel">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist"  style="background-color: gray">
                        <li class="active" ><a href="#solidanalysis" aria-controls="solidanalysis" role="tab" data-toggle="tab">% Solid Analysis</a></li>
                        <li><a href="#washerprofile" aria-controls="washerprolife" role="tab" data-toggle="tab" onclick="addInputs();">Washer Profile & PDS</a></li>
                        <li><a href="#mglsolids" aria-controls="washerprolife" role="tab" data-toggle="tab" onclick="addInputs();">SOF/WOF Solids</a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content" style="padding-top: 20px">
                        <div role="tabpanel" class="tab-pane active" id="solidanalysis">

                            <div class="row clearfix" style="padding-bottom: 5px">

                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                    <b>% Solid Analysis</b>
                                    <asp:GridView ID="gv_psa" runat="server" Height="16px" Width="260px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="SUF" ItemStyle-Width="50">
                                                <HeaderTemplate>
                                                    <asp:Label ID="gv_psa_suf" ToolTip="ID" runat="server" Text="SUF"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_psa_suf" runat="server" Text='<%# Eval("SASUF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WUF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_psa_wuf" runat="server" Text='<%# Eval("SAWUF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MTL" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_psa_mtl" runat="server" Text='<%# Eval("SAMTL") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Filter Aid" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_psa_faid" runat="server" Text='<%# Eval("SAFA") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lime Rec" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_psa_lrec" runat="server" Text='<%# Eval("SALR") %>' Width="65px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="txtbox_pft_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>' />
                                                                </ItemTemplate>
                                                                <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                <HeaderStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                <ItemStyle Width="1px" BackColor="white" ForeColor="white"></ItemStyle>
                                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>
                               
                                <div class="table-responsive" style="float: left; margin-left: 5px;">
                                    <b>Digestion GPL Solids</b>
                                    <asp:GridView ID="gv_gpl" runat="server" Height="16px" Width="250px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="  V-4" ItemStyle-Width="50" >
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_gpl_tri" runat="server" Text='<%# Eval("TRIDIGEST") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No5 FT" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_gpl_no5ft" runat="server" Text='<%# Eval("FT5") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Dig Disch" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_gpl_ddisch" runat="server" Text='<%# Eval("DIGDISCH") %>' Width="50px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                            </div>
                        
                            <div class="row clearfix" style="padding-bottom: 5px">
                          
                               <div class="table-responsive"  style="float: left; margin-left: 20px">
                                            <b>Grams Per Liter Solids</b>
                                            <asp:GridView ID="gv_gpls" runat="server" Height="16px" Width="240px"
                                                CssClass="table table-bordered table-hover"
                                                AutoGenerateColumns="False"
                                                EditRowStyle-Width="20px">
                                                <EditRowStyle CssClass="GridViewEditRow" />

                                                <Columns>

                                                    <asp:TemplateField HeaderText="Tray 1" ItemStyle-Width="50">
                                                  
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_gpls1" runat="server" Text='<%# Eval("GPLS1") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tray 2" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_gpls2" runat="server" Text='<%# Eval("GPLS2") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Tray 3" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_gpls3" runat="server" Text='<%# Eval("GPLS3") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Tray 4" ItemStyle-Width="70">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_gpls4" runat="server" Text='<%# Eval("GPLS4") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="70px"></ItemStyle>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="B.Filtrate" ItemStyle-Width="70">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_bf" runat="server" Text='<%# Eval("GPLSBF") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="70px"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ox. Set" ItemStyle-Width="70">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtbox_gpls_oxset" runat="server" Text='<%# Eval("GPLSOXSET") %>' Width="50px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="70px"></ItemStyle>
                                                    </asp:TemplateField>


                                                </Columns>
                                                <RowStyle BackColor="#DDDDDD" />
                                            </asp:GridView>
                                        </div>
                              
                            </div>
                          
                            <div class="row clearfix" style="padding-bottom: 5px">

                                <div class="table-responsive" style="float: left; margin-left: 20px; padding-right: 10px;">
                                    <b>Soda Analysis</b>
                                    <asp:GridView ID="gv_soda" runat="server" Height="16px" Width="200px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="B. Filtrate" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_soda_bf" runat="server" Text='<%# Eval("SABF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ox Set" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_soda_oxset" runat="server" Text='<%# Eval("SAOXSET") %>' Width="50px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lime Rec" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_soda_lrec" runat="server" Text='<%# Eval("SALIMEREC") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                    <b>Sulfide Analysis</b>
                                    <asp:GridView ID="gv_sa" runat="server" Height="16px" Width="100px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="Sulfide Tank" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sa_st" runat="server" Text='<%# Eval("SAST") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LtP" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sa_lp" runat="server" Text='<%# Eval("SALP") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                                <div class="table-responsive" style="float: left; margin-left: 5px; ">
                                    <b>Settling Rates &nbsp&nbsp&nbsp&nbsp Settling Feed </b>
                                    <asp:GridView ID="gv_sr" runat="server" Height="16px" Width="280px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Plant Floc" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sr_rf" runat="server" Text='<%# Eval("SRPF") %>' Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Solids (gpl)" ItemStyle-Width="40" HeaderStyle-Wrap="true">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sr_srs" runat="server" Text='<%# Eval("SRS") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ind. Starch" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sr_is" runat="server" Text='<%# Eval("SRSTARCHI") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Set. Starch" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_sr_ss" runat="server" Text='<%# Eval("SRSTARCHS") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                            </div>

                            <div class="row clearfix" style="padding-bottom: 5px">
                            
                                <div class="table-responsive" style="float: left; margin-left: 20px; ">
                                    <b>Liquor Oxalate Analysis</b>
                                    <asp:GridView ID="gv_loa" runat="server" Height="16px" Width="240px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="LtP" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_loa_ltp" runat="server" Text='<%# Eval("LtP") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Spent Liquor" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_loa_sl" runat="server" Text='<%# Eval("SPENTLIQ") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="B. Filtrate" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_loa_bf" runat="server" Text='<%# Eval("OABF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ox Set" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_loa_oxs" runat="server" Text='<%# Eval("OAOXSET") %>' Width="50px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                                <div class="table-responsive" style="float: left; margin-left: 5px">
                                    <b>Solid Phase Oxalate</b>
                                    <asp:GridView ID="gv_spo" runat="server" Height="16px" Width="250px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="1B Cake" ItemStyle-Width="50">

                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_1bc" runat="server" Text='<%# Eval("OA1CAKE") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2B Cake" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_2bc" runat="server" Text='<%# Eval("OA2CAKE") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ST Seed" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_sts" runat="server" Text='<%# Eval("OASTSEED") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="6 A/B" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_6ab" runat="server" Text='<%# Eval("OA6AB") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Y 15/16" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_y15" runat="server" Text='<%# Eval("Y1516") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Prim Fd." ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_spo_pf" runat="server" Text='<%# Eval("OAPF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                            </div>
                           
                            <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; margin-left: 20px">
                                    <b>% TAA Analysis</b>
                                    <asp:GridView ID="gv_taa" runat="server" Height="16px" Width="250px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="V-4" ItemStyle-Width="50">

                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_td" runat="server" Text='<%# Eval("TD") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No5 FT" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_n5ft" runat="server" Text='<%# Eval("TAAA4FT") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_sf" runat="server" Text='<%# Eval("TAAASF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SUF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_suf" runat="server" Text='<%# Eval("TAAASUF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WUF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_wuf" runat="server" Text='<%# Eval("TAAAWUF") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MTL" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_taa_mtl" runat="server" Text='<%# Eval("TAAAMTL") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 5px">
                                    <b>LTP Ca</b>
                                    <asp:GridView ID="gv_ltpca" runat="server" Height="16px" Width="80px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="(mg/l)" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_ltpca_ltpca" runat="server" Text='<%# Eval("LTPCA") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>

                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>

                        <div role="tabpanel" class="tab-pane" id="washerprofile">
                            <div class="row clearfix">
                                <div class="table-responsive" style="float: left; margin-left: 20px">
                                    <b>Washer Profile</b>
                                    
                                    <asp:GridView ID="gv_wp" runat="server" Height="16px" Width="250px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px"
                                        OnRowCreated="gv_WasherProfile_RowCreated">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="-0-" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_wp_wp0" runat="server" Text='<%# Eval("wp0") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_wp_wp1" runat="server" Text='<%# Eval("wp1") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="-2-" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_wp_wp2" runat="server" Text='<%# Eval("wp2") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>
                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                    <br />
                                    <asp:GridView ID="gv_pds" runat="server" Height="16px" Width="80px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="PDS No" ItemStyle-Width="50">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("PDS No") %>' Width="70px"></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_pds_cpds" runat="server" Text='<%# Eval("CPDS1") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="A/C" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_pds_apds" runat="server" Text='<%# Eval("APDS1", "{0:0.###}") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="%Solid" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_pds_spds" runat="server" Text='<%# Eval("SPDS1") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Density" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_pds_d1pds" runat="server" Text='<%# Eval("D1PDS") %>' Width="50px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>


                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>

                         <div role="tabpanel" class="tab-pane" id="mglsolids">
                            <div class="row clearfix">
                                <div class="table-responsive" style="float: left; margin-left: 20px">
                                    <b></b>
                                



                                    <asp:GridView ID="gv_solids" runat="server" Height="16px" Width="250px"
                                        CssClass="table table-bordered"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                      <%--  OnRowCreated="gv__RowCreated"--%>
                                        
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>
                                     <%--       <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_solids_date" runat="server" Text='<%# Eval("mgLSolids_DATE") %>' Width="68px" Readonly="true"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                                   <ControlStyle BackColor="LightSlateGray" Width="68px" />
                                            </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_solids_time" runat="server" Text='<%# Eval("Time") %>' Width="50px" ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                                  
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="SOF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_solids_sof" runat="server" Text='<%# Eval("SOF") %>' Width="50px" R></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                                
                                            </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="WOF" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_solids_wof" runat="server" Text='<%# Eval("WOF") %>' Width="50px"> </asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                                          
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="SULFIDE" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_solids_sulfide" runat="server" Text='<%# Eval("SULFIDE") %>' Width="50px" ></asp:TextBox>
                                                </ItemTemplate>
                                                
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                     
                                            <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="txtbox_solids_id" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                                <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                <HeaderStyle BackColor="white" ForeColor="white" Width="1px" />
                                                <ItemStyle Width="1px" BackColor="white" ForeColor="white"></ItemStyle>
                                            </asp:TemplateField>
                               
                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                      

                            </div>
                        </div>
                    </div>
                </div>
            </div>
               
         
        </div>
    </div>


     <input type="hidden" runat="server" id="role" value="" />  
<%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
     <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>

     <script>

         $(document).ready(function () {

             var role = (document.getElementById('MainContent_role').value);
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSave').style.display = "none";
             }


         });
         function addInputs() {
           
             //(1)collection of all the inputs I want (not all the inputs on my form)
             $(":text").on("keydown", function () {//(2)When an input field detects a keydown event
                 //alert('key down');
                 if (event.keyCode == 13) {
                     event.preventDefault();
                     var allInputs = $(':text:visible'); 
                     var nextInput = allInputs.get(allInputs.index(this) + 1);//(3)The next input in my collection of all inputs
                     if (nextInput) {
                         nextInput.focus(); //(4)focus that next input if the input is not null
                     }
                 }
             });
         }

         
         $(function () {
             $("input[type=text]").keypress(function () {
                 if (event.keyCode == 13) {
                     event.preventDefault();
                     var allInputs = $(':text:visible');
                     var nextInput = allInputs.get(allInputs.index(this) + 1);//(3)The next input in my collection of all inputs
                     if (nextInput.id.match(/MainContent_gvHydrate_txtbox_hydratedate_.*/)
                         || nextInput.id.match(/MainContent_gvWetHydrate_txtbox_wethydratedate_.*/)
                     ) {
                         nextInput = allInputs.get(allInputs.index(this) + 2);
                         nextInput.focus();
                         //(4)focus that next input if the input is not null
                     }
                     else
                         nextInput.focus();
                 }

             });
         });

        

         //$(document).ready(function () {
             //var allInputs = $(':text:visible'); //(1)collection of all the inputs I want (not all the inputs on my form)
             //$(":text").on("keydown", function () {//(2)When an input field detects a keydown event
             //    //alert('key down');
             //    if (event.keyCode == 13) {
             //        event.preventDefault();
             //        addInputs()
             //        //var nextInput = allInputs.get(allInputs.index(this) + 1);//(3)The next input in my collection of all inputs
             //        //if (nextInput) {
             //        //    nextInput.focus(); //(4)focus that next input if the input is not null
             //        //}
             //    }
             //});
         //});

         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

         var date = new Date(document.getElementById('MainContent_date_max').value);
       
         $('#datetimepicker').datepicker('setDate', date);

         $("#datetimepicker").datepicker().on('changeDate', function (e) {
             var selectedDate = $('#datetimepicker').datepicker("getDate");
                 var data = $('#datetimepicker').datepicker("getDate");
                 $.ajax({
                     type: "POST",
                     url: 'Sec_12.aspx/callCodeBehind',
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
 
         </script>

</asp:Content>
