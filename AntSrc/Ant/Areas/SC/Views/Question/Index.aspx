<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Ant.Models.Questions.Question>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="left">
	<div class="box-tip">题库中共有GMAT&nbsp;SC题目<b>99999</b>道</div>
    <div class="box2 classify">
    	<div class="box-title1">题目筛选</div>
    	<div class="box-content">
        	<div class="fliter">
            	<div class="label">题目价值：</div>
                <ul>
                	<li class="selected">不限</li>
                    <li><a href="#">4.0以上</a></li>
                    <li><a href="#">3.0至3.9</a></li>
                    <li><a href="#">2.0至2.9</a></li>
                    <li><a href="#">2.0以下</a></li>
                </ul>
                <div class="blank5 clear"></div>
                <div class="label">题目来源：</div>
                <ul>
                	<li class="selected">不限</li>
                    <li><a href="#">GWD</a></li>
                    <li><a href="#">OG</a></li>
                    <li><a href="#">OG10th</a></li>
                    <li><a href="#">OG11th</a></li>
                    <li><a href="#">OG12th</a></li>
                    <li><a href="#">PREP</a></li>
                </ul>
                <div class="clear"></div>
            </div>
        </div>    
    </div>
    <div class="blank5"></div>
    <div class="box2 list">
    	<div class="box-title2">
        	<div class="sort">
                <span>排序：</span>
                <ul>
                    <li class="selected"><a href="#">更新时间</a></li>
                    <li><a href="#">浏览量</a></li>
                    <li><a href="#">回复数</a></li>
                </ul>
                <div class="clear"></div>
            </div>
        </div>
    	<div class="box-content">
			<div class="item item-hover">
            	<div class="info">
                	<a href="#">SC-10203</a>
                    <i>来自于<span>GWD</span></i>
                    <i>浏览量<span>10000</span></i>
                    <i>回复数<span>10000</span></i>
                    <b>更新于<span>2010年7月1日</span></b>
                    <div class="clear"></div>
                </div>
                
                <div class="value"><b>3.9</b><span>/5</span><i>题目价值</i></div>
                <div class="text"><p>Your use of Google's products, software, services and web sites (referred to collectively as the "Services" in this document and excluding any services provided to you by Google under a separate written agreement) is subject to the terms of a legal agreement between you and Google. "Google" means Google Inc., whose principal place of business is at 1600 Amphitheatre Parkway, Mountain View, CA 94043, United States. This document explains how the agreement is made up, and sets out some of the terms of that agreement.</p></div>
            	<div class="clear"></div>
            </div>
            <div class="item">
            	<div class="info">
                	<a href="#">SC-10203</a>
                    <i>来自于<span>GWD</span></i>
                    <i>浏览量<span>10000</span></i>
                    <i>回复数<span>10000</span></i>
                    <b>更新于<span>2010年7月1日</span></b>
                    <div class="clear"></div>
                </div>
                
                <div class="value"><b>3.9</b><span>/5</span><i>题目价值</i></div>
                <div class="text"><p>Your use of Google's products, software, services and web sites (referred to collectively as the "Services" in this document and excluding any services provided to you by Google under a separate written agreement) is subject to the terms of a legal agreement between you and Google. "Google" means Google Inc., whose principal place of business is at 1600 Amphitheatre Parkway, Mountain View, CA 94043, United States. This document explains how the agreement is made up, and sets out some of the terms of that agreement.</p></div>
            	<div class="clear"></div>
            </div>
            <div class="item">
            	<div class="info">
                	<a href="#">SC-10203</a>
                    <i>来自于<span>GWD</span></i>
                    <i>浏览量<span>10000</span></i>
                    <i>回复数<span>10000</span></i>
                    <b>更新于<span>2010年7月1日</span></b>
                    <div class="clear"></div>
                </div>
                
                <div class="value"><b>3.9</b><span>/5</span><i>题目价值</i></div>
                <div class="text"><p>Your use of Google's products, software, services and web sites (referred to collectively as the "Services" in this document and excluding any services provided to you by Google under a separate written agreement) is subject to the terms of a legal agreement between you and Google. "Google" means Google Inc., whose principal place of business is at 1600 Amphitheatre Parkway, Mountain View, CA 94043, United States. This document explains how the agreement is made up, and sets out some of the terms of that agreement.</p></div>
            	<div class="clear"></div>
            </div>
        </div>    
    </div>
</div>
<div class="right">
	<div class="box3">ds</div>
</div>
<div class="clear"></div>
</asp:Content>
