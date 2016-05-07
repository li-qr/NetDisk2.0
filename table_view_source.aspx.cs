using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Newtonsoft.Json.Linq;
using RDotNet;
public partial class table_view_source : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(Request.Form["table"]!=null)
        {
            if (!String.IsNullOrEmpty(Request.Form["table"].ToString()))
            {
                Workbook wb = new Workbook(MapPath("/146.xls"));
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
                                string na = i.ToString() +"."+ j;
                                te.Add(new JProperty("ismarged", 0));
                                jo1.Add(na, te);
                            }

                            
                        }
                        else
                        {
                            te.Add(new JProperty("value", ""));
                            string na = i.ToString() + "."+j;
                            te.Add(new JProperty("ismarged", 0));
                            jo1.Add(na, te);
                        }
                    }
                string jj = jo.ToString();
                Response.Clear();
                //将字符串写入响应输出流  
                Response.Write(jj);
                //将当前所有缓冲的输出发送的客户端，并停止该页执行  
                Response.End();
                //wb.Save(MapPath("/14.html"), Aspose.Cells.SaveFormat.Html);
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>window.open('/14.html'" + ",'_blank')</script>");
            }

        }
        else if (Request.Form["num"] != null)
        {
            string worklist = Request.Form["num"].ToString();
            string[] aa = worklist.Split(',');
            double sum = 0;
            for (int i = 0; i < aa.Length; i++)
            {
                sum += System.Convert.ToDouble(aa[i]);
            }
            for (int i = 0; i < 10000000;i++ )
                Response.Clear();
            Response.Write(sum);
            Response.End();
        }
       
    }
}