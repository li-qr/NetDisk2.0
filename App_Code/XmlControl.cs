using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;
using System.IO;

/// <summary>
/// XmlControl 的摘要说明
/// </summary>
    public class XmlControl
    {
      protected string strXmlFile;
      XmlDocument objXmlDoc = new XmlDocument();
      public XmlControl(string XmlFile)
      {
      try
      {
      objXmlDoc.Load(XmlFile);
      }
      catch (System.Exception ex)
      {
      throw ex;
      }
      strXmlFile = XmlFile;
      }
      public DataView GetData(string XmlPathNode)
      {
      //查找数据。返回一个DataView
      DataSet ds = new DataSet();
      StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
      ds.ReadXml(read);
      return ds.Tables[0].DefaultView;
      }
      public void Replace(string XmlPathNode,string Content)
 
      {
          string mainNode = XmlPathNode.Substring(0, XmlPathNode.LastIndexOf("/"));
          XmlNode oldNode = objXmlDoc.DocumentElement.SelectSingleNode(XmlPathNode);
          XmlNode newNode = objXmlDoc.CreateElement(Content);
          
      //更新节点内容。
          objXmlDoc.DocumentElement.SelectSingleNode(mainNode).ReplaceChild(newNode,oldNode);
      }
      public void Delete(string Node)
      { 
      //删除一个节点。
      string mainNode = Node.Substring(0,Node.LastIndexOf("/"));
      try
      {
          objXmlDoc.DocumentElement.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.DocumentElement.SelectSingleNode(Node));
      }
      catch { }
      }
      public void InsertNode(string MainNode,string ChildNode)
      {
      //插入一节点和此节点的一子节点。
      XmlNode objRootNode = objXmlDoc.DocumentElement.SelectSingleNode(MainNode);
      XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
      objRootNode.AppendChild(objChildNode);
      }
      public void InsertElement(string MainNode,string Element,string Attrib,string AttribContent,string Content)
 
      {
      //插入一个节点，带一属性。
      XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
      XmlElement objElement = objXmlDoc.CreateElement(Element);
      objElement.SetAttribute(Attrib,AttribContent);
      objElement.InnerText = Content;
      objNode.AppendChild(objElement);
      }
      public void InsertElement(string MainNode,string Element,string Content)
 
      {
      //插入一个节点，不带属性。
      XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
      XmlElement objElement = objXmlDoc.CreateElement(Element);
      objElement.InnerText = Content;
      objNode.AppendChild(objElement);
 
      }
      public void Save()
 
      {
      //保存文檔。
      try
      {
      objXmlDoc.Save(strXmlFile);
      }
      catch (System.Exception ex)
      {
      throw ex;
      }
      objXmlDoc = null;
      }
 
      }