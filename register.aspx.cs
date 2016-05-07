using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Text;
using System.Security.Cryptography;

public partial class register : System.Web.UI.Page
{
    MongoServer server;
    MongoDatabase mydb;
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;       
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //调用isNameFormar自定义方法判断用户名输入的是否满足要求
        if (isNameFormar())
        {
            //调用自定义isName方法判断用户名是否已存在
            if (isName())
            {
                //使用Label控件显示提示信息
                labIsName.Text = "用户名已存在！";
                //设置Label控件的颜色
                labIsName.ForeColor = System.Drawing.Color.Red;
               Response.Write("<script>alert('请正确填写信息！')</script>");
            }
            else
            {
                //获取用户填写的会员名
                string userid = txtName.Text;
                //获取用户填写的密码并使用MD5进行加密
                string userPass = txtPass.Text;
                //获取昵称
                string username = txtNickname.Text;
                //获取电话号
                string phone = txtPhone.Text;
                //获取电子邮件地址
                string email = txtEmail.Text;

                Users user = new Users();
                user.userid = userid;
                user.key = userPass;
                user.name = username;
                user.tel = phone;
                user.email = email;               
                try
                {
                    server =  MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
                    mydb = server.GetDatabase("centerdb");
                    MongoCollection mycoll = mydb.GetCollection("registerinfo");
                    mycoll.Insert<Users>(user);
                    Response.Write( "<script>alert('注册成功！等待管理员审核！')</script>");    
                    
                    //清空文本框中的信息              
                }
                catch
                {
                    Response.Write("<script>alert('请正确填写信息！')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('请正确填写信息！')</script>");
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
    protected bool isName()
    {
        ////创建一个布尔型变量并初始化为false;
        bool blIsName = false;
        server = MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
        mydb = server.GetDatabase("centerdb");
        MongoCollection mycoll = mydb.GetCollection("registerinfo");
        MongoCollection mycoll1 = mydb.GetCollection("personinfo");
        var query = new QueryDocument { { "userid", txtName.Text } };
        var result = mycoll.FindAs<Users>(query);
        if (result.Count() > 0)
        {
            blIsName = true;
        }
        else
        {
            result = mycoll1.FindAs<Users>(query);
            if (result.Count() > 0)
            { blIsName = true; }
            else
            {
                blIsName = false;
            }
        }
        //返回布尔值变量
        return blIsName;

    }

    protected bool isNameFormar()
    {
        //创建一个布尔型变量并初始化为false;
        bool blNameFormar = false;
        //设置正则表达式
        Regex re = new Regex("^\\w+$");
        //使用Regex对象中的IsMatch方法判断用户名是否满足正则表达式
        if (re.IsMatch(txtName.Text))
        {
            //设置布尔变量为true
            blNameFormar = true;
            //设置label控件的颜色
            labUser.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            labUser.ForeColor = System.Drawing.Color.Red;
            blNameFormar = false;
        }
        //返回布尔型变量
        return blNameFormar;
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        //判断用户名是否为空
        if (txtName.Text == "")
        {
            //使用Label控件给出提示
            labIsName.Text = "用户名不能为空";
            //设置Label控件的颜色
            labIsName.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            //调用自定义isNameFormar方法判断用户名是否满足格式要求
            if (isNameFormar())
            {
                //调用isName自定义方法判断用户名是否已注册
                if (isName())
                {
                    labIsName.Text = "用户名已存在！";
                    labIsName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    labIsName.Text = "可以注册！";
                    labIsName.ForeColor = System.Drawing.Color.Blue;
                }
            }
            else
            {
                labIsName.Text = "";
            }
        }
    }

  
}