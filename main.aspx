<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <link  rel="stylesheet" type="text/css" href="Page.css"/>
    <link href="Menu.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="menu.js"></script>
     <style type="text/css">
         .TextBox {}
        .auto-style17 {
             font-size: 16px;
             color: black;
             color: black;
             line-height: 24px;
             font-weight: normal;
             font-family: "黑体";
             width: 119px;
             background:#FFF url(../images/导航栏.png) no-repeat left top;
         }
        .auto-style18 {
            width: 175px;
        }
        .auto-style19 {
            font-size: 14px;
            color: #8AB600;
            color: #8AB600;
            line-height: 24px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 824px;
        }
        .auto-style20 {
            width: 824px;
            text-align: left;
        }
        .auto-style21 {
            height: 1px;
        }
         .auto-style22 {
             width: 50px;
         }
         .auto-style23 {
             width: 119px;
             text-align:right;
         }
         .auto-style24 {
             height: 40px;
         }
         .auto-style25 {
             width: 119px;
             height: 21px;
         }
         .auto-style26 {
             width: 824px;
             text-align: left;
             height: 21px;
         }
         .auto-style27 {
             height: 21px;
         }
         #mainContent {
            height: 745px;
            width: 100%;
        }
         .background
         {
              background:url(images\新闻背景.jpg)
         }
    </style>
   
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
       <!--页头-->
        <table style="font-size:15px; height: 30px; color:White;width: 100%;">
            <tr>
                
            </tr>
        </table>
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
    <table id="list" style="width: 100%; height: 22px;">
        <tr>
            
             <td align="left"  width="50%" >
               
            </td>
           
            <td align="right" width="40%">
                   
                </td>
        </tr>
    </table>


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
                                                <h2>用户登录</h2>
                                                <table border="0">
                                                   <tr>
                <td class="auto-style22">用户名</td>
                <td class="auto-style14" align="left">
                    <asp:TextBox ID="txtUserName" runat="server" Width="129px" Height="22px" CssClass="TextBox" ErrorMessage="用户名必须填写"></asp:TextBox>          
                </td>
            </tr>
            <tr>
                <td class="auto-style22">登录码</td>
                <td class="auto-style14"align="left">
                    <asp:TextBox ID="txtUserpass" runat="server" TextMode="Password" Width="129px" Height="22px" CssClass="TextBox" ErrorMessage="密码必须填写"></asp:TextBox>
                </td>
            </tr>
                         <tr>
                <td class="auto-style22">验证码</td>
                <td class="auto-style14"align="left">
                     <asp:Image ID="Image2" runat="server" Height="30px" src="check_code.aspx" Width="100px" onclick="this.src=this.src+'?'" />                  
                </td>
            </tr>
                                                       <tr>
                <td class="auto-style22"></td>
                <td class="auto-style14"align="left">                   
                   
                     <asp:TextBox ID="txtCode" runat="server"  Width="129px" Height="22px" CssClass="TextBox" align="left"  ErrorMessage="验证码必须填写" ></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style5">
                     <script >
                         function zhuceclick() {
                             content.style.display = "none";
                             mainContent.style.display ="";
                         }
                    </script>
                    <input id="Button2" type="button"  value="注册" class="button"  style="height:40px;width:82px"  onclick="zhuceclick()"/>
<%--                    <asp:Button ID="Button2" runat="server" Text="注册"  CssClass="button" align="left" Height="40px" Width="82px" onclick="javascript:zhuceclick()" />--%>
                    <asp:Button ID="Button1" runat="server" Text="登录" Width="82px" CssClass="button" Height="40px" align="right" OnClick="Button1_Click"  />
                </td>
            </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           
                                        </td>
                                    </tr>
                                </table>
                            </td>
                             
                            <td valign="top" id="news" class="auto-style19">
<iframe runat="server" id="mainContent" name="mainContent1" src="register.aspx"  frameborder="0"  scrolling="yes" marginheight="0" marginwidth="0"  style="display:none"  ></iframe>
                                <table  id="content" width="100%" border="0" cellspacing="0" cellpadding="0" class="background">
 <tr>
                  <td align="center" class="auto-style17">通知公告</td>
                  <td class="auto-style19"><strong></strong></td>
                  <td width="100" height="30"><a href="jwtz.asp"><img src="images/more.png" border="0" style="height: 21px; width: 66px" /></a></td>
                </tr>

<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td height="21" class="auto-style20"><a href="jwtznews.asp?lei1=1712">关于公布xxx的通知</a></td>
                    <td width="135" align="left">2015年12月2日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td height="21" class="auto-style20"><a href="jwtznews.asp?lei1=1714">关于开展xxx的通知</a>&nbsp;&nbsp;</td>
                    <td width="135" align="left">2015年12月9日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td height="21" class="auto-style20"><a href="jwtznews.asp?lei1=1713">关于xxx的通知</a></td>
                    <td width="135" align="left">2015年12月8日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td height="21" class="auto-style20"><a href="jwtznews.asp?lei1=1711">关于公布xxx的通知</a></td>
                    <td width="135" align="left">2015年11月30日</td>
   </tr><tr>
                    <td colspan="3" background="images/bj3.jpg" class="auto-style21"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td class="auto-style26"><a href="jwtznews.asp?lei1=1710">关于公布xxx的通知</a></td>
                    <td width="135" align="left" class="auto-style27">2015年11月30日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>
     <tr>
                    <td colspan="3" background="images/bj3.jpg" class="auto-style24"></td>
                  </tr>
     <tr>
        <td align="center" class="auto-style17">新闻动态</td>
                  <td class="bt2"><strong class="lvz"></strong></td>
                  <td width="100" height="30"><a href="jwxw.asp"><img src="images/more.png" border="0" style="height: 21px; width: 66px" /></a></td>
     </tr>
     <tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td width="817" height="21" class="auto-style20"><a href="jwxwnews.asp?lei1=373">xxx</a></td>
    <td width="138" align="left">2015年12月7日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td width="817" height="21" class="auto-style20"><a href="jwxwnews.asp?lei1=372">xxx</a></td>
    <td width="138" align="left">2015年11月17日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td width="817" height="21" class="auto-style20"><a href="jwxwnews.asp?lei1=371">xxx</a></td>
    <td width="138" align="left">2015年11月13日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td width="817" height="21" class="auto-style20"><a href="jwxwnews.asp?lei1=370">xxx</a></td>
    <td width="138" align="left">2015年11月13日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>


<tr>
                    <td class="auto-style23"><img src="images/04.jpg" width="8" height="10" /></td>
                    <td width="817" height="21" class="auto-style20"><a href="jwxwnews.asp?lei1=369">xxx</a></td>
    <td width="138" align="left">2015年11月9日</td>
   </tr><tr>
                    <td height="1" colspan="3" background="images/bj3.jpg"></td>
                  </tr>
</table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" width="33%" colspan="2" style="width: 66%">
                    
                </td>
            </tr>
        </table>
        
    </div>      
    </form>
    <footer style="background:url(../images/导航栏.png)repeat-x;color:black;height:38px; width:100%;text-align:center">
        版权所有：防灾科技学院 <br />
            Copyright &amp;copy;2015 fzxy.edu.cn.All Right Reserved.
    </footer>
</body>
</html>
