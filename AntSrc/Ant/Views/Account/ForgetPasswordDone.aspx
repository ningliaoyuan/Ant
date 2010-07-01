<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.ForgetPasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ForgetPasswordDone
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box2 forget-password">
    	<div class="box-title1">邮件已经成功发送</div>
    	<div class="box-content">
        	<p>你的密码已经发送到你的邮箱: <%:Model.Email %>。<br />请点击<a href="/">这里</a>返回首页。</p>
            
        </div>
    </div>
</div>
<div class="right">
	<div class="box3">ds</div>
</div>
<div class="clear"></div>
</asp:Content>
