<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NerdDinner.Models.DinnerFormViewModel>" %>

    <%: Html.ValidationSummary("Please correct the errors and try again.") %>
    <% using (Html.BeginForm()) {%>
        

        <fieldset>


            <p>
                <%: Html.LabelFor(m => m.Dinner.Title) %>
                <%: Html.TextBoxFor(m => m.Dinner.Title)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Title, "*")%>
            </p>
            <p>
                <%: Html.LabelFor(m => m.Dinner.EventDate)%>
                <%: Html.TextBoxFor(m => m.Dinner.EventDate)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.EventDate, "*")%>
            </p>
            <p>
                <%: Html.LabelFor(m => m.Dinner.Description)%>
                <%: Html.TextBoxFor(m => m.Dinner.Description)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Description, "*")%>
            </p>
            <p>
                <%: Html.LabelFor(m => m.Dinner.Address)%>
                <%: Html.TextBoxFor(m => m.Dinner.Address)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Address, "*")%>
            </p>       
            <p>
                <%: Html.LabelFor(m => m.Dinner.Country)%>
                <%: Html.DropDownListFor(m => m.Dinner.Country, Model.Countries)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Country, "*")%>
            </p>
            <p>
                <%: Html.LabelFor(m => m.Dinner.ContactPhone)%>
                <%: Html.TextBoxFor(m => m.Dinner.ContactPhone)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.ContactPhone, "*")%>
            </p> 
            <p>
                <%: Html.LabelFor(m => m.Dinner.Latitude)%>
                <%: Html.TextBoxFor(m => m.Dinner.Latitude)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Latitude, "*")%>
            </p>            
            <p>
                <%: Html.LabelFor(m => m.Dinner.Longitude)%>
                <%: Html.TextBoxFor(m => m.Dinner.Longitude)%>
                <%: Html.ValidationMessageFor(m => m.Dinner.Longitude, "*")%>
            </p>            
            
            
            
                
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>