<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HouseKeeping.aspx.cs" Inherits="QA_LAB_project.HouseKeeping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

     <script src="Scripts/jquery-3.1.0.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>


    <script src="https://files.codepedia.info/files/uploads/iScripts/html2canvas.js"></script>

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
         .btn-secondary:hover 
         {border: 2px solid green;
          opacity: 0.9;
         }
      .form-control:hover{
         border: 2px solid green;
      }
 
        .wide {
     width:100%;
     min-width:100%;
  }

        a.btn {
  -webkit-appearance: button;
  -moz-appearance: button;
 
}
    </style>
    <br />
   

<%--     <div id="html-content-holder" style="width: 1280px;  padding-left: 25px; padding-top: 10px;">--%>
    <div class="panel panel-default" style="width: 800px;  margin: auto" id="panel1" runat="server" >
        <div class="panel-heading">
            <div>
                <p style="color:white">Housekeeping Checklist</p>
            </div>
          
        </div>
        <div class="panel-body" style="border:  solid;  margin: 10px">
            <div class="row">
                <div class="col-md-1">
                    Date:
                </div>
                <div class="col-md-2">
                    <div class="form-group" style="width: 150px">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker" />
                            <span class="input-group-addon"></span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    Tech:
                </div>
                <div class="col-md-2">
                    <asp:DropDownList Style="width: 150px" ID="ddlTech" runat="server" CssClass="form-control" EnableViewState="true" >
                     <%--    OnSelectedIndexChanged = "tech_OnSelectedIndexChanged" Autopostback="true" >--%>
                        <asp:ListItem Text="- - Technician - -" Value="0"></asp:ListItem>
                     
                   
                        <asp:ListItem Text="Brent" Value="4"></asp:ListItem>
                           
                           <asp:ListItem Text="Daniel" Value="1"></asp:ListItem>

                        <asp:ListItem Text="Gene" Value="5"></asp:ListItem>
                             <asp:ListItem Text="Joe" Value="2"></asp:ListItem>
             
                        <asp:ListItem Text="Lavater" Value="6"></asp:ListItem>
                                   <asp:ListItem Text="Patrick" Value="3"></asp:ListItem>
                           <asp:ListItem Text="Raleigh" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Todd" Value="7"></asp:ListItem>
                  
                      
                      

                    </asp:DropDownList>
                </div>
            </div>
          <br />
            <div class="row">
                <div class="col-md-1">
                    Shift:
                </div>
                <div class="col-md-2">
                    <asp:DropDownList Style="width: 150px" ID="ddlShift" runat="server" CssClass="form-control" EnableViewState ="true" 
                        onchange="myFunction();" OnSelectedIndexChanged = "shift_OnSelectedIndexChanged" Autopostback="true">
                     <%--   OnSelectedIndexChanged = "shift_OnSelectedIndexChanged" Autopostback="true" >--%>
                        <asp:ListItem Text="- - Shift - -" Value="0"></asp:ListItem>
                        <asp:ListItem Text="AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="2"></asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>
             <br />
      
          
            
            <div class="row" style="margin-left: 5px">
            <div class="row">
                <div class="col-md-9">
                </div>
              <div class="col-md-1">
                    1
                </div>
                <div class="col-md-1">
                    2
                </div>
                
            </div>
                <div class="row">
                    <div class="col-md-9">
                        Lab Sump pump area has been checked to ensure there is no pump overflow?
                    </div>

                    <div class="col-md-1">
                        <asp:CheckBox ID="CheckBoxSumpPump1" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <asp:CheckBox ID="CheckBoxSumpPump2" runat="server" />
                    </div>


                </div>
                <br />
            <div class="row">
                <div class="col-md-9">
                    All benchtop areas in your section have been wiped down and free of clutter?
                </div>

                <div class="col-md-1">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>

              
            </div>
            <br />
            <div class="row">
                <div class="col-md-9">
                    All trash and extraneous product have been swept up and discarded in your areas?
                </div>

                <div class="col-md-1">
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                </div>

                
            </div>
            <br />
            <div class="row">
                <div class="col-md-9">
                    Daily MSHA worksheet has been filled out?
                </div>

                <div class="col-md-1">
                    <asp:CheckBox ID="CheckBox5" runat="server" />
                </div>

              
            </div>
            <br />
            <div class="row">
                <div class="col-md-9">
                    Missing Lab Samples Worksheet  has been filled out and emailed to QA Lab Manager?
                </div>

                <div class="col-md-1">
                    <asp:CheckBox ID="CheckBox7" runat="server" />
                </div>

             
            </div>
            <br />
            <div class="row">
                <div class="col-md-9">
                    All samples have been properly discarded and retains have been properly stored?
                </div>

                <div class="col-md-1">
                    <asp:CheckBox ID="CheckBox9" runat="server" />
                </div>

               
            </div>
            <br />
                <div class="row">
                    <div class="col-md-9">
                        All emails have been checked and read?
                    </div>

                    <div class="col-md-1">
                        <asp:CheckBox ID="CheckBox10" runat="server" />
                    </div>


                </div>
            <br />
               <%--    <div class="row">
                    <div class="col-md-9">
                        Communication on missing samples has been established to QA Lab Manager and unit Ops?
                    </div>

                    <div class="col-md-1">
                        <asp:CheckBox ID="CheckBox11" runat="server" />
                    </div>


                </div>
            <br />--%>
            <div class="row">
                <div class="col-md-9">
                    Any equipment out of service?  If so please list.
                </div>

            </div>
            <div class="row">
                <div class="col-md-9">
                    <asp:TextBox ID="TextBox1" TextMode="multiline"  CssClass="wide" Rows="3" runat="server" />
                </div>

            </div>
            <br />
            <div class="row">
                <div class="col-md-9">
                    Any OOS samples or any routine sample data not entered?  Please list.
                </div>

            </div>
            <div class="row">
                <div class="col-md-9">
                    <asp:TextBox ID="TextBox2" TextMode="multiline"  CssClass="wide" Rows="3" runat="server" />
                </div>
            </div>
            <br />
                <div class="row" style="margin-left: 200px">
                    <div class="col-md-3">
                        <asp:Button ID="btnSave" Text="Save" runat="server" Style="width: 80px"
                            class="btn btn-secondary" OnClick="btnSubmit_Click" />
                    </div>

                     <%-- <div> <a id="btn-Convert-Html2Image" href="#">Email</a></div>--%>

                <%--    <div class="col-md-3">
                        <asp:Button ID="Button2" runat="server" Text="Call Button Click" OnClick="Button2_Click" />
                    </div>--%>
                   <%-- <div>
                        <div class="col-md-2">
                            <a id="btnSaveImage2" class="btn" >Send</a>
                        </div>
                    </div>--%>
                </div>

            </div>
        </div>
    
   
         
        </div>

           
<br />



     <input type="hidden" runat="server" id="role" value="" />  
<%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
    
     <input type="hidden" id="shift" name="shift" value="" runat="server"/>
    <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>


    <%--</div>--%>
 <%--   <input id="btn-Preview-Image" type="button" value="Preview" />--%>
     

    <div id="previewImage" style="margin: 900px" >


    </div>
    
 
     <script>

         var element = $("#html-content-holder"); // global variable
         var getCanvas; // global variable

      //$("#btn-Preview-Image").on('click', function () {
         //html2canvas(element, {
         //onrendered: function (canvas) {
         //       $("#previewImage").append(canvas);
         //       getCanvas = canvas;
         //    }
         //});
         //});
         

    //     $("#btnSaveImage").on('click', function () {
    //var imgageData = getCanvas.toDataURL("image/png");
    //// Now browser starts downloading it instead of just showing it
    //var newData = imgageData.replace(/^data:image\/png/, "data:application/octet-stream");
    //$("#btnSaveImage").attr("download", "your_pic_name.png").attr("href", newData);
    //     });

         $("#btnSaveImage2").on('click', function () {

             getdata();
          

             //else {

             //    var imgageData = getCanvas.toDataURL("image/png");
             //    // Now browser starts downloading it instead of just showing it
             //    var newData = imgageData.replace(/^data:image\/png/, "data:application/octet-stream");
             //    $("#btnSaveImage2").attr("download", "HKchecklist.png").attr("href", newData);

             //}
            // 
            //$.ajax({
            //    type : 'post',
             
            //    url: ' HouseKeeping.aspx/Button2_Click',
            //    success : function(data){
            //        console.log('Data returned fron the server : ' + data);
            //    }
            //});
         
             download();
         });

        
         function download() {

               document.getElementById('MainContent_Button2').click();
         }
       
         function getdata() {

                if (getCanvas.msToBlob) { //for IE
                 var blob = getCanvas.msToBlob();
                 window.navigator.msSaveBlob(blob, 'HKchecklist.png', true);
                 //var newData = imgageData.replace(/^data:image\/png/, "data:application/octet-stream");
                // $("#btnSaveImage2").attr("download", "HKchecklist.png").attr("href");

                    window.navigator.close();
             }
         }

         function preview() {
               html2canvas(element, {onrendered: function (canvas) {
                $("#previewImage").append(canvas);
                getCanvas = canvas;
               }
             });


 
         }


    //     var link = document.createElement('a');
    //link.setAttribute('download', 'test.png');
    //link.setAttribute('href', canvas.toDataURL("image/png").replace("image/png", "image/octet-stream"));
    //document.body.appendChild(link);
    //link.click();
    //document.body.removeChild(link);
 

    var role = (document.getElementById('MainContent_role').value);
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSave').style.display = "none";
             }


         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

      
         //if (document.getElementById('MainContent_date_max').value = " ") {
         //    var date = new Date();
         //}
         //else {
         //    var date = new Date(document.getElementById('MainContent_date_max').value);
         //}

          var date = new Date(document.getElementById('MainContent_date_max').value);
         $('#datetimepicker').datepicker('setDate', date);

         
         

             
            
            
          
           
         function myFunction() {

           
              var selectedDate = $('#datetimepicker').datepicker("getDate");
             
             var selectedShift = $('[id*=ddlShift] option:selected').text();

              var today = new Date((new Date().setHours(0, 0, 0, 0)));
             //if (selectedDate < today)
             {
                 $.ajax({
                     type: "POST",
                     url: 'HouseKeeping.aspx/callCodeBehind',
                     data: JSON.stringify({ hkDate: selectedDate, hkShift: selectedShift }),
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (msg) {
                         //window.location.reload();


                     },
                     error: function (e) {

                     }
                 });
                 //location.reload();
             }


         }




         </script>

</asp:Content>

