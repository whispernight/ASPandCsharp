<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication3.Models.Blog>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Blog
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
 <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary("Please correct the errors and try again.")%>
 
        <fieldset>
            <legend>Fields</legend>
            
 
 
            
            <div class="editor-label">
                <%: Html.LabelFor(m => m.BlogText) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(m => m.BlogText)%>
                <%: Html.ValidationMessageFor(m => m.BlogText) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Mood) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Mood) %>
                <%: Html.ValidationMessageFor(m => m.Mood) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            
 
            
 
  
 
            
 
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
 
    <% } %>
 
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
 
</asp:Content>