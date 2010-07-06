<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%if (Request.IsAuthenticated)
  { %>
    <span>欢迎你，Lanslot</span>
    <a href="/Account/Favorite/">收藏夹</a>
    <a href="/Account/Record/">浏览记录</a>
    <a href="/Account/ChangePassword/">修改密码</a>
    <a href="/Account/Logoff/">退出登录</a>
<%}
  else
  { %>
	<a class="LinkLogon">登录</a>
    <a class="LinkRegister">注册</a>
<%}%>
