<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Misc.aspx.cs" Inherits="QA_LAB_project.Misc" %>
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
     <p style="color:white">Miscellaneous Data</p>
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
                    <asp:Button ID="Button1" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                </div>
            </div>
            
            <div class="row" style="margin: 0px">
                <div class="panel panel-default" style="width: 98%; padding: 10px;" id="panel1">

                    <div class="row clearfix" style="padding-bottom: 5px">
                           <div class="table-responsive" style="float: left; margin-left: 20px; height: 300px; width: 80%; overflow-x: hidden; overflow-y: scroll">
                        
                                             <asp:GridView ID="gv_misc" runat="server" Height="16px" Width="75%"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                 EditRowStyle-Width="20px"


                                                 >
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="Misc Description" ItemStyle-Width="400">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_misc_desc" runat="server" Text='<%# Eval("MMISCDESCR") %>' Width="400px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="Misc Amount">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_misc_amt" runat="server" Text='<%# Eval("MMISCQTY") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>

                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="Misc Size">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_misc_size" runat="server" Text='<%# Eval("MMISCSIZE") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                           <asp:TemplateField ItemStyle-Width="80" HeaderText="Round">
                                                         <ItemTemplate>
                                                                    <asp:DropDownList ID="gv_misc_ddlccround" runat="server" SelectedValue='<%# Eval("CCRound") %>' Width="80px">
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
                                                            <%-- <asp:TextBox ID="gv_misc_ccround" runat="server" Text='<%# Eval("CCROUND") %>' Width="50px"></asp:TextBox>--%>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>


                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                         <ItemTemplate>
                                                             <asp:HiddenField ID="gv_misc_id" runat="server" Value='<%# Eval("MD_ID") %>' />
                                                         </ItemTemplate>
                                                                    <ControlStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                    <HeaderStyle BackColor="white" ForeColor="white" Width="1px" />
                                                                    <ItemStyle Width="1px" BackColor="white" ForeColor="white"></ItemStyle>
                                                      </asp:TemplateField>
                                                 </Columns>
                                                   <%--  <RowStyle BackColor="#DDDDDD" />--%>
                                             </asp:GridView>
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
                     addInputs();
                 }

             });
         });



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
                 url: 'Misc.aspx/callCodeBehind',
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
