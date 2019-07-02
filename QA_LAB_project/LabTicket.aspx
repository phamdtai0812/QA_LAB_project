<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="LabTicket.aspx.cs" Inherits="QA_LAB_project.LabTicket" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

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
 

    </style>
    <br />
  
    <div class="panel panel-default" style="width: 800px; margin: auto" id="panel1" runat="server">
        <div class="panel-heading">
            <div>
                <p style="color:white">Lab Ticket</p>
            </div>
          
        </div>
        <div class="panel-body">
            <div class="row">

                <div class="col-md-3">
                    <div class="form-group">
                        <div class='input-group date'>
                            <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker" />
                            <span class="input-group-addon">
                                <%-- <span class="glyphicon glyphicon-calendar" ></span>--%>
                            </span>
                        </div>
                    </div>
                </div>
             
                <div class="col-md-2">
                    <asp:DropDownList Style="width: 150px" ID="ddlCCROUND" runat="server" CssClass="form-control" EnableViewState="true" OnSelectedIndexChanged="gvccontrol_OnSelectedIndexChanged" AutoPostBack="true">
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
                   <%--<asp:Button ID="btnSendEmail" Text="Email as Pdf" Style="width: 120px; margin-left: 150px" runat="server"
                       class="btn btn-secondary"  OnClick="SendPDF_Click" />--%>
                </div>
            </div>
       
            <div class="row" style="margin-left: 3px">
                    <div class="row clearfix">
                        <div class="table-responsive" style="float: left; margin-left: 20px; width: auto" >
                            <asp:GridView ID="gv_labticket1" runat="server" EnableViewState="true"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Style="border-radius: 10px"
                                Font-Size="Small" CellSpacing="0">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_labticket1_s" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_labticket1_a" runat="server" Text='<%# Eval("a", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="table-responsive" style="float: left; width: auto">
                            <asp:GridView ID="gv_labticket2" runat="server" Height="16px" EnableViewState="true"
                             
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Style="border-radius: 10px"
                                OnRowDataBound ="gv_mhdliquor_OnRowDataBound"
                                Font-Size="Small">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_labticket_s" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_labticket2_" runat="server" Text='<%# Eval("a", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; width: auto">
                            <asp:GridView ID="gv_labticket3" runat="server"  EnableViewState="true"
                             
                                AutoGenerateColumns="False"
                                OnRowDataBound="gv_ccontrol_OnRowDataBound"
                                EditRowStyle-Width="20px"
                                Style="border-radius: 10px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="GridViewEditRow" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Sample" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_ccontrol_s" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_caustic" runat="server" Text='<%# Eval("a", "{0:.#}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="A/C" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_ac" runat="server" Text='<%# Eval("b") %>' Width="55px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C/S" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_ccontrol_cs" runat="server" Text='<%# Eval("c") %>' Width="55px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </div>
                        <div class="table-responsive" style="float: left; width: auto">

                            <asp:GridView ID="gv_labticket4" runat="server" Height="16px"
                                AutoGenerateColumns="False"
                                OnRowDataBound="gv_soda_OnRowDataBound"
                                EditRowStyle-Width="20px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="GridViewEditRow" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_soda_s" runat="server" Text='<%# Eval("s") %>' Width="162px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_soda_gpl" runat="server" Text='<%# Eval("a", "{0:0.#}") %>' Width="60px"  ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <asp:GridView ID="gv_labticket5" runat="server" Height="16px"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="gv_labticket5" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_soda_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LOI" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_soda1" runat="server" Text='<%# Eval("a", "{0:0.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leach." ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_soda2" runat="server" Text='<%# Eval("b", "{0:0.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                            <asp:GridView ID="gv_labticket6" runat="server" 
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="gv_labticket6" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_soda_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Refl." ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt6" runat="server" Text='<%# Eval("a", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leach." ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt7" runat="server" Text='<%# Eval("b", "{0:0.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                             <asp:GridView ID="gv_pfcolor" runat="server" 
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="gv_labticket09" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_pf" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt6_1" runat="server" Text='<%# Eval("a", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt6_2" runat="server" Text='<%# Eval("pscolor", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                         <div class="table-responsive" style="float: left; width: auto">
                                 <asp:GridView ID="gv_labticket7" runat="server"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Font-Size="Smaller">
                                <EditRowStyle CssClass="gv_labticket7" />
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_labticket7_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MiscAmt" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt7_a" runat="server" Text='<%# Eval("a", "{0:0.000}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Size" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt7_b" runat="server" Text='<%# Eval("b", "{0:0.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <RowStyle BackColor="#DDDDDD" />
                            </asp:GridView>
                             </div>
                               <div class="table-responsive" style="float: left; width: auto">
                                 <asp:GridView ID="gv_labticket8" runat="server"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                Font-Size="Small">
                                <EditRowStyle CssClass="gv_labticket8" />
                                <Columns>
                                    <asp:TemplateField HeaderText="CC" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_labticket8_s" runat="server" Text='<%# Eval("s") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caustic" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt8_a" runat="server" Text='<%# Eval("a", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                         <asp:TemplateField HeaderText="AC" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt8_b" runat="server" Text='<%# Eval("b", "{0:0.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

<%--                                         <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox onchange="onChange(this.id);" ID="gv_lt8" runat="server" Text='<%# Eval("c", "{0:.###}") %>' Width="60px" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>



                                </Columns>
                                <RowStyle BackColor="#DDDDDD" />
                            </asp:GridView>
                             </div>
                    </div>
             <%--   </div>--%>
            </div>
         
        </div>
    </div>


<br />

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
         //for (var i = 0; i < myArray.length; i++) {
         //    if (myArray[i].name === 'MainContent_gv_ccontrol_gv_ccontrol_caustic_0') {
         //        alert(i);
         //        alert(myArray[i].min);
         //        alert(myArray[i].max);
         //        //return i;
         //    }
         //}
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
             //role = "ReadOnly"
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSendEmail').style.display = "none";
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

                 alert('Time cannot be in future!');
                      

         }

         function confirmation() {
             if (confirm("Has the latest lab ticket been saved as a PDF file?") == true)
                 return true;
             else
                 return false;
         }



         </script>

</asp:Content>
