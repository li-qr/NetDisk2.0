using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

//添加对应mongodb的命名空间
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Builders;
/// <summary>
///DBshow 的摘要说明
/// </summary>
public class DBshow
{
	public DBshow()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    static public TreeView DBnodes(string IP)
    {
        TreeView view =new TreeView();
        MongoServer server = MongoServer.Create(IP);//连接Mongodb服务器
        IEnumerable<string> names = server.GetDatabaseNames();//查询存在的数据库
        TreeNode newNode = new TreeNode();//定义TreeView节点
        TreeNode sonNode = new TreeNode();//定义子节点    
        for (int i = 0; i < names.Count<string>(); i++)//对存在的数据库生成节点和子节点
        {
            string name = names.ElementAtOrDefault(i);//获取数据库库的名称
            newNode.Text = name;//将数据库的名称显示到对应节点上
            view.Nodes.Add(newNode);//将节点添加到TreeView上
            MongoDatabase db = server.GetDatabase(name);//连接到数据库name
            IEnumerable<string> collnames = db.GetCollectionNames();//获取数据库的集合
            IEnumerator<string> coll = collnames.GetEnumerator();//建立循环查找机制
            while (coll.MoveNext())//循环添加数据库字节点
            {
                string sonname = coll.Current.ToString();//获取集合的名称
                sonNode.Text = sonname;//将集合的名称显示到对应节点上
                view.Nodes[i].ChildNodes.Add(sonNode);//将子节点节点添加到TreeView上
            }
        }
        return view;
    }
}