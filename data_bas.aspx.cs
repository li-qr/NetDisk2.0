using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

//添加对应mongodb的命名空间
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;

public partial class data_bas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("not_login.aspx", true);
        }
        else
        {
            string IP = ConfigurationManager.AppSettings["dbserver"];
            //TreeView1 = DBshow.DBnodes(IP);
            MongoServer server = MongoServer.Create(IP);//连接Mongodb服务器
            IEnumerable<string> names = server.GetDatabaseNames();//查询存在的数据库
            //定义TreeView节点
            TreeView1.Nodes.Clear();//删除树的现有节点
            for (int i = 0; i < names.Count<string>(); i++)//对存在的数据库生成节点和子节点
            {
                string name = names.ElementAtOrDefault(i);//获取数据库库的名称
                TreeNode newNode = new TreeNode(name);//定义节点并将数据库的名称显示到对应节点上
                //newNode.Text = name;
                TreeView1.Nodes.Add(newNode);//将节点添加到TreeView1上
                MongoDatabase db = server.GetDatabase(name);//连接到数据库name
                IEnumerable<string> collnames = db.GetCollectionNames();//获取数据库的集合
                IEnumerator<string> coll = collnames.GetEnumerator();//建立循环查找机制
                while (coll.MoveNext())//循环添加数据库字节点
                {
                    string sonname = coll.Current.ToString();//获取集合的名称
                    TreeNode sonNode = new TreeNode(sonname);//定义子节点并将集合的名称显示到对应节点上
                    //sonNode.Text = sonname;
                    TreeView1.Nodes[i].ChildNodes.Add(sonNode);//将子节点节点添加到TreeView上
                }
            }
            if (!IsPostBack)
            {
                string[] dbnames = DBmanage.Getdbs(IP);
                for (int i = 0; i < dbnames.Count(); i++)
                {
                    if (dbnames[i] != "local")
                    {
                        DropDownList1.Items.Add(dbnames[i]);
                    }
                }
                for (int i = 0; i < dbnames.Count(); i++)
                {
                    if (dbnames[i] != "local")
                    {
                        DropDownList2.Items.Add(dbnames[i]);
                    }
                }
                for (int i = 0; i < dbnames.Count(); i++)
                {
                    if (dbnames[i] != "local")
                    {
                        DropDownList3.Items.Add(dbnames[i]);
                    }
                }
            }
        }
        }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string IP = ConfigurationManager.AppSettings["dbserver"];//连接服务器
        string dbname = TextBox1.Text;//获取创建数据库的名称
        int check;
        if (dbname == "")//判断数据库名称是否为空
        {
            Response.Write("<script language='javascript'>alter('数据库名称不能为空！');</script>");//输出提示信息
        }
        else
        {

            check = DBmanage.DBadd(IP, dbname);//添加数据库
            if (check == 0)
            {
                Response.Write("<script language='javascript'>alter('数据库已存在');</script>");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string IP = ConfigurationManager.AppSettings["dbserver"];//连接服务器
        string dbname = DropDownList1.SelectedValue;//获取创建数据库的名称
        DBmanage.DBdel(IP, dbname);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string IP = ConfigurationManager.AppSettings["dbserver"];//连接服务器
        string dbname = DropDownList2.SelectedValue;//获取创建集合所在数据库的名称
        string collname = TextBox2.Text;//获取集合名
        int check;
        if (dbname == "")//判断数据库名称是否为空
        {
            Response.Write("<script language='javascript'>alter('集合名称不能为空！');</script>");//输出提示信息
        }
        else
        {

            check = DBmanage.Colladd(IP, dbname, collname);//添加集合
            if (check == 0)
            {
                Response.Write("<script language='javascript'>alter('集合名已存在');</script>");
            }
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dbname = DropDownList3.SelectedValue;
        string IP = ConfigurationManager.AppSettings["dbserver"];//连接服务器
        string[] collnames = DBmanage.Getcolls(IP, dbname);
        for (int i = 0; i < collnames.Count(); i++)
        {
            if (collnames[i] != "system.indexes")
            {
                DropDownList4.Items.Add(collnames[i]);
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string IP = ConfigurationManager.AppSettings["dbserver"];//连接服务器
        string dbname = DropDownList3.SelectedValue;//获取创建数据库的名称
        string collname = DropDownList4.SelectedValue;
        DBmanage.Colldel(IP, dbname, collname);
    }
}