<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"   CodeFile="data_bas.aspx.cs" Inherits="data_bas" %>

<!DOCTYPE html>

<html lang="zn">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>   
</head>
<body>   
      <form id="form1"  runat="server">      
    <table>
        <tr>
            <td >
                <asp:TreeView ID="TreeView1" runat="server" Height="209px" Width="179px">
                </asp:TreeView>
            </td>
            <td >
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="添加数据库："></asp:Label>
                            <br/>
                            <br/>
                            <asp:TextBox ID="TextBox1" runat="server" Width="260px"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Height="18px" onclick="Button1_Click" 
                                Text="确定" Width="70px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br/>
                            <asp:Label ID="Label2" runat="server" Text="删除数据库："></asp:Label>
                            <br/>
                            <br/>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                Height="19px" Width="263px">
                            </asp:DropDownList>
                            <asp:Button ID="Button2" runat="server" Text="确定" Width="72px" 
                                onclick="Button2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br/>
                            <asp:Label ID="Label3" runat="server" Text="在数据库："></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                Height="19px" Width="263px">
                            </asp:DropDownList>
                            <br/>
                            <br/>
                            <asp:Label ID="Label4" runat="server" Text="添加集合："></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Width="214px"></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" Text="确定" Width="72px" 
                                onclick="Button3_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br/>
                        <asp:Label ID="Label5" runat="server" Text="在数据库："></asp:Label>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                                Height="19px" Width="263px" onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br/>
                            <br/>
                            <asp:Label ID="Label6" runat="server" Text="删除集合："></asp:Label>
                            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                Height="20px" Width="225px">
                            </asp:DropDownList>
                            <asp:Button ID="Button4" runat="server" Text="确定" Width="72px" 
                                onclick="Button4_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
  </form>     
      
</body>
</html>


