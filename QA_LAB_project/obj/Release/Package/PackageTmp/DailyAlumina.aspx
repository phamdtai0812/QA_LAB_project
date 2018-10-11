<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyAlumina.aspx.cs" Inherits="QA_LAB_project.DailyAlumina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <script src="Scripts/jquery-3.1.0.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
        
    </style>

<%--    <div class="container-fluid main-container" style="margin-top: 2px">
        <div class="col-md-12 content col-xs-offset-2">--%>
    <br />
    <br />
     <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
         <p style="color:white">Daily Alumina & Hydrate Analysis</p>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" name="datetimepicker" readonly="readonly" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                 
                <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                    <%--OnClick="SaveButtonClick"--%>
                </div>
                       
            </div>
            <div class="row">
                <div class="panel panel-default" style="width: 90%; padding: 10px; margin: 10px" id="panel1">
                    <div id="Tabs" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#aluminadaily" aria-controls="aluminadaily" role="tab" data-toggle="tab">Alumina Daily Comp. Analysis</a></li>
                            <li><a href="#hydratedaily" aria-controls="hydratedaily" role="tab" data-toggle="tab">Hydrate Daily Comp. Analysis</a></li>
                            <li><a href="#wethydratedaily" aria-controls="wethydratedaily" role="tab" data-toggle="tab">Wet Hydrate Daily Comp. Analysis</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <div role="tabpanel" class="tab-pane active" id="aluminadaily">
                                <div class="container">
                                    <div class="row clearfix">
                                       
                                                    <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                                        <asp:GridView ID="gv_alumina" runat="server" Height="16px" Width="210px"
                                                            CssClass="table  table-bordered table-hover"
                                                            ShowHeader="False"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                          
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="150">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_alumina" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="80">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_alumina" runat="server" Text='<%# String.Format("{0:0.00000}",Eval("value")) %>' Width="80px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                    </div>
                                </div>
                            </div>

                            <div role="tabpanel" class="tab-pane" id="hydratedaily">
                                <div class="container">
                                    <div class="row clearfix">
                                        
                                              <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                            <asp:GridView ID="gv_hydrate1" runat="server" Height="16px" Width="210px" ShowHeader="False" 
                                                            CssClass="table  table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                            OnRowDataBound="gv_hydrate1_RowDataBound"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="40" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="labelname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="80" >
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_hydrate1" runat="server" Text='<%# Eval("value") %>' Width="80px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                  </div>
                                       
                                            <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                            <asp:GridView ID="gv_hydrate2" runat="server" Height="16px" Width="210px"
                                                            CssClass="table table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                ShowHeader="False"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="150">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="labelname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="80">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_hydrate2" runat="server" Text='<%# Eval("value") %>' Width="80px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane" id="wethydratedaily">
                                 <div class="container">
                                    <div class="row clearfix">
                                           <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                            <asp:GridView ID="gv_wethydrate1" runat="server" Height="16px" Width="210px" ShowHeader="False" 
                                                            CssClass="table table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="40" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="labelname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="80" >
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_wethydrate1" runat="server" Text='<%# Eval("value") %>' Width="80px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                        </div>
                                         <%--   <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                                            <asp:GridView ID="gv_wethydrate2" runat="server" Height="16px" Width="210px"
                                                            CssClass="table table-bordered table-hover"
                                                            AutoGenerateColumns="False"
                                                            EditRowStyle-Width="20px"
                                                ShowHeader="False"
                                                            >
                                                            <EditRowStyle CssClass="GridViewEditRow" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="150">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="labelname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-Width="80">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtbox_wethydrate2" runat="server" Text='<%# Eval("value") %>' Width="80px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                        </div>--%>
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

         var allInputs = $(':text:visible'); //(1)collection of all the inputs I want (not all the inputs on my form)
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

             var role = (document.getElementById('MainContent_role').value);
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSave').style.display = "none";
             }


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

             //if (selectedDate > date) {
             //    //alert('selectedDate > date');

             //    document.getElementById("panel_gvhydrate").style.display = "none";
             //    document.getElementById("panel_gvhwethydrate").style.display = "none";
             //    document.getElementById("panel_hydrate_add").style.display = "block";
             //    document.getElementById("panel_wethydrate_add").style.display = "block";
             //    document.getElementById("MainContent_btnSave").style.display = "block";
             //    document.getElementById('dateSave').value = $('#datetimepicker').datepicker("getDate");
             //}
             //else {

                 //alert('selected < date');
                 //    document.getElementById("panel1").style.display = "block";
                 //    document.getElementById("panel2").style.display = "none";

                 var data = $('#datetimepicker').datepicker("getDate");
                 $.ajax({
                     type: "POST",
                     url: 'DailyAlumina.aspx/callCodeBehind',
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
