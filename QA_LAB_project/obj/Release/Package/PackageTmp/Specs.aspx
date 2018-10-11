<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Specs.aspx.cs" Inherits="QA_LAB_project.Specs" %>
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
    <br />
 <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <p style="color:white">Product Specs</p>
        </div>
        <div class="panel-body" >
          <%--  <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" name="datetimepicker" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" OnClick="SaveButtonClick" CssClass="btn btn-secondary" />
                </div>
            </div>--%>
            <div class="row">
                <div class="panel panel-default" style="width: 90%; padding: 10px; margin: 10px" id="panel1">
                    <div id="Tabs" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#c70" aria-controls="c70" role="tab" data-toggle="tab">C70</a></li>
                            <li><a href="#h30" aria-controls="h30" role="tab" data-toggle="tab">H30</a></li>
                            <li><a href="#wh30" aria-controls="wh30" role="tab" data-toggle="tab">WH30</a></li>
                             <li><a href="#pitags" aria-controls="pitags" role="tab" data-toggle="tab">Pi Tag List</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <div role="tabpanel" class="tab-pane active" id="c70">
                                <div class="container">
                                    <div class="row clearfix" style="padding-bottom: 5px">

                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                    <asp:GridView ID="gv_c70" runat="server" Height="16px" Width="260px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="50">
                                            <%--    <HeaderTemplate>
                                                    <asp:TextBox ID="gv_c70" ToolTip="ID" runat="server" Text="Item"></asp:TextBox>
                                                </HeaderTemplate>--%>

                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_c70_item" runat="server" Text='<%# Eval("ITEM_NAME") %>' Width="100px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_c70_sd" runat="server" Text='<%# Eval("START_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_c70_ed" runat="server" Text='<%# Eval("END_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Min Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_c70_tl" runat="server" Text='<%# Eval("TOLERANCE_LOWER") %>' Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Max Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbox_c70_tu" runat="server" Text='<%# Eval("TOLERANCE_UPPER") %>' Width="65px"></asp:TextBox>
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

                         

                            </div>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane" id="h30">
                                <div class="container">
                                     <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                    <asp:GridView ID="gv_h30" runat="server" Height="16px" Width="260px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="50">
                                             

                                                <ItemTemplate>
                                                    <asp:TextBox  runat="server" Text='<%# Eval("ITEM_NAME") %>' Width="100px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("START_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("END_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Min Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("TOLERANCE_LOWER") %>' Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Max Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("TOLERANCE_UPPER") %>' Width="65px"></asp:TextBox>
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

                         

                            </div>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane" id="wh30">
                                 <div class="container">
                                 <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                    <asp:GridView ID="gv_wh30" runat="server" Height="16px" Width="260px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px">
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="50">
                                             

                                                <ItemTemplate>
                                                    <asp:TextBox  runat="server" Text='<%# Eval("ITEM_NAME") %>' Width="100px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("START_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Date" ItemStyle-Width="50">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("END_DATE") %>' Width="80px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Min Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("TOLERANCE_LOWER") %>' Width="60px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Max Amt." ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("TOLERANCE_UPPER") %>' Width="65px"></asp:TextBox>
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

                         

                            </div>
                                </div>
                            </div>
                             <div role="tabpanel" class="tab-pane" id="pitags">
                                 <div class="container">
                                 <div class="row clearfix" style="padding-bottom: 5px">
                                <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc; overflow-y: scroll; height: 500px">
                                    <asp:GridView ID="gv_PiTagList" runat="server" Height="16px" Width="260px"
                                        CssClass="table table-bordered table-hover"
                                        AutoGenerateColumns="False"
                                        EditRowStyle-Width="20px"
                                        
                                        >
                                        <EditRowStyle CssClass="GridViewEditRow" />

                                        <Columns>

                                            <asp:TemplateField HeaderText="PiTag Name" ItemStyle-Width="50">
                                             

                                                <ItemTemplate>
                                                    <asp:TextBox  runat="server" Text='<%# Eval("PiTagName") %>' Width="180px" Height="35px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px"></ItemStyle>

                                            </asp:TemplateField>
                                            

                                            <asp:TemplateField HeaderText="Description" ItemStyle-Width="70">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Eval("Description") %>' Width="230px" Height="35px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"></ItemStyle>

                                            </asp:TemplateField>
                                        

                                        </Columns>
                                        <RowStyle BackColor="#DDDDDD" />
                                    </asp:GridView>
                                </div>

                         

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
     


         //$('#datetimepicker').datepicker({
         //    format: "mm/dd/yyyy",
         //    autoclose: true
         //});

         //var date = new Date(document.getElementById('MainContent_date_max').value);
       
         //$('#datetimepicker').datepicker('setDate', date);

         //$("#datetimepicker").datepicker().on('changeDate', function (e) {
         //    var selectedDate = $('#datetimepicker').datepicker("getDate");
         //        var data = $('#datetimepicker').datepicker("getDate");
         //        $.ajax({
         //            type: "POST",
         //            url: 'Sec_12.aspx/callCodeBehind',
         //            data: JSON.stringify({ selDate: selectedDate }),
         //            contentType: "application/json; charset=utf-8",
         //            dataType: "json",
         //            success: function (msg) {
         //                window.location.reload();

         //            },
         //            error: function (e) {

         //            }
         //        });

             

         //});
 
         </script>
</asp:Content>
