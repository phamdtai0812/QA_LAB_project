<%@ Page Title="Hydrate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HydrateAnalysis.aspx.cs" Inherits="QA_LAB_project.HydrateAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <script src="Scripts/jquery-3.1.0.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
 
<%--    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript" ></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>--%>


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
   
    <div class="panel panel-default" style="width: 800px; margin-left: 150px">
        <div class="panel-heading">
            <p style="color:white">Hydrate Analysis</p>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" readonly="readonly" placeholder="Date" name="datetimepicker" tabindex="80" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-md-2" style="margin-left: 150px">
                    <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                    <%--OnClick="SaveButtonClick"--%>
                </div>
            </div>

            <div class="row">


                <div class="panel panel-default" style="width: 90%; padding: 10px; margin: 10px" id="panel1">
                    <div id="Tabs" role="tabpanel" >
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist" style="background-color: gray">
                            <li class="active"><a href="#hydrate" aria-controls="hydrate" role="tab" data-toggle="tab">Hydrate Shipment Analysis</a></li>
                            <li><a href="#wethydrate" aria-controls="wethydrate" role="tab" data-toggle="tab">Wet Hydrate Shipment Analysis</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <div role="tabpanel" class="tab-pane active" id="hydrate">
                                <div class="row clearfix">
                                    <%--<div style="margin-left: 20px"><asp:LinkButton ID="btnAdd"  runat="server" Text="Add Row" onclick="btnAdd_Click"></asp:LinkButton></div>--%>
                                   

                                    <div style="margin-left: 20px">TruckID &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Reflectance &nbsp&nbsp&nbsp  L-Soda</div>
                                    <div class="table-responsive" style="float: left; margin-left: 20px; margin-top: 20px; height: 400px; width: 360px; overflow-x: hidden; overflow-y: scroll">
                                        <asp:GridView ID="gvHydrate" runat="server" Height="16px" Width="250px"
                                            CssClass="table table-bordered table-hover"
                                            AutoGenerateColumns="False"
                                       
                                            EditRowStyle-Width="20px">
                                            <EditRowStyle CssClass="GridViewEditRow" />

                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="80">
                                                    <ItemTemplate>
                                                        <asp:TextBox Readonly="true"  ID ="txtbox_hydratedate" runat="server" Text='<%# Eval("SADATE", "{0:M-dd-yyyy}") %>' Width="80px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TruckID" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_hydrate_containerid"    runat="server" Text='<%# Eval("CONTAINERID") %>' Width="150px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reflectance" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_hydrate_ref" runat="server" Text='<%# Eval("REFLECTANCE") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="L-Soda" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_hydrate_lsoda" runat="server" Text='<%# Eval("LEACHSODA") %>' Width="70px"></asp:TextBox>
                                                    </ItemTemplate>
                              <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="txtbox_hydrate_id" runat="server" Value='<%# Eval("HYDRATE_ID") %>' />

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
                                </div>
                              
                            </div>

                            <div role="tabpanel" class="tab-pane" id="wethydrate">
                                <div class="row clearfix">
                                        <%--<div style="margin-left: 20px"><asp:LinkButton ID="LinkButton1"  runat="server" Text="Add Row" onclick="btnAdd_Click"></asp:LinkButton></div>--%>
                                   
                                    <div style="margin-left: 20px">TruckID &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                        &nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp   Reflectance &nbsp&nbsp&nbsp  L-Soda &nbsp&nbsp&nbsp Moisture</div>
                                    <div class="table-responsive" style="float: left; margin-left: 20px; margin-top: 20px; height: 200px; width: 390px; overflow-x: hidden; overflow-y: scroll">
                                        <asp:GridView ID="gvWetHydrate" runat="server" Height="16px" Width="250px"
                                            CssClass="table table-bordered table-hover"
                                            AutoGenerateColumns="False"
                                            EditRowStyle-Width="20px">
                                            <EditRowStyle CssClass="GridViewEditRow" />

                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_wethydratedate" runat="server" Text='<%# Eval("SADATE", "{0:M-dd-yyyy}") %>' Width="80px"></asp:TextBox>
                                                        
                                                    </ItemTemplate>

                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TruckID" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_wethydrate_containerid" runat="server" Text='<%# Eval("CONTAINERID") %>' Width="120px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reflectance" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_wethydrate_ref" runat="server" Text='<%# Eval("REFLECTANCE") %>' Width="70px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="L-Soda" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_wethydrate_lsoda" runat="server" Text='<%# Eval("LEACHSODA") %>' Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Moisture" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbox_wethydrate_moisture" runat="server" Text='<%# Eval("MOISTURE") %>' Width="50px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px"></ItemStyle>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="" ItemStyle-Width="1">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="txtbox_wethydrate_id" runat="server" Value='<%# Eval("HYDRATE_ID") %>' />

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
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
                         
                

     <%-- <input type="TEXT" runat="server" id="Hidden1" value="" />  --%>
        <input type="hidden" runat="server" id="role" value="" />  
<%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
     <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>

     <script>
         //$(function () {
            
         //    $(".autosuggest").autocomplete({
         //           source: function (request, response) {
         //               $.ajax({
         //                   url: "HydrateAnalysis.aspx/GetNames",
         //                   data: "{ 'pre':'" + request.term + "'}",
         //                   dataType: "json",
         //                   type: "POST",
         //                   contentType: "application/json; charset=utf-8",
         //                   success: function (data) {
         //                       response($.map(data.d, function (item) {
         //                           return { value: item }
         //                       }))
         //                   },
         //                   error: function (XMLHttpRequest, textStatus, errorThrown) {
         //                       alert(textStatus);
         //                   }
         //               });
         //           }
         //       });
         //   });


         function addInputs() {

             //(1)collection of all the inputs I want (not all the inputs on my form)
             $(":text").on("keydown", function () {//(2)When an input field detects a keydown event
                 //alert('key down');
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
             $.ajax({
                 type: "POST",
                 url: 'HydrateAnalysis.aspx/arrayData',
                 data: JSON.stringify({ hydrateArray: hydrateArray, wethydrateArray: wethydrateArray, date: date  }),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     
                     window.location.reload();

                 },
                 error: function (e) {

                 }
             });
      

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
         $('#datetimepicker').datepicker('setDate', date);
        $("#datetimepicker").datepicker().on('changeDate', function (e) {
            var selectedDate = $('#datetimepicker').datepicker("getDate");
           
     
                var data = $('#datetimepicker').datepicker("getDate");
                $.ajax({
                    type: "POST",
                    url: 'HydrateAnalysis.aspx/callCodeBehind',
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
