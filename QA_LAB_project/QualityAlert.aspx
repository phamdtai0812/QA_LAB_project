<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="QualityAlert.aspx.cs" Inherits="QA_LAB_project.QualityAlert" EnableEventValidation="false" %>
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
    <br />
    <div class="panel panel-default" style="width: 800px; margin: auto" id="panel1" runat="server">
        <div class="panel-heading">
            <div>
                <p style="color:white">Quality Alert</p>
            </div>
          
        </div>
        <div class="panel-body">
            <div class="row">

                <div class="col-md-2">
                    <asp:DropDownList Style="width: 340px" ID="ddlQualAlert" runat="server" CssClass="form-control" EnableViewState="true" >
                        <asp:ListItem Text="- - Select Quality Alert - - " Value="0"></asp:ListItem>
                        <asp:ListItem Text="Acid Insols" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Caustic Seds" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Evap Feed Caustic" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Leachable Soda Hydrate/Wet Cake" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Leachable Soda Kiln Feed" Value="5"></asp:ListItem>
                        <asp:ListItem Text="LOI" Value="6"></asp:ListItem>
                         <asp:ListItem Text="MTL Soda" Value="7"></asp:ListItem>
                         <asp:ListItem Text="North/South Water Tanks" Value="8"></asp:ListItem>
                         <asp:ListItem Text="Press Solids" Value="9"></asp:ListItem>
                         <asp:ListItem Text="% Solids on Wet Cake Shipments" Value="10"></asp:ListItem>
                         <asp:ListItem Text="#8 Washer UFlow" Value="11"></asp:ListItem>
                         
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                   <asp:Button ID="btnSendEmail" Text="Submit" Style="width: 120px; margin-left: 150px" runat="server"
                       class="btn btn-secondary"  OnClick="SendPDF_Click" OnClientClick="SendPDF_Click" />
                </div>
            </div>
            <br />
            <div class="row" style="margin-left: 20px">
                <div class="row">
                    CONSTITUENT:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <textarea id="TextArea1" cols="40" rows="2" runat="server"></textarea>

                </div>
                <br />
                <div class="row">
                    RESULTS:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <textarea id="TextArea2" cols="40" rows="2" runat="server"></textarea>

                </div>
                 <br />
                <div class="row">
                    INT LIMIT:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <textarea id="TextArea3" cols="20" rows="2" runat="server"></textarea>

                </div>
                 <br />
                <div class="row">
                    SPEC LIMIT:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <textarea id="TextArea4" cols="20" rows="2" runat="server"></textarea>

                </div>
               <div class="row">
                      <textarea id="TextArea5" cols="40" rows="2" runat="server" style="border: none"> Take appropriate action.</textarea>
                   

                </div>
            </div>
       
    
         
        </div>
    </div>


<br />

     <input type="hidden" runat="server" id="role" value="" />  


     <script>

         $(document).ready(function () {

             var role = (document.getElementById('MainContent_role').value);
             //role = "ReadOnly"
             if (role != "Admin") {
                 document.getElementById('MainContent_btnSendEmail').style.display = "none";
             }
         });




      </script>

</asp:Content>
