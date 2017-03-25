using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
namespace HuiYuIfo.PiccFQP1.Service.Yw
{
    public class YwCyhService
    {
        private BaseDao baseDao = new BaseDao();
        public bool Validate(string type,YwCyh entity,ref string errmsg)
        {
            switch (type)
            {
                case "all":
                    #region validate all
                    if (entity.Qd != "直销" && entity.Qd != "电销")
                    {
                        errmsg = "渠道 内容不正确，应该为【直销】或【电销】";
                        return false;
                    }
                    if (entity.Xz != "商业险" && entity.Xz != "交强险")
                    {
                        errmsg = "险种 内容不正确，应该为【商业险】或【交强险】";
                        return false;
                    }

                    if (entity.Dbdsz != "是" && entity.Dbdsz != "否")
                    {
                        errmsg = "是否单保第三者 内容不正确，应该为【是】或【否】";
                        return false;
                    }
                    if (entity.Dbjq != "是" && entity.Dbjq != "否")
                    {
                        errmsg = "是否单保交强 内容不正确，应该为【是】或【否】";
                        return false;
                    }
                    if (entity.Cllx == "")
                    {
                        errmsg = "车辆类型 不能为空";
                        return false;
                    }
                    if (entity.Ywly == "")
                    {
                        errmsg = "业务来源 不能为空";
                        return false;
                    }
                    if (entity.Zhcxcs == "")
                    {
                        errmsg = "综合出险次数 不能为空";
                        return false;
                    }
                    if (entity.Synx == "")
                    {
                        errmsg = "使用年限 不能为空";
                        return false;
                    }

                    if (entity.Sfbcs != "是" && entity.Sfbcs != "否")
                    {
                        errmsg = "是否保车损 内容不正确，应该为【是】或【否】";
                        return false;
                    }
                    if (entity.Pfvsfc100 != "是" && entity.Pfvsfc100 != "否")
                    {
                        errmsg = "赔付率是否超100% 内容不正确，应该为【是】或【否】";
                        return false;
                    }
                    decimal decTemp=0;

                    #region 基础手续费
                    try
                    {
                        if (entity.Jcsxf == null || entity.Jcsxf == "")
                        {
                            errmsg = "基础手续费 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Jcsxf);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "基础手续费 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "基础手续费 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 车上人员
                    try
                    {
                        if (entity.Bcsry == null || entity.Bcsry == "")
                        {
                            errmsg = "保车上人员 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Bcsry);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "保车上人员 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "保车上人员 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 保盗抢险
                    try
                    {
                        if (entity.Bdqx == null || entity.Bdqx == "")
                        {
                            errmsg = "保盗抢险 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Bdqx);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "保盗抢险 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "保盗抢险 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 保自燃险
                    try
                    {
                        if (entity.Bzrx == null || entity.Bzrx == "")
                        {
                            errmsg = "保自燃险 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Bzrx);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "保自燃险 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "保自燃险 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 保发动机
                    try
                    {
                        if (entity.Bfdj == null || entity.Bfdj == "")
                        {
                            errmsg = "保发动机 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Bfdj);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "保发动机 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "保发动机 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 三者100万
                    try
                    {
                        if (entity.Sz100 == null || entity.Sz100 == "")
                        {
                            errmsg = "三者100万 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Sz100);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "三者100万 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "三者100万 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 推修
                    try
                    {
                        if (entity.Qx == null || entity.Qx == "")
                        {
                            errmsg = "推修 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Qx);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "推修 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "推修 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 优质平安
                    try
                    {
                        if (entity.Uzpa == null || entity.Uzpa == "")
                        {
                            errmsg = "优质平安 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Uzpa);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "优质平安 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "优质平安 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion

                    #region 优质转入基数
                    try
                    {
                        if (entity.Yzzrjs == null || entity.Yzzrjs == "")
                        {
                            errmsg = "优质转入基数 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                        decTemp = decimal.Parse(entity.Yzzrjs);
                        if (decTemp < 0 || decTemp > 100)
                        {
                            errmsg = "优质转入基数 内容不正确，应该为0到100之间的数字";
                            return false;
                        }
                    }
                    catch
                    {
                        errmsg = "优质转入基数 内容不正确，应该为0到100之间的数字";
                        return false;
                    }
                    #endregion
                    break;
                #endregion
            }
            return true;
        }
        public bool CheckExist(YwCyh entity)
        {
            YwCyh temp = new YwCyh();
            temp.Xz = entity.Xz;
            temp.Dbdsz = entity.Dbdsz;
            temp.Dbjq = entity.Dbjq;
            temp.Sxflx = entity.Sxflx;
            temp.Wfglcxcs = entity.Wfglcxcs;
            temp.Ywly = entity.Ywly;
            temp.Zhcxcs = entity.Zhcxcs;
            temp.Synx = entity.Synx;
            temp.Sfbcs = entity.Sfbcs;
            temp.Pfvsfc100 = entity.Pfvsfc100;
            temp.Cx3c = entity.Cx3c;
          
            int count = baseDao.Count(temp);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public IWorkbook Export()
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("cyhExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            YwCyh param = new YwCyh();
            IList<YwCyh> list = baseDao.List(param);
            int i = 0;
            foreach (YwCyh temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateRow(rowT, temp);
            }

            return book;
        }
        public IWorkbook ExportExample()
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("cyhExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            IRow rowT = sheet.CreateRow(1);
            CreateExampleRow(rowT);
            return book;
        }
        public bool DealWorkbook(IWorkbook book, ref string errmsg)
        {
            bool result = true;
            ISheet sheet = book.GetSheetAt(0);
            IRow headRow = sheet.GetRow(0);
            int count = headRow.Cells.Count;
            if (count < 18)
            {
                errmsg = "总列数至少应该为18列，上传文件格式不正确，请确认";
                return false;
            }
            for (int i = 0; i < headRow.Cells.Count; i++)
            {
                result = CheckCell(i, headRow.Cells[i].StringCellValue, ref errmsg);
                if (result == false)
                {
                    return result;
                }
            }
            string qd = System.Configuration.ConfigurationManager.AppSettings["Sxflx"].Trim();
            Dictionary<string, string> qdDic = new Dictionary<string, string>();
            string[] qdArr = qd.Split('|');
            foreach (string temp in qdArr)
            {
                string[] tempArr = temp.Split(',');
                qdDic.Add(tempArr[0], tempArr[0]);
            }

            string xz = System.Configuration.ConfigurationManager.AppSettings["Xz"].Trim();
            Dictionary<string, string> xzDic = new Dictionary<string, string>();
            string[] xzArr = xz.Split('|');
            foreach (string temp in xzArr)
            {
                string[] tempArr = temp.Split(',');
                xzDic.Add(tempArr[0], tempArr[0]);
            }

            string cllx = System.Configuration.ConfigurationManager.AppSettings["Cllx"].Trim();
            Dictionary<string, string> cllxDic = new Dictionary<string, string>();
            string[] cllxArr = cllx.Split('|');
            foreach (string temp in cllxArr)
            {
                string[] tempArr = temp.Split(',');
                cllxDic.Add(tempArr[0], tempArr[0]);
            }

            string ywly = System.Configuration.ConfigurationManager.AppSettings["Ywly"].Trim();

            Dictionary<string, string> ywlyDic = new Dictionary<string, string>();
            string[] ywlyArr = ywly.Split('|');
            foreach (string temp in ywlyArr)
            {
                string[] tempArr = temp.Split(',');
                ywlyDic.Add(tempArr[0], tempArr[0]);
            }

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                DealRow(i, sheet.GetRow(i),qdDic,xzDic,cllxDic,ywlyDic);

            }
            return true;
        }
        private void CreateRow(IRow row, YwCyh entity)
        {
            int i = 0;
            ICell cell = row.CreateCell(i+0);
            cell.SetCellValue(entity.Did.ToString());
            //ICell cell1 = row.CreateCell(1);
            //cell1.SetCellValue(entity.Qd);
            i--;
            ICell cell2 = row.CreateCell(i + 2);
            cell2.SetCellValue(entity.Xz);
            ICell cell3 = row.CreateCell(i + 3);
            cell3.SetCellValue(entity.Dbdsz);
            ICell cell4 = row.CreateCell(i + 4);
            cell4.SetCellValue(entity.Dbjq);
            ICell cell5 = row.CreateCell(i + 5);
            cell5.SetCellValue(entity.Sxflx);
            ICell cell6 = row.CreateCell(i + 6);
            cell6.SetCellValue(entity.Ywly);

            i += 1;
            ICell cell6t = row.CreateCell(i + 6);
            cell6t.SetCellValue(entity.Wfglcxcs);


            ICell cell7 = row.CreateCell(i + 7);
            cell7.SetCellValue(entity.Zhcxcs);
            ICell cell8 = row.CreateCell(i + 8);
            cell8.SetCellValue(entity.Synx);
            ICell cell9 = row.CreateCell(i + 9);
            cell9.SetCellValue(entity.Sfbcs);
            ICell cell10 = row.CreateCell(i + 10);
            cell10.SetCellValue(entity.Pfvsfc100);

            i += 1;
            ICell cell10t = row.CreateCell(i + 10);
            cell10t.SetCellValue(entity.Cx3c);


            ICell cell11 = row.CreateCell(i + 11);
            cell11.SetCellValue(entity.Jcsxf);
            ICell cell12 = row.CreateCell(i + 12);
            cell12.SetCellValue(entity.Bcsry);
            ICell cell13 = row.CreateCell(i + 13);
            cell13.SetCellValue(entity.Bdqx);
            ICell cell14 = row.CreateCell(i + 14);
            cell14.SetCellValue(entity.Bzrx);
            ICell cell15 = row.CreateCell(i + 15);
            cell15.SetCellValue(entity.Bfdj);
            ICell cell16 = row.CreateCell(i + 16);
            cell16.SetCellValue(entity.Sz100);
            //ICell cell17 = row.CreateCell(i + 17);
            //cell17.SetCellValue(entity.Qx);
        }
        private void CreateHead(IRow row)
        {
            int i = 0;
            ICell cell = row.CreateCell(i+0);
            cell.SetCellValue("序号");
            i -= 1;
            //ICell cell1 = row.CreateCell(1);
            //cell1.SetCellValue("渠道");
            ICell cell2 = row.CreateCell(i+2);
            cell2.SetCellValue("险种");
            ICell cell3 = row.CreateCell(i + 3);
            cell3.SetCellValue("是否单保第三者");
            ICell cell4 = row.CreateCell(i + 4);
            cell4.SetCellValue("是否单保交强");
            ICell cell5 = row.CreateCell(i + 5);
            cell5.SetCellValue("手续费类型");
            ICell cell6 = row.CreateCell(i + 6);
            cell6.SetCellValue("业务来源");

            i += 1;
            ICell cell6t = row.CreateCell(i + 6);
            cell6t.SetCellValue("是否无法关联出险次数");


            ICell cell7 = row.CreateCell(i + 7);
            cell7.SetCellValue("综合出险次数");
            ICell cell8 = row.CreateCell(i + 8);
            cell8.SetCellValue("使用年限");
            ICell cell9 = row.CreateCell(i + 9);
            cell9.SetCellValue("是否保车损");
            ICell cell10 = row.CreateCell(i + 10);
            cell10.SetCellValue("赔付率是否超100%");
            i += 1;
            ICell cell10t = row.CreateCell(i + 10);
            cell10t.SetCellValue("出险3次，是否赔付200%");


            ICell cell11 = row.CreateCell(i + 11);
            cell11.SetCellValue("基础手续费");
            ICell cell12 = row.CreateCell(i + 12);
            cell12.SetCellValue("保车上人员");
            ICell cell13 = row.CreateCell(i + 13);
            cell13.SetCellValue("保盗抢险");
            ICell cell14 = row.CreateCell(i + 14);
            cell14.SetCellValue("保自燃险");
            ICell cell15 = row.CreateCell(i + 15);
            cell15.SetCellValue("保发动机");
            ICell cell16 = row.CreateCell(i + 16);
            cell16.SetCellValue("三者100万");
            //ICell cell17 = row.CreateCell(i + 17);
            //cell17.SetCellValue("推修");
      
        }
        private void CreateExampleRow(IRow row)
        {
            int i = 0;
            ICell cell = row.CreateCell(i+0);
            cell.SetCellType(CellType.String);
            cell.SetCellValue("1");
            i -= 1;
            //ICell cell1 = row.CreateCell(1);
            //cell1.SetCellType(CellType.String);
            //cell1.SetCellValue("直销");

            ICell cell2 = row.CreateCell(i + 2);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue("商业险");
            ICell cell3 = row.CreateCell(i + 3);
            cell3.SetCellType(CellType.String);
            cell3.SetCellValue("是");
            ICell cell4 = row.CreateCell(i + 4);
            cell4.SetCellType(CellType.String);
            cell4.SetCellValue("是");
            ICell cell5 = row.CreateCell(i + 5);
            cell5.SetCellValue("");
            cell5.SetCellType(CellType.String);
            ICell cell6 = row.CreateCell(i + 6);
            cell6.SetCellType(CellType.String);
            cell6.SetCellValue("续保");

            i += 1;
            ICell cell6t = row.CreateCell(i + 6);
            cell6t.SetCellValue("是");


            ICell cell7 = row.CreateCell(i + 7);
            cell7.SetCellType(CellType.String);
            cell7.SetCellValue("1");
            ICell cell8 = row.CreateCell(i + 8);
            cell8.SetCellType(CellType.String);
            cell8.SetCellValue("1");
            ICell cell9 = row.CreateCell(i + 9);
            cell9.SetCellType(CellType.String);
            cell9.SetCellValue("是");
            ICell cell10 = row.CreateCell(i + 10);
            cell10.SetCellType(CellType.String);
            cell10.SetCellValue("是");

            i += 1;
            ICell cell10t = row.CreateCell(i + 10);
            cell10t.SetCellValue("是");


            ICell cell11 = row.CreateCell(i + 11);
            cell11.SetCellType(CellType.String);
            cell11.SetCellValue("18");
            ICell cell12 = row.CreateCell(i + 12);
            cell12.SetCellType(CellType.String);
            cell12.SetCellValue("1");
            ICell cell13 = row.CreateCell(i + 13);
            cell13.SetCellType(CellType.String);
            cell13.SetCellValue("1");
            ICell cell14 = row.CreateCell(i + 14);
            cell14.SetCellType(CellType.String);
            cell14.SetCellValue("1");
            ICell cell15 = row.CreateCell(i + 15);
            cell15.SetCellType(CellType.String);
            cell15.SetCellValue("1");
            ICell cell16 = row.CreateCell(i + 16);
            cell16.SetCellType(CellType.String);
            cell16.SetCellValue("1");
            //ICell cell17 = row.CreateCell(i + 17);
            //cell17.SetCellType(CellType.String);
            //cell17.SetCellValue("1");
            

        }

        private bool CheckCell(int index, string title, ref string errmsg)
        {

            switch (index)
            {
                //case 1:
                //    if ("渠道" != title)
                //    {
                //        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【渠道】,请确认";
                //        return false;
                //    }
                //    break;
                case 1:
                    if ("险种" != title)
                    {
                        errmsg= "第" + (index + 1) + "列抬头不正确，应该为【险种】,请确认";
                        return false;
                    }
                    break;
                case 2:
                    if ("是否单保第三者" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【是否单保第三者】,请确认";
                        return false;
                     }
                    break;
                case 3:
                    if ("是否单保交强" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【是否单保交强】,请确认";
                        return false;
                    }
                    break;
                case 4:
                    if ("手续费类型" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【手续费类型】,请确认";
                        return false;
                    }
                    break;
                case 5:
                    if ("业务来源" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【业务来源】,请确认";
                        return false;
                     }
                    break;
                case 6:
                    if ("是否无法关联出险次数" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【是否无法关联出险次数】,请确认";
                        return false;
                    }
                    break;
                case 7:
                    if ("综合出险次数" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【综合出险次数】,请确认";
                        return false;
                    }
                    break;
                case 8:
                    if ("使用年限" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【使用年限】,请确认";
                        return false;
                     }
                    break;
                case 9:
                    if ("是否保车损" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【是否保车损】,请确认";
                        return false;
                    }
                    break;
                case 10:
                    if ("赔付率是否超100%" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【赔付率是否超100%】,请确认";
                        return false;
                     }
                    break;
                case 11:
                    if ("出险3次，是否赔付200%" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【出险3次，是否赔付200%】,请确认";
                        return false;
                    }
                    break;
                case 12:
                    if ("基础手续费" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【基础手续费】,请确认";
                        return false;
                    }
                    break;
                case 13:
                    if ("保车上人员" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【保车上人员】,请确认";
                        return false;
                    }
                    break;
                case 14:
                    if ("保盗抢险" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【保盗抢险】,请确认";
                        return false;
                    }
                    break;
                case 15:
                    if ("保自燃险" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【保自燃险】,请确认";
                        return false;
                    }
                    break;
                case 16:
                    if ("保发动机" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【保发动机】,请确认";
                        return false;
                    }
                    break;
                case 17:
                    if ("三者100万" != title)
                    {
                        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【三者100万】,请确认";
                        return false;
                    }
                    break;
                //case 18:
                //    if ("推修" != title)
                //    {
                //        errmsg = "第" + (index + 1) + "列抬头不正确，应该为【推修】,请确认";
                //        return false;
                //    }
                //    break;
            }
            return true;
        }

        private void DealRow(int rowindex, IRow row, Dictionary<string, string> sxflxDic, Dictionary<string, string> xzDic, Dictionary<string, string> cllxDic, Dictionary<string, string> ywlyDic)
        {
            decimal decTemp = 0;
            YwCyh temp = new YwCyh();
            for (int index = 0; index < row.Cells.Count; index++)
            {
                ICell cell = row.GetCell(index);
                cell.SetCellType(CellType.String);

                switch (index)
                {
                    //case 1://渠道
                    //    try
                    //    {
                    //        String temp1 = cell.StringCellValue.Trim();
                    //        if (qdDic.ContainsKey(temp1))
                    //        {
                    //            temp.Qd = temp1;
                    //        }
                    //        else
                    //        {
                    //            throw new Exception("第" + rowindex + "行    渠道 内容不正确");
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        throw new Exception("第" + rowindex + "行    渠道 内容不正确");
                    //    }
                    //    break;
                    case 1://险种
                        try
                        {
                            String temp2 = cell.StringCellValue.Trim();
                            if (xzDic.ContainsKey(temp2))
                            {
                                temp.Xz = temp2;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    险种 内容不正确");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    险种 内容不正确");
                        }
                        break;
                    case 2://担保第三者
                        try
                        {
                            String temp3 = cell.StringCellValue.Trim();
                            if (temp3 == "是" || temp3 == "否")
                            {
                                temp.Dbdsz = temp3;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    是否单保第三者 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    是否单保第三者 内容不正确，应该为【是】或【否】");
                        }
                        break;
                    case 3://是否单保交强
                        try
                        {
                            String temp4 = cell.StringCellValue.Trim();
                            if (temp4 == "是" || temp4 == "否")
                            {
                                temp.Dbjq = temp4;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    是否单保交强 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    是否单保交强 内容不正确，应该为【是】或【否】");
                        }

                        break;
                    case 4://手续费类型
                        try
                        {
                            String temp1 = cell.StringCellValue.Trim();
                            if (sxflxDic.ContainsKey(temp1))
                            {
                                temp.Sxflx = temp1;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    手续费类型 内容不正确");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    手续费类型 内容不正确");
                        }
                        break;
                    
                    case 5://业务来源
                        try
                        {
                            temp.Ywly = cell.StringCellValue.Trim();
                            if (ywlyDic.ContainsKey(temp.Ywly) == false)
                            {
                                throw new Exception("第" + rowindex + "行    业务来源 内容不正确");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    业务来源 内容不正确");
                        }
                        break;
                    case 6://是否无法关联出险次数
                        try
                        {
                            String temp4 = cell.StringCellValue.Trim();
                            if (temp4 == "是" || temp4 == "否")
                            {
                                temp.Wfglcxcs = temp4;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    是否无法关联出险次数 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    是否无法关联出险次数 内容不正确，应该为【是】或【否】");
                        }

                        break;
                    case 7://综合出险次数
                        try
                        {
                            temp.Zhcxcs = cell.StringCellValue.Trim();
                            if (temp.Zhcxcs == "")
                            {
                                throw new Exception("第" + rowindex + "行    综合出险次数不能为空");
                            }
                            if (temp.Zhcxcs != "4及以上")
                            {
                                int csT = int.Parse(temp.Zhcxcs);
                                if (csT > 3)
                                {
                                    temp.Zhcxcs = "4及以上";
                                }
                            }
                        }
                        catch
                        {

                            throw new Exception("第" + rowindex + "行    综合出险次数数据有误");
                        }
                        break;
                    case 8://使用年限
                        try
                        {
                            temp.Synx = cell.StringCellValue.Trim();
                            if (temp.Synx == "")
                            {
                                throw new Exception("第" + rowindex + "行    使用年限不能为空");
                            }
                            if (temp.Synx != "3及以上")
                            {
                                int nxT = int.Parse(temp.Synx);
                                if (nxT > 2)
                                {
                                    temp.Synx = "3及以上";
                                }
                            }
                        }
                        catch
                        {

                            throw new Exception("第" + rowindex + "行    使用年限数据有误");
                        }
                        break;
                    case 9://车损
                        try
                        {
                            String temp9 = cell.StringCellValue.Trim();
                            if (temp9 == "是" || temp9 == "否")
                            {
                                temp.Sfbcs = temp9;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    是否保车损 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    是否保车损 内容不正确，应该为【是】或【否】");
                        }
                        break;
                    case 10://赔付率
                        try
                        {
                            String temp10 = cell.StringCellValue.Trim();
                            if (temp10 == "是" || temp10 == "否")
                            {
                                temp.Pfvsfc100 = temp10;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    赔付率是否超100% 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    赔付率是否超100% 内容不正确，应该为【是】或【否】");
                        }

                        break;

                    case 11://出险3次，是否赔付200%
                        try
                        {
                            String temp10 = cell.StringCellValue.Trim();
                            if (temp10 == "是" || temp10 == "否")
                            {
                                temp.Cx3c = temp10;
                            }
                            else
                            {
                                throw new Exception("第" + rowindex + "行    出险3次，是否赔付200% 内容不正确，应该为【是】或【否】");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowindex + "行    出险3次，是否赔付200% 内容不正确，应该为【是】或【否】");
                        }

                        break;
                     case 12://基础手续费
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    基础手续费  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    基础手续费  值应该在0和100之间");
                        }
                        temp.Jcsxf = cell.StringCellValue.Trim();
                        break;

                     case 13:
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    保车上人员  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    保车上人员  值应该在0和100之间");
                        }
                        temp.Bcsry = cell.StringCellValue.Trim();
                      
                        break;
                     case 14:
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    保盗抢险  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    保盗抢险  值应该在0和100之间");
                        }
                        temp.Bdqx = cell.StringCellValue.Trim();
                      
                        break;

                     case 15:
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    保自燃险  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    保自燃险  值应该在0和100之间");
                        }
                        temp.Bzrx = cell.StringCellValue.Trim();
                      
                        break;

                     case 16:
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    保发动机  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    保发动机  值应该在0和100之间");
                        }
                        temp.Bfdj = cell.StringCellValue.Trim();
                        break;
                     case 17:
                        try
                        {
                            decTemp = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowindex + "行    三者100万  错误,应该在0和100之间的数字");
                        }
                        if (decTemp < 0 || decTemp > 100)
                        {
                            throw new Exception("第" + rowindex + "行    三者100万  值应该在0和100之间");
                        }
                        temp.Sz100 = cell.StringCellValue.Trim();
                        break;

                     //case 18:
                     //    try
                     //   {
                     //       decTemp = decimal.Parse(cell.StringCellValue.Trim());
                     //   }
                     //   catch (Exception ex)
                     //   {
                     //       throw new Exception("第" + rowindex + "行    推修  错误,应该在0和100之间的数字");
                     //   }
                     //   if (decTemp < 0 || decTemp > 100)
                     //   {
                     //       throw new Exception("第" + rowindex + "行    推修  值应该在0和100之间");
                     //   }
                     //   temp.Qx = cell.StringCellValue.Trim();
                     //   break;
                }
            }

            if (CheckExist(temp) == true)
            {
                throw new Exception("第" + rowindex + "行  差异化信息重复定义");
            }
            baseDao.Insert(temp);
        }
    }
}