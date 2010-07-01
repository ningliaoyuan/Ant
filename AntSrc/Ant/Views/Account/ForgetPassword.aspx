<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.ForgetPasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">忘记密码</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box2 forget-password">
    	<div class="box-title1">忘记密码</div>
    	<div class="box-content">
        	<p>请在下面输入您注册时使用的邮箱，我们将向您的邮箱发送确认邮件。如果还没有账户，请点击<a class="LinkRegister">这里</a>注册。</p>
            <% using (Html.BeginForm()) { %>
        	
        	<div class="formstyle">
                <div class="item">
                    <div class="title">注册邮箱<span>*</span></div>
                    <div class="detail">
                        <%: Html.TextBoxFor(m => m.Email, new { @class = "inp inp1" })%>
                        
                        <%if (!MvcHtmlString.IsNullOrEmpty(Html.ValidationSummary()))
                          { %>
                            <div class="blank5"></div>
                            <div class="warn">
                                <%: Html.ValidationSummary(true, "Send password email was unsuccessful. Please correct the errors and try again.")%>
                                <%: Html.ValidationMessageFor(m => m.Email)%>
                            </div> 
                        <%} %>                                
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item noborder">
                      <div class="title">&nbsp;<span></span></div>
                      <div class="detail">
                          <input type="submit" class="btn2 btn-blue" value="发送邮件" />
                      </div>
                      <div class="clear"></div>  
                  </div>
        	</div>
    		<% } %>
        </div>
    </div>
</div>
<div class="right">
	<div class="box3">ds</div>
</div>
<div class="clear"></div>
</asp:Content>
