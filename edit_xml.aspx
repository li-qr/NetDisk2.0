<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_xml.aspx.cs" Inherits="edit_xml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
<asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ImageSet="Arrows">
    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
                <td style="clip: rect(auto, auto, auto, auto); float: left; clear: both;">
                    
                    <asp:Label ID="Label1" runat="server" Text="当 前 节 点 ："></asp:Label><asp:Label ID="TextBox1" runat="server"></asp:Label>
                    <br />            
                          <br />           
                   输入更改信息： <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <br />
                          <br />   
                    <asp:Button ID="Button1" runat="server" Text="删除此节点" OnClick="Button1_Click" />
                          <br /> 
                          <br />     <asp:Button ID="Button2" runat="server" Text="添加同级节点" OnClick="Button2_Click" />
                          <br />   
                          <br />   <asp:Button ID="Button3" runat="server" Text="添加子节点" OnClick="Button3_Click" />
                </td>
            </tr>
        </table>
        
       
    </div>
    </form>
</body>
</html>
