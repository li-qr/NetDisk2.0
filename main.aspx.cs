using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


public partial class main : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;        
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string code = txtCode.Text;
        //判断用户输入的验证码是否正确
        if (Request.Cookies["CheckCode"].Value == code)
        {
           MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
           MongoDatabase mydb = server.GetDatabase("centerdb");
           MongoCollection  mycoll = mydb.GetCollection("registerinfo");
           MongoCollection mycoll1 = mydb.GetCollection("personinfo");
            var query = new QueryDocument { { "userid", txtUserName.Text } };
            var result = mycoll.FindAs<Users>(query);
            if (result.Count() > 0)
            {
                Response.Write("<script>alert('管理员正在审核！');</script>");                
            }
            else
            {
                result = mycoll1.FindAs<Users>(query);
                if (result.Count() > 0)
                { 
                    BsonDocument bsdc = (BsonDocument)mycoll1.FindOneAs<BsonDocument>(query);                    
                    if (txtUserpass.Text != bsdc[2].RawValue.ToString())
                    {
                        Response.Write("<script>alert('密码错误！');</script>");

                    }
                    else {
                        Session.Remove("user");
                        Session.Remove("group");                       
                        Session["user"] = txtUserName.Text;
                        Response.Redirect("default.aspx"); 
                    }
                }
                else
                {
                    Response.Write("<script>alert('账号不存在或管理员已拒绝申请！');</script>");
                }
            }
        }
        else { 
          Response.Write("<script>alert('验证码错误！');</script>") ;
        }
    }
    
}