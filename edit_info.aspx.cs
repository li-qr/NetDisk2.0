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

public partial class edit_info : System.Web.UI.Page
{
     MongoCollection coll;
    protected void Page_Load(object sender, EventArgs e)
    {
        string con = ConfigurationManager.AppSettings["dbserver"];
        MongoServer server = MongoServer.Create(con);
        MongoDatabase mydb = server.GetDatabase("centerdb") ;
        coll = mydb.GetCollection("personinfo");
        var query = Query.Matches("userid", Session["user"]+"?");
        var result = coll.FindOneAs<Users>(query);
        Label7.Text = result.userid;
        txtNickname.Text = result.name;
        txtEmail.Text = result.email;
        txtPhone.Text = result.tel;
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
}