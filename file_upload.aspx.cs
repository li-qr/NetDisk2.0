using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;

public partial class file_upload : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public class Fileinfo
    {
        public ObjectId _id;//BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId 
        public string infoid { get; set; }
        public string info { set; get; }        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {        
        MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
        MongoDatabase mydb = server.GetDatabase("centerdb");
        MongoCollection mycoll = mydb.GetCollection("fileinfo");       
        if (FileUpload1.HasFile)
        {
            
            HttpPostedFileBase file = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[1]);
            //获取上传文件的长度
            int nFileLen = file.ContentLength;
            //获取上传文件的值
            string nFileName = file.FileName;
            //利用GridFS 创建
            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "file" };
            MongoGridFS fs = new MongoGridFS(mydb, fsSetting);
            byte[] myData = new Byte[nFileLen];
            file.InputStream.Read(myData, 0, nFileLen);
            //调用Write、WriteByte、WriteLine函数时需要手动设置上传时间
            //通过Metadata 添加附加信息
            MongoGridFSCreateOptions option = new MongoGridFSCreateOptions();
            option.UploadDate = DateTime.Now;
            //创建文件，文件并存储数据
            using (MongoGridFSStream gfs = fs.Create(file.FileName, option))
            {
                gfs.Write(myData, 0, nFileLen);
                gfs.Close();
            }
            string key = file.FileName;
             file = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[0]);
            //获取上传文件的长度
            nFileLen = file.ContentLength;
            //获取上传文件的值
             nFileName = file.FileName;
            //利用GridFS 创建
             fsSetting = new MongoGridFSSettings() { Root = "imaginfo" };
             fs = new MongoGridFS(mydb, fsSetting);
            myData = new Byte[nFileLen];
            file.InputStream.Read(myData, 0, nFileLen);
            //调用Write、WriteByte、WriteLine函数时需要手动设置上传时间
            //通过Metadata 添加附加信息
            option = new MongoGridFSCreateOptions();
            option.UploadDate = DateTime.Now;
            //创建文件，文件并存储数据
            string []oi=file.FileName.Split('.');

            using (MongoGridFSStream gfs = fs.Create(key+"."+oi[oi.Length-1], option))
            {
                gfs.Write(myData, 0, nFileLen);
                gfs.Close();
            }
            Fileinfo fil = new Fileinfo();
            fil.infoid = key;
            fil.info = TextBox1.Text;

            try
            {
                mycoll.Insert<Fileinfo>(fil);

            }
            catch { }      
        }
        else {
            HttpPostedFileBase file = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[1]);
            //获取上传文件的长度
            int nFileLen = file.ContentLength;
            //获取上传文件的值
            string nFileName = file.FileName;
            //利用GridFS 创建
            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "file" };
            MongoGridFS fs = new MongoGridFS(mydb, fsSetting);
            byte[] myData = new Byte[nFileLen];
            file.InputStream.Read(myData, 0, nFileLen);
            //调用Write、WriteByte、WriteLine函数时需要手动设置上传时间
            //通过Metadata 添加附加信息
            MongoGridFSCreateOptions option = new MongoGridFSCreateOptions();
            option.UploadDate = DateTime.Now;
            //创建文件，文件并存储数据
            using (MongoGridFSStream gfs = fs.Create(file.FileName, option))
            {
                gfs.Write(myData, 0, nFileLen);
                gfs.Close();
            }
            string key = file.FileName;
            Fileinfo fil = new Fileinfo();
            fil.infoid = key;
            fil.info = TextBox1.Text;

            try
            {
                mycoll.Insert<Fileinfo>(fil);

            }
            catch { }
           
        }
       
    }
}