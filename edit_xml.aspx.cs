using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
public partial class edit_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("not_login.aspx", true);
        }
        else
        {
            datebind();
        }
    }
    protected void datebind()
    {
        if (File.Exists(Server.MapPath("~/treexml.xml")))
        {
            XmlDataSource xmldata = new XmlDataSource();
            xmldata.DataFile = Server.MapPath("~/treexml.xml");
            xmldata.XPath = "/查询/*";
            TreeView1.DataSource = xmldata;
            TreeView1.DataBind();
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TextBox1.Text = TreeView1.SelectedNode.ValuePath.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strXmlFile = Server.MapPath("treexml.xml");
        XmlControl xmlTool = new XmlControl(strXmlFile);
        xmlTool.Delete(TextBox1.Text.ToString());
        xmlTool.Save();
        datebind();
        Response.Redirect(Request.Url.ToString()); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.ToString()=="")
        {
            TextBox1.Text = "/请选择一个节点！！";
        }
        else{
        string strXmlFile = Server.MapPath("treexml.xml");
        XmlControl xmlTool = new XmlControl(strXmlFile);
        string mainnode=TextBox1.Text.ToString().Substring(0,TextBox1.Text.ToString().LastIndexOf("/"));
        xmlTool.InsertNode(mainnode, TextBox2.Text);
        xmlTool.Save();
        datebind();
        Response.Redirect(Request.Url.ToString()); 
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string strXmlFile = Server.MapPath("treexml.xml");
        XmlControl xmlTool = new XmlControl(strXmlFile);
        xmlTool.InsertNode(TextBox1.Text, TextBox2.Text);
        xmlTool.Save();
        datebind();
        Response.Redirect(Request.Url.ToString()); 
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string strXmlFile = Server.MapPath("treexml.xml");
        XmlControl xmlTool = new XmlControl(strXmlFile);
        xmlTool.Replace(TextBox1.Text,TextBox2.Text);
        xmlTool.Save();
        datebind();
        Response.Redirect(Request.Url.ToString()); 
    }
}