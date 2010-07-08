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
                <%: Html.LabelFor(model => model.Content) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Content) %>
                <%: Html.ValidationMessageFor(model => model.Content) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ask) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ask) %>
                <%: Html.ValidationMessageFor(model => model.Ask) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Options) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Options) %>
                <%: Html.ValidationMessageFor(model => model.Options) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Solution) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Solution) %>
                <%: Html.ValidationMessageFor(model => model.Solution) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Answer) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Answer) %>
                <%: Html.ValidationMessageFor(model => model.Answer) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Source) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Source) %>
                <%: Html.ValidationMessageFor(model => model.Source) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Type) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Type) %>
                <%: Html.ValidationMessageFor(model => model.Type) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Rate) %>
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

