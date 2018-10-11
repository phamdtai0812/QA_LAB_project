<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelDownloads.aspx.cs" Inherits="QA_LAB_project.ExcelDownloads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

     <script src="Scripts/jquery-3.1.0.js"></script>
  
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></scrip>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>




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
   background-color: #dcdcdc;
 }

        
    </style>

<%--    <div class="container-fluid main-container" style="margin-top: 2px">
        <div class="col-md-12 content col-xs-offset-2">--%>
    <br />
    <br />
  <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <p style="color:white">Downloads to Excel</p>
        </div>
        <div class="panel-body">
            <div class="row" >
                <div class="col-md-3">
                    From Date:
                    <div class="form-group">
                        <div class='input-group date'>

                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-md-1">
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        To Date:
                        <div class='input-group date'>

                            <input type='text' id="datetimepicker2" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker2" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>

                <%--  <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" class="btn btn-secondary" OnClick="SaveButtonClick" />
                </div>--%>
            </div>
            <div class="row">
                <div class="panel panel-default" style="width: 98%; padding: 10px; margin: 10px" id="panel1">
                    <br />
                    <div class="row" style="margin-left: 140px; padding-bottom: 10px">
                        
                   
                        <div class="col-md-4">
                   <%--          <input type="checkbox" name="cc" ID="CausticClean" value="1" class="chkbx">--%>
                            <asp:Button ID="btnCC" Text="Caustic Clean" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" OnClick="CausticClean_ExportToExcel"   />
                        </div>
                        <div class="col-md-1">
                        </div>
                           <div class="col-md-4">
                       <%--    <input type="checkbox" name="ha" value="2" ID="HydrateAnalysis" class="chkbx">--%>
                            <asp:Button ID="btnHydrateAnalysis" OnClick="Hydrate_ExportToExcel"  Text="Hydrate Analysis" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                    </div>
                    <div class="row" style="margin-left: 140px; padding-bottom: 10px">
                         <div class="col-md-4">
                      <%--    <input type="checkbox" name="ccon" value="3" ID="ChargeControl" class="chkbx">--%>
                            <asp:Button ID="btnChargeC"  OnClick="ChargeControl_ExportToExcel"  Text="Charge Control" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-4">
                     <%--     <input type="checkbox" name="kd" value="4" id="KilnDryer" class="chkbx">--%>
                            <asp:Button ID="btnKiln"  OnClick="KilnDryer_ExportToExcel" Text="Kiln Dryer" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                    </div>
                    <div class="row" style="margin-left: 140px; padding-bottom: 10px">
                        <div class="col-md-4">
             <%--               <input type="checkbox" name="da" value="5" id="DailyAnalysis" class="chkbx">--%>
                            <asp:Button ID="btnDaily" OnClick="Daily_ExportToExcel"   Text="Daily Analysis" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-4">
                 <%--         <input type="checkbox" name="mis" value="6" class="chkbx" id="Misc">--%>
                            <asp:Button ID="btnMisc" OnClick="Misc_ExportToExcel" Text="Miscellaneous" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                    </div>
                    <div class="row" style="margin-left: 140px; padding-bottom: 10px">
                        <div class="col-md-4">
                       <%--   <input type="checkbox" name="env" value="7" class="chkbx" id="Environmental">--%>
                            <asp:Button ID="btnEnv" OnClick="Env_ExportToExcel" Text="Environmental" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-4">
                           <%-- <input type="checkbox" name="h" value="8" class="chkbx" id="Sec1_2">--%>
                            <asp:Button ID="btnSec1"  OnClick="Sec1_ExportToExcel" Text="Section I/II" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                    </div>
                    <div class="row" style="margin-left: 140px; padding-bottom: 20px">
                        <div class="col-md-4">
                         <%--   <input type="checkbox" name="h" value="9" class="chkbx" id="H2O">--%>
                            <asp:Button ID="btnH2O"  OnClick="H2O_ExportToExcel"  Text="H2O Tank" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-4">
                    <%--        <input type="checkbox" name="h" value="10" class="chkbx" id="Sec3">--%>
                            <asp:Button ID="btnSec3" OnClick="Sec3_ExportToExcel"  Text="Section III" Style="width: 160px;" runat="server" class="btn btn-outline-secondary" />
                        </div>
                    </div>

                    <div class="row" style="margin-left: 155px; padding-bottom: 10px">
                     <%--   <div class="col-md-3">
                           <asp:Button ID="Button1" OnClick="H2O_ExportToExcel" id='custom_button' Text="Download Selected" Style="width: 140px;" runat="server" class="btn btn-outline-secondary" />
                        </div>--%>
                     
                        <div class="col-md-4">
                          <%--    <asp:Button class="btn btn-outline-secondary" ID="Button1" runat="server" Font-Bold="False" OnClientClick="GetSelected();"  Text="Download Selected" />--%>
<%--                            <input class="btn btn-outline-secondary" type="button" name="chkbxall" value="Download Selected Reports" id='custom_button' OnClientClick="GetSelected();" />--%>
                        </div>
                        <div class="col-md-2">
<%--                           <asp:Button class="btn btn-outline-secondary" ID="Button2" runat="server" Font-Bold="False" OnClientClick="GetAll();"  Text="Download All" />--%>
                          </div>
                    </div>







                </div>
            </div>
        </div>
    </div>
   

     <%--   <input type="hidden" runat="server" id="role" value="" />  
=
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
     <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>--%>

     <script>
         jQuery('#custom_button').click(function () {
             jQuery('.chkbx').each(function () { //loop through each checkbox
                 this.checked = true; //deselect all checkboxes with class "checkbox1"                       
             });
      <%--       var name = document.getElementById('<%=txtname.ClientID %>').value;
             var address = document.getElementById('<%=txtaddress.ClientID %>').value;--%>
             //var name = "tai";
             //var address = "1234 address";
             //$.ajax({
             //    type: "POST",
             //    url: 'ExcelDownloads.aspx/GetAll',
             //    data: JSON.stringify({ name: name }),
             //    contentType: "application/json; charset=utf-8",
             //    dataType: "json",
             //});
             return true
         });
         function GetSelected() {

             //jQuery('.chkbx').each(function () { //loop through each checkbox
             //    this.checked = true; //deselect all checkboxes with class "checkbox1"                       
             //});


             var checkedBoxes = document.querySelectorAll('input[type=checkbox]:checked');
             var listReport = [];
             for (var i = 0; i < checkedBoxes.length; i++) {
                 // And stick the checked ones onto an array...
                 //if (checkedBoxes[i].checked) {
                 listReport.push(checkedBoxes[i].id);
                 //}
             };

             var fromDate = $('#datetimepicker').datepicker("getDate");
             var toDate = $('#datetimepicker2').datepicker("getDate");
            

             //listReport.push(1);
             //listReport.push(2);
             //listReport.push(3);
             //listReport.push(4);
             $.ajax({
                 type: "POST",
                 url: 'ExcelDownloads.aspx/GetSelected',
                 data: JSON.stringify({ fromDate: fromDate, toDate: toDate, reportName: listReport}),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     window.location.reload();

                 },
                 error: function (e) {

                 }
             });

         }
         function GetAll() {
   
             jQuery('.chkbx').each(function () { //loop through each checkbox
                 this.checked = true; //deselect all checkboxes with class "checkbox1"                       
             });
             var fromDate = $('#datetimepicker').datepicker("getDate");
             var toDate = $('#datetimepicker2').datepicker("getDate");
             $.ajax({
                 type: "POST",
                 url: 'ExcelDownloads.aspx/GetAll',
                 data: JSON.stringify({ fromDate: fromDate, toDate: toDate }),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     window.location.reload();

                 },
                 error: function (e) {

                 }
             });

         }
      
         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

         $('#datetimepicker2').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

         //var date = new Date(document.getElementById('MainContent_date_max').value);
         var date = new Date();
         
         $('#datetimepicker').datepicker('setDate', date);
         $('#datetimepicker2').datepicker('setDate', date);


         //$("#datetimepicker").datepicker().on('changeDate', function (e) {
         //    var selectedDate = $('#datetimepicker').datepicker("getDate");

           
         //        var data = $('#datetimepicker').datepicker("getDate");
         //        $.ajax({
         //            type: "POST",
         //            url: 'Sec_III.aspx/callCodeBehind',
         //            data: JSON.stringify({ selDate: selectedDate }),
         //            contentType: "application/json; charset=utf-8",
         //            dataType: "json",
         //            success: function (msg) {
         //                window.location.reload();

         //            },
         //            error: function (e) {

         //            }
         //        });

         //    //}

         //});
 
         </script>

</asp:Content>
