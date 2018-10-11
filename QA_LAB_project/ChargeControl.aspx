<%@ Page Title="Charge Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChargeControl.aspx.cs" Inherits="QA_LAB_project.ChargeControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <%--   <meta http-equiv="X-UA-Compatible" content="IE=11" />--%>
    <script src="Scripts/jquery-3.1.0.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
   
<%--   <script src="Scripts/bootstrap-datepicker.min.js"></script>
     <link rel="stylesheet" href="Content/bootstrap.min.css" />
      <script src="Scripts/bootstrap.min.js"></script>
     <script src="Scripts/moment.min.js"></script>--%>



  <%--  <meta name="viewport" content="width=device-width, initial-scale=1">--%>
      <style>
        Body{

background: #DCDCDC; /* will apply color */

}

       .panel > .panel-heading {
  
    background-color: lightskyblue;
    

}

      .btn-secondary{
              background-color: lightskyblue;
       }
        
    </style>
 
  <%--  <div class="container-fluid main-container" style="margin-top: 5px">
    <div class="col-md-10 content col-xs-offset-2">--%>
  <div class="panel panel-default"   style="width: 800px; margin-left: 150px">
            <div class="panel-heading">
               Charge Control 
            </div>
            <div class="panel-body">

        
                <div class="row" >
              
                    <%--<div style="margin-left: 0px">--%>
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class='input-group date'>
                                <input type='text' id="datetimepicker" class="form-control" placeholder="Date" name="datetimepicker" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <asp:DropDownList Style="width: 100px" ID="ddlCCROUND" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-2">
                        <%--    <div>
        <%=GetLabData() %>
    </div>--%>
                        <div id="tm">
                            <asp:Button ID="Button1" Text="Select" runat="server" class="btn btn-secondary"
                                CommandName="ThisBtnClick" OnClick="SelectButtonClick" />
                        </div>

                    </div>
                    <div class="col-md-2">

                        <button id="btncreate" type="button" class="btn btn-secondary" style="width: 100px" onclick="createNew();">Create New</button>
                        &nbsp;<br />
                        <%--  <asp:Label ID="lblmsg" runat="server"></asp:Label>--%>
                    </div>

                    <%--     <button type="button" class="btn btn-secondary" style="width: 80px" onclick="saveRecord();a">Save</button>--%>
                    <%--</div>--%>
                </div>
      
                    

                <div id="panel1">

                    <div class="panel panel-default" id="panel01" style="width: 100%">
                        <div class="container">

                            <div class="row" style="margin-top: 10px; font-size: small">

                                <div class="row" style="margin-left: 20px; font-weight: 600">
                                    <asp:Literal ID="date" runat="server" Text='' />
                                </div>
                                <br />
                                <div class="form-group col-sm-2">

                                    <label for="tt"></label>

                                    <label for="soda">Soda(Gpl) </label>
                                </div>
                                <div class="form-group col-sm-1">

                                    <label for="oxsettler">Ox Settler </label>
                                    <input type="text" class="form-control" id="oxsettler" name="oxsettler" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="wuf">WUF</label>
                                    <input type="text" class="form-control" id="wuf" name="wuf" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="mtl">MTL</label>
                                    <input type="text" class="form-control" id="mtl" name="mtl" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="srt">SRT</label>
                                    <input type="text" runat="server" class="form-control" id="srt" name="srt">
                                </div>
                                <div class="form-group col-sm-2" id="pf" runat="server">

                                    <label for="oxsettler">Press Filtrate(MG/L)</label>
                                    <input type="text" style="width: 65px" class="form-control" id="pressfiltrate" name="pressfiltrate" runat="server">
                                </div>
                            </div>

                        </div>

                        <div class="container">

                            <div class="row">
                                <div class="form-group col-sm-2">
                                    <label for="tt">Sample </label>
                                    <br />
                                    <label for="tt">Test Tank </label>
                                </div>
                                <div class="form-group col-sm-1">

                                    <label for="caustic">Caustic </label>
                                    <input type="text" class="form-control" id="ttcaustic" name="ttcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">
                                    <label for="ac">A/C</label>
                                    <input type="text" class="form-control" id="ttac" name="ttac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="cs">C/S</label>
                                    <input type="text" class="form-control" id="ttcs" name="ttcs" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="four">AIM</label>

                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Tri-Digestor </label>
                                </div>
                                <div class="form-group col-sm-1">
                                    <input type="text" class="form-control" id="tridcaustic" name="tridcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="tridac" name="tridac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="tridcs" name="tridcs" runat="server">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" runat="server" class="form-control" id="tridaim" name="tridaim">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">No.5 FlashTank </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="no5caustic" name="no5caustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="no5ac" name="no5ac" runat="server">
                                </div>
                                <div class="form-group col-sm-1" style="margin-bottom: 2px;">

                                    <input type="text" class="form-control" id="no5cs" name="no5cs" runat="server">
                                </div>
                                <div class="form-group col-sm-1" style="margin-bottom: 2px;">

                                    <input type="text" class="form-control" id="no5aim" name="no5aim" runat="server">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Dig Disch </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="ddcaustic" name="ddcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ddac" name="ddac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ddcs" name="ddcs" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Settler Feed</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="sfcaustic" name="sfcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="sfac" name="sfac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="sfcs" name="sfcs" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Press Feed </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="pfcaustic" name="pfcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="pfac" name="pfac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">LTP</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="ltpcaustic" name="ltpcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ltpac" name="ltpac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ltpaim" name="ltpaim" runat="server">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Evap Feed</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="efcaustic" name="efcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="efac" name="efac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Evap Disch</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="edcaustic" name="edcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="edac" name="edac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 2px;">
                                <div class="form-group col-sm-2">


                                    <label for="tt">WOF</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="wofcaustic" name="wofcaustic" runat="server">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="wofac" name="wofac" runat="server">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>


                            <div id="panel1_0300">
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">A7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="a7caustic" name="a7caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="a7ac" name="a7ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">B7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="b7caustic" name="b7caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="b7ac" name="b7ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Y15 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="y15caustic" name="y15caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="y15ac" name="y15ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Y16 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="y16caustic" name="y16caustic" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="y16ac" name="y16ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>
                            <div id="panel1_0600">
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T1 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t1caustic" name="t1caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t1ac" name="t1ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="panel1_t3">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T3 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t3caustic" name="t3caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t3ac" name="t3ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t7caustic" name="t7caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t7ac" name="t7ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG1</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag1caustic" name="ag1caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag1ac" name="ag1ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="panel1_ag4">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG4</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag4caustic" name="ag4caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag4ac" name="ag4ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG7</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag7caustic" name="ag7caustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag7ac" name="ag7ac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>
                            <div id="panel1_0600_">
                                <div class="row" id="panel1_suf">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">SUF Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="sufcaustic" name="sufcaustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="sufac" name="sufac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="panel1_evapcc">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Evap C/C</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="evapcccaustic" name="evapcccaustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="evapccac" name="evapccac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="panel1_presscc">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Press C/C</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="presscccaustic" name="presscccaustic" runat="server">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="pressccac" name="pressccac" runat="server">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>

                <div id="panel2">
                    <div class="panel panel-default" id="panel02" style="width: 100%">
                        <div class="container">
                            <div class="row" style="margin-top: 10px">
                                <div class="form-group col-sm-2">
                                    <label for="tt"></label>
                                    <br />
                                    <label for="soda">Soda(Gpl) </label>
                                </div>
                                <div class="form-group col-sm-1">

                                    <label for="oxsettler">Ox Settler </label>
                                    <input type="text" class="form-control" id="oxsettler2" name="oxsettler2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">
                                    <label for="wuf">WUF</label>
                                    <input type="text" class="form-control" id="wuf2" name="wuf2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="mtl">MTL</label>
                                    <input type="text" class="form-control" id="mtl2" name="mtl2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="srt">SRT</label>
                                    <input type="text" runat="server" class="form-control" id="srt2" name="srt2" onblur="myFunction(this.id)">
                                </div>


                                <div class="form-group col-sm-2" id="pf2">

                                    <label for="oxsettler">Press Filtrate(MG/L)</label>
                                    <input type="text" style="width: 65px" class="form-control" id="pressfiltrate2" name="pressfiltrate2" runat="server" onblur="myFunction(this.id)">
                                </div>
                            </div>
                        </div>

                        <div class="container">
                            <div class="row">
                                <div class="form-group col-sm-2">
                                    <label for="tt">Sample </label>
                                    <br />
                                    <label for="tt">Test Tank </label>
                                </div>
                                <div class="form-group col-sm-1">

                                    <label for="caustic">Caustic </label>
                                    <input type="text" class="form-control" id="ttcaustic2" name="ttcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">
                                    <label for="ac">A/C</label>
                                    <input type="text" class="form-control" id="ttac2" name="ttac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="cs">C/S</label>
                                    <input type="text" class="form-control" id="ttcs2" name="ttcs" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                    <label for="four">AIM</label>

                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Tri-Digestor </label>
                                </div>
                                <div class="form-group col-sm-1">
                                    <input type="text" class="form-control" id="tridcaustic2" name="tridcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="tridac2" name="tridac" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="tridcs2" name="tridcs" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" runat="server" class="form-control" id="tridaim2" name="tridaim" onblur="myFunction(this.id)">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">No.5 FlashTank </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="no5caustic2" name="no5caustic" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="no5ac2" name="no5ac" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="no5cs2" name="no5cs" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="no5aim2" name="no5aim" runat="server" onblur="myFunction(this.id)">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Dig Disch </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="ddcaustic2" name="ddcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ddac2" name="ddac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ddcs2" name="ddcs2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Settler Feed</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="sfcaustic2" name="sfcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="sfac2" name="sfac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="sfcs2" name="sfcs2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Press Feed </label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="pfcaustic2" name="pfcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="pfac2" name="pfac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">LTP</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="ltpcaustic2" name="ltpcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ltpac2" name="ltpac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="ltpaim2" name="ltpaim2" runat="server" onblur="myFunction(this.id)">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Evap Feed</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="efcaustic2" name="efcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="efac2" name="efac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">Evap Disch</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="edcaustic2" name="edcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="edac2" name="edac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-sm-2">


                                    <label for="tt">WOF</label>
                                </div>
                                <div class="form-group col-sm-1">


                                    <input type="text" class="form-control" id="wofcaustic2" name="wofcaustic2" runat="server" onblur="myFunction(this.id)">
                                </div>

                                <div class="form-group col-sm-1">

                                    <input type="text" class="form-control" id="wofac2" name="wofac2" runat="server" onblur="myFunction(this.id)">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                                <div class="form-group col-sm-1">
                                </div>
                            </div>

                            <div id="panel2_0300">
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">A7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="a7caustic2" name="a7caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="a7ac2" name="a7ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">B7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="b7caustic2" name="b7caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="b7ac2" name="b7ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Y15 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="y15caustic2" name="y15caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="y15ac2" name="y15ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Y16 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="y16caustic2" name="y16caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="y16ac2" name="y16ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>
                            <div id="panel2_0600">
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T1 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t1caustic2" name="t1caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t1ac2" name="t1ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="t3">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T3 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t3caustic2" name="t3caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t3ac2" name="t3ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">T7 Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="t7caustic2" name="t7caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="t7ac2" name="t7ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG1</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag1caustic2" name="ag1caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag1ac2" name="ag1ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="ag4">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG4</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag4caustic2" name="ag4caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag4ac2" name="ag4ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">AG7</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="ag7caustic2" name="ag7caustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="ag7ac2" name="ag7ac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>
                            <div id="panel2_0600_">
                                <div class="row" id="suf">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">SUF Overflow</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="sufcaustic2" name="sufcaustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="sufac2" name="sufac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="evapcc">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Evap C/C</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="evapcccaustic2" name="evapcccaustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="evapccac2" name="evapccac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                                <div class="row" id="presscc">
                                    <div class="form-group col-sm-2">


                                        <label for="tt">Press C/C</label>
                                    </div>
                                    <div class="form-group col-sm-1">


                                        <input type="text" class="form-control" id="presscccaustic2" name="presscccaustic2" runat="server" onblur="myFunction(this.id)">
                                    </div>

                                    <div class="form-group col-sm-1">

                                        <input type="text" class="form-control" id="pressccac2" name="pressccac2" runat="server" onblur="myFunction(this.id)">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                    <div class="form-group col-sm-1">
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div style="margin-left: 400px">
                            <asp:Button ID="Button2" Text="Save" runat="server" class="btn btn-secondary"
                                CommandName="ThisBtnClick" OnClick="SaveButtonClick" />
                            <%--     <button type="button" class="btn btn-secondary" style="width: 80px" onclick="saveRecord();a">Save</button>--%>
                        </div>


                        <br />
                    </div>
                </div>
                   

            </div>
        </div>
<%--    </div>
</div--%>>
    
     <input type="hidden" runat="server" id="role" value="" />  
    <input type="text" runat="server" id="displayRole" value="" />  
    <input type="hidden" id="dueDate" name="dueDate" />
    <input type="text" id="userName_" name="userName_" runat="server" />
    <div>
        <div id="popupdiv" title="Basic modal dialog" style="display: none">
        </div>
    </div>
    
    <script type="text/javascript">
   

        function DisplayPanels_OnCreateNew() {
            //alert('Selected Value is : ' + $('[id*=ddlCCROUND]').val());
            if ($('[id*=ddlCCROUND]').val() == 2) {
                document.getElementById("panel2_0600").style.display = "block";
                document.getElementById("panel2_0600_").style.display = "block";
                document.getElementById("panel2_0300").style.display = "none";
                document.getElementById("pf2").style.display = "block";
                
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 1 || $('[id*=ddlCCROUND]').val() == 3) {
                document.getElementById("panel2_0600").style.display = "none";
                document.getElementById("panel2_0600_").style.display = "none";
                document.getElementById("panel2_0300").style.display = "block";
                document.getElementById("pf2").style.display = "none";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 4 || $('[id*=ddlCCROUND]').val() == 8) {
                document.getElementById("panel2_0600").style.display = "none";
                document.getElementById("panel2_0600_").style.display = "none";
                document.getElementById("panel2_0300").style.display = "none";
                document.getElementById("pf2").style.display = "block";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 6) {
                document.getElementById("panel2_0600").style.display = "none";
                document.getElementById("panel2_0600_").style.display = "block";
                document.getElementById("panel2_0300").style.display = "block";
                document.getElementById("pf2").style.display = "block";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 5 || $('[id*=ddlCCROUND]').val() == 7) {
                document.getElementById("panel2_0600").style.display = "block";
                document.getElementById("panel2_0600_").style.display = "none";
                document.getElementById("panel2_0300").style.display = "none";
                document.getElementById("pf2").style.display = "none";
                if ($('[id*=ddlCCROUND]').val() == 5)
                {
                    document.getElementById("t3").style.display = "none";
                }
                else
                {
                    document.getElementById("t3").style.display = "none";
                    document.getElementById("ag4").style.display = "none";
                }
            }
        }

        function createNew() {
     
            document.getElementById("panel1").style.display = "none";
            document.getElementById("panel2").style.display = "block";
            $("input:text").val("");
            DisplayPanels_OnCreateNew();
            document.getElementById("tm").style.display = "none";
            $('#datetimepicker').datepicker(
                $('#datetimepicker').datepicker('setDate', 'now')
            )
        };

        function DisplayPanels_OnSelect() {

          
            //alert('Selected Value is : ' + $('[id*=ddlCCROUND]').val());
            if ($('[id*=ddlCCROUND]').val() == 2) {
                document.getElementById("panel1_0600").style.display = "block";
                document.getElementById("panel1_0600_").style.display = "block";
                document.getElementById("panel1_0300").style.display = "none";
                //document.getElementById("pf").style.display = "block";

            }
            else if
            ($('[id*=ddlCCROUND]').val() == 1 || $('[id*=ddlCCROUND]').val() == 3) {
                document.getElementById("panel1_0600").style.display = "none";
                document.getElementById("panel1_0600_").style.display = "none";
                document.getElementById("panel1_0300").style.display = "block";
                //document.getElementById("pf").style.display = "none";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 4 || $('[id*=ddlCCROUND]').val() == 8) {
                document.getElementById("panel1_0600").style.display = "none";
                document.getElementById("panel1_0600_").style.display = "none";
                document.getElementById("panel1_0300").style.display = "none";
                //document.getElementById("pf").style.display = "block";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 6) {
                document.getElementById("panel1_0600").style.display = "none";
                document.getElementById("panel1_0600_").style.display = "block";
                document.getElementById("panel1_0300").style.display = "block";
                //document.getElementById("pf").style.display = "block";
            }
            else if
            ($('[id*=ddlCCROUND]').val() == 5 || $('[id*=ddlCCROUND]').val() == 7) {
                document.getElementById("panel1_0600").style.display = "block";
                document.getElementById("panel1_0600_").style.display = "none";
                document.getElementById("panel1_0300").style.display = "none";
                //document.getElementById("pf2").style.display = "none";
                if ($('[id*=ddlCCROUND]').val() == 5) {
                    document.getElementById("panel1_t3").style.display = "none";
                }
                else {
                    document.getElementById("panel1_t3").style.display = "none";
                    document.getElementById("panel1_ag4").style.display = "none";
                }
            }
        }

        var date;
        var dueDate_; 

        $(document).ready(function () {
           

            //disable create button if not admin
            var role = (document.getElementById('MainContent_role').value);
            if (role != "Admin") {
                document.getElementById('btncreate').style.display = "none";

            }

            document.body.style.zoom = "100%"

            DisplayPanels_OnSelect();
            var controls = document.getElementById("panel1").getElementsByTagName("input");
            for (var i = 0; i < controls.length; i++)
                controls[i].disabled = true;
            document.getElementById("panel2").style.display = "none";

            var sessionValue = '<%= Session["date"] %>';
            //alert(sessionValue);
            //if (document.getElementById('dueDate').value == "")
            if(sessionValue == "" || sessionValue == null)
            {
                $('#datetimepicker').datepicker({

                    format: "mm/dd/yyyy",
                    autoclose: true

                });
                //$('#datetimepicker').datepicker(
                    $('#datetimepicker').datepicker('setDate', 'now');
                //)
                document.getElementById('dueDate').value = $('#datetimepicker').datepicker("getDate");
                    //.on('changeDate', function (ev) {
                    //    //dp.val(ev.target.value);
                    //    document.getElementById('dueDate').value = '12-01-2017';
                    //});
            }
            else {
                //alert('else');
                var today = new Date(sessionValue);
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();

                today = mm + '/' + dd + '/' + yyyy;
                $('#datetimepicker').datepicker({

                    format: "mm/dd/yyyy",
                    autoclose: true

                });
                $('#datetimepicker').datepicker('setDate', 'now');
                document.getElementById('dueDate').value = $('#datetimepicker').datepicker("getDate");
                
            }

            $("#datetimepicker").datepicker().on('changeDate', function (e) {
                //alert('date has changed!');
                //document.getElementById('dueDate').value = '12-01-2017';
                document.getElementById('dueDate').value = $('#datetimepicker').datepicker("getDate");
                autoclose: true
            });
        });
     
      
        function myFunction(_inputId) {
            
            if (document.getElementById(_inputId).value.match(/[\-\][A-Za-z][A-Za-z0-9]*/) ) {
                alert('ERROR: Only non-negative numbers allowed!');
                <%--$("#<%=ttcaustic2.ClientID %>").focus();--%>
                document.getElementById(_inputId).focus();
                document.getElementById(_inputId).value = '';
                }
                else
                    return true;
        }
     
       
            $('#topnavbar').affix({
                offset: {
                top: $('#banner').height()
                }
            });
        

    </script>
   
</asp:Content>
   
 
