<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="QA_LAB_project.Inventory" %>
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
     <p style="color:white">Inventory Data</p>
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
                           <div class="table-responsive" style="float: left; margin-left: 20px; height: 700px; width: 55%; overflow-x: hidden; overflow-y: scroll ">
                        
                                        <asp:GridView ID="gv_inventory" runat="server" Height="16px" Width="284px" EnableViewState ="true"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                
                                                 EditRowStyle-Width="20px"
                                                style="border-radius: 10px"
                                                 >
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                            <asp:Label  ID="gv_invt_s" runat="server" Text='<%# Eval("s") %>' Width="170px"></asp:Label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="A" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_invt_a" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="C" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                               <asp:TextBox onchange="onChange(this.id);" ID="gv_invt_b" runat="server" Text='<%# Eval("b", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="S" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                              <asp:TextBox onchange="onChange(this.id);" ID="gv_invt_c" runat="server" Text='<%# Eval("c", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                    
                                                 </Columns>
                                                  <RowStyle BackColor="#DDDDDD" />
                                             </asp:GridView>
                        </div>

                           <div class="table-responsive" style="float: left; margin-left: 5px; height: 130px; width: 40%; overflow-x: hidden;">
                        
                                        <asp:GridView ID="gv_invt2" runat="server" Height="16px" Width="284px" EnableViewState ="true"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                
                                                 EditRowStyle-Width="20px"
                                                style="border-radius: 10px"
                                                 >
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                            <asp:Label  ID="gv_invt2_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="WT64" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_invt2_a" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="WT77" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                               <asp:TextBox onchange="onChange(this.id);" ID="gv_invt2_b" runat="server" Text='<%# Eval("b", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="WT90" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                              <asp:TextBox onchange="onChange(this.id);" ID="gv_invt2_c" runat="server" Text='<%# Eval("c", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                    
                                                 </Columns>
                                                  <RowStyle BackColor="#DDDDDD" />
                                             </asp:GridView>
                        </div>
                         <div class="table-responsive" style="float: left; margin-left: 5px; height: 130px; width: 40%; overflow-x: hidden;">
                        
                                        <asp:GridView ID="gv_invt3" runat="server" Height="16px" Width="284px" EnableViewState ="true"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                
                                                 EditRowStyle-Width="20px"
                                                style="border-radius: 10px"
                                                 >
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                            <asp:Label  ID="gv_invt3_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TT" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_invt3_a" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="ST" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                               <asp:TextBox onchange="onChange(this.id);" ID="gv_invt3_b" runat="server" Text='<%# Eval("b", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="PT" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                              <asp:TextBox onchange="onChange(this.id);" ID="gv_invt3_c" runat="server" Text='<%# Eval("c", "{0:.#}") %>' Width="40px"></asp:TextBox>
                                                         </ItemTemplate>
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


     <input type="hidden" runat="server" id="role" value="" />  

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
