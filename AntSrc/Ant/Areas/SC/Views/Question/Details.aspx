<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.Questions.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="left">
	<div class="box2">
    	<div class="box-title"></div>
        <div class="box-content"></div>
    </div>
</div>
<div class="right">
</div>
<div class="clear"></div>




    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Number</div>
        <div class="display-field"><%: Model.Number %></div>
        
        <div class="display-label">Content</div>
        <div class="display-field"><%: Model.Content %></div>
        
        <div class="display-label">Ask</div>
        <div class="display-field"><%: Model.Ask %></div>
        
        <div class="display-label">Options</div>
        <div class="display-field"><%: Model.Options %></div>
        
        <div class="display-label">Solution</div>
        <div class="display-field"><%: Model.Solution %></div>
        
        <div class="display-label">Answer</div>
        <div class="display-field"><%: Model.Answer %></div>
        
        <div class="display-label">Source</div>
        <div class="display-field"><%: Model.Source %></div>
        
        <div class="display-label">Type</div>
        <div class="display-field"><%: Model.Type %></div>
        
        <div class="display-label">Rate</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Rate) %></div>
        
        <div class="display-label">ViewCount</div>
        <div class="display-field"><%: Model.ViewCount %></div>
        
        <div class="display-label">CommentsCount</div>
        <div class="display-field"><%: Model.CommentsCount %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

