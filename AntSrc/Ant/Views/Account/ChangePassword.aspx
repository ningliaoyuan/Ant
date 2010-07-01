<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">修改密码</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box2 change-password">
    	<div class="box-title1">修改密码</div>
    	<div class="box-content">
			<p>新密码至少需要<%: ViewData["PasswordLength"] %>个字符。</p>
            <% using (Html.BeginForm()) { %>
			<%: Html.ValidationSummary(true, "Password change was unsuccessful. Please correct the errors and try again.") %>
            <div class="formstyle">
            	<div class="item">
                    <div class="title"><%: Html.LabelFor(m => m.OldPassword) %><span>*</span></div>
                    <div class="detail">
                        <%: Html.PasswordFor(m => m.OldPassword, new { @class = "inp inp1" }) %>                      
                        <%if (!MvcHtmlString.IsNullOrEmpty(Html.ValidationSummary()))
                          { %>
                            <div class="blank5"></div>
                            <div class="warn"><%: Html.ValidationMessageFor(m => m.OldPassword) %></div> 
                        <%} %>                                
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title"><%: Html.LabelFor(m => m.NewPassword) %><span>*</span></div>
                    <div class="detail">
                        <%: Html.PasswordFor(m => m.NewPassword, new { @class = "inp inp1" }) %>                      
                        <%if (!MvcHtmlString.IsNullOrEmpty(Html.ValidationSummary()))
                          { %>
                            <div class="blank5"></div>
                            <div class="warn"><%: Html.ValidationMessageFor(m => m.NewPassword) %></div> 
                        <%} %>                                
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title"><%: Html.LabelFor(m => m.ConfirmPassword) %><span>*</span></div>
                    <div class="detail">
                        <%: Html.PasswordFor(m => m.ConfirmPassword, new { @class = "inp inp1" }) %>                      
                        <%if (!MvcHtmlString.IsNullOrEmpty(Html.ValidationSummary()))
                          { %>
                            <div class="blank5"></div>
                            <div class="warn"><%: Html.ValidationMessageFor(m => m.ConfirmPassword) %></div> 
                        <%} %>                                
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item noborder">
                    <div class="title">&nbsp;<span></span></div>
                    <div class="detail">
                        <input type="submit" class="btn2 btn-blue" value="确认修改" />
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
