<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvironmentalAnalysis.aspx.cs" Inherits="QA_LAB_project.EnvironmentalAnalysis" %>
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
        
    </style>
    <br />
    <br />
 <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <p style="color: white">Environmental Analysis</p>
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
            
            <div class="row" style="margin: 0px">
                <div class="panel panel-default" style="width: 98%; padding: 10px;" id="panel1">

                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                            pH Analysis
                                             <asp:GridView ID="gv_pha" runat="server" Height="16px" Width="284px"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                 EditRowStyle-Width="20px">
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>

                                                     <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:label ID="gv_pha_name" runat="server" Text='<%# Eval("name") %>' Width="50px"></asp:label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="River Water Return">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_rwrph" runat="server" Text='<%# Eval("rwrph") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>

                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="East Ditch">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_edph" runat="server" Text='<%# Eval("edph") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="West Ditch">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_wdph" runat="server" Text='<%# Eval("wdph") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="Far East Ditch">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_fedph" runat="server" Text='<%# Eval("fedph") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="Cane Field Ditch">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_cdph" runat="server" Text='<%# Eval("cdph") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="OxPond">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="gv_pha_oxpph" runat="server" Text='<%# Eval("oxpond") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>

                                                 </Columns>
                                             </asp:GridView>
                        </div>
                    </div>

                    <div class="row clearfix" style="padding-bottom: 5px">

                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                            Sewers & Dams
                                                <asp:GridView ID="gv_sad" runat="server" Height="16px" Width="284px"
                                                    CssClass="table  table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelph" runat="server" Text='pH'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No.1" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sad_sph1" runat="server" Text='<%# Eval("SEWERPH1") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="No.2">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sad_sph2" runat="server" Text='<%# Eval("SEWERPH2") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="No.3">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sad_sph3" runat="server" Text='<%# Eval("SEWERPH3") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="No.5">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sad_sph5" runat="server" Text='<%# Eval("SEWERPH5") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="No.1 Dam">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sad_dam1" runat="server" Text='<%# Eval("DAMPH1") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                        </div>




                        <div class="table-responsive" style="float: left; margin-left: 5px; background-color: #dcdcdc">
                            Soda Analysis
                                                <asp:GridView ID="gv_soda" runat="server" Height="16px" Width="284px"
                                                    CssClass="table  table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Hot Well" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_htw" runat="server" Text='<%# Eval("SAHOTWELL") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Plant Drain">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_plant" runat="server" Text='<%# Eval("SAPLANTDRAIN") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Lift Station">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_lift" runat="server" Text='<%# Eval("SALIFTSTATION") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Surge Basin">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_surge" runat="server" Text='<%# Eval("SASURGEBASIN") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                        </div>
                    </div>

                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                            P205/Caustic Analysis
                                                <asp:GridView ID="gv_p205" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>

                                                                <asp:Label ID="txtbox_p205_name" runat="server" Text='<%# Eval("name") %>' Width="80px"></asp:Label>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_p205_data" runat="server" Text='<%# Eval("data") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 5px; background-color: #dcdcdc">
                            ABS/Caustic Analysis
                                                <asp:GridView ID="gv_abs" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtbox_abs_name" runat="server" Text='<%# Eval("name") %>' Width="70px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_abs_data" runat="server" Text='<%# Eval("data") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                        </div>
                    </div>
                   
                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc">
                            Silica/Caustic Analysis
                                                <asp:GridView ID="gv_silica" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Test Tank" ItemStyle-Width="70">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_scatt" runat="server" Text='<%# Eval("SCATESTTANK") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="No. 4 FT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_sca4ft" runat="server" Text='<%# Eval("SCA4FT") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="90" HeaderText="Settler Feed">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_scasf" runat="server" Text='<%# Eval("SCASETTLERFD") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="LTP">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_scaltp" runat="server" Text='<%# Eval("SCALTP") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; margin-left: 5px; background-color: #dcdcdc">
                            Floc Analysis
                            
                                                <asp:GridView ID="gv_floc" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>
                                                        
                                                        <asp:TemplateField HeaderText="Settler" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                 <br />
                                                                <asp:TextBox ID="txtbox_floc_settler" runat="server" Text='<%# Eval("FASETTLER") %>' Width="50px"></asp:TextBox>
                                                            
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Washer">
                                                            <ItemTemplate>
                                                                 <br />
                                                                <asp:TextBox ID="txtbox_floc_washer" runat="server" Text='<%# Eval("FAWASHER") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="Middle">
                                                            <ItemTemplate>
                                                                <br />
                                                                <asp:TextBox ID="txtbox_floc_middle" runat="server" Text='<%# Eval("FAMIDDLE") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
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
                 url: 'EnvironmentalAnalysis.aspx/callCodeBehind',
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
