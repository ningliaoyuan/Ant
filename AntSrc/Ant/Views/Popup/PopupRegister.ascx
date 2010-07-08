<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<a class="close"><span>x&nbsp;</span><i>关闭</i></a>
<div class="title">注册新用户</div>
<div class="subtitle">注册成为kaoGMAT会员以使用更多功能</div>
<form class="FormPopup">
    <div><label>登录用邮箱地址：</label></div>
    <div><input type="text" class="inp" id="InpEmail" ajaxrequest="EmailCheck" /></div>
    <div class="wrong hidden">邮箱地址不符合规范</div>
    <div><label>用户昵称：</label></div>
    <div><input type="text" class="inp" id="InpNickname" ajaxrequest="NickCheck" /></div>
    <div class="tip">只允许汉字、英文字母、阿拉伯数字，最多8个中文字符或者16个英文字符</div>
    <div><label>登录密码：</label></div>
    <div><input type="password" class="inp" id="InpPassword2" /></div>
    <div class="tip">最少6个字符</div>
    <div><label>确认密码：</label></div>
    <div><input type="password" class="inp" id="InpPassword3" /></div>
    <div class="wrong hidden">确认密码与登录密码输入不一致</div>
    <div class="wrong hidden">所有项都不得为空！</div>
    <div><input type="button" class="btn btn-blue" id="BtnRegisterSubmit" value="注册" ajaxrequest="Register" /><input type="button" class="btn btn-gray" value="注册提交中..." ajaxstatus="loading" /></div>
</form>