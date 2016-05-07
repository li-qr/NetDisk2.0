using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//添加对应mongodb的命名空间
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;

/// <summary>
///DBmanage 的摘要说明
/// </summary>
public class DBmanage
{
	public DBmanage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //添加数据库
    static public int DBadd(string IP ,string dbname)
    {
        MongoServer server = MongoServer.Create(IP);
        if (server.DatabaseExists(dbname))//判断数据库是否存在
        {
            return 0;
        }
        else
        {
            MongoDatabase db = server.GetDatabase(dbname);
            db.CreateCollection("yipinjia");
            db.DropCollection("yipinjia");
            return 1;
        }
    }

    static public void DBdel(string IP, string dbname)
    {
        MongoServer server = MongoServer.Create(IP);
        server.DropDatabase(dbname);
    }

    static public string[] Getdbs(string IP)
    {
        MongoServer server = MongoServer.Create(IP);
        IEnumerable<string> database = server.GetDatabaseNames();
        IEnumerator<string> db = database.GetEnumerator();
        string[] dbnames = new string[database.Count()];
        int i = 0;
        while(db.MoveNext())
        {
            dbnames[i] = db.Current.ToString();
            i++;
        }
        return dbnames;
    }

    static public int Colladd(string IP, string dbname, string collname)
    {
        MongoServer server = MongoServer.Create(IP);
        MongoDatabase db = server.GetDatabase(dbname);
        if (db.CollectionExists(collname))//判断数据库是否存在
        {
            return 0;
        }
        else
        {
            db.CreateCollection(collname);
            return 1;
        }
    }

    static public string[] Getcolls(string IP, string dbname)
    {
        MongoServer server = MongoServer.Create(IP);
        MongoDatabase db = server.GetDatabase(dbname);
        IEnumerable<string> Collname = db.GetCollectionNames();
        IEnumerator<string> Coll = Collname.GetEnumerator();
        string[] collnames = new string[Collname.Count()];
        int i = 0;
        while (Coll.MoveNext())
        {
            collnames[i] = Coll.Current.ToString();
            i++;
        }
        return collnames;
    }

    static public void Colldel(string IP, string dbname,string collname)
    {
        MongoServer server = MongoServer.Create(IP);
        MongoDatabase db = server.GetDatabase(dbname);
        db.DropCollection(collname);
    }
}