<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<a class="close"><span>x&nbsp;</span><i>关闭</i></a>
<div class="title">注册新用户</div>
<div class="subtitle">注册成为kaoGMAT会员以使用更多功能</div>
<form id="FormPopup">
    <div><label>登录用邮箱地址：</label></div>
    <div><input type="text" class="inp" /></div>
    <div class="wrong"><span>&nbsp;!&nbsp;</span>&nbsp;邮箱地址不符合规范</div>
    <div><label>用户昵称：</label></div>
    <div><input type="text" class="inp" /></div>
    <div class="tip">最多8个中文字符或者16个英文字符</div>
    <div><label>登录密码：</label></div>
    <div><input type="password" class="inp" /></div>
    <div class="tip">最少6个字符</div>
    <div><label>确认密码：</label></div>
    <div><input type="password" class="inp" /></div>
    <div class="wrong"><span>&nbsp;!&nbsp;</span>&nbsp;确认密码与登录密码输入不一致</div>
    <div><button class="btn btn-gray">确认注册</button></div>
</form>