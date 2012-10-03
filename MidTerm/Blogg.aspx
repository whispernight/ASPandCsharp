<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Blogg.aspx.cs" Inherits="MidTerm_Blogg" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <b>Select user: </b><asp:DropDownList ID="ddUsers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddUsers_SelectedIndexChanged" />
                <br /><br />
                <asp:Panel runat="server" EnableTheming="true" GroupingText="Login View">
                <asp:LoginView ID="LoginViewPostBlog" runat="server">
                    <AnonymousTemplate>
                        You need to <a href="Account/Login.aspx"> Login</a> to post a blog. 
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <b><asp:Label ID="LabelMood" runat="server" Text="Mood: " /></b><br />
                        <asp:TextBox ID="TextBoxMood" runat="server" Width="250px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMood" ControlToValidate="TextBoxMood" runat="server" 
                            ErrorMessage="Mood text cannot be empty" ForeColor="red" ValidationGroup="Mood" />
                        <br />
                        <b><asp:Label ID="Label2" runat="server" Text="Description: " /></b><br />
                        <asp:TextBox ID="TextBoxDescription" runat="server" Rows="3" TextMode="MultiLine" Width="247px"></asp:TextBox><br />
                        <asp:Button ID="ButtonPostBlog" ValidationGroup="Mood" runat ="server" OnClick ="ButtonPostBlog_Click" Text="Post Blog" />
                        <br /><br /> 
                    </LoggedInTemplate>
                </asp:LoginView>
                </asp:Panel>
                <br />
                <asp:ListView ID="ListViewBlogs" runat="server" OnItemDataBound="ListViewBlogs_ItemDataBound"  
                    OnItemCommand="ListViewBlogs_ItemCommand">
                    <ItemTemplate>
                    <asp:Panel ID="panelX" runat="server" BackColor="0xFF9C9D">
                        <br /><br /> 
                        <div  style="margin-bottom: 18px;padding-left: 10px;padding-right: 10px;">
                            <b>Mood:</b> <%# Eval("Mood")%> 
                            <div style="float: right;width: 45%;padding:  0px 10px 0 0;text-align: right;">
                                <asp:HyperLink ID="HyperLinkEditBlog" NavigateUrl='<%# "~/UpdateDeletePost.aspx?id=" + Eval("BlogID") %>' 
                                runat="server" Visible="false" >Want to edit Blog?</asp:HyperLink>
                            </div><br />
                            <b>Descripton: </b><%# Eval("Description")%>
                            <br /><br />
                            <br />
                            <div>
                                <b>Posted on:</b> <%# ((DateTime)Eval("TimeOfCreation")).ToString("ddd, MMM d, yyyy 'at' h:mm tt")%>
                            </div>
                            <asp:Label ID="labelAuthor" runat="server" Text='<%# Eval("Author")%>' Visible="false" ></asp:Label>
                            <asp:Label ID="labelBlogID" runat="server" Text='<%# Eval("BlogID")%>' Visible="false" ></asp:Label>
                            <asp:Label ID="labelDescripton" runat="server" Text=''></asp:Label>
                            <div>
                                <b>Posted by:</b> <%# Eval("Author") %>
                            </div>
                             


                            <b><asp:Label ID="labelNoOfResponses" runat="server" Text="" /></b>
                            <b><asp:Label ID="labelResponses" runat="server" Text=" Responses" /></b>
                            <asp:LinkButton ID="LinkButtonToggleListViewResponse" runat="server" CommandName="ToggleListViewResponse" >
                            Show/Hide Response</asp:LinkButton>
                              <br /><br />
                            <div runat="server" id="divResponse" style="width: 430px;overflow: auto;height: auto;">
                                <asp:ListView ID="ListViewResponses" runat="server" Visible="false"  OnItemDataBound="ListViewResponses_ItemDataBound"  
                                OnItemCommand="ListViewResponses_ItemCommand">
                                    <ItemTemplate>
                                    <asp:Panel runat="server" BorderStyle="Ridge" BorderColor="Red" BackColor="0xFCC2C3">
                                        <asp:Label ID="labelResponseID" runat="server" Text='<%# Eval("BlogResponseID")%>' Visible="false" ></asp:Label>
                                        <asp:Label ID="labelResponseText" runat="server" Text='<%# Eval("ResponseText")%>'></asp:Label><br />
                                        Posted By: <asp:Label ID="labelAuthor" runat="server" Text='<%# Eval("UserName")%>'  ></asp:Label>
                                        Time: <asp:Label ID="labelRecCreation" runat="server" Text='<%# Eval("RecCreation")%>' ></asp:Label>
                                        IP Addess: <asp:Label ID="labelIPAddress" runat="server" Text='<%# Eval("IPAddress")%>' ></asp:Label>
                                        <br /> 
                                        <asp:LinkButton ID="LinkButtonDeleteResponse" runat="server" CommandName="DeleteResponse" 
                                        CommandArgument='<%# Eval("BlogID") %>' Visible="false" >
                                        Delete Response</asp:LinkButton> 
                                        <br /><br />
                                        </asp:Panel>
                                </ItemTemplate>
                            </asp:ListView>
                            </div>
                            <br />
                            <div>
                            <div style="float:left;">
                                <b><asp:Label ID="labelResponse" runat="server" Text="Response"/></b>
                                <asp:TextBox ID="TextBoxResponse" runat="server" MaxLength="250"/></div>
                            <div>
                                <asp:Button ID="ButtonPostResponse" runat ="server"  Text="Post Reply!"
                                CommandName="PostResponse" CommandArgument='<%# Eval("BlogID") %>' />
                                <asp:Label ID="labelResponseErr" runat="server" Text="Response text cannot be empty" ForeColor="Red" Visible="false" /></div>
                            </div>
                        </div>
                        </asp:Panel>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                       <b>That user did not post any blogs!</b> 
                    </EmptyDataTemplate>
                </asp:ListView>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>