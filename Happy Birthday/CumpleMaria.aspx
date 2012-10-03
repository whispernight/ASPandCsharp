<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CumpleMaria.aspx.cs" Inherits="Happy_Birthday_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    body
    {
      margin:50px 0px; padding:0px;
      text-align:center;
      }
     
    .Image
    {
          width:675px;
          margin:0px auto;
          text-align:center;
          padding:20px;
          border:1px dashed gray;
          background-color:Silver;
      }
 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>FELICIDADES MARIA!</h1>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="Image">
             <asp:Image ID="img1" runat="server"
             Height="600px" Width="600px"
             ImageUrl="~/Images/Cumple1.JPG" />
        </div>       
        <cc1:SlideShowExtender ID="SlideShowExtender1" runat="server"
            BehaviorID="SSBehaviorID"
            TargetControlID="img1"
            SlideShowServiceMethod="GetSlides"
            AutoPlay="true"
            ImageDescriptionLabelID="lblDesc"
            NextButtonID="btnNext"
            PreviousButtonID="btnPrev"
            PlayButtonID="btnPlay"
            PlayButtonText="Play"
            StopButtonText="Stop"
            Loop="true" >
        </cc1:SlideShowExtender>
        <div>
            <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnPrev" runat="server" Text="Anterior" />
            <asp:Button ID="btnPlay" runat="server" Text="" />
            <asp:Button ID="btnNext" runat="server" Text="Siguiente" />
        </div>
    </div>
    </form>
</body>
</html>
