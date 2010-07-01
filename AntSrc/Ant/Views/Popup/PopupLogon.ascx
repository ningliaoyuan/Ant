<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<a class="close"><span>x&nbsp;</span><i>关闭</i></a>
<div class="title">登录</div>
<div class="subtitle">登录kaoGMAT来保存做题记录</div>
<form class="FormPopup">
    <div><label>邮箱/昵称：</label><a id="LinkRegister">注册新用户</a></div>
    <div><input type="text" class="inp" id="InpUsername" /></div>
    <div class="wrong hidden">用户昵称或邮箱地址不存在</div>
    <div><label>密码：</label><a href="/Account/ForgetPassword/">忘记密码了？</a></div>
    <div><input type="password" class="inp" id="InpPassword" /></div>
    <div class="wrong hidden">登录密码错误</div>
    <div><input type="checkbox" id="ChkRemember" />&nbsp;<span>下次自动登录</span></div>
    <div class="wrong hidden" id="DivLogonEmpty">所有项都不得为空</div>
    <div><input type="button" class="btn btn-blue" id="BtnLogonSubmit" value="登录" ajaxrequest="Logon" /><input type="button" class="btn btn-gray" value="登录中..." ajaxstatus="loading" /></div>
</form>