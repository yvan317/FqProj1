using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Controller;
using System.IO;
using NPOI.SS.UserModel;
using HuiYuIfo.PiccFQP1.Service.Yw;
using System.Collections;
using ICSharpCode.SharpZipLib.Zip;

namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwYwyDataController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                #region 业务员编辑页面
                case "ywyEdit"://业务员编辑（第二次）
                    task.PagePath = "YwyDataEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "clearAllAtt"://业务员清除附件
                    ClearAllAtt(task, ref errmsg);
                    break;
                case "ywySubmit":
                    YwySubmit(task, ref errmsg);
                    break;
                case "ywySave"://业务员保存（第二步)
                    YwySave(task, ref errmsg);
                    break;
                #endregion
                case "showAtt":
                    task.PagePath = "YwyShowAtt.aspx";
                    task.PageParam = ((YwData)task.Entity).Did.ToString();
                    break;
                
                //#region 结账数据导出
                //case "ywyQueryExport":
                //    ///业务员结账数据导出
                //    YwDataService service3 = new YwDataService();
                //    IWorkbook book3 = service3.YwyExportData();
                //    if (task.paralist == null)
                //    {
                //        task.paralist = new System.Collections.ArrayList();
                //    }
                //    task.paralist.Add(book3);
                //    break;
               
                //#endregion
            }
            return true;
        }
        #region 清空附件
        private bool ClearAllAtt(Framework.Task.Task task, ref string errmsg)
        {
            this.BeginTran();
            try
            {
                BaseDao baseDao = new BaseDao();
                YwData entity = task.Entity as YwData;
                entity.AttachmentCount = 0;
                Hashtable ht = new Hashtable();
                ht.Add("Did", entity.Did);
                baseDao.UpdateUdf("YwDataAttClear", ht);

                YwAttach att = new YwAttach();
                att.Dataid = entity.Did;
                baseDao.Delete(att);
                this.CommitTran();
                errmsg = "清空成功";
            }
            catch (Exception ex)
            {
                this.RollbackTran();
                errmsg = ex.Message;
                return false;
            }
            return true;

        }
        #endregion

        #region 业务员保存，提交
        private bool YwySubmit(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            this.BeginTran();
            try
            {
                YwData entity = task.Entity as YwData;
                BaseDao baseDao = new BaseDao();

                YwAttach att = new YwAttach();
                att.Type = "1";
                att.Dataid = entity.Did;
                IList<YwAttach> attList = baseDao.List(att);
                if (attList != null && attList.Count > 0)
                {
                    entity.AttachmentCount = attList.Count;
                }
                else
                {
                    entity.AttachmentCount = 0;
                }
                entity.Status = "3";
                entity.YwySubmit = DateTime.Now;
                if (entity.Bbr.Length <= 4)
                {
                    if (entity.Sfypz == "是")
                    {
                        YwDataService service = new YwDataService();
                        service.FirstCalculate(1, entity);
                        service.SeconeCalculate(entity);
                    }
                }
                else
                {
                    YwDataService service = new YwDataService();
                    service.FirstCalculate(1, entity);
                    service.SeconeCalculate(entity);
                }
                int count = baseDao.Update(entity);
                if (count <= 0)
                {
                    errmsg = "数据在页面显示后被其他人修改过，请重新打开编辑";
                    task.ParentRebind = true;
                    task.Rebind = true;
                    task.IsClose = true;
                    return false;
                }
                
                //文件压缩
                //删除压缩文件
                
                att.Type = "2";
               
                baseDao.DeleteUdf("YwAttachDeleteByType", att);
                //重新压缩附件
                if (attList!=null&&attList.Count > 0)
                {
                    string zipdic = attList[0].Dic;
                    string zipFileN = Guid.NewGuid().ToString() + ".zip";
                    string path = zipdic + zipFileN;
                    using (ZipFile zip = ZipFile.Create(@path))
                    {

                        zip.BeginUpdate();
                        foreach (YwAttach attTemp in attList)
                        {
                            string pathT = attTemp.Dic + attTemp.FileN;
                            zip.Add(@pathT, attTemp.FileN);
                        }
                        zip.CommitUpdate();
                    }
                    att.Type = "2";
                    att.Dic = zipdic;
                    att.FileN = zipFileN;
                    att.RealName = zipFileN;
                    att.Dataid = entity.Did;
                    baseDao.Insert(att);
           
                }
                if (result == true)
                {
                    errmsg = "保存成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
                this.CommitTran();
            }
            catch (Exception ex)
            {
                this.RollbackTran();
                errmsg = ex.Message;
            }
            return result;
        }
        private bool YwySave(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            this.BeginTran();
            try
            {
                YwData entity = task.Entity as YwData;
                if (entity.Bbr.Length <= 4)
                {
                    if (entity.Sfypz == "是")
                    {
                        YwDataService service = new YwDataService();
                        service.FirstCalculate(1, entity);
                        service.SeconeCalculate(entity);
                    }
                }
                else
                {
                    YwDataService service = new YwDataService();
                    service.FirstCalculate(1, entity);
                    service.SeconeCalculate(entity);
                }
                BaseDao baseDao = new BaseDao();
                
                int count=baseDao.Update(entity);
                if (count <= 0)
                {
                    errmsg = "数据在页面显示后被其他人修改过，请重新打开编辑";
                    task.ParentRebind = true;
                    task.IsClose = true;
                    return false;
                }
                //文件压缩
                //删除压缩文件
                YwAttach att = new YwAttach();
                att.Type = "2";
                att.Dataid = entity.Did;
                baseDao.DeleteUdf("YwAttachDeleteByType", att);
                //重新压缩附件
                att.Type = "1";
                IList<YwAttach> attList = baseDao.List(att);

                if (attList.Count > 0)
                {
                    string zipdic = attList[0].Dic;
                    string zipFileN = Guid.NewGuid().ToString() + ".zip";
                    string path = zipdic + zipFileN;
                    using (ZipFile zip = ZipFile.Create(@path))
                    {

                        zip.BeginUpdate();
                        foreach (YwAttach attTemp in attList)
                        {
                            string pathT = attTemp.Dic + attTemp.FileN;
                            zip.Add(@pathT, attTemp.FileN);
                        }
                        zip.CommitUpdate();
                    }
                    att.Type = "2";
                    att.Dic = zipdic;
                    att.FileN = zipFileN;
                    att.RealName = zipFileN;
                    att.Dataid = entity.Did;
                    baseDao.Insert(att);
                }
                if (result == true)
                {
                   
                    YwData temp = new YwData();
                    temp.Did = entity.Did;
                    temp = baseDao.Get<YwData>(temp);
                    task.Entity = temp;
                    errmsg = "保存成功";
                    task.ParentRebind = true;
                }
                this.CommitTran();
            }
            catch (Exception ex)
            {
                this.RollbackTran();
                errmsg = ex.Message;
            }
            return result;
        }
        #endregion
    }
}
