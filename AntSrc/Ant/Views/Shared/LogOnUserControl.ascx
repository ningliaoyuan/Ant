<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%if (Request.IsAuthenticated)
  { %>
    <a href="#">收藏夹</a>
    <a href="#">浏览记录</a>
    <a href="#">退出登录</a>
<%}
  else
  { %>
	<a id="LinkLogon" rel="#DivLogon">登录</a>
    <a id="LinkRegister">注册</a>
<%}
}%>