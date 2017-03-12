<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>主页</title>
    <link href="Page.css" rel="stylesheet" type="text/css" />
     <link href="Menu.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="menu.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
        #mainContent {
            height: 745px;
            width: 100%;
        }
        .auto-style18 {
            width: 20%; 
        }
        .auto-style19 {
            width: 413px;
        }
        .auto-style21 {
            width: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!--页头-->
        <table id="list" style="width: 100%; height: 28px; background:url(images/导航栏.png);">
        <tr>
            <td class="auto-style21"  >  
                <img src="images/用户.png" style="width:28px;height:28px;" />
            </td>
             <td align="left"  >
                 <asp:HyperLink ID="us" runat="server"></asp:HyperLink> 
            </td>
           
            <td align="right" >
                    <div id="header">
                        <asp:HyperLink ID="HyperLink1"  NavigateUrl="~/main.aspx" runat="server">首页</asp:HyperLink>  <span class="sep">|</span> <a href="" target="_blank" >
                            帮助</a> <span class="sep">|</span> <asp:HyperLink ID="dz" NavigateUrl="~/main.aspx" runat="server">登陆</asp:HyperLink> <span class="sep">
                             &nbsp; &nbsp; 
                    </div>
                </td>
        </tr>
    </table>

        <%--<table style="font-size:15px; height: 30px; color:White;width: 100%;">
            <tr>
                
            </tr>
        </table>--%>
        <!--搜索-->
        <table class="table-top">
            <tr>
            <td id="Td1" class="auto-style16" valign="center" align="center">
                私人文件柜
            </td>

            </tr>
        </table>
        <!--页中-->
    <!-- 导航栏-->
    


         <table id="table1" class="style1">
        
        <tr>
            <td>
                <hr style="color: White; height: 2px;" />
            </td>
        </tr>
       <!--页中-->
            <tr>
                <td class="td-left">
                    <table id="table3" class="tableleft">
                        <tr>
                            <td valign="top" class="auto-style18">
                                <table id="table4">
                                    <tr>
                                        <td>
                                            <div>
                                                <h2>搜索</h2>
                                                <table border="0" style="text-align:center ;height:38px">
                                                    <tr style="">
                                                        <td class="auto-style1">
                                                            <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="117px"></asp:TextBox>
                                                        </td>
                                                         <td>
                                                             <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" Height="38px" Width="53px"  OnClick="Button1_Click"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="box">
	<h2>导航</h2>
	<ul class="menu">
		<li class="level1">     <a href="#none"></a> 
            </li>
		<li class="level1">
			<a href="edit_info.aspx" target="mainContent">用户管理</a>
			<ul class="level2">
				<li><a href="#none">用户基础信息</a></li>
				<li><a href="#none">用户密码操作</a></li>
				<li><a href="#none">用户操作记录</a></li>
			</ul>
		</li>
		<li class="level1">
			<a href="#none">管理员</a>
			<ul class="level2">
				<li><a href="data_bas.aspx" target="mainContent">数据库管理</a></li>
				<li><a href="edit_user.aspx" target="mainContent">账号管理</a></li>
				<li><a href="use.aspx" target="mainContent">注册账号管理</a></li>
                <li><a href="edit_xml.aspx" target="mainContent">Xml管理</a></li>
			</ul>
		</li>
		<li class="level1">
			<a href="#none">基础数据管理</a>
			<ul class="level2">
				<li><a href="#none">类型管理</a></li>
				<li><a href="#none">时间管理</a></li>
				<li><a href="#none">工区管理</a></li>				
			</ul>
		</li>  		  
		<li class="level1">
			<a href="#none">信息管理</a>
			<ul class="level2">
				<li><a href="#none">同步动态</a></li>
				<li><a href="#none">常见问题</a></li>
				<li><a href="#none">站内消息管理</a></li>      
			</ul>
		</li> 
		<li class="level1">
			<a href="#none">数据统计</a>
			<ul class="level2">
				<li><a href="#none">总体统计</a></li>				
				<li><a href="#none">按日期等统计</a></li>
				<li><a href="#none">按小时统计</a></li>     
			</ul>
		</li> 
	</ul>
</div>
                                                                        <div>
                                                <h2>查询</h2>
                                                <table border="0">
                                                    <tr>
                                                        <td class="auto-style1">
                                                            
                                                             <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/treexml.xml"  XPath="/查询/*"></asp:XmlDataSource>
                      <%--  <asp:TreeView ID="TreeView1" runat="server"  DataSourceID="XmlDataSource1" ExpandDepth="1"  BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="1px" Font-Bold="False" Font-Names="微软雅黑" ForeColor="#333333" Font-Size="Small" EnableTheming="True" NodeIndent="30" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" OnTreeNodeExpanded="TreeView1_TreeNodeExpanded">
                            <RootNodeStyle ChildNodesPadding="20px" />                            
                        </asp:TreeView>--%> 
              <asp:Menu ID="Menu1" runat="server" DataSourceID="XmlDataSource1" StaticSubMenuIndent="16px" StaticDisplayLevels="2" Font-Names="微软雅黑" Font-Size="Small" ForeColor="#333333" Width="168px"   OnMenuItemClick="Menu1_MenuItemClick">
                  <DynamicHoverStyle BackColor="Silver" />
                  <DynamicMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" Width="100px" />
                  <DynamicMenuStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" BackColor="White" />
                  <StaticHoverStyle BorderColor="#333333"  BorderStyle="Solid" BorderWidth="1px" />
                  <StaticMenuItemStyle VerticalPadding="3px" />
        </asp:Menu>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" class="auto-style19">
                                <iframe runat="server" id="mainContent" name="mainContent" src="grid-view.aspx"  frameborder="0"
                                      scrolling="yes" marginheight="0" marginwidth="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" width="33%" colspan="2" style="width: 66%">
                    <table>
                        <tr>
                            <td>
                               
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <footer style="background:url(../images/导航栏.png) repeat-x;color:black;height:38px; width:100%;text-align:center">
        版权所有：防灾科技学院 <br />
            Copyright &amp;copy;2015 fzxy.edu.cn.All Right Reserved.
    </footer>
</body>
   
</html>
