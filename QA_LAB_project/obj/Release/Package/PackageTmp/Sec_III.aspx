<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sec_III.aspx.cs" Inherits="QA_LAB_project.Sec_III" %>
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

<%--    <div class="container-fluid main-container" style="margin-top: 2px">
        <div class="col-md-12 content col-xs-offset-2">--%>
    <br />
    <br />
 <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
            <p style="color:white">SEC III Worksheet</p>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                 
                <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                  
                </div>
                       
            </div>
            <div class="row">
               <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="panel1">
                    <div id="Tabs" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#pts" aria-controls="pts" role="tab" data-toggle="tab">Precip. Top Samples</a></li>
                            <li><a href="#cps" aria-controls="cps" role="tab" data-toggle="tab">Cont. Precip. - South</a></li>
                            <li><a href="#cpn" aria-controls="cpn" role="tab" data-toggle="tab">Cont. Precip. - North</a></li>
                            <li><a href="#cc" aria-controls="cc" role="tab" data-toggle="tab">Caustic Cleaning</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <div role="tabpanel" class="tab-pane active" id="pts">
                                <div class="container">
                                    <div class="row clearfix">

                                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                            Batch Precipitation ST Top Samples
                                                        <asp:GridView ID="gv_stts" runat="server" Height="16px" Width="250px"
                                                            CssClass="table  table-bordered  table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                             OnRowDataBound ="gv_stts_OnRowDataBound"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="50" HeaderText="TK NO">

                                                                    <ItemTemplate>
                                                                        <asp:TextBox  ID="txtbox_stts_secid" Style="padding: 0;" runat="server" Text='<%# Eval("SECID") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="50px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                                    <%--<HeaderTemplate>
                                                                    <asp:Label ID="Label3" ToolTip="ID" runat="server" Text="+100"></asp:Label>
                                                                </HeaderTemplate>--%>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_p100" runat="server" Text='<%# Eval("p100") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="50px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_p200" runat="server" Text='<%# Eval("P200") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="50px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_p325" runat="server" Text='<%# Eval("P325") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="50px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="-20um" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_um20" runat="server" Text='<%# Eval("UM20") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_caus" runat="server" Text='<%# Eval("CAUS") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_ac" runat="server" Text='<%# Eval("AC") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="GPLSOL" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_gplsol" runat="server" Text='<%# Eval("GPLSOL") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SA" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_stts_sa" runat="server" Text='<%# Eval("SA") %>' Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="30px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="txtbox_stts_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>' />

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
                                    <br />
                                    <div class="row clearfix">
                                        
                                                    <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                                        Batch Precipitation TT Top Samples
                                                        <asp:GridView ID="gv_ttts" runat="server" Height="16px" Width="250px"
                                                            CssClass="table  table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                             OnRowDataBound ="gv_ttts_OnRowDataBound"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                              <asp:TemplateField ItemStyle-Width="50" HeaderText="TK NO">

                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_secid" runat="server" Text='<%# Eval("SECID") %>' Width="50px" ></asp:TextBox>
                                                                </ItemTemplate>

                                                               

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label3" ToolTip="ID" runat="server" Text="+100"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_p100" runat="server" Text='<%# Eval("p100") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_p200" runat="server" Text='<%# Eval("P200") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_p325" runat="server" Text='<%# Eval("P325") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-20um" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_um20" runat="server" Text='<%# Eval("UM20") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_caus" runat="server" Text='<%# Eval("CAUS") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_ac" runat="server" Text='<%# Eval("AC") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GPLSOL" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_gplsol" runat="server" Text='<%# Eval("GPLSOL") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SA" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_ttts_sa" runat="server" Text='<%# Eval("SA") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_ttts_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>'  />
                                                             
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
                                    <br />
                                    <div class="row clearfix">
                                       
                                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                                       Primary Feed/Seed Tanks
                                                    <asp:GridView ID="gv_pft" runat="server" Height="16px" Width="250px"
                                                        CssClass="table table-bordered table-hover"
                                                        AutoGenerateColumns="False"
                                                        EditRowStyle-Width="20px"
                                                        OnRowDataBound="gv_pft_RowDataBound">
                                                        <EditRowStyle CssClass="GridViewEditRow" />

                                                        <Columns>

                                                            <asp:TemplateField ItemStyle-Width="50" HeaderText="">

                                                                <ItemTemplate>
                                                                    <asp:TextBox TabIndex="-1" ID="txtbox_pft_secid" runat="server" Text='<%# Eval("SECID") %>' Width="70px" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ControlStyle BackColor="#CCCCCC" />

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="+100" ItemStyle-Width="50">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="Label3" ToolTip="ID" runat="server" Text="+100"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_p100" runat="server" Text='<%# Eval("P100") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="+200" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_p200" runat="server" Text='<%# Eval("P200") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="+325" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_p325" runat="server" Text='<%# Eval("P325") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="50px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-20um" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_um20" runat="server" Text='<%# Eval("UM20") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_caus" runat="server" Text='<%# Eval("CAUS") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_ac" runat="server" Text='<%# Eval("AC") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GPLSOL" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_gplsol" runat="server" Text='<%# Eval("GPLSOL") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SA" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_pft_sa" runat="server" Text='<%# Eval("SA") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_pft_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>'  />
                                                             
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

                            <div role="tabpanel" class="tab-pane" id="cps">
                                <div class="container">
                                    <div class="row clearfix">
                                        <div class="col-md-8 column" style="padding-top: 20px;" >
                                            <asp:GridView ID="gv_cps" runat="server" Height="16px" Width="250px" ShowHeader="True" 
                                                            CssClass="table  table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                OnRowDataBound="gv_cps_RowDataBound"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                               <Columns>
                                                     
                                                                  <asp:TemplateField HeaderText="" ItemStyle-Width="70">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_secid" runat="server" Text='<%# Eval("SECID") %>'  Width="70px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                        <ControlStyle BackColor="#CCCCCC" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_p100" runat="server" Text='<%# Eval("p100") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="+200" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_p200" runat="server" Text='<%# Eval("P200") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="+325" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_p325" runat="server" Text='<%# Eval("P325") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="-20um" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_um20" runat="server" Text='<%# Eval("UM20") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_caus" runat="server" Text='<%# Eval("CAUS") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_ac" runat="server" Text='<%# Eval("AC") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="GPLSOL" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_gplsol" runat="server" Text='<%# Eval("GPLSOL") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SA" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_cps_sa" runat="server" Text='<%# Eval("SA") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_cps_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>'  />
                                                             
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
                            <div role="tabpanel" class="tab-pane" id="cpn">
                                 <div class="container">
                                    <div class="row clearfix">
                                        <div class="col-md-8 column" style="padding-top: 20px;" >
                                            <asp:GridView ID="gv_cpn" runat="server" Height="16px" Width="250px" ShowHeader="true" 
                                                            CssClass="table table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                OnRowDataBound="gv_cpn_RowDataBound"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                                 <Columns>
                                                        
                                                                  <asp:TemplateField HeaderText="" ItemStyle-Width="70">
                                                                    <ItemTemplate>
                                                             
                                                                        <asp:TextBox ID="txtbox_cpn_secid" runat="server" Text='<%# Eval("SECID") %>'  Width="70px" ></asp:TextBox>
                                                                    </ItemTemplate>
                                                                        <ControlStyle BackColor="#CCCCCC" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="+100" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        
                                                                        <asp:TextBox ID="txtbox_cpn_p100" runat="server" Text='<%# Eval("p100") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="+200" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                   
                                                                        <asp:TextBox ID="txtbox_cpn_p200" runat="server" Text='<%# Eval("P200") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="+325" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                           
                                                                        <asp:TextBox ID="txtbox_cpn_p325" runat="server" Text='<%# Eval("P325") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="-20um" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                            
                                                                        <asp:TextBox ID="txtbox_cpn_um20" runat="server" Text='<%# Eval("UM20") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                      
                                                                        <asp:TextBox ID="txtbox_cpn_caus" runat="server" Text='<%# Eval("CAUS") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                           
                                                                        <asp:TextBox ID="txtbox_cpn_ac" runat="server" Text='<%# Eval("AC") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="GPLSOL" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_cpn_gplsol" runat="server" Text='<%# Eval("GPLSOL") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SA" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_cpn_sa" runat="server" Text='<%# Eval("SA") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_cpn_seciii_id" runat="server" Value='<%# Eval("SecIII_ID") %>' />
                                                             
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
                            <div role="tabpanel" class="tab-pane" id="cc">
                                <div class="container">
                   <%--                  <div style="height: 200px; width: 270px; overflow: scroll">--%> 

                                                <div style="margin-left: 20px">TANK NO &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  Caustic &nbsp&nbsp&nbsp&nbsp&nbsp A/C</div>
                                                <div class="table-responsive" style="float: left; margin-left: 20px; height: 300px; width: 30%; overflow-x: hidden; overflow-y: scroll">
                                                  
                                                    <asp:GridView ID="gv_cc" runat="server" Height="16px" 
                                                        CssClass="table  table-bordered table-hover"
                                                   
                                                        AutoGenerateColumns="False"
                                                        EditRowStyle-Width="20px">
                                                        <EditRowStyle CssClass="GridViewEditRow" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="TK NO" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                  
                                                                    <asp:TextBox ID="txtbox_cc_truck" runat="server" Text='<%# Eval("CCTRUCK") %>' Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                
                                                                <ItemStyle Width="30px"></ItemStyle>
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                               
                                                                    <asp:TextBox ID="txtbox_cc_caustic" runat="server" Text='<%# Eval("CCCAUSTIC") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                             
                                                                    <asp:TextBox ID="txtbox_cc_ac" runat="server" Text='<%# Eval("CCAC") %>' Width="50px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="CCRound" ItemStyle-Width="30">
                                                                <ItemTemplate>
                                                                      <asp:DropDownList ID="txtbox_cc_round" runat="server" SelectedValue='<%# Eval("CCRound") %>' Width="80px">
                                                                            <asp:ListItem Text="Round" Value="0"></asp:ListItem>
                                                                                  <asp:ListItem Text="0300" Value="0300"></asp:ListItem>
                                                                                  <asp:ListItem Text="0600" Value="0600"></asp:ListItem>
                                                                                  <asp:ListItem Text="0900" Value="0900"></asp:ListItem>
                                                                                   <asp:ListItem Text="1200" Value="1200"></asp:ListItem>
                                                                                  <asp:ListItem Text="1500" Value="1500"></asp:ListItem>
                                                                                  <asp:ListItem Text="1800" Value="1800"></asp:ListItem>
                                                                                   <asp:ListItem Text="2100" Value="2100"></asp:ListItem>
                                                                                  <asp:ListItem Text="2400" Value="2400"></asp:ListItem>
                                                                          </asp:DropDownList>
                                                             
                                                               <%--     <asp:TextBox ID="txtbox_cc_round" runat="server" Text='<%# Eval("CCRound") %>' Width="50px"></asp:TextBox>--%>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="txtbox_cc_ccid" runat="server" Value='<%# Eval("CCID") %>' />

                                                                </ItemTemplate>
                                                                <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                <FooterStyle Width="5px" />
                                                                <HeaderStyle BackColor="white" ForeColor="white" Width="5px" />
                                                                <ItemStyle Width="5px" BackColor="white" ForeColor="white"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                           <RowStyle BackColor="#DDDDDD" />
                                                    </asp:GridView>
                                                </div>
                                         
                                   <%-- </div>--%>
                                     
                                                <div class="table-responsive" style="float: left; margin-left: 20px">
                                                    H2O Tank
                                                    <asp:GridView ID="gv_h2o" runat="server" Height="16px" Width="150px"
                                                        CssClass="table table-bordered table-hover "
                                                        EditRowStyle-Width="20px"
                                                        AutoGenerateColumns="False">
                                                     
                                                        <EditRowStyle CssClass="GridViewEditRow" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="TK NO" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbox_h2o_name" runat="server" Text='<%# Eval("name") %>' Width="50px" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ControlStyle BackColor=#dcdcdc />

                                                                <ItemStyle Width="30px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-0000-" ItemStyle-Width="30">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtbox_h2o_0000" runat="server" Text='<%# Eval("-0000-") %>' Width="40px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-0600-" ItemStyle-Width="30">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtbox_h2o_0600" runat="server" Text='<%# Eval("-0600-") %>' Width="40px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-1200-" ItemStyle-Width="30">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtbox_h2o_1200" runat="server" Text='<%# Eval("-1200-") %>' Width="40px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="-1800-" ItemStyle-Width="30">
                                                                <ItemTemplate>

                                                                    <asp:TextBox ID="txtbox_h2o_1800" runat="server" Text='<%# Eval("-1800-") %>' Width="40px"></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle Width="30px"></ItemStyle>

                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField ItemStyle-Width="10">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="txtbox_h2o_id" runat="server" Value='<%# Eval("H2O_ID") %>' />

                                                                </ItemTemplate>
                                                                <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                <FooterStyle Width="1px" />
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
                    
                        <br />
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
           
                     if (nextInput.id.match(/MainContent_gv_pft_txtbox_pft_secid_.*/) || nextInput.id.match(/MainContent_gv_cps_txtbox_cps_secid_.*/)
                         || nextInput.id.match(/MainContent_gv_cpn_txtbox_cpn_secid_.*/)  ) {
                         nextInput = allInputs.get(allInputs.index(this) + 2); 
                         nextInput.focus();
                          //(4)focus that next input if the input is not null
                     }
                     else
                         nextInput.focus();
                         
                 }
             });
         }


         $(function () {
             $("input[type=text]").keypress(function () {
                 if (event.keyCode == 13) {
                     event.preventDefault();
                     var allInputs = $(':text:visible');
                     var nextInput = allInputs.get(allInputs.index(this) + 1);//(3)The next input in my collection of all inputs

                     if (nextInput.id.match(/MainContent_gv_pft_txtbox_pft_secid_.*/) || nextInput.id.match(/MainContent_gv_cps_txtbox_cps_secid_.*/)
                         || nextInput.id.match(/MainContent_gv_cpn_txtbox_cpn_secid_.*/)) {
                         nextInput = allInputs.get(allInputs.index(this) + 2);
                         nextInput.focus();
                        
                         //(4)focus that next input if the input is not null
                     }
                     else
                         nextInput.focus();
                 }

             });
         });
         function CallJS() {
             //alert('clientclick');
             var hydrate_controls = document.getElementById("panel_hydrate_add").getElementsByTagName("input");
             var hydrateArray = new Array();
             for (var i = 0; i < hydrate_controls.length; i++) {
                 // alert(controls[i].value);
                 hydrateArray[i] = (hydrate_controls[i].value);
             }
             var wethydrate_controls = document.getElementById("panel_wethydrate_add").getElementsByTagName("input");
             var wethydrateArray = new Array();

             for (var i = 0; i < wethydrate_controls.length; i++) {
                 // alert(controls[i].value);
                 wethydrateArray[i] = (wethydrate_controls[i].value);
             }

             //var count_ = 0;
             //var controls = document.getElementById("panel_wethydrate_add").getElementsByTagName("input");
             //for (var i = 0; i < controls.length; i++) {
             //   // alert(controls[i].value);
             //    count_ = count_ + 1;
             //}
             //alert(count_)
             //return confirm('Everything ok?');
             var date = $('#datetimepicker').datepicker("getDate");
             //$.ajax({
             //    type: "POST",
             //    url: 'HydrateAnalysis.aspx/arrayData',
             //    data: JSON.stringify({ hydrateArray: hydrateArray, wethydrateArray: wethydrateArray, date: date }),
             //    contentType: "application/json; charset=utf-8",
             //    dataType: "json",
             //    success: function (msg) {

             //        window.location.reload();

             //    },
             //    error: function (e) {

             //    }
             //});


         };
         $(document).ready(function () {
             
         });


         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

         var date = new Date(document.getElementById('MainContent_date_max').value);
         //var date = new Date();
         $('#datetimepicker').datepicker('setDate', date);


         $("#datetimepicker").datepicker().on('changeDate', function (e) {
             var selectedDate = $('#datetimepicker').datepicker("getDate");

           
                 var data = $('#datetimepicker').datepicker("getDate");
                 $.ajax({
                     type: "POST",
                     url: 'Sec_III.aspx/callCodeBehind',
                     data: JSON.stringify({ selDate: selectedDate }),
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (msg) {
                         window.location.reload();

                     },
                     error: function (e) {

                     }
                 });

             //}

         });
 
         </script>

</asp:Content>


<%--       <div role="tabpanel" class="tab-pane active" id="cc">
                                <div class="container">
                                    <div class="row clearfix">
                                        <div class="col-md-3 column">
                                            <div class="row" style="padding-top: 10px;">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gv_cc" runat="server" Height="16px" Width="210px"
                                                        CssClass="table table-striped table-bordered table-striped table-bordered table-hover"
                                                        AutoGenerateColumns="False"
                                                        EditRowStyle-Width="20px">
                                                        <EditRowStyle CssClass="GridViewEditRow" />
                                                        <Columns>
                                                              <asp:TemplateField HeaderText="TK NO" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                           
                                                                        <asp:TextBox ID="txtbox_cc_truck" runat="server" Text='<%# Eval("CCTRUCK") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_cc_caustic" runat="server" Text='<%# Eval("CCCAUSTIC") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="A/C" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_cc_ac" runat="server" Text='<%# Eval("CCAC") %>'  Width="50px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="s3id" ItemStyle-Width="1">
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_cc_ccid" runat="server" Value='<%# Eval("CCID") %>' />
                                                             
                                                                    </ItemTemplate>
                                                                    <ControlStyle BackColor="white" ForeColor="white" Width="5px" />
                                                                           <FooterStyle Width="5px" />
                                                                    <HeaderStyle BackColor="white" ForeColor="white" Width="5px" />
                                                                    <ItemStyle Width="5px" BackColor="white" ForeColor="white"></ItemStyle>
                                                                </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                   
                                        <div class="col-md-4 column">
                                            <div class="row" style="padding-top: 10px;">
                                                <div class="table-responsive">
                                                    H2O Tank
                                                    <asp:GridView ID="gv_h2o" runat="server" Height="16px" Width="210px"
                                                        CssClass="table table-striped table-bordered table-striped table-bordered table-hover"
                                                        EditRowStyle-Width="20px"
                                                        AutoGenerateColumns="False">
                                                     
                                                        <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>
                                                              <asp:TemplateField HeaderText="TK NO" ItemStyle-Width="30" >
                                                                    <ItemTemplate>
                                                                           
                                                                        <asp:TextBox ID="txtbox_h2o_name" runat="server" Text='<%# Eval("name") %>'  Width="40px" ReadOnly="true"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                   <ControlStyle BackColor="gray"  />

<ItemStyle Width="30px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="-0000-" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_h2o_00" runat="server" Text='<%# Eval("-0000-") %>'  Width="40px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="-0600-" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_h2o_0600" runat="server" Text='<%# Eval("-0600-") %>'  Width="40px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="-1200-" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_h2o_1200" runat="server" Text='<%# Eval("-1200-") %>'  Width="40px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="-1800-" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                               
                                                                        <asp:TextBox ID="txtbox_h2o_1800" runat="server" Text='<%# Eval("-1800-") %>'  Width="40px"></asp:TextBox>
                                                                    </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>

                                                                </asp:TemplateField>
                                                                       <asp:TemplateField ItemStyle-Width="10" >
                                                                    <ItemTemplate>
                                                                          <asp:HiddenField ID="txtbox_h20_id" runat="server" Value='<%# Eval("H2O_ID") %>' />
                                                             
                                                                    </ItemTemplate>
                                                                    <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                           <FooterStyle Width="1px" />
                                                                    <HeaderStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                    <ItemStyle Width="1px" BackColor="white" ForeColor="white"></ItemStyle>
                                                                </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>--%>