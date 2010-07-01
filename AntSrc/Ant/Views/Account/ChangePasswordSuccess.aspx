<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">修改密码</asp:Content>

<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box2 forget-password">
    	<div class="box-title1">密码修改成功</div>
    	<div class="box-content">
        	<p>你的密码已经被成功修改，以后请使用新密码登录。<br />请点击<a href="/">这里</a>返回首页。</p>            
        </div>
    </div>
</div>
<div class="right">
	<div class="box3">ds</div>
</div>
<div class="clear"></div>
</asp:Content>
