<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.Questions.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
              <div class="editor-label">
                    <%: Html.LabelFor(m => m.Content) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Content) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Options) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Options) %>
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

