<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<a class="close"><span>x&nbsp;</span><i>关闭</i></a>
<div class="title">登录</div>
<div class="subtitle">登录kaoGMAT来保存做题记录</div>
<form id="FormPopup">
    <div><label>邮箱/昵称：</label><a id="LinkRegister2">注册新用户</a></div>
    <div><input type="text" class="inp" /></div>
    <div class="wrong"><span>&nbsp;!&nbsp;</span>&nbsp;用户昵称或邮箱地址不存在</div>
    <div><label>密码：</label><a id="LinkForgetPassword">忘记密码了？</a></div>
    <div><input type="password" class="inp" /></div>
    <div class="wrong"><span>&nbsp;!&nbsp;</span>&nbsp;密码错误</div>
    <div><input type="checkbox" />&nbsp;<span>下次自动登录</span></div>
    <div><button class="btn btn-blue">登录</button></div>
</form>