// Antaeus.AJAX
// 这里是AJAX的主控调用相关函数

//AJAX的全局设定
$.ajaxSetup({
	async    : true,
	cache    : false,
	dataType : "text",
	timeout  : 5000,
	error    : function(XMLHttpRequest, textStatus, errorThrown){
		var s1 = "";
		var s2 = "你对于"+this.url+"的请求失败。";
		if(textStatus=="timeout")     s1="因为超时，";
		if(textStatus=="error")       s1="因为其它错误，";
		if(textStatus=="notmodified") s1="因为请求页面无变化，";
		if(textStatus=="parsererror") s1="因为请求地址不存在，";
		alert(s1+s2);
		if(g_param.ajaxEnduringObj!=null && typeof(g_param.ajaxEnduringObj)=="object")	ajaxLoading(g_param.ajaxEnduringObj);
	}
});

//所有AJAX的直接请求URL判断与控制
var ajaxFunction = {};
ajaxFunction["Logon"] = function(param, callback){$.post("/Account/AjaxLogon/",{Username:param.un, Password: param.psd, RememberMe: param.remember==1?'true':'false'}, callback);};
ajaxFunction["Register"] = function(param, callback){$.post("/Account/AjaxRegister/",{Email:param.email, Username: param.nick, Password: param.psd, ConfirmPassword:param.cpsd}, callback);};
ajaxFunction["EmailCheck"] = function (param, callback) { $.get("/Account/AjaxEmailCheck", { Email: param.email }, callback); };
ajaxFunction["NickCheck"] = function (param, callback) { $.get("/Account/AjaxNickCheck", { Username: param.nick }, callback); };
ajaxFunction["LogonStatus"] = function (param, callback) { $.get("/Account/AjaxPartLogon", callback); };

//Refresh函数用于调用AJAX来自我刷新
function ajaxRefresh(obj, param, callback) {
    var f = obj.attr("ajaxrefresh");
    obj.html("loading...");
    ajaxFunction[f](param, function(data) { 
		obj.html(data);
		if(typeof(callback)=="function") callback(); 
	});
}

//obj发起请求的html上的obj
//param要请求的url相关需要的参数
//callback请求结束成功后要执行的函数
//error请求失败后要执行的函数
function ajaxRequest(obj,param,callback,error){
	//将主控元素写入全局变量，这个主要是给在任何地方控制出错回滚用的
	g_param.ajaxEnduringObj = obj;
	if(obj.attr("ajaxrequest")!=null && obj.attr("ajaxrequest")!=""){		
		//发起请求的obj进入loading状态
		ajaxLoading(obj);
		//执行并获得ajax请求的结果
		ajaxFunction[obj.attr("ajaxrequest")](param,function(data){
			//请求结束了返回非loading状态
			ajaxLoading(obj);
			//判断请求返回的结果
			if(data.substring(0,6)=="error:"){
				if(error==null || typeof(error)!="function"){
					alert(data.replace("error:",""));
				}else{
					error(data.replace("error:",""));
				}
			}else{
				callback(data);
			}
		});	
	}
}

//函数ajaxLoading用于执行让ajax请求的主控元素进入loading状态或者回滚
function ajaxLoading(obj){
	//从全局变量中获得主控元素
	//var obj=g_param.ajaxEnduringObj;
	//判断主控元素有没有loading装态
	if(obj.next().attr("ajaxstatus")=="loading"){
		obj.next().toggle();
		obj.toggle();
	}
}


