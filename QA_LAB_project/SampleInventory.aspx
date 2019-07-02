<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SampleInventory.aspx.cs" Inherits="QA_LAB_project.SampleInventory" %>
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
   

<%--    <div id="html-content-holder" style="width: 1280px; padding-left: 25px; padding-top: 10px;">--%>


        <div class="panel panel-default" style="width: 800px; margin: auto" id="panel1" runat="server">
            <div class="panel-heading">
                <div id="header1">
                    <p style="color: white">Daily Operations Sample Inventory (Sec 2)</p>
                    <p style="color: dodgerblue">Sec 3</p>
                </div>

            </div>
            <div class="panel-body" style="border: solid; margin: 10px">
                <div class="row">

                    <div class="col-md-3" style="margin-left: 10px">
                        <div class="form-group">
                            <div class='input-group date'>
                                <input type='text' id="datetimepicker" class="form-control" placeholder="Date" readonly="readonly" name="datetimepicker"  />
                                <span class="input-group-addon"></span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-2">
                 
                    </div>
                  

                        <div class="col-md-2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-secondary"  Width="80px"   OnClick="btnSubmit_Click" />
                   
                        </div>
                   
                </div>
                
             


                <div class="row" style="margin-left: 5px">

                    <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc; border-radius: 5px">
                            <asp:GridView ID="gv_section2" runat="server" Height="16px" Width="500px" EnableViewState="true"
                                CssClass="table  table-bordered table-hover"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                OnRowDataBound="gv_sec2_onrowdatabound"
                                Style="border-radius: 10px">
                                <EditRowStyle CssClass="GridViewEditRow" />
                                <Columns>

                                    <%--  <asp:TemplateField HeaderText="Sample" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Label ID="gv" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Section 2:" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec2_c1" runat="server" Text='<%# Eval("a") %>' Width="130px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Frequency" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec2_c2" runat="server" Text='<%# Eval("b") %>' Width="80px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Received" ItemStyle-Width="50">
                                        <%--  <ItemTemplate>
                                        <asp:TextBox ID="gv_sec2_c3" runat="server" Text='<%# Eval("c") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="gv_sec2_c3" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comments" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec2_c4" runat="server" Text='<%# Eval("d") %>' Width="150px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#DDDDDD" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                 
                </div>


            
            </div>

        </div>





        <div class="panel panel-default" style="width: 800px; margin: auto" id="panel2" runat="server">
            <div class="panel-heading">
                <div id="header2">
                    <p style="color: white">Daily Operations Sample Inventory (Section 3)</p>

                    <p style="color: dodgerblue">Sec 2</p>
                </div>
               
            </div>
            <div class="panel-body" style="border: solid; margin: 10px">
               <div class="row clearfix" style="padding-bottom: 5px">
                        <div class="table-responsive" style="float: left; margin-left: 20px; background-color: #dcdcdc; border-radius: 5px">
                           <asp:GridView ID="gv_section3" runat="server" Height="16px" Width="500px" EnableViewState="true"
                                CssClass="table  table-bordered table-hover"
                                AutoGenerateColumns="False"
                                EditRowStyle-Width="20px"
                                OnRowDataBound="gv_sec3_onrowdatabound"
                                Style="border-radius: 10px">
                                <EditRowStyle CssClass="GridViewEditRow" />
                                <Columns>

                                    <%--  <asp:TemplateField HeaderText="Sample" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Label ID="gv" runat="server" Text='<%# Eval("s") %>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Section 3:" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec3_c1" runat="server" Text='<%# Eval("a") %>' Width="130px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Frequency" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec3_c2" runat="server" Text='<%# Eval("b") %>' Width="80px" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Received" ItemStyle-Width="50">
                                        <%--  <ItemTemplate>
                                        <asp:TextBox ID="gv_sec2_c3" runat="server" Text='<%# Eval("c") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="gv_sec3_c3" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comments" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:TextBox ID="gv_sec3_c4" runat="server" Text='<%# Eval("d") %>' Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#DDDDDD" />
                            </asp:GridView>
                        </div>
                    </div>
            </div>
           
          
        </div>
        <br />



        <input type="hidden" runat="server" id="role" value="" />
        <%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
        <input type="hidden" id="date_max" name="date_max" value="" runat="server" />

        <input type="hidden" id="shift" name="shift" value="" runat="server" />
        <input type="hidden" id="dateSave" name="dateSave" value="" />
        <input type="hidden" id="date_select" name="date_select" value="" />



        <div id="previewImage" style="margin: 900px">
        </div>

<%--    </div>--%>
     <script>

        
    

         $("document").ready(function () {
             $("#MainContent_panel2").hide();
             $("#datetimepicker").datepicker().on('changeDate', function(e) {
                 //alert('date has changed!');
                 //myFunction();
});
});

   $('#header1, #header2').click(function(){
     if($('#MainContent_panel1').is(':visible'))
     {
       $('#MainContent_panel1').hide();
       $('#MainContent_panel2').show();
     }
     else if($('#MainContent_panel2').is(':visible'))
     {
       $('#MainContent_panel2').hide();
       $('#MainContent_panel1').show();
     }
   });

         var element = $("#html-content-holder"); // global variable
         var getCanvas; // global variable


    
        
         function download() {

               document.getElementById('MainContent_Button2').click();
         }
       





    var role = (document.getElementById('MainContent_role').value);
             if (role != "Admin") {
                 //document.getElementById('MainContent_btnSave').style.display = "none";
             }


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
                 url: 'SampleInventory.aspx/callCodeBehind',
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

