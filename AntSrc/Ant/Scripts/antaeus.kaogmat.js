var g_param = {};
//Popup的全局变量设计
g_param.overlay_mask = {color:"#000",loadSpeed:200,opacity:0.5};
jQuery(document).ready(function($) {

$("*[ajaxstatus='loading']").hide();

//定义俩个Popup
var Logon = $("#DivLogon").overlay({top:150,mask:g_param.overlay_mask,closeOnClick:false});
var Register = $("#DivRegister").overlay({
	top:100,mask:g_param.overlay_mask,closeOnClick: false,
	onLoad:function(){if($("#exposeMask:visible").length<=0){$("#exposeMask").show();$("#DivRegister").css("z-index","9999");}}
});
//俩个Popup的四个触发方式
$("#LinkLogon").click(function(e){Logon.overlay().load();});
$(".LinkRegister").click(function(e){Register.overlay().load();});
$("#LinkRegister2").click(function(e){Logon.overlay().close();Register.overlay().load();});

//提交登录
var LogonSubmit = function(){
	var Username = $.trim($("#InpUsername").val());
	var Password = $.trim($("#InpPassword").val());
	var RememberMe = ($("#ChkRemember:checked").length>0)?1:0;
	//首先判断不为空
	if(Username!="" && Password!=""){
		ajaxRequest(
			$(this),
			{un:Username,psd:Password,remember:RememberMe},
			function(){
				//成功的话
				//执行ajax刷新登录区域
				//TODO
				//ajaxRefresh
				//最后关闭Popup
				Logon.overlay().close();
			},
			function(error){
				//判断这个文本的出错信息里面是用户名错还是密码错
				var temp = (error.indexOf("密码")>0)?"#InpPassword":"#InpUsername";
				$(temp).parent().next().html(error).show();
			}
		);
	}else{
		$("#DivLogonEmpty").show();
	}
};
$("#BtnLogonSubmit").bind("click",LogonSubmit);
$("#InpUsername, #InpPassword").keyup(function(event){if(event.keyCode==13)LogonSubmit();});
//当光标在文本输入框内失去焦点，做为空判断
$("#InpUsername, #InpPassword").blur(function(){
	var Username = $.trim($("#InpUsername").val());
	var Password = $.trim($("#InpPassword").val());
	if(Username!="" && Password!=""){
		$("#DivLogonEmpty").hide();
	}
});



});