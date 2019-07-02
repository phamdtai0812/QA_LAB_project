<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="INV_LAB_MISC.aspx.cs" Inherits="QA_LAB_project.INV_LAB_MISC" EnableEventValidation="false" %>
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
           
               
             <%--   <asp:HyperLink id="qualityalert"  NavigateUrl="#" Text="Quality Alert" runat="server" ForeColor="White"/>--%>
                 <asp:HyperLink id="misc"  NavigateUrl="~/Misc.aspx" Text="Misc. Info" runat="server" ForeColor="White"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:HyperLink id="inventory"  NavigateUrl="~/Inventory.aspx" Text="Inventory Data " runat="server" ForeColor="White"/> 
            </div>
          
        </div>
        <div class="panel-body">
           
         
        </div>
    </div>


<br />

     <input type="hidden" runat="server" id="role" value="" />  
<%--    <input type="text" runat="server" id="displayRole" value="" />  --%>
    <input type="hidden" id="date_max" name="date_max" value="" runat="server"/>
    <input type="hidden" id="dateSave" name="dateSave" value=""/>
    <input type="hidden" id="date_select" name="date_select" value=""/>

  

</asp:Content>
