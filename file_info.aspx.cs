using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;
using System.Text.RegularExpressions;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Configuration;
public partial class file_info : System.Web.UI.Page
{
    DataTable dt = new DataTable();  
    MongoDatabase mydb;
    MongoGridFS fs;
    MongoCollection mycoll;
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request.QueryString["file"];
                string con = ConfigurationManager.AppSettings["dbserver"];
                MongoServer server = MongoServer.Create(con);
                mydb = server.GetDatabase("centerdb");
                mycoll = mydb.GetCollection("fileinfo");
                MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "imaginfo" };
                fs = new MongoGridFS(mydb, fsSetting);
                var query = Query.Matches("filename", name + "+");
                MongoGridFSFileInfo finfo = fs.FindOne(query);
                fs.Download(MapPath("/temp/Info/") + finfo.Name, finfo.Name);
                Image1.ImageUrl = "temp/Info/" + finfo.Name;
                query = Query.Matches("infoid", name + "+");
                var result = mycoll.FindOneAs<Fileinfo>(query);
        if (!IsPostBack)
        {
            if (Request.QueryString["file"] != null)
            {
                
                TextBox1.Text = result.info;
            }
        }
    }
    public class Fileinfo
    {
        public ObjectId _id;//BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId 
        public string infoid { get; set; }
        public string info { set; get; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.ReadOnly = false;
        Button1.Visible = false;
        Button2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button1.Visible = true;
        Button2.Visible = false;
        TextBox1.ReadOnly = true;
        string name = Request.QueryString["file"]; 
        var query = Query.Matches("infoid", name + "+");
        var result = mycoll.Remove(query);
        Fileinfo i = new Fileinfo();
        i.infoid = name;
        i.info = TextBox1.Text;
        mycoll.Insert<Fileinfo>(i);
    }
}