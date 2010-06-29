var g_param = {};
jQuery(document).ready(function($) {

$("*[ajaxstatus='loading']").hide();

var Logon = $("#DivLogon").overlay({
	top: 150,
	mask: {color:"#000",loadSpeed:200,opacity:0.5},
	closeOnClick: false
});
var Register = $("#DivRegister").overlay({
	top: 100,
	mask: {color:"#000",loadSpeed:200,opacity:0.5},
	closeOnClick: false,
	onLoad:function(){
		if($("#exposeMask:visible").length<=0){
			$("#exposeMask").show();
			$("#DivRegister").css("z-index","9999");
		}
	}
});
var ForgetPassword = $("#DivForgetPassword").overlay({
	top: 150,
	mask: {color:"#000",loadSpeed:200,opacity:0.5},
	closeOnClick: false,
	onLoad:function(){
		$("#exposeMask").show();
		$("#DivForgetPassword").css("z-index","9999");
	}
});
$("#LinkLogon").click(function(e){Logon.overlay().load();});
$("#LinkRegister").click(function(e){Register.overlay().load();});

$("#LinkForgetPassword").click(function(e){
	Logon.overlay().close();
	ForgetPassword.overlay().load();
});
$("#LinkRegister2").click(function(e){
	Logon.overlay().close();	
	Register.overlay().load();
});
//提交登录
$("#BtnLogonSubmit").click(function(e){
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
});
//当光标在文本输入框内失去焦点，做为空判断
$("#InpUsername, #InpPassword").blur(function(){
	var Username = $.trim($("#InpUsername").val());
	var Password = $.trim($("#InpPassword").val());
	if(Username!="" && Password!=""){
		$("#DivLogonEmpty").hide();
	}
});

});