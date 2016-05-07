<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_info.aspx.cs" Inherits="file_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    <table>
       
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server"  ImageUrl="images/用户.png"/>
            </td>
            <td>
                <asp:TextBox ID="TextBox1"  ReadOnly="true" runat="server" TextMode="MultiLine" Height="300" Width="400" BorderWidth="0" ></asp:TextBox>
                <br/>
               <asp:Button ID="Button1" runat="server" Text="编辑"  OnClick="Button1_Click" /> <asp:Button ID="Button2" runat="server"   Visible="false" Text="完成"  OnClick="Button2_Click"/>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
