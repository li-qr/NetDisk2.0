<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="use.aspx.cs" Inherits="use" %>

<!DOCTYPE html>

<html lang="zn">
<head id="Head1" runat="server">
    
</head>
<body>   
      <form id="form1"  runat="server">  
       <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left" CellPadding="4" ForeColor="#333333" GridLines="None" Width="750px"  Font-Size="Medium" AllowSorting="True"  Style="margin-bottom: 137px" OnRowCommand="GridView1_RowCommand"  >
                            <%--<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#9ACFE3" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />--%>
            <Columns>
                <asp:BoundField DataField="userid" HeaderText="用户名">
                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="key" HeaderText="密码">
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="昵称">
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="tel" HeaderText="电话">
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="邮箱">
                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                </asp:BoundField>
                <asp:ButtonField Text="删除"  CommandName="de" ControlStyle-Width="35px" />
              
                <asp:ButtonField Text="同意"  CommandName="ok" ControlStyle-Width="35px" />
                
            </Columns>
        </asp:GridView>
 
             
               
        </form>     
      
</body>
</html>
