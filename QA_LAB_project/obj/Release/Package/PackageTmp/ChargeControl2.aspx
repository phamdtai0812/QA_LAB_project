<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChargeControl2.aspx.cs" Inherits="QA_LAB_project.ChargeControl2" %>
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
         .btn-secondary:hover 
         {border: 2px solid green;
          opacity: 0.9;
         }
      .form-control:hover{
         border: 2px solid green;
      }
      .ui-state-highlight {
    border: 1px solid #d3d3d3;
    background-color: #e6e6e6 
}
    </style>
    <br />
    <br />
    <div class="panel panel-default" style="width: 800px; margin:auto">
        <div class="panel-heading">
           <div>
    <p style="color:white">Charge Control Information -- <%= ccround_ %></p>
</div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker"  />
                       
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>

                      <div class="col-md-2">
                          <asp:DropDownList Style="width: 150px" ID="ddlCCROUND" runat="server" CssClass="form-control" EnableViewState ="true"  OnSelectedIndexChanged = "gvccontrol_OnSelectedIndexChanged" AutoPostBack="true" >
                               <asp:ListItem Text="Select Round" Value="0"></asp:ListItem>
                              <asp:ListItem Text="0300" Value="1"></asp:ListItem>
                              <asp:ListItem Text="0600" Value="2"></asp:ListItem>
                              <asp:ListItem Text="0900" Value="3"></asp:ListItem>
                               <asp:ListItem Text="1200" Value="4"></asp:ListItem>
                              <asp:ListItem Text="1500" Value="5"></asp:ListItem>
                              <asp:ListItem Text="1800" Value="6"></asp:ListItem>
                               <asp:ListItem Text="2100" Value="7"></asp:ListItem>
                              <asp:ListItem Text="2400" Value="8"></asp:ListItem>
                          </asp:DropDownList>
                    </div>

                <div class="col-md-2">
                    <asp:Button ID="btnSave" Text="Save" Style="width: 80px; margin-left: 150px" runat="server" class="btn btn-secondary" OnClientClick="return exFunction();"  OnClick="SaveButtonClick" />
                </div>
                <div class="col-md-2">

                </div>
                 <div class="col-md-2">
                      <asp:Button ID="btnSend" Text="Send Data to Pi"  Style="width: 120px;"  runat="server" class="btn btn-secondary"  OnClick="ResendDataToPi" ToolTip="Send Data to Pi" />
                </div>
               
               
            </div>
            
            
            <div class="row" style="margin-left: 3px">
                <div class="panel panel-default" style="width: 98%; padding: 10px;" id="panel1">

                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc; border-radius: 5px">
                            <asp:ListView ID="ListView1" runat="server"></asp:ListView>  
                         

                        
                                             <asp:GridView ID="gv_ccontrol" runat="server" Height="16px" Width="284px" EnableViewState ="true"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                 OnRowDataBound ="gv_ccontrol_OnRowDataBound"
                                                 EditRowStyle-Width="20px"
                                                style="border-radius: 10px"
                                                 >
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="Sample" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                            <asp:Label  ID="gv_ccontrol_s" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_caustic" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="60px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="A/C" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_ac" runat="server" Text='<%# Eval("b") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="C/S" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox  onchange="onChange(this.id);" ID="gv_ccontrol_cs" runat="server" Text='<%# Eval("c") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="AIM" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_aim" runat="server" Text='<%# Eval("AIM", "{0:.###}") %>' Width="50px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                                  <RowStyle BackColor="#DDDDDD" />
                                             </asp:GridView>
                        </div>
                         <div class="table-responsive" style="float: left; margin-left: 5px; background-color: #dcdcdc;  border-radius: 5px">
                          
                                             <asp:GridView ID="gv_soda" runat="server" Height="16px" Width="284px"
                                                 CssClass="table  table-bordered table-hover"
                                                 AutoGenerateColumns="False"
                                                 OnRowDataBound ="gv_soda_OnRowDataBound"
                                                 EditRowStyle-Width="20px">
                                                 <EditRowStyle CssClass="GridViewEditRow" />
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="Sample" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                            <asp:Label ID="gv_soda_s" runat="server" Text='<%# Eval("s") %>' Width="130px"></asp:Label>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Soda(Gpl)" ItemStyle-Width="50">
                                                         <ItemTemplate>
                                                             <asp:TextBox  onchange="onChange(this.id);" ID="gv_soda_gpl" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="60px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                    
                                                 </Columns>
                                                  <RowStyle BackColor="#DDDDDD" />
                                             </asp:GridView>
                        </div>
                        <div>
                              <asp:DropDownList Style="width: 150px" ID="ddlcolor" runat="server"  
                                  CssClass="form-control" EnableViewState ="false"  >
                               <asp:ListItem Text="- Select Color -" Value="0"></asp:ListItem>
                              <asp:ListItem Text="White" Value="1"></asp:ListItem>
                              <asp:ListItem Text="Tan" Value="2"></asp:ListItem>
                              <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                             </asp:DropDownList>

                        </div>
                    </div>

                    
                </div>
          </div>

             <%-- <div class="col-md-4">
                     
                </div>--%>
    </div>
</div>

     <input type="hidden" runat="server" id="role" value="" />  
<%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
    <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>

     <script>

     
         //var myArray;
         var myArray = [];
         var obj = {};
         function onChange(id) {
             for (var i = 0; i < myArray.length; i++) {
                 if (myArray[i][0] === id) {
                     //alert(document.getElementById(id).value);
                     if (document.getElementById(id).value != '') {
                         if (document.getElementById(id).value > 0) {
                             if (document.getElementById(id).value < myArray[i][1] || document.getElementById(id).value > myArray[i][2]) {
                                 var r = confirm("Value should be between " + myArray[i][1] + " and " + myArray[i][2] + "  Continue?");
                                 if (r == false) {
                                     //alert(arr[j].Tag_Name + " value is out of range.  Please correct.");
                                     //document.getElementById(arr[j].Tag_Name).focus();
                                     //document.getElementById(arr[j].Tag_Name).value = "";
                                     //document.getElementById(arr[j].Tag_Name).style.border = "solid 1px red";
                                     setTimeout(function () { document.getElementById(id).focus(); }, 100);
                                     document.getElementById(id).value = "";
                                    
                                     //document.getElementById(id).style.backgroundColor = "yellow";
                                     //x.addEventListener("focus", myFocusFunction, true);
                                     //x.addEventListener("blur", myBlurFunction, true);
                                   
                                     //function myFocusFunction() {
                                     //    document.getElementById(id).style.backgroundColor = "yellow";
                                         
                                     //}
                                     //function myBlurFunction() {
                                     //    document.getElementById(id).style.backgroundColor = "";
                                     //}
                                     return false;
                                 }
                             }
                         }
                         else {
                             alert('Invalid value')
                             setTimeout(function () { document.getElementById(id).focus(); }, 100);
                             document.getElementById(id).value = "";
                             return false;
                         }
                     }
                 }
             }
         }
     
        



         function validate(a) {
             for (var j = 0; j < arr.length; j++) {
                 if (a[j] !== '') {
                     if ((a[j] < arr[j].Min || a[j] > arr[j].Max) && (validatedArray.indexOf(arr[j].Tag_Name) < 0)) {
                         var r = confirm(arr[j].Tag_Name + " value should be between " + arr[j].Min + " and " + arr[j].Max + ".  Continue?");
                         if (r == false) {
                             //alert(arr[j].Tag_Name + " value is out of range.  Please correct.");
                             //document.getElementById(arr[j].Tag_Name).focus();
                             //document.getElementById(arr[j].Tag_Name).value = "";
                             //document.getElementById(arr[j].Tag_Name).style.border = "solid 1px red";
                             var x = document.getElementById(arr[j].Tag_Name);

                             x.focus();
                             x.addEventListener("focus", myFocusFunction, true);
                             x.addEventListener("blur", myBlurFunction, true);
                             x.value = "";
                             function myFocusFunction() {
                                 document.getElementById(arr[j].Tag_Name).style.backgroundColor = "yellow";
                             }
                             function myBlurFunction() {
                                 document.getElementById(arr[j].Tag_Name).style.backgroundColor = "";
                             }
                             return false;
                         }
                         validatedArray.push(arr[j].Tag_Name);
                     }
                 }

             }
             return true;
         };


         function exFunction() {
             var selectoption = document.getElementById("MainContent_ddlCCROUND");
             var optionText = selectoption.options[selectoption.selectedIndex].text;
             optionText = optionText.substring(0, optionText.length - 2);
             var time = new Date();
             ;
             //alert(optionText);
             //alert(time.getHours());
             var selDate = $('#datetimepicker').datepicker("getDate");
             //alert(time);
             //alert(selDate);
             if (optionText > time.getHours() && selDate.setHours(0,0,0,0) == time.setHours(0, 0, 0, 0))
             {
                 //alert('Time is in future.  Pi data WILL NOT be sent!');
             }

             return true;
         }
         $(document).ready(function () {




             var role = (document.getElementById('MainContent_role').value);
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSave').style.display = "none";
                  document.getElementById('MainContent_btnSend').style.display = "none";
             }
           
             $.ajax({
                 type: "POST",
                 url: "ChargeControl2.aspx/GetNames",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {
                     //alert("Success");
                     result = {};
                     if (myArray.length < 23)
                     {
                         // alert(data[i]);
                         for (var i = 0; i < response.d.length; i++) {
                             //alert(response.d[i].Gv_ControlName);
                             //obj["name"] = response.d[i].Gv_ControlName;
                             //obj["min"] = response.d[i].Min;
                             //obj["max"] = response.d[i].Max;
                             result = [response.d[i].Gv_ControlName, response.d[i].Min, response.d[i].Max];
                             myArray.push(result) ;

                         }
                     }
                 }
             });
             

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
         };


         $(function () {
             $("input[type=text]").keypress(function () {
                 if (event.keyCode == 13) {
                     event.preventDefault();
                     var allInputs = $(':text:visible');
                     var nextInput = allInputs.get(allInputs.index(this) + 1);//(3)The next input in my collection of all inputs
                     if (nextInput) {
                         nextInput.focus(); //(4)focus that next input if the input is not null
                     }
                 }

             });
         });



         $('#datetimepicker').datepicker({
             format: "mm/dd/yyyy",
             autoclose: true
         });

         var date = new Date(document.getElementById('MainContent_date_max').value);
         $('#datetimepicker').datepicker('setDate', date);

         var selectedRound = $('[id*=ddlCCROUND]').val();
         //alert(selectedRound);
         $("#datetimepicker").datepicker().on('changeDate', function (e) {
             var selectedDate = $('#datetimepicker').datepicker("getDate");
             var data = $('#datetimepicker').datepicker("getDate");
             $.ajax({
                 type: "POST",
                 url: 'ChargeControl2.aspx/callCodeBehind',
                 data: JSON.stringify({ selDate: selectedDate, selRound: selectedRound  }),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (msg) {
                     //window.location.reload();
                   

                 },
                 error: function (e) {

                 }
             });

         });



         function MyFunction()
         {

           <%--  var message = '<%=Session["message"]%>';
             if (message == "true") {--%>
                 alert('Time cannot be in future!');
             //}
                 

         }



         </script>

</asp:Content>
