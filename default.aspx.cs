using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
         if (File.Exists(Server.MapPath("~/treexml.xml")))
        { }
        else { Response.Redirect("main.aspx?wrong=缺少管理员配置文件！！！！！！！！！", true); }

         if (Session["user"] == null)
         {             
             us.Text = "游客";
             us.NavigateUrl = "main.aspx";
         }
         else{             
             us.Text = Session["user"].ToString();
             us.NavigateUrl = "#";
            dz.Text = "注销";
            dz.NavigateUrl = "logout.aspx";            
        }
        if (Request.QueryString["type"] != null)
        {
            string type = Request.QueryString["type"];
            mainContent.Src = "grid-view.aspx?type=" + type;

        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (Menu1.SelectedItem.Depth != 0)
        {
            if (Menu1.SelectedItem.Depth == 1)
            {
                mainContent.Src = "grid-view.aspx?type=" + Menu1.SelectedItem.Text;                

            }
            else
            {
                mainContent.Src = "grid-view.aspx?type="+ Menu1.SelectedItem.Text + " " + Menu1.SelectedItem.Parent.Text;            

            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        mainContent.Src = "grid-view.aspx?type="+TextBox1.Text;
    }
    
}