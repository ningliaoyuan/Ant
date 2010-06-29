<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.ForgetPasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ForgetPassword
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ForgetPassword</h2>
    <p>
        Please enter your username and your registered email. password.
    </p>
    <p>
        <%: Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Send password email was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email)%>
                    <%: Html.ValidationMessageFor(m => m.Email)%>
                </div>
                
                <p>
                    <input type="submit" value="Send me password" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>
