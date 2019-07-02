<%@ Page Title="Main" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="QA_LAB_project.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .btn-info {
            font-size: small;
            color: black;
            height: 80px;
             opacity: 0.7;
  transition: 0.3s;
  font-weight: 600;
  background-color: steelblue;
  
  
        }
        .btn-info:hover {
            opacity: 1;
            border: 3px solid green;
            height: 70px;
          
        }
          .centerPanel {
             border: 1px solid white;
            z-index: 1;
            position: relative;
            margin: 0 auto;
            top: 10px;
            width: 600px;
            height: 310px;
        }

    </style>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
      <asp:Panel ID="Panel1" runat="server"  CssClass="centerPanel" >
          <br />
          <div class="row" style="margin-left: 50px">
           <div class="row">
            
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button1" OnClientClick="javascript:return(ReDirect('EnvironmentalAnalysis.aspx'));" runat="server" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png');  white-space: normal" Text="Environmental Analysis" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return(ReDirect('ChargeControl2.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Charge Control" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button3" runat="server" OnClientClick="javascript:return(ReDirect('HydrateAnalysis.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Hydrate Analysis" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button4" runat="server" OnClientClick="javascript:return(ReDirect('KilnDryer.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Kiln and Dryer Data" class="btn btn-info" Width="120px" />
                    </div>
                </div>
        </div>


        <div class="row">
          
                   <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button5" runat="server" OnClientClick="javascript:return(ReDirect('DailyAlumina.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Daily Alumina & Hydrate Analysis" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button6" runat="server" OnClientClick="javascript:return(ReDirect('Sec_III.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="SEC III Worksheet" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button7" runat="server" OnClientClick="javascript:return(ReDirect('Sec_12.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="SEC I & II Data" class="btn btn-info" Width="120px" />
                    </div>
                </div>
                <div class="btn-group">
                    <div class="col-sm-12" style="padding: 5px">
                        <asp:Button ID="Button8" runat="server"  OnClientClick="javascript:return(ReDirect('Misc.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Misc Information" class="btn btn-info" Width="120px" />
                    </div>
                </div>
        </div>
              <div class="row">

                  <div class="btn-group">
                      <div class="col-md-12" style="padding: 5px">
                          <asp:Button ID="Button9" runat="server" OnClientClick="javascript:return(ReDirect('Reporting.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Reporting" class="btn btn-info" Width="120px" />

                      </div>
                  </div>
                  <div class="btn-group">
                      <div class="col-md-12" style="padding: 5px">
                          <asp:Button ID="Button12" runat="server" OnClientClick="javascript:return(ReDirect('ExcelDownloads.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Excel Downloads" class="btn btn-info" Width="120px" />
                      </div>
                  </div>
                  <div class="btn-group">
                      <div class="col-md-12" style="padding: 5px">
                          <asp:Button ID="Button10" runat="server" OnClientClick="javascript:return(ReDirect('Specs.aspx'));" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="Product Specs & Pi Tag List" class="btn btn-info" Width="120px" />

                      </div>
                  </div>
                  <div class="btn-group">
                      <div class="col-md-12" style="padding: 5px">
                       <%--  <asp:Button ID="Button11" runat="server" OnClientClick="" Style="margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="" class="btn btn-info" Width="120px" />--%>
                        <asp:Button ID="Button11" runat="server" OnClientClick="javascript:return(ReDirect('LTQA.aspx'));" Style="font-size:12px;  margin-left: 0px; background-image: url('~/Image/4169E1.png'); white-space: normal" Text="  Lab Ticket        Quality Alert              Housekeeping" class="btn btn-info" Width="120px" />
                      </div>
                  </div>
              </div>

              </div>
               <input type="hidden" runat="server" id="role" value="" />  
                <input type="hidden" runat="server" id="displayRole" value="" />  
          </asp:Panel>
    
           <script>

               var currentTime = new Date().getMinutes();
               if (1 <= currentTime && currentTime < 10) {
                   if (document.body) {
                       document.body.style.backgroundColor = "#F0F8FF";
                   }
               }
               if (10 <= currentTime && currentTime < 20) {
                   if (document.body) {
                       document.body.style.backgroundColor = "#F0F6FF";
                   }
               }
               if (20 <= currentTime && currentTime < 30) {
                   if (document.body) {
                       document.body.style.backgroundColor = "#F0F3FF";
                   }
               }
               if (30 <= currentTime && currentTime < 40) {
                   if (document.body) {
                       document.body.style.backgroundColor = "#F0F0FF";
                   }
               }
               if (40 <= currentTime && currentTime < 50) {
                   if (document.body) {
                       document.body.style.backgroundColor = "#F0FAFF";
                   }
               }
           
               else {
                   if (document.body) {
                       document.body.background = "#F0FDFF";
                   }
               }

               function ReDirect(location) {
                   //window.open(location);
                   window.location.replace(location);
                   return false;
               }
               document.body.style.zoom = "90%"
    </script>
</asp:Content>
