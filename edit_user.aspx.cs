using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
//添加对应mongodb的命名空间
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;
public partial class edit_user : System.Web.UI.Page
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
            string Collection = "personinfo";
            DataTable dt = DBconnect.Connect(IP, Collection);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }


    public class Users
    {
        public ObjectId _id;//BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId 
        public string userid { get; set; }
        public string key { set; get; }
        public string name { set; get; }
        public string tel { set; get; }
        public string email { set; get; }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvr = GridView1.Rows[index];//判断点击的按钮是哪一行
        //GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        //GridViewRow gvr = ((GridViewRow)((Control)(e.CommandSource)).Parent.Parent); 
        string IP = ConfigurationManager.AppSettings["dbserver"];//声明连接数据库的IP     
        if (e.CommandName == "de")//当管理员点击删除是执行的操作
        {
            string name = gvr.Cells[0].Text;
            string Collection = "personinfo";
            DBconnect.Delete(IP, Collection, name);//将存入数据库的申请用户数据删除
        }
        //if (e.CommandName == "ok")//当管理员点击删除是执行的操作
        //{
        //    Users us = new Users();
        //    us.userid = gvr.Cells[0].Text;
        //    us.key = gvr.Cells[1].Text;
        //    us.name = gvr.Cells[2].Text;
        //    us.tel = gvr.Cells[2].Text;
        //    us.email = gvr.Cells[2].Text;
        //    string name = gvr.Cells[0].Text;
        //    string Collection = "registerinfo";
        //    DBconnect.Delete(IP, Collection, name);//将存入数据库的申请用户数据删除
        //    mycoll1.Insert<Users>(us);
        //}
        Response.Redirect("edit_user.aspx", true);
    }
}