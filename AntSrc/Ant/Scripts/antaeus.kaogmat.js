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

});