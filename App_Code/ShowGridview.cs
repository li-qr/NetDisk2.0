using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using System.Configuration;

/// <summary>
/// ShowGridview 的摘要说明
/// </summary>
public class ShowGridview
{
	public ShowGridview()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    static public DataTable Show(string key)
    {
        MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
        MongoDatabase mydb = server.GetDatabase("centerdb");
        MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "file" };
       MongoGridFS  fs = new MongoGridFS(mydb,fsSetting);
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("文件名", typeof(string)), new DataColumn("更新时间", typeof(string)), new DataColumn("id", typeof(string)) });
        var query = Query.Matches("filename", ".");
        if (key == "") { return dt; }
        else
        {
            string[] b = key.Split(' ');
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != "")
                {
                    query = Query.And(query, Query.Matches("filename", b[i] + "+"));
                }
            }
        }
        MongoCursor<MongoGridFSFileInfo> mc;
        mc = fs.Find(query);
        foreach (MongoGridFSFileInfo fileinfo in mc)
        {
            if (fileinfo.Name.Substring(fileinfo.Name.Length - 3, 3) != ".ii")
            {
                int flag = 0;
                int run;
                for (run = 0; run < dt.Rows.Count; run++)
                {
                    string s1 = fileinfo.Name;
                    string s2 = dt.Rows[run].ItemArray[0].ToString();
                    if (s1 == s2)
                    {
                        DateTime dt1 = Convert.ToDateTime(fileinfo.UploadDate);
                        DateTime dt2 = Convert.ToDateTime(dt.Rows[run].ItemArray[1]);
                        if (DateTime.Compare(dt1, dt2) > 0)
                        {
                            dt.Rows[run].Delete();
                            dt.Rows.Add(fileinfo.Name, fileinfo.UploadDate, fileinfo.MD5);
                        }
                        flag = 1;
                    }

                }
                if (flag == 0) { dt.Rows.Add(fileinfo.Name, fileinfo.UploadDate, fileinfo.MD5); }
            }
        }
        return dt;
    }
}