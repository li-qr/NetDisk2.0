<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="grid-view.aspx.cs" Inherits="grid_view" %>

<!DOCTYPE html>

<html lang="zn">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>    
       <style type="text/css">  
        .cell
{
            width:0px;
    display:none;
}
        html
         { overflow-x:hidden; }
    </style>   
</head>
<body>   
      <form id="form1"  runat="server">  
          <script>
              function uploa() {
                  info.style.display = "";
                  infoContent.src = "file_upload.aspx";
              }
              function clo() {
                  info.style.display = "none";
                  infoContent.src = "";
              }
              </script>
          <input type="button" id="up" runat="server" value="上传" onclick="uploa()" style="width: 100px; cursor: pointer; background-color: #FFFFFF; border-style: solid; border-color: #333333; border-width: 1px; font-size: medium" />
          <asp:Button ID="Button2" runat="server" Text="批量下载" CssClass="btn" BackColor="#FFFFFF" BorderStyle="Solid" BorderColor="#333333" BorderWidth="1px" Width="100px" ForeColor="#000000" Font-Size="Medium" OnClick="Button2_Click" />              
          <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left" CellPadding="4" ForeColor="#333333" GridLines="None" Width="750px" Font-Size="Medium" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging"   OnRowCommand="GridView1_RowCommand" Style="margin-bottom: 137px" OnPreRender="GridView1_PreRender" >
                            
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="20px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="selectall" runat="server" Text=" " OnCheckedChanged="cbtSelectAll_CheckedChanged" AutoPostBack="True" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="文件名" HeaderText="文件名" ItemStyle-Width="100%">
                                    <ItemStyle Width="350px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="更新时间" HeaderText="更新时间" ItemStyle-Width="100%">
                                    <ItemStyle Width="70px"></ItemStyle>
                                </asp:BoundField>
                               <asp:BoundField DataField="id" HeaderText=""  ControlStyle-CssClass="cell">
                                    <ItemStyle  CssClass="cell"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField ItemStyle-Width="35px">
                                    <ItemTemplate>
                                        <asp:Button ID="Button7" runat="server" BackColor="White" BorderStyle="None" CommandName="查看" CssClass="btn" Font-Size="Medium" Font-Underline="True" Text="查看" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="35px">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="Button4" runat="server" BackColor="White" BorderStyle="None" CommandName="描述" CssClass="btn" Font-Size="Medium" Font-Underline="True" Text="描述" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="35px">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="Button3" runat="server" BackColor="White" BorderStyle="None" CommandName="单个下载" CssClass="btn" Font-Size="Medium" Font-Underline="True" Text="下载" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35" />
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Button ID="Button5" runat="server" Text="删除" CssClass="btn" BackColor="White" BorderStyle="None" Font-Underline="True" Font-Size="Medium" CommandName="删除" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

              <input type="file" id="refile" onchange="javascript:__doPostBack('reUpload','')" runat="server" style="position: absolute; filter: alpha(opacity=0);" size="0" hidden="hidden">
                        <asp:LinkButton ID="reUpload" runat="server" OnClick="reUpload_Click"></asp:LinkButton>
<%--          <input type="file" id="File1" onchange="javascript:__doPostBack('Uploadd','')" runat="server" style="position: absolute; filter: alpha(opacity=0);" size="0" hidden="hidden" aria-multiline="True" aria-multiselectable="True" multiple="multiple">--%>
<%--          <asp:LinkButton ID="Uploadd" runat="server" OnClick="Uploadd_Click"></asp:LinkButton>--%>
               

          <div id="info" runat="server" style="background-color:white; margin-left:80px;margin-top:100px; height:400px;width:600px;position:absolute; display:none">
              <input id="Button1" type="button" value="×" onclick="clo()" />
              <iframe id="infoContent" runat="server" src=""   width="598" height="398" name="infoCOntent" frameborder="2" style="border-style:solid" marginheight="0" marginwidth="0"></iframe>
              </div>
        </form>     
      
</body>
</html>
