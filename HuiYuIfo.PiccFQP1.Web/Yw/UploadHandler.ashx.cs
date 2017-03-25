using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using HuiYuIfo.Framework.Dao;
using System.Collections;
using HuiYuIfo.PiccFQP1.Entity.Yw;
namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file = context.Request.Files["Filedata"];
            string id = context.Request["id"].Trim();
            try
            {
                int temp = int.Parse(id);
                if (temp < 0)
                {
                    context.Response.Write("0");
                }
                string pathtemp = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
                string uploadPath = HttpContext.Current.Server.MapPath("upload" + "\\" + pathtemp+"\\");
                //判断上传的文件是否为空
                if (file != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    YwAttach att = new YwAttach();
                    att.RealName = file.FileName;
                    //保存文件
                    string[] arr = file.FileName.Split('.');
                    string fileName = "";
                    if (arr.Length > 1)
                    {
                        fileName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];
                    }
                    else
                    {
                        fileName = Guid.NewGuid().ToString();
                    }
                    file.SaveAs(uploadPath + fileName);
                    BaseDao baseDao = new BaseDao();
                    
                    att.Dic = uploadPath;
                    att.FileN = fileName;
                    att.Dataid = temp;
                    att.Type = "1";
                    baseDao.Insert(att);
                    //Hashtable ht=new Hashtable();
                    //ht.Add("Did", temp);
                    //baseDao.UpdateUdf("YwDataAttUpdate", ht);
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }  
            }
            catch
            {
                context.Response.Write("0");
            }
            context.Response.Write("0");
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}