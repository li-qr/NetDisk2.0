<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_upload.aspx.cs" Inherits="file_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
  <table>
       <script>
           
            </script>
      <tr>
          <td>              
              描述：<asp:TextBox ID="TextBox1" runat="server"  TextMode="MultiLine" Height="300" Width="400"></asp:TextBox>
          </td>          
      </tr>
      <tr>
          <td>
              截图：<asp:FileUpload ID="FileUpload1" runat="server" />
          </td>
      </tr>
      <tr>
          <td>
              文件：<asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="True" />
          </td>
      </tr>
      <tr>
          <td>
              <asp:Button ID="Button1" runat="server" Text="确定上传" OnClick="Button1_Click"  />
          </td>
      </tr>
  </table>
    </form>
</body>
</html>
