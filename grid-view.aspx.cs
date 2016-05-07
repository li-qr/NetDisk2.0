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
using Aspose.Words;
using Aspose.Cells;

public partial class grid_view : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    MongoCursor<MongoGridFSFileInfo> mc;
    MongoDatabase mydb;
    MongoGridFS fs;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("文件名", typeof(string)), new DataColumn("更新时间", typeof(string)), new DataColumn("id", typeof(string)) });
           
            MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["dbserver"]);
            mydb = server.GetDatabase("centerdb");
            fs = new MongoGridFS(mydb);
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("not_login.aspx",true);
            //}
            if (!IsPostBack)
            {

                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"];
                    //gridshow(type);
                    GridView1.DataSource = ShowGridview.Show(type);
                    GridView1.DataBind();
                }
            }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView1.PageIndex = e.NewPageIndex;
       Server.Transfer("grid-view.aspx?type=" +Request.QueryString["type"] , true);
    }
    protected void cbtSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ((CheckBox)(GridView1.HeaderRow.Cells[0].FindControl("selectall"))).Checked;
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            ((CheckBox)(gvRow.Cells[0].FindControl("CheckBox1"))).Checked = isChecked;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "单个下载")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent; 
            DownFile(gvr.Cells[3].Text, gvr.Cells[1].Text);
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(Request.UserHostAddress);      //根据目标ip地址的获取ip对象

            System.Net.IPHostEntry ihe = System.Net.Dns.GetHostEntry(ip);

        } if (e.CommandName == "描述")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent; 
            info.Style.Remove("display");
            info.Style.Add("display","bilck");
            infoContent.Src = "file_info.aspx?file="+gvr.Cells[1].Text;

        }
        if (e.CommandName == "删除")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent; ;
            var manfilename = gvr.Cells[3].Text;
            var query = Query.EQ("md5", manfilename);
            var fsinfo = mydb.GridFS;
            fsinfo.Delete(query);
            GridView1.DataSource=ShowGridview.Show( "");
            GridView1.DataBind();
        }
        if (e.CommandName == "查看")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent; ;
            var manfilename = gvr.Cells[3].Text;
            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "file" };
            MongoGridFS fs = new MongoGridFS(mydb, fsSetting);           
            var query = Query.EQ("md5", manfilename);
            fs.Download(MapPath("/temp/") + gvr.Cells[1].Text, query);
            System.IO.FileInfo file = new System.IO.FileInfo(MapPath("/temp/") + gvr.Cells[1].Text);
            if (file.Extension == ".doc" || file.Extension == ".docx" || file.Extension == ".DOC" || file.Extension == ".DOCX")//|| file.Extension == "xls" || file.Extension == "xlsx")
            {
               
                Aspose.Words.Document awd = new Aspose.Words.Document(MapPath("/temp/") + gvr.Cells[1].Text);
                awd.Save(MapPath("/temp/" + manfilename + ".pdf"), Aspose.Words.SaveFormat.Pdf);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/web/viewer.html?file=/temp/" + manfilename + ".pdf'" + ",'_blank')</script>");
            }
            if (file.Extension == ".xls" || file.Extension == ".xlsx" || file.Extension == ".XLS" || file.Extension == ".XLSX")
            {
                
                Workbook wb = new Workbook(MapPath("/temp/") + gvr.Cells[1].Text);
               
                wb.Save(MapPath("/temp/" + manfilename + ".html"), Aspose.Cells.SaveFormat.Html);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/temp/" + manfilename + ".html'" + ",'_blank')</script>");
            }
            if (file.Extension == ".pdf" || file.Extension == ".PDF")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/web/viewer.html?file=/temp/" + gvr.Cells[1].Text + "','_blank')</script>");
            }
            if (file.Extension == ".txt" || file.Extension == ".TXT")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/temp/" + gvr.Cells[1].Text + "','_blank')</script>");
            }
            if (file.Extension == ".bmp" || file.Extension == ".BMP" || file.Extension == ".jpg" || file.Extension == ".jpeg" || file.Extension == ".JPG" || file.Extension == ".JPEG" || file.Extension == ".gif" || file.Extension == ".GIF" || file.Extension == ".png" || file.Extension == ".PNG")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/temp/" + gvr.Cells[1].Text + "','_blank')</script>");
            }
        }
    }
    public void DownFile(string dowfilename, string fnme)
    {
        if (dowfilename != null)
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(Request.UserHostAddress);      //根据目标ip地址的获取ip对象
           System.Net.IPHostEntry ihe = System.Net.Dns.GetHostEntry(ip);
            //获取图片名
            MongoGridFSSettings fsSetting = new MongoGridFSSettings() { Root = "file" };
            //通过文件名去数据库查值
            MongoGridFS fs = new MongoGridFS(mydb, fsSetting);
            //方法一，很简洁
            MemoryStream iee = new MemoryStream();
            using (ZipOutputStream s = new ZipOutputStream(iee))
            {
               
                s.SetLevel(4);
                if (dowfilename.IndexOf('|') > 0)
                {
                    string[] temp = dowfilename.Split('|');
                    string[] trmp1 = fnme.Split('|');
                    for (int t = 0; t < temp.Length - 1; t++)
                    {
                        // MongoGridFSFileInfo gfInfo = new MongoGridFSFileInfo(fs, temp[t]);
                        MemoryStream ie = new MemoryStream();
                        var query = Query.EQ("md5", temp[t]);
                        fs.Download(ie, query);
                        ZipEntry entry = new ZipEntry(trmp1[t]);
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        s.Write(ie.GetBuffer(), 0, (int)ie.Length);
                    }
                }
                else
                {
                    //    MongoGridFSFileInfo gfInfo = new MongoGridFSFileInfo(fs, dowfilename);
                    MemoryStream ie = new MemoryStream();
                    var query = Query.EQ("md5", dowfilename);
                    fs.Download(ie, query);
                    ZipEntry entry = new ZipEntry(fnme);
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);
                    s.Write(ie.GetBuffer(), 0, (int)ie.Length);
                }
                s.Finish();
                Response.ContentType = "application/octet-stream";
                //实现下载+文件名
                Response.AddHeader("Content-Disposition", "attachment; filename=" + ihe.HostName + ".zip");
                Response.OutputStream.Write(iee.GetBuffer(), 0, (int)iee.Length);
                s.Close();
                // Response.Flush();
                Response.End();
            }
        }
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        GridViewRowCollection gvrc = GridView1.Rows;
        foreach (GridViewRow gr in gvrc)
        {
            String strExtension = gr.Cells[1].Text.Substring(gr.Cells[1].Text.LastIndexOf(".") + 1);
            if (strExtension != "doc" && strExtension != "DOC" && strExtension != "docx" && strExtension != "DOCX" && strExtension != "xls" && strExtension != "XLS" && strExtension != "xlsx" && strExtension != "XLSX" && strExtension != "pdf" && strExtension != "PDF" && strExtension != "TXT" && strExtension != "txt" && strExtension != "bmp" && strExtension != "BMP" && strExtension != "png" && strExtension != "PNG" && strExtension != "jpg" && strExtension != "JPG" && strExtension != "jpeg" && strExtension != "JPEG" && strExtension != "gif" && strExtension != "GIF" && strExtension != "png" && strExtension != "PNG")
            {
                Button bt = gr.FindControl("Button7") as Button;
                bt.Enabled = false;
            }
        }
    }

    protected void reUpload_Click(object sender, EventArgs e)
    {
        refUpload();
    }

    public void refUpload()
    {
        if (refile.PostedFile != null && refile.PostedFile.ContentLength > 0)
        {

            //string ext = System.IO.Path.GetExtension(refile.PostedFile.FileName).ToLower();
            //if (ext != ".jpg" && ext != ".jepg" && ext != ".bmp" && ext != ".gif")
            //{
            //    return;
            //}
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(Request.UserHostAddress);      //根据目标ip地址的获取ip对象

            System.Net.IPHostEntry ihe = System.Net.Dns.GetHostEntry(ip);    //根据ip对象创建主机对象          

            HttpFileCollection uploadFiles = Request.Files;
            HttpPostedFile file = uploadFiles[0];
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
        }
        else
        {
            //do some thing;   
        }
    }

    protected void Uploadd_Click(object sender, EventArgs e)
    {
        Upload();
    }


    public void Upload()
    {
        try
        {
            for (int run = 0; run < HttpContext.Current.Request.Files.Count; run++)
            {
                HttpPostedFileBase file = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[run]);
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
            }
        }
        catch (Exception e)
        {
            Response.Write("Sorry your file is not upload successfully!" + e.Message);
        }

        //Response.End();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string nn = null;
        string mm = null;
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            if (((CheckBox)(gvRow.Cells[0].FindControl("CheckBox1"))).Checked)
            {
                nn += gvRow.Cells[1].Text + "|";
                mm += gvRow.Cells[3].Text + "|";
            }
        }
        DownFile(mm, nn);   
    }
 
}