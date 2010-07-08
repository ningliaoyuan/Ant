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
$(".LinkLogon").click(function(e){Logon.overlay().load();});
$(".LinkRegister").click(function(e){Register.overlay().load();});
$("#LinkRegister").click(function(e){Logon.overlay().close();Register.overlay().load();});

//提交登录
var LogonSubmit = function(){
	var Username = $.trim($("#InpUsername").val());
	var Password = $.trim($("#InpPassword").val());
	var RememberMe = ($("#ChkRemember:checked").length>0)?1:0;
	//首先判断不为空
	if(Username!="" && Password!=""){
		ajaxRequest(
			$("#BtnLogonSubmit"),
			{un:Username,psd:Password,remember:RememberMe},
			function(){
				//执行ajax刷新登录区域
				ajaxRefresh($("#LogonStatus"),{});
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
		alert("ee");
		$("#DivLogonEmpty").show();
	}
};
$("#BtnLogonSubmit").bind("click",LogonSubmit);
$("#InpUsername, #InpPassword").keyup(function(event){if(event.keyCode==13){LogonSubmit();}});
//当光标在文本输入框内失去焦点，做为空判断
$("#InpUsername, #InpPassword").blur(function(){
	var Username = $.trim($("#InpUsername").val());
	var Password = $.trim($("#InpPassword").val());
	if(Username!="" && Password!=""){
		$("#DivLogonEmpty").hide();
	}
});

var GetStringLength = function(strTemp){  
	var i,sum;  
	sum=0;  
	for(i=0;i<strTemp.length;i++){  
		if((strTemp.charCodeAt(i)>=0) && (strTemp.charCodeAt(i)<=255)){
			sum=sum+1;
		}else{
			sum=sum+2;
		}
	}  
	return sum;  
};
var RegisterSubmit = function(){
	var Email = $.trim($("#InpEmail").val());
	var Nickname = $.trim($("#InpNickname").val());
	var Password = $.trim($("#InpPassword2").val());
	var RePassword = $.trim($("#InpPassword3").val());
	//为空判断
	if(Email=="" || Nickname=="" || Password=="" || RePassword=="")	{
		$("#BtnRegisterSubmit").parent().prev().html("所有项都不能为空！");
		$("#BtnRegisterSubmit").parent().prev().show();
	}else{
		//不为空则隐藏为空信息
		$("#BtnRegisterSubmit").parent().prev().hide();	
		//判断密码重复度
		if(Password!=RePassword){
			$("#InpPassword3").parent().next().show();
		}else{
			$("#InpPassword3").parent().next().hide();
			//验证邮箱地址
			if(!/(\S)+[@]{1}(\S)+[.]{1}(\w)+/.test(Email)){
				$("#InpEmail").parent().next().html("邮箱地址不符合规范");
				$("#InpEmail").parent().next().show();
			}else{
				$("#InpEmail").parent().next().hide();
				//判断昵称长度
				if(GetStringLength(Nickname)>16){
					$("#InpNickname").parent().next().removeClass("tip").addClass("wrong");
				}else{
					$("#InpNickname").parent().next().addClass("tip").removeClass("wrong");
					//判断密码长度
					if(Password.length<6){
						$("#InpPassword2").parent().next().removeClass("tip").addClass("wrong");
					}else{
						$("#InpPassword2").parent().next().addClass("tip").removeClass("wrong");
						//判断了这么多之后，丫的终于开始做提交了！！！
						ajaxRequest(
							$(this),
							{email:Email,nick:Nickname,psd:Password,cpsd:RePassword},
							function(){
								//执行ajax刷新登录区域
								ajaxRefresh($("#LogonStatus"),{});
								//最后关闭Popup
								Register.overlay().close();
							},
							function(error){
								$("#BtnRegisterSubmit").parent().prev().html(error);
								$("#BtnRegisterSubmit").parent().prev().show();
							}
						);
					}
				}
				
			}
		}
	}
};
$("#BtnRegisterSubmit").bind("click",RegisterSubmit);
$("#InpEmail").blur(function(){
	var o = $(this);
	var v = o.val();
	if(!/(\S)+[@]{1}(\S)+[.]{1}(\w)+/.test(v)){
		o.parent().next().html("邮箱地址不符合规范");
		o.parent().next().show();		
	}else{
		ajaxRequest(o,{email:v},function(){o.parent().next().hide();},
			function(error){
				o.parent().next().html("邮箱地址已经被注册！");
				o.parent().next().show();
			}
		);
	}
});
$("#InpNickname").blur(function(){
	var o = $(this);
	var v = o.val();
	if(GetStringLength(v)>16){
		o.parent().next().html("只允许汉字、英文字母、阿拉伯数字，最多8个中文字符或者16个英文字符");
		o.parent().next().removeClass("tip").addClass("wrong");
	}else{
		ajaxRequest(o,{nick:v},function(){o.parent().next().addClass("tip").removeClass("wrong");},
			function(error){
				o.parent().next().html("昵称已经被注册！");
				o.parent().next().show();
			}
		);
	}
});

//Question Index页面list的hover效果
$(".list .item").mouseover(function(){
	$(this).addClass("item-hover");
	$(this).children(".text").css("height","auto");
}).mouseout(function(){
	$(this).removeClass("item-hover");
	$(this).children(".text").css("height","50px");
});

});