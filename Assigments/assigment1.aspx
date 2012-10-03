<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="assigment1.aspx.cs" Inherits="_564_Assigments_assigment1" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

        <div id="Div1" runat="server" style="width:550px; float:left; margin-left:20px">
        <h1><b>SqlDataReader</b></h1>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="400px" BorderColor="Aquamarine" BorderStyle="Dashed">
            </asp:GridView>
        </div>
 
 
         <div id="Div2" runat="server" style="width:550px; float:left; margin-left:20px">
        <h1><b>SqlDataAdaptor</b></h1>
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="400px" BorderColor="DarkGreen" BorderStyle="Solid">
            </asp:GridView>
        </div>
 
        
         <div id="Div3" runat="server" style="width:550px; float:left; margin-left:20px">
        <h1><b>Using DbFactoryProvider and DbDataAdapter with Mysql..</b></h1>
            <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="400px" BorderColor="Black" BorderStyle="Dotted">
            </asp:GridView>
 
        </div>
 
                <div id="Div4" runat="server" style="width:550px; float:left; margin-left:20px">
        <h1><b>Using DbFactoryProvider and DbDataAdapter with SqlClient..</b></h1>
            <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="400px" BorderColor="Brown" BorderStyle="Groove">
             </asp:GridView>
 
        </div>
</asp:Content>