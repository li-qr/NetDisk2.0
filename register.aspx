<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册</title>
    <link  rel="stylesheet" type="text/css" href="Page.css"/>
    <style type="text/css">
        .auto-style6{
             font-size: 16px;
             color: black;
             line-height: 24px;
             font-weight: normal;
             font-family: "黑体";
             width: 119px;
             background:#FFF url(../images/导航栏.png) no-repeat left top;
             vertical-align :top;
             text-align:center;
         }
        .auto-style12 {
            font-size: 16px;
             color: black;
             line-height: 24px;
             font-weight: normal;
             font-family: "黑体";
             width: 119px;
             text-align:center;
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
        
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
     <table style="height: 302px; width: 744px;" align="center">
            <tr>                
                <td rowspan="2">
                    <table style="width: 92%; height: 225px; text-align:center"class="table"align="center">
            <tr>
                <td class="auto-style12">会员名</td>
                <td class="auto-style13">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入会员名。" ControlToValidate="txtName" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtName" runat="server" Width="181px" Height="20px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Width="218px" Font-Size="8pt" >请输入6位数字或字符数字</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">昵 称</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtNickname" runat="server"  Width="182px" Height="20px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Width="218px" Font-Size="8pt" >请输入6~16位由字符数字组成的集合</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">密 码</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtPass" runat="server"  TextMode="Password" Width="182px" Height="20px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Width="218px" Font-Size="8pt" >请输入6~16个字符，区分大小写</asp:Label>
                </td>
            </tr>
                           <tr>
                <td class="auto-style12">密 码</td>
                <td class="auto-style13">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致。" ControlToCompare="txtPass" ControlToValidate="covPass" Display="None" ></asp:CompareValidator>
                    <asp:TextBox ID="covPass" TextMode="Password" runat="server"  Width="182px" Height="20px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Width="218px" Font-Size="8pt" >重复密码</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">电话号码</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtPhone" runat="server"  Width="185px" Height="21px" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="Label3" runat="server" Width="218px" Font-Size="8pt" Height="16px" >请填写手机号码</asp:Label>                
                </td>
            </tr>
             <tr>
                <td class="auto-style12">邮件地址</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtEmail" runat="server"  Width="182px" Height="20px" CssClass="TextBox"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Width="218px" Font-Size="8pt" >请输入有效的邮箱地址</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style5">
                    <asp:Label ID="labIsName" runat="server" Text=""></asp:Label>
            <asp:Label ID="labUser" runat="server" Text=""></asp:Label><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    <asp:Button ID="btnRegister" runat="server" Text="保存"  CssClass="button" align="center" Height="40px" Width="82px" OnClick="btnRegister_Click" />
                    
                </td>
            </tr>
                 
        </table>
    </form>
</body>
</html>
