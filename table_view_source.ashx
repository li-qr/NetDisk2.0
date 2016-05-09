<%@ WebHandler Language="C#" Class="table_view_source" %>

using System;
using System.Web;
using Aspose.Cells;
using Newtonsoft.Json.Linq;
using RDotNet;
using System.Collections;
using System.IO;
public class table_view_source : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       // context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        if (context.Request.Form["table"] != null)
        {
            if (!String.IsNullOrEmpty(context.Request.Form["table"].ToString()))
            {
                Workbook wb = new Workbook(HttpContext.Current.Server.MapPath("/146.xls"));
                Worksheet ws = wb.Worksheets[0];
                JObject jo = new JObject();
                int whith = ws.Cells.MaxColumn + 1;
                int height = ws.Cells.MaxRow + 1;
                jo.Add(new JProperty("with", whith));
                jo.Add(new JProperty("height", height));
                JObject jo1 = new JObject();
                jo.Add(new JProperty("member", jo1));
                for (int i = 0; i < ws.Cells.MaxRow + 1; i++)
                    for (int j = 0; j < ws.Cells.MaxColumn + 1; j++)
                    {
                        JObject te = new JObject();
                        if (ws.Cells.GetRow(i).GetCellOrNull(j) != null)
                        {
                            if (ws.Cells.GetRow(i).GetCellOrNull(j).IsMerged)
                            {
                                if (i == ws.Cells.GetRow(i).GetCellOrNull(j).GetMergedRange().FirstRow && j == ws.Cells.GetRow(i).GetCellOrNull(j).GetMergedRange().FirstColumn)
                                {
                                    te.Add(new JProperty("value", ws.Cells.GetRow(i).GetCellOrNull(j).StringValue));
                                    string na = i.ToString() + "." + j;
                                    te.Add(new JProperty("ismarged", 1));
                                    te.Add(new JProperty("startx", ws.Cells.GetRow(i).GetCellOrNull(j).GetMergedRange().ColumnCount));
                                    te.Add(new JProperty("starty", ws.Cells.GetRow(i).GetCellOrNull(j).GetMergedRange().RowCount));
                                    j += ws.Cells.GetRow(i).GetCellOrNull(j).GetMergedRange().ColumnCount - 1;
                                    jo1.Add(na, te);
                                }
                            }
                            else
                            {
                                te.Add(new JProperty("value", ws.Cells.GetRow(i).GetCellOrNull(j).StringValue));
                                string na = i.ToString() + "." + j;
                                te.Add(new JProperty("ismarged", 0));
                                jo1.Add(na, te);
                            }


                        }
                        else
                        {
                            te.Add(new JProperty("value", ""));
                            string na = i.ToString() + "." + j;
                            te.Add(new JProperty("ismarged", 0));
                            jo1.Add(na, te);
                        }
                    }
                string jj = jo.ToString();
                context.Response.Clear();
                //将字符串写入响应输出流  
                context.Response.Write(jj);
                //将当前所有缓冲的输出发送的客户端，并停止该页执行  
                context.Response.End();
                //wb.Save(MapPath("/14.html"), Aspose.Cells.SaveFormat.Html);
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/14.html'" + ",'_blank')</script>");
            }

        }
        else if (context.Request.Form["num"] != null)
        {


            string worklist = context.Request.Form["num"].ToString();
            string[] aa = worklist.Split(',');

            var oldPath = System.Environment.GetEnvironmentVariable("PATH");
            var rPath = System.Environment.Is64BitProcess ? @"C:\Program Files\R\R-3.2.4revised\bin\x64" : @"C:\Program Files\R\R-3.2.4revised\bin\i386";
            if (Directory.Exists(rPath) == false)
                throw new DirectoryNotFoundException(string.Format("Could not found the specified path to the directory containing R.dll: {0}", rPath));
            var newPath = string.Format("{0}{1}{2}", rPath, System.IO.Path.PathSeparator, oldPath);
            System.Environment.SetEnvironmentVariable("PATH", newPath);
            //string rHome = @"C:\Program Files (x86)\R-3.2.4revised";
            // string rPath = System.IO.Path.Combine(rHome, @"bin\i386");
            REngine.SetEnvironmentVariables(rPath);
            REngine engine = REngine.GetInstance();
            ArrayList List = new ArrayList();
            for (int i = 0; i < 10; i++)//aa.Length; i++)
            {
                List.Add(System.Convert.ToDouble(aa[i]));
            }
            //   Int32[] values = (Int32[])List.ToArray(typeof(Int32));
            NumericVector group1 = engine.CreateNumericVector((double[])List.ToArray(typeof(double)));//(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            engine.SetSymbol("group1", group1);
            double[] mean = engine.Evaluate("mean(group1)").AsNumeric().ToArray();
            double[] var = engine.Evaluate("var(group1)").AsNumeric().ToArray();
            double[] sd = engine.Evaluate("sd(group1)").AsNumeric().ToArray();
            string result = "平均值：" + mean[0].ToString() + "<br />方差：" + var[0].ToString() + "<br />标准差：" + sd[0].ToString();
            // NumericVector group1 = engine.CreateNumericVector();
            // for (int i = 0; i < 10000000;i++ )
            context.Response.Clear();
            context.Response.Write(result);
            context.Response.End();
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}