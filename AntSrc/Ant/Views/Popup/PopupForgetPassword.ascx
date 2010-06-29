<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<a class="close"><span>x&nbsp;</span><i>关闭</i></a>
<div class="title">忘记密码</div>
<div class="subtitle">我们将向你注册时填写的邮箱发邮件确认</div>
<form id="FormPopup">
    <div><label>邮箱地址：</label></div>
    <div><input type="text" class="inp" /></div>
    <div class="wrong"><span>&nbsp;!&nbsp;</span>&nbsp;邮箱地址不存在</div>
    <div><button class="btn btn-blue">发送确认邮件</button></div>
    <div class="correct"><span>&nbsp;√&nbsp;</span>&nbsp;邮件已经发送，请查收您的邮箱。</div>
</form>