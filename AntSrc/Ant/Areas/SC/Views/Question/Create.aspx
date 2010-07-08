<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Ant.Models.Questions.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box2 change-password">
    	<div class="box-title1">创建问题</div>
    	<div class="box-content">
            <div class="formstyle">
            	<div class="item">
                    <div class="title">题目来源<span>*</span></div>
                    <div class="detail">
                        <select class="inp inp1">
                            <option selected="selected">GWD</option>
                            <option>OG10th</option>
                            <option>OG11th</option>
                            <option>OG12th</option>
                            <option>Prep</option>
                            <option>其它</option>
                        </select>
                    </div>
                    <div class="clear"></div>                        
                </div>
            	<div class="item">
                    <div class="title">问题内容<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">选项A<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa" style="height:60px;"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">选项B<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa" style="height:60px;"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">选项C<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa" style="height:60px;"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">选项D<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa" style="height:60px;"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">选项E<span>*</span></div>
                    <div class="detail">
                        <textarea class="textarea inp1" id="aaa" style="height:60px;"></textarea>                               
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item">
                    <div class="title">正确答案<span>*</span></div>
                    <div class="detail">
                        <select class="inp inp1">
                            <option selected="selected">A</option>
                            <option>B</option>
                            <option>C</option>
                            <option>D</option>
                            <option>E</option>
                        </select>
                    </div>
                    <div class="clear"></div>                        
                </div>
                <div class="item noborder">
                    <div class="title">&nbsp;<span></span></div>
                    <div class="detail">
                        <input type="submit" class="btn2 btn-blue" value="确认提交" />
                    </div>
                    <div class="clear"></div>  
                </div>
            </div>
        </div>
    </div>
</div>
<div class="right">
	<div class="box3">ds</div>
</div>
<div class="clear"></div>

<!--这里下面的都是不要的了-->

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Content) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Content) %>
                <%: Html.ValidationMessageFor(model => model.Content) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ask) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ask) %>
                <%: Html.ValidationMessageFor(model => model.Ask) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Options) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Options) %>
                <%: Html.ValidationMessageFor(model => model.Options) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Solution) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Solution) %>
                <%: Html.ValidationMessageFor(model => model.Solution) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Answer) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Answer) %>
                <%: Html.ValidationMessageFor(model => model.Answer) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Source) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Source) %>
                <%: Html.ValidationMessageFor(model => model.Source) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Type) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Type) %>
                <%: Html.ValidationMessageFor(model => model.Type) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Rate) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

