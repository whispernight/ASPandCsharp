<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication3.Models.Blog>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Edititing blog <%: Model.BlogID %></h2>
 
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary("Please correct the errors and try again.") %>
        
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
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
 
    <% } %>
 
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
 
</asp:Content>