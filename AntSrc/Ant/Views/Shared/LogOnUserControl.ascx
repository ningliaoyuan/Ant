<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%if (Request.IsAuthenticated)
  { %>
    <div class="logined">
        <p>Lanslot，欢迎您的登录&nbsp;&nbsp;<a href="/Account/">进入用户中心</a>&nbsp;&nbsp;<a href="/Account/Logoff/">注销</a></p>
        <div class="hidden">
            <span>要加油了，距离你参加考试还有&nbsp;<b>23天3小时45分</b></span></div>
        <span>你还没有设置参加考试的时间，点击&nbsp;<a href="#">这里</a>&nbsp;设置</span>
    </div>
<%}
  else
  { %>
    <%using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { id = "FormLoginHeader" }))
      {%>
    <div class="loginform">
        <div class="email">
            <%= Html.TextBox("Username", "昵称或邮箱地址")%>
        </div>
        <div class="password">
            <%= Html.Password("Password", "")%>
        </div>
        <div class="submit">
            <a id="FormLoginHeaderSubmit" ajaxrequest="Login"></a>
            <a ajaxstatus="loading">验证...</a>
        </div>
        <div class="auto">
            <span>
                <%= Html.CheckBox("RememberMe")%>下次自动登录</span>
        </div>
        <div class="forgot">
            <a href="/Account/ForgetPassword/">救救我！忘记密码了</a></div>
        <div class="register">
            <a href="<%=Url.Action("Register","Account")%>">注册新用户</a></div>
    </div>
<%}
}%>