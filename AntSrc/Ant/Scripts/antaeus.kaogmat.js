jQuery(document).ready(function($) {

$("*[ajaxstatus='loading']").hide();
	

var Logon = $("#DivLogon").overlay({
	top: 150,
	mask: {color:"#000",loadSpeed:200,opacity:0.5},
	closeOnClick: false
});
$("#LinkLogon").click(function(e){Logon.overlay().load();});

});