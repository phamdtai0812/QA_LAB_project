<%@ Page Title=" Kiln Dryer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KilnDryer.aspx.cs" Inherits="QA_LAB_project.KilnDryer"
    EnableEventValidation="false" %>
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
    <br />
   
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
   <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <p style="color:white">Kiln Dryer Analysis</p>
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
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 300px" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                    <%--OnClick="SaveButtonClick"--%>
                </div>
            </div>
            <div class="row" style="margin-left: 3px">
                <div class="panel panel-default" style="width: 98%;" id="panel1">
                    <div class="panel-body">
                        <div class="col-md-6">

                            <div class="row" style="margin-left: 10px;">
                                <div class="row clearfix">
                                    <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                        Kiln Feed Leach Soda
                                             <asp:GridView ID="gv_kfls" runat="server" Height="16px" Width="284px"
                                                 CssClass="table  table-bordered table-hover"
                                                 OnRowDataBound="gv_kfls_OnRowDataBound"
                                                 AutoGenerateColumns="False"
                                                 OnRowEditing="OnRowEditing"
                                                 EditRowStyle-Width="20px">
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>


                                                     <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:Label ID="labelkfls" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                         </ItemTemplate>

                                                     </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtbox_kfls1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>

                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtbox_kfls2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>

                                                     </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtbox_kfls3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                             </asp:GridView>
                                    </div>
                                </div>
                                <div class="row clearfix" style="padding-top: 10px">
                                    <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                        Kiln Discharge L.O.I.
                                                <asp:GridView ID="gv_kdloi" runat="server" Height="16px" Width="284px"
                                                    CssClass="table  table-bordered table-hover"
                                                    OnRowDataBound="gv_kdloi_OnRowDataBound"
                                                    AutoGenerateColumns="False"
                                                    OnRowEditing="OnRowEditing"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelkdloi" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtbox_kdloi1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdloi2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdloi3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                    </div>
                                </div>
                                <div class="row clearfix" style="padding-top: 10px">
                                    <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                        Kiln Discharge Na.
                                                <asp:GridView ID="gv_kdna" runat="server" Height="16px" Width="284px"
                                                    CssClass="table  table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    OnRowDataBound="gv_kdna_OnRowDataBound"
                                                    OnRowEditing="OnRowEditing"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />
                                                    <%--OnRowDataBound="OnRowDataBound"--%>
                                                    <%--   OnRowEditing="OnRowEditing"--%>
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelkdna" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtbox_kdna1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdna2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdna3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                    </div>
                                </div>
                                <div class="row clearfix" style="padding-top: 10px">
                                    <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                        Kiln Discharge Ca.
                                                <asp:GridView ID="gv_kdca" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    AutoGenerateColumns="False"
                                                    OnRowDataBound="gv_kdca_OnRowDataBound"
                                                    OnRowEditing="OnRowEditing"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />

                                                    <Columns>


                                                        <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelkdca" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtbox_kdca1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdca2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdca3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                    </div>
                                </div>
                                <div class="row clearfix" style="padding-top: 10px">
                                    <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                        Kiln Discharge Zn.
                                                <asp:GridView ID="gv_kdzn" runat="server" Height="16px" Width="284px"
                                                    CssClass="table table-bordered table-hover"
                                                    OnRowEditing="OnRowEditing"
                                                    AutoGenerateColumns="False"
                                                    OnRowDataBound="gv_kdzn_OnRowDataBound"
                                                    EditRowStyle-Width="20px">
                                                    <EditRowStyle CssClass="GridViewEditRow" />

                                                    <Columns>


                                                        <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblkdzn" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                                            <ItemTemplate>

                                                                <asp:TextBox ID="txtbox_kdzn1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdzn2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtbox_kdzn3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-6">


                            <div class="row clearfix">
                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                    Hydrate Dryer
                                           <asp:GridView ID="gv_hydryer" runat="server" Height="16px" Width="284px"
                                               CssClass="table  table-bordered table-hover"
                                               OnRowEditing="OnRowEditing"
                                               AutoGenerateColumns="False"
                                               OnRowDataBound="gv_hydryer_OnRowDataBound"
                                               EditRowStyle-Width="20px">
                                               <EditRowStyle CssClass="GridViewEditRow" />

                                               <Columns>


                                                   <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                       <ItemTemplate>
                                                           <asp:Label ID="lblhydratedryer" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="L-Soda" ItemStyle-Width="50">
                                                       <ItemTemplate>
                                                           <asp:TextBox ID="txtbox_lsoda" runat="server" Text='<%# Eval("L-Soda") %>' Width="50px"></asp:TextBox>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                                   <asp:TemplateField ItemStyle-Width="50" HeaderText="Reflect">
                                                       <ItemTemplate>
                                                           <asp:TextBox ID="txtbox_reflect" runat="server" Text='<%# Eval("Reflect") %>' Width="50px"></asp:TextBox>

                                                       </ItemTemplate>

                                                   </asp:TemplateField>

                                               </Columns>
                                           </asp:GridView>
                                </div>
                            </div>
                       <div class="row clearfix">
                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                  Dryer #5
                                           <asp:GridView ID="gv_dryer5" runat="server" Height="16px" Width="180px"
                                               CssClass="table  table-bordered table-hover"
                                               OnRowEditing="OnRowEditing"
                                               AutoGenerateColumns="False"
                                               
                                               EditRowStyle-Width="20px">
                                               <EditRowStyle CssClass="GridViewEditRow" />

                                               <Columns>


                                                   <asp:TemplateField HeaderText="Time" ItemStyle-Width="50">
                                                       <ItemTemplate>
                                                           <asp:Label ID="lbldryer5" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="L-Soda" ItemStyle-Width="50">
                                                       <ItemTemplate>
                                                           <asp:TextBox ID="txtbox_dryer5ls" runat="server" Text='<%# Eval("L-Soda") %>' Width="50px"></asp:TextBox>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               

                                               </Columns>
                                           </asp:GridView>
                                </div>
                            </div>
                            <div class="row clearfix" style="padding-top: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                    Dryer Feed 
                                        <br />
                                    &nbsp Moisture &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Kiln Feed Moisture
                        <asp:GridView ID="gv_dryerfm" runat="server" Height="16px" Width="284px"
                            CssClass="table  table-bordered table-hover"
                            OnRowEditing="OnRowEditing"
                            AutoGenerateColumns="False"
                            OnRowDataBound="gv_dryerfm_OnRowDataBound"
                            EditRowStyle-Width="20px">
                            <EditRowStyle CssClass="GridViewEditRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="-" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbox_dryerfm1" runat="server" Text='<%# Eval("-") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="-1-" ItemStyle-Width="50">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtbox_kilnfm1" runat="server" Text='<%# Eval("-1-") %>' Width="50px"></asp:TextBox>

                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="50" HeaderText="-2-">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbox_kilnfm2" runat="server" Text='<%# Eval("-2-") %>' Width="50px"></asp:TextBox>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="50" HeaderText="-3-">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbox_kilnfm3" runat="server" Text='<%# Eval("-3-") %>' Width="50px"></asp:TextBox>

                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                                </div>
                            </div>

                            <div class="row clearfix" style="padding-top: 10px">
                                <div class="table-responsive" style="float: left; margin-left: 5px; padding-right: 10px;">
                                    Sec III Process Samples Metals Analysis
                         <asp:GridView ID="gv_psma" runat="server" Height="16px" Width="284px"
                             CssClass="table  table-bordered table-hover"
                             OnRowEditing="OnRowEditing"
                             AutoGenerateColumns="False"
                             OnRowDataBound="gv_psma_OnRowDataBound"
                             EditRowStyle-Width="20px">
                             <EditRowStyle CssClass="GridViewEditRow" />
                             <%-- OnRowDataBound="OnRowDataBound"--%>
                             <%--  OnRowEditing="OnRowEditing"--%>
                             <Columns>


                                 <asp:TemplateField ItemStyle-Width="50">
                                     <ItemTemplate>
                                         <asp:Label ID="lblpsma" runat="server" Text='<%# Eval("-") %>'></asp:Label>
                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="-Na-" ItemStyle-Width="30">
                                     <ItemTemplate>

                                         <asp:TextBox ID="txtbox_psmana" runat="server" Text='<%# Eval("Na") %>' Width="50px"></asp:TextBox>

                                     </ItemTemplate>

                                 </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="50" HeaderText="-Ca-">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtbox_psmaca" runat="server" Text='<%# Eval("Ca") %>' Width="50px"></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="50" HeaderText="-Zn-">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtbox_psmazn" runat="server" Text='<%# Eval("Zn") %>' Width="50px"></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="50" HeaderText="-CaO-">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtbox_psmacao" runat="server" Text='<%# Eval("CaO") %>' Width="50px"></asp:TextBox>
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

        </div>

    </div>

<input type="hidden" runat="server" id="role" value="" />  
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
   
             var date = $('#datetimepicker').datepicker("getDate");
             //$.ajax({
             //    type: "POST",
             //    url: 'HydrateAnalysis.aspx/arrayData',
             //    data: JSON.stringify({ hydrateArray: hydrateArray, wethydrateArray: wethydrateArray, date: date  }),
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


            //document.getElementById("panel2").style.display = "none";
            document.getElementById("panel1").style.display = "block";
            //document.getElementById("MainContent_btnSave").style.display = "none";

            $('#date').datepicker({
                format: "mm/dd/yyyy",
                autoclose: true
            });
         });
       
        $('#datetimepicker').datepicker({
            format: "mm/dd/yyyy",
            autoclose: true
        });
      
         //document.getElementById('MainContent_date_max').value = $('#datetimepicker').datepicker("getDate");
         //alert('date= ' + document.getElementById('MainContent_date_max').value);

         //alert(document.getElementById('MainContent_date_max').value);
         var date = new Date(document.getElementById('MainContent_date_max').value);
         //alert(date);
         $('#datetimepicker').datepicker('setDate', date);
        $("#datetimepicker").datepicker().on('changeDate', function (e) {
            var selectedDate = $('#datetimepicker').datepicker("getDate");
            //if (selectedDate > date)
            //{
                //alert('selectedDate > date');

                //document.getElementById("panel_gvhydrate").style.display = "none";
                //document.getElementById("panel_gvhwethydrate").style.display = "none";
                //document.getElementById("panel_hydrate_add").style.display = "block";
                //document.getElementById("panel_wethydrate_add").style.display = "block";
                //document.getElementById("MainContent_btnSave").style.display = "block";
                //document.getElementById('dateSave').value = $('#datetimepicker').datepicker("getDate");
            //}
            //else {

                //alert('selected < date');
            //    document.getElementById("panel1").style.display = "block";
           //   document.getElementById("panel2").style.display = "none";
                var dt_ = $('#datetimepicker').datepicker("getDate");
                $.ajax({
                    type: "POST",
                    url: 'kilndryer.aspx/callCodeBehind',
                    data: JSON.stringify({ selDate: dt_ }),
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
