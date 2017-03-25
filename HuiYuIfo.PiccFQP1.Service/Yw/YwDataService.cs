using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Dao;
using System.Collections;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Service.Yw
{
    public class YwDataService
    {
        private XtmConfig config;
        private BaseDao baseDao = new BaseDao();

        public bool Validate(string type, YwData entity, ref string errmsg)
        {
            switch (type)
            {
                case "cbCreate":
                    #region 承保新增保存校验
                    if (entity.Jbr == "")
                    {
                        errmsg = "经办人 不能为空";
                        return false;
                    }
                    if (entity.Gsr == "")
                    {
                        errmsg = "归属人 不能为空";
                        return false;
                    }
                    if (entity.Cx == "")
                    {
                        errmsg = "车型 不能为空";
                        return false;
                    }
                    if (entity.Bbr == "")
                    {
                        errmsg = "被保险人 不能为空";
                        return false;
                    }
                    if (entity.Dzh == "")
                    {
                        errmsg = "单证号 不能为空";
                        return false;
                    }
                    if (entity.Cph == "")
                    {
                        errmsg = "车牌号 不能为空";
                        return false;
                    }
                    if (entity.Sybf < 0)
                    {
                        errmsg = "商业保费 不正确，应该为大于或者等于0的数字";
                        return false;
                    }
                    if (entity.Jqbf < 0)
                    {
                        errmsg = "交强保费 不正确，应该为大于或者等于0的数字";
                        return false;
                    }
                    if (entity.Sybf <= 0 && entity.Jqbf <= 0)
                    {
                        errmsg = "交强保费和商业保费必须有一个大于0";
                        return false;
                    }
                    if (entity.Sybf > 0 && entity.Jqbf > 0)
                    {
                        errmsg = "交强保费和商业保费只能有一个大于0";
                        return false;
                    }
                    if (entity.Cqs < 0)
                    {
                        errmsg = "车船税 不正确，应该为大于或者等于0的数字";
                        return false;
                    }
                    if (entity.Zbf < 0)
                    {
                        errmsg = "总保费/变动保费 不正确，应该为大于或者等于0的数字";
                        return false;
                    }

                    if (entity.Depart == "")
                    {
                        errmsg = "部门不能为空";
                        return false;
                    }
                    if (entity.Ywy == "")
                    {
                        errmsg = "业务员不能为空";
                        return false;
                    }

                    
                    if (entity.Tslx != "")
                    {
                        YwSpec spec = new YwSpec();
                        spec.SpecName = entity.Tslx;
                        int count = baseDao.Count(spec);
                        if (count <= 0)
                        {
                            errmsg = "特殊类型不存在";
                            return false;
                        }
                    }
                    #endregion
                    break;
                case "cbEdit":
                    #region 承保编辑保存校验
                    if (entity.Depart == "")
                    {
                        errmsg = "部门不能为空";
                        return false;
                    }
                    if (entity.Ywy == "")
                    {
                        errmsg = "业务员不能为空";
                        return false;
                    }
                    
                    if (entity.Tslx != "")
                    {
                        YwSpec spec = new YwSpec();
                        spec.SpecName = entity.Tslx;
                        int count = baseDao.Count(spec);
                        if (count <= 0)
                        {
                            errmsg = "特殊类型不存在";
                            return false;
                        }
                    }
                    #endregion
                    break;
            }
            return true;
        }
        //导出数据(Excel格式)
        public IWorkbook ExportData(YwData param, ref string errmsg)
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("fyExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            IList<YwData> list = baseDao.List(param);
            int i = 0;
            foreach (YwData temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateCbRow(rowT, temp);
            }
            return book;
        }
        #region 处理导出(承保)
        private void CreateCbRow(IRow row, YwData temp)
        {
            int index = 0;
            ICell cellxh = row.CreateCell(index + 0);
            cellxh.SetCellType(CellType.String);
            cellxh.SetCellValue(temp.Did.ToString());

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellType(CellType.String);
            cellnf.SetCellValue(temp.Year);

            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellType(CellType.String);
            cellyf.SetCellValue(temp.Month);
            //////////////////////////////////// 第一更新
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellType(CellType.String);
            cell1.SetCellValue(temp.Depart);

            index += 1;
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellType(CellType.String);
            cellywy.SetCellValue(temp.Ywy);

            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue(temp.Cxcs);

            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellType(CellType.String);
            cell3.SetCellValue(temp.Sncbgs);

            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellType(CellType.String);
            cell4.SetCellValue(temp.Sfpa);

            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellType(CellType.String);
            cell5.SetCellValue(temp.Sfyz);

            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellType(CellType.String);
            cell6.SetCellValue(temp.Cx2c);

            index++;
            ICell cell61 = row.CreateCell(index + 8);
            cell61.SetCellType(CellType.String);
            cell61.SetCellValue(temp.Cx3c);

            index++;
            ICell cell62 = row.CreateCell(index + 8);
            cell62.SetCellValue(temp.Wfglcx);

            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellType(CellType.String);
            cell7.SetCellValue(temp.Sfcgb);

            //ICell cell8 = row.CreateCell(index + 10);
            //cell8.SetCellType(CellType.Numeric);
            //cell8.SetCellValue(temp.Bp.ToString());
            //index++;
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellType(CellType.String);
            cellbz.SetCellValue(temp.Bz);

            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellType(CellType.String);
            cell9.SetCellValue(temp.Tslx);

            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellType(CellType.Numeric);
            //cell10.SetCellValue(temp.Zjfy.ToString());
            index--;
            ////////////////////////////////////////// 系统提取

            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellType(CellType.String);
            cell11.SetCellValue(temp.Jbr);

            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellType(CellType.String);
            cell12.SetCellValue(temp.Gsr);

            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellType(CellType.String);
            cell13.SetCellValue(temp.Cx);

            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellType(CellType.String);
            cell14.SetCellValue(temp.Qdm);

            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellType(CellType.String);
            cell15.SetCellValue(temp.Tk);

            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellType(CellType.String);
            cell16.SetCellValue(temp.Clxs);

            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellType(CellType.String);
            cell17.SetCellValue(temp.Bbr);

            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellType(CellType.String);
            cell18.SetCellValue(temp.Dzh);

            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellType(CellType.String);
            cell19.SetCellValue(temp.Cph);

            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellType(CellType.String);
            cell20.SetCellValue(temp.Dwxz);

            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellType(CellType.String);
            cell21.SetCellValue(temp.Zwh);

            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellType(CellType.String);
            cell22.SetCellValue(temp.Dws);

            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellType(CellType.String);
            cell23.SetCellValue(temp.Sfxb);

            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellType(CellType.String);
            cell24.SetCellValue(temp.Sfbbd);

            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellType(CellType.String);
            cell25.SetCellValue(temp.Sfbcsry);

            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellType(CellType.String);
            cell26.SetCellValue(temp.Sfbzr);

            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellType(CellType.String);
            cell27.SetCellValue(temp.Sfbfdj);

            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellType(CellType.String);
            cell28.SetCellValue(temp.Dbdsz);

            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellType(CellType.String);
            cell29.SetCellValue(temp.Dbjq);

            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellType(CellType.String);
            cell30.SetCellValue(temp.Sflwxm);

            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellType(CellType.String);
            cell31.SetCellValue(temp.Synx);

            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellType(CellType.String);
            cell32.SetCellValue(temp.Yhkh);

            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellType(CellType.String);
            cell33.SetCellValue(temp.Ywly);

            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellType(CellType.String);
            cell34.SetCellValue(temp.Khq);

            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellType(CellType.String);
            cell35.SetCellValue(temp.Qdrq.ToShortDateString());

            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellType(CellType.String);
            cell36.SetCellValue(temp.Qbrq.ToShortDateString());

            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellType(CellType.String);
            cell37.SetCellValue(temp.Zbrq.ToShortDateString());

            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellType(CellType.Numeric);
            cell38.SetCellValue(temp.Zbf.ToString());

            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellType(CellType.Numeric);
            cell39.SetCellValue(temp.Sybf.ToString());

            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellType(CellType.Numeric);
            cell40.SetCellValue(temp.Jqbf.ToString());

            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellType(CellType.Numeric);
            cell41.SetCellValue(temp.Cqs.ToString());

        }
        private void CreateHead(IRow row)
        {
            int index = 0;
            ICell cellxh = row.CreateCell(index + 0);
            cellxh.SetCellValue("序列号(不要修改)");

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("统计年份");

            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellValue("统计月份");
            //////////////////////////////////// 第一更新
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellValue("部门");

            index += 1;
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellValue("业务员");

            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellValue("上年出险总次数");

            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellValue("上年承保公司");

            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellValue("是否平安");

            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellValue("是否优质");

            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellValue("出险2次，是否赔付100%");

            index++;
            ICell cell61 = row.CreateCell(index + 8);
            cell61.SetCellValue("出险3次，是否赔付200%");

            index++;
            ICell cell62 = row.CreateCell(index + 8);
            cell62.SetCellValue("是否无法关联出险次数");

            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellValue("是否采购办");

            //ICell cell8 = row.CreateCell(index + 10);
            //cell8.SetCellValue("报批");
            //index++;
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellValue("备注");

            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellValue("特殊类型");

            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellValue("追加费用");
            index--;
            ////////////////////////////////////////// 系统提取

            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellValue("经办人");

            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellValue("归属人");

            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellValue("车型");

            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellValue("渠道码");

            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellValue("条款");

            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellValue("车辆类型性质");

            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellValue("被保险人");

            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellValue("单证号");

            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellValue("车牌号");

            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellValue("单位性质");

            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellValue("座位数");

            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellValue("吨位数");

            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellValue("是否新保、过户");

            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellValue("是否保盗抢");

            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellValue("是否保车上人员");

            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellValue("是否保自燃");

            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellValue("是否保发动机险");

            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellValue("单保三者");

            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellValue("单保交强");

            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellValue("是否录维修码");

            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellValue("使用年限");

            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellValue("银行卡号");

            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellValue("业务来源");

            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellValue("客户群");

            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellValue("签单日期");

            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellValue("起保日期");

            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellValue("终保日期");

            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellValue("总保费/变动保费");

            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellValue("商业保费");

            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellValue("交强保费");

            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellValue("车船税");

        }
        #endregion
        //处理承保导入的excel
        private void CreateErrorRow(ISheet sheet,int index,string msg)
        {
            IRow row = sheet.CreateRow(index);
            ICell cellxh = row.CreateCell(0);
            cellxh.SetCellType(CellType.String);
            cellxh.SetCellValue(msg);
        }
        public bool DealCbImport(IWorkbook book, XSSFWorkbook errBook,ref string errType, ref string errmsg)
        {
            
            ISheet errSheet = errBook.CreateSheet("error");
            int errIndex = 0;

            bool result = true;
            ISheet sheet = book.GetSheetAt(0);
            IRow headRow = sheet.GetRow(0);
            Dictionary<string, int> ht = new Dictionary<string, int>();
            result = CheckCbHead(headRow, ht,ref errmsg);
            if (result == false)
            {
                return false;
            }
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                try
                {
                    DealCbRow(i, sheet.GetRow(i), ht);
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    errType="content";
                    CreateErrorRow(errSheet, errIndex, ex.Message);
                    errIndex++;
                }
            }
            if (errIndex !=0)
            {
                return false;
            }
            return true;
        }
        #region 处理承保导入的excel
        private bool CheckCbHead(IRow headRow, Dictionary<string, int> ht, ref string errmsg)
        {
            int count = 0;
            for (int i = 0; i < headRow.Cells.Count; i++)
            {
                String sVal = headRow.GetCell(i).StringCellValue.Trim();
                switch (sVal)
                {
                    case "序列号(不要修改)":
                        if (ht.ContainsKey("did"))
                        {
                            errmsg = "[序列号]重复定义";
                            return false;
                        }

                        ht.Add("did", i);
                        count++;
                        break;
                    case "部门":
                        if (ht.ContainsKey("depart"))
                        {
                            errmsg = "[部门]重复定义";
                            return false;
                        }
                        ht.Add("depart", i);
                        count++;
                        break;
                    case "业务员":
                        if (ht.ContainsKey("ywy"))
                        {
                            errmsg = "[业务员]重复定义";
                            return false;
                        }
                        ht.Add("ywy", i);
                        count++;
                        break;
                    case "上年出险总次数":
                        if (ht.ContainsKey("cxcs"))
                        {
                            errmsg = "[上年出险总次数]重复定义";
                            return false;
                        }
                        ht.Add("cxcs", i);
                        count++;
                        break;
                    case "上年承保公司":
                        if (ht.ContainsKey("sncbgs"))
                        {
                            errmsg = "[上年承保公司]重复定义";
                            return false;
                        }
                        ht.Add("sncbgs", i);
                        count++;
                        break;
                    case "是否平安":
                        if (ht.ContainsKey("sfpa"))
                        {
                            errmsg = "[是否平安]重复定义";
                            return false;
                        }
                        ht.Add("sfpa", i);
                        count++;
                        break;
                    case "是否优质":
                        if (ht.ContainsKey("sfyz"))
                        {
                            errmsg = "[是否优质]重复定义";
                            return false;
                        }
                        ht.Add("sfyz", i);
                        count++;
                        break;
                    case "出险2次，是否赔付100%":
                        if (ht.ContainsKey("cx2c"))
                        {
                            errmsg = "[出险2次，是否赔付100%]重复定义";
                            return false;
                        }
                        ht.Add("cx2c", i);
                        count++;
                        break;
                    case "出险3次，是否赔付200%":
                        if (ht.ContainsKey("cx3c"))
                        {
                            errmsg = "[出险3次，是否赔付200%]重复定义";
                            return false;
                        }
                        ht.Add("cx3c", i);
                        count++;
                        break;
                    case "是否无法关联出险次数":
                        if (ht.ContainsKey("wfglcxcs"))
                        {
                            errmsg = "是否无法关联出险次数重复定义";
                            return false;
                        }
                        ht.Add("wfglcxcs", i);
                        count++;
                        break;
                    case "是否采购办":
                        if (ht.ContainsKey("sfcgb"))
                        {
                            errmsg = "[是否采购办]重复定义";
                            return false;
                        }
                        ht.Add("sfcgb", i);
                        count++;
                        break;
                    //case "报批":
                    //    if (ht.ContainsKey("bp"))
                    //    {
                    //        errmsg = "[报批]重复定义";
                    //        return false;
                    //    }
                    //    ht.Add("bp", i);
                    //    count++;
                    //    break;
                    case "备注":
                        if (ht.ContainsKey("bz"))
                        {
                            errmsg = "[备注]重复定义";
                            return false;
                        }
                        ht.Add("bz", i);
                        count++;
                        break;
                    case "特殊类型":
                        if (ht.ContainsKey("tslx"))
                        {
                            errmsg = "[特殊类型]重复定义";
                            return false;
                        }
                        ht.Add("tslx", i);
                        count++;
                        break;
                    //case "追加费用":
                    //    if (ht.ContainsKey("zjfy"))
                    //    {
                    //        errmsg = "[追加费用]重复定义";
                    //        return false;
                    //    }
                    //    ht.Add("zjfy", i);
                    //    count++;
                    //    break;
                }
            }
            if (count < 13)
            {
                errmsg = "需要填写的列数不正确";
                return false;
            }
            return true;
        }
        private void DealCbRow(int rowIndex, IRow row, Dictionary<string, int> ht)
        {

            YwData temp = new YwData();
            int count = 0;
            String did = "";
            try
            {
                ICell didCell = row.GetCell(ht["did"]);
                didCell.SetCellType(CellType.String);
                did = didCell.StringCellValue.Trim();
                if (did == null || did == "")
                {
                    throw new Exception("第" + rowIndex + "行 序列号没有值");
                }
                temp.Did = int.Parse(did);
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 序列号 格式不正确,应该为数字");
            }
           
            temp = baseDao.Get(temp);
            if (temp == null)
            {
                throw new Exception("第" + rowIndex + "行 没有找到序列号【" + did + "】的数据");
            }

            if (temp.CreateDate < this.GetBegDate())
            {
                throw new Exception("第" + rowIndex + "行 数据已经超过结账日，不允许导入");
            }
            if (temp.Status!=null&&temp.Status != "" && temp.Status != "1" && temp.Status != "2")
            {
                throw new Exception("第" + rowIndex + "行 数据流程已经到后道维护，不允许修改");
            }
            XtmDepart depT = new XtmDepart();
            try
            {
                ICell departCell = row.GetCell(ht["depart"]);
                departCell.SetCellType(CellType.String);
                String depart = departCell.StringCellValue.Trim();
                if (depart == null || depart == "")
                {
                    throw new Exception("第" + rowIndex + "行 部门没有值");
                }
               
                depT.DepartCode = depart;
                IList<XtmDepart> listDep = baseDao.List(depT);
                if (listDep== null||listDep.Count<=0)
                {
                    throw new Exception("第" + rowIndex + "行 部门不存在");
                }
                depT = listDep[0];
                temp.Depart = depart;
            }
            catch (Exception ex)
            {
                throw new Exception("第" + rowIndex + "行 部门没有值");
            }

            XtmUser user = new XtmUser();
            try
            {
                ICell ywyCell = row.GetCell(ht["ywy"]);
                ywyCell.SetCellType(CellType.String);
                String ywy = ywyCell.StringCellValue.Trim();
                if (ywy == null || ywy == "")
                {
                    throw new Exception("第" + rowIndex + "行 业务员没有值");
                }
               
                user.UserType = "ywy";
                user.UserCode = ywy;
                IList<XtmUser> userListt = baseDao.List(user);
                if (userListt == null || userListt.Count<=0)
                {
                    throw new Exception("第" + rowIndex + "行 业务员不存在");
                }
                user = userListt[0];
               
                temp.Ywy = ywy;
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 业务员没有值");
            }

            if (depT.Did != user.DepartId)
            {
                throw new Exception("第" + rowIndex + "行 业务员不是属于该部门");
            }


            int cxcsTemp = 0;
            try
            {
                ICell cxcsCell = row.GetCell(ht["cxcs"]);
                
                cxcsCell.SetCellType(CellType.String);
                string cxcsStr = cxcsCell.StringCellValue.Trim();
                if (cxcsStr == "3及以上")
                {
                    temp.Cxcs = "3及以上";
                }
                else
                {
                    cxcsTemp = int.Parse(cxcsStr);
                    if (cxcsTemp < 0)
                    {
                        throw new Exception("第" + rowIndex + "行 出险次数不正确，应该为大于或者等于0的整数");
                    }
                    switch (cxcsTemp)
                    {
                        case 0:
                            temp.Cxcs = "0";
                            break;
                        case 1:
                            temp.Cxcs = "1";
                            break;
                        case 2:
                            temp.Cxcs = "2";
                            break;
                        case 3:
                            temp.Cxcs = "3";
                            break;
                        default:
                            temp.Cxcs = "3及以上";
                            break;
                    }
                }
               
            }
            catch 
            {
                throw new Exception("第" + rowIndex + "行 出险次数不正确，应该为整数");
            }
            


            try
            {
                ICell sncbgsCell = row.GetCell(ht["sncbgs"]);
                sncbgsCell.SetCellType(CellType.String);
                temp.Sncbgs = sncbgsCell.StringCellValue.Trim();
            }
            catch
            {
                temp.Sncbgs = "";
            }

            try
            {
                ICell sfpaCell = row.GetCell(ht["sfpa"]);
                sfpaCell.SetCellType(CellType.String);
                String sfpa = sfpaCell.StringCellValue.Trim();
                if (sfpa == "是" || sfpa == "否")
                {
                    temp.Sfpa = sfpa;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 是否平安值格式不正确，应该为是或者否");
                }
            }
            catch 
            {
                throw new Exception("第" + rowIndex + "行 是否平安值格式不正确，应该为是或者否");
            }

            try
            {
                ICell sfyzCell = row.GetCell(ht["sfyz"]);
                sfyzCell.SetCellType(CellType.String);
                String sfyz = sfyzCell.StringCellValue.Trim();
                if (sfyz == "是" || sfyz == "否")
                {
                    temp.Sfyz = sfyz;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 是否优质值格式不正确，应该为是或者否");
                }
            }
            catch 
            {
                throw new Exception("第" + rowIndex + "行 是否优质值格式不正确，应该为是或者否");
            }

            try
            {
                ICell cx2cCell = row.GetCell(ht["cx2c"]);
                cx2cCell.SetCellType(CellType.String);
                String cx2c = cx2cCell.StringCellValue.Trim();
                if (cx2c == "是" || cx2c == "否")
                {
                    temp.Cx2c = cx2c;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 出险2次，是否赔付100%不正确，应该为是或者否");
                }
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 出险2次，是否赔付100%不正确，应该为是或者否");
            }

            try
            {
                ICell cx3cCell = row.GetCell(ht["cx3c"]);
                cx3cCell.SetCellType(CellType.String);
                String cx3c = cx3cCell.StringCellValue.Trim();
                if (cx3c == "是" || cx3c == "否")
                {
                    temp.Cx3c = cx3c;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 出险3次，是否赔付200%不正确，应该为是或者否");
                }
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 出险3次，是否赔付200%不正确，应该为是或者否");
            }

            try
            {
                ICell wfglCell = row.GetCell(ht["wfglcxcs"]);
                wfglCell.SetCellType(CellType.String);
                String wfgl = wfglCell.StringCellValue.Trim();
                if (wfgl == "是" || wfgl == "否")
                {
                    temp.Wfglcx = wfgl;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 是否无法关联出险次数，应该为是或者否");
                }
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 是否无法关联出险次数，应该为是或者否");
            }

            try
            {
                ICell sfcgbCell = row.GetCell(ht["sfcgb"]);
                sfcgbCell.SetCellType(CellType.String);
                String sfcgb = sfcgbCell.StringCellValue.Trim();
                if (sfcgb == "是" || sfcgb == "否")
                {
                    temp.Sfcgb = sfcgb;
                }
                else
                {
                    throw new Exception("第" + rowIndex + "行 是否采购办不正确，应该为是或者否");
                }
            }
            catch
            {
                throw new Exception("第" + rowIndex + "行 是否采购办不正确，应该为是或者否");
            }

            //try
            //{
            //    ICell bpCell = row.GetCell(ht["bp"]);
            //    bpCell.SetCellType(CellType.String);
            //    temp.Bp = decimal.Parse(bpCell.StringCellValue.Trim());
            //    if (temp.Bp < 0)
            //    {
            //        throw new Exception("第" + rowIndex + "行 报批应该为大于0的数字");
            //    }
            //}
            //catch
            //{
            //    throw new Exception("第" + rowIndex + "行 报批应该为大于0的数字");
            //}

            try
            {
                ICell bzCell = row.GetCell(ht["bz"]);
                bzCell.SetCellType(CellType.String);
                temp.Bz = bzCell.StringCellValue.Trim();
            }
            catch
            {
                temp.Bz = "";
            }

            try
            {
                ICell tslxCell = row.GetCell(ht["tslx"]);
                tslxCell.SetCellType(CellType.String);
                String tslx = tslxCell.StringCellValue.Trim();
                if (tslx != null && tslx != "")
                {
                    YwSpec spec = new YwSpec();
                    spec.SpecName = tslx;
                    count = baseDao.Count(spec);
                    if (count <= 0)
                    {
                        throw new Exception("第" + rowIndex + "行 特殊类型不存在");
                    }
                    temp.Tslx = tslx;
                }
            }
            catch
            {
                temp.Tslx = "";
            }

            //try
            //{
            //    ICell zjfyCell = row.GetCell(ht["zjfy"]);
            //    zjfyCell.SetCellType(CellType.String);
            //    String zjfy = zjfyCell.StringCellValue.Trim();
            //    if (zjfy != null && zjfy != "")
            //    {
            //        temp.Zjfy = decimal.Parse(zjfy);
            //        if (temp.Zjfy < 0)
            //        {
            //            throw new Exception("第" + rowIndex + "行 追加费用应该为大于0的数字");
            //        }
            //    }
            //}
            //catch
            //{
            //    throw new Exception("第" + rowIndex + "行 追加费用应该为大于0的数字");
            //}

            if (temp.Sybf <= 0)
            {
                temp.Xz = "交强险";
            }
            else
            {
                temp.Xz = "商业险";
            }

            if (temp.Xz == "商业险")
            {
                temp.Status = "2";
            }
            else
            {
                temp.Status = "4";
                FirstCalculate(rowIndex, temp);
                SeconeCalculate(temp);
            }
            temp.CbSubmit = DateTime.Now;
            baseDao.Update(temp);
        }
        #endregion
        //数据计算（第一次、第二次）
        #region 第一次计算
        public void FirstCalculate(int rowIndex, YwData param)
        {
            #region 字段补充
            CalculateSxflx(param, rowIndex);
            if (IsGH(param.Yhkh))
            {
                param.Ghsk = "是";
            }
            else
            {
                param.Ghsk = "否";
            }
            #endregion

            //计算 手续费差异化 、手续费
            //除手续费+工行刷卡费外无其他费用
            bool result = CalculateSpec1(rowIndex, param);
            if (result ==false)
            {
                if (param.Sfcgb == "是")
                {
                    param.CalculateType = "2";
                    //计算 手续费差异化 取固定值  、 手续费

                    CalculateSpec2(rowIndex, param);
                }
                else
                {
                    param.CalculateType = "3";
                    //计算手续费差异化 、  手续费
                    CalculateCYH(rowIndex, param);
                }
            }
            /////////上面只计算  手续费差异化   和手续费


            //计算 工行刷卡   0.002*(商业保费+交强保费+车船税)
            if (param.Ghsk == "是")
            {
                param.Ghskjl = (param.Sybf + param.Jqbf + param.Cqs) * decimal.Parse("0.002");
            }
            else
            {
                param.Ghskjl = 0;
            }
            if (param.CalculateType == "1")
            {
                return;
            }


            if (param.Sfyz == "是")
            {
                param.Cxydjl = param.Sybf * decimal.Parse("0.03");
            }
            else
            {
                param.Zxzwfy = 0;
                param.Cxydjl = 0;
            }

            //计算  交通通讯费宣传品  家用车、非营业车商业险保费*0.011
            if (param.Clxs == "家庭自用车" || param.Clxs.StartsWith("非营业"))// == "非营业货车" || param.Clxs == "非营业客车")
            {
                param.Jttxf = param.Sybf * decimal.Parse("0.011");
            }
            else
            {
                param.Jttxf = 0;
            }
        }
        #endregion
        #region 第二次计算
        public void SeconeCalculate(YwData param)
        {
            if (param.CalculateType == "1")
            {
                param.Zdxje = param.Sxfje + param.Ghskjl;
                return;
            }
            //兑现金额  
            if (param.Sfypz == "否")
            {
                if (param.Dwxz == "个人")
                {
                    param.Dxje = 0;
                }
                else
                {
                    param.Dxje = param.Sxfje + param.Bp;
                }
            }
            else
            {
                if (param.Sjscfy > (param.Sxfje + param.Bp))
                {
                    param.Dxje = param.Sxfje + param.Bp;
                }
                else
                {
                    param.Dxje = param.Sjscfy;
                }
            }
            //计算  税收  实际支付市场费用(凭证金额) /9  只有是有凭证的情况下才考虑税收
            if (param.Sfypz == "是")
            {
                param.Sh = param.Dxje / 9;
            }
            //计算 总兑现金额   兑现金额+交通通讯宣传费+车险月度奖励+工行刷卡
            param.Zdxje = param.Dxje + param.Jttxf + param.Cxydjl + param.Ghskjl + param.Sh;
            param.Zj = param.Dxje + param.Sh;
        }
        #endregion
        #region 计算
        //第一特例
        private bool CalculateSpec1(int rowIndex, YwData param)
        {
            YwSpec spec = new YwSpec();
            spec.SpecName = param.Bbr.Trim();

            IList<YwSpec> listT = baseDao.List(spec);
            if (listT == null || listT.Count <= 0)
            {
                return false;
            }
            decimal temp1 = 0;
            decimal temp2 = 0;
            if (param.Sybf != 0)
            {
                param.Sxfcyh = listT[0].Syxfv;
                temp1 = param.Sybf * listT[0].Syxfv / 100;
            }
            else
            {
                param.Sxfcyh = listT[0].Jqxfv;
                temp2 = param.Jqbf * listT[0].Jqxfv / 100;
            }
            param.CalculateType = "1";
            param.Sxfje = temp1 + temp2;
            return true;
        }
        //第二特例
        private void CalculateSpec2(int rowIndex, YwData param)
        {
            decimal temp1 = 0;
            decimal temp2 = 0;
            if (param.Sybf != 0)
            {
                param.Sxfcyh = decimal.Parse("8");
                temp1 = param.Sybf * decimal.Parse("8") / 100;
            }
            else
            {
                param.Sxfcyh = decimal.Parse("4");
                temp2 = param.Jqbf * decimal.Parse("4") / 100;
            }
            param.Sxfje = temp1 + temp2;// (param.Sybf * decimal.Parse("0.08")) + (param.Jqbf * decimal.Parse("0.04"));
        }
        //手续费差异化计算手续费
        private void CalculateCYH(int rowIndex, YwData param)
        {
            YwCyh temp = new YwCyh();
            //temp.Qd = param.Qd;//渠道
            temp.Xz = param.Xz;//险种
            temp.Dbdsz = param.Dbdsz;//单保第三者
            temp.Dbjq = param.Dbjq;//单保交强
            temp.Sxflx = param.Sxflx;//手续费类型
            //temp.Cllx = param.Clxs;//车辆类型
            temp.Ywly = param.Ywly;//业务类型
            temp.Wfglcxcs = param.Wfglcx;//是否无法关联出险次数
            switch (param.Cxcs)//出现次数
            {
                case "0":
                    temp.Zhcxcs = "0";
                    break;
                case "1":
                    temp.Zhcxcs = "1";
                    break;
                case "2":
                    temp.Zhcxcs = "2";
                    break;
                case "3":
                    temp.Zhcxcs = "3";
                    break;
                default:
                    temp.Zhcxcs = "4及以上";
                    break;
            }

            int synxT = (int)decimal.Parse(param.Synx);//使用年限
            //if (synxT == 0)
            //{
            //    temp.Synx = "0";
            //}
            //else
            //{
            switch (synxT)
            {
                case 0:
                    temp.Synx = "0";
                    break;
                case 1:
                    temp.Synx = "1";
                    break;
                case 2:
                    temp.Synx = "2";
                    break;
                default:
                    temp.Synx = "3及以上";
                    break;
            }
            //}
            //    if (synxT == 1)
            //    {
            //        temp.Synx = "1";
            //    }
            //    else
            //    {
            //        temp.Synx = "1年以上";
            //    }
            //}

            temp.Sfbcs = param.Sfbcs;//保车损
            if (temp.Xz == "商业险" && temp.Sfbcs != "是")
            {
                temp.Dbdsz = "是";
            }
            else
            {
                temp.Dbdsz = "否";
            }
            temp.Pfvsfc100 = param.Cx2c;//出现两次赔付100%
            temp.Cx3c = param.Cx3c;
            IList<YwCyh> listT = baseDao.List(temp);
            if (listT == null || listT.Count <= 0)
            {
                throw new Exception("第" + rowIndex + "行 无法取到 差异化信息,取值条件：险种：" + temp.Xz + "  单保第三者：" + temp.Dbdsz + "  单保交强:" + temp.Dbjq + "  手续费类型：" + temp.Sxflx + "  业务类型：" + temp.Ywly + "  是否无法关联出险次数：" + temp.Wfglcxcs + "  出险次数：" + temp.Zhcxcs + "  使用年限：" + temp.Synx + "  保车损：" + temp.Sfbcs + "  出现两次赔付100%：" + temp.Pfvsfc100 + "  出现三次赔付200%:" + temp.Cx3c);
            }
            else
            {
                param.qzbz = "取值条件：险种：" + temp.Xz + "  单保第三者：" + temp.Dbdsz + "  单保交强:" + temp.Dbjq + "  手续费类型：" + temp.Sxflx + "  业务类型：" + temp.Ywly + "  是否无法关联出险次数：" + temp.Wfglcxcs + "  出险次数：" + temp.Zhcxcs + "  使用年限：" + temp.Synx + "  保车损：" + temp.Sfbcs + "  出现两次赔付100%：" + temp.Pfvsfc100 + "  出现三次赔付200%:" + temp.Cx3c;
            }
            //=MAX(L2+M2+N2+MAX(O2,P2)+Q2-R2+S2,0)
            //基础手续费
            decimal Jcsxf = decimal.Parse(listT[0].Jcsxf);
            //临时量
            decimal cyhsxf = 0;

            //保车上人员(L2)
            if (param.Sfbcsry == "是")
            {
                cyhsxf += decimal.Parse(listT[0].Bcsry);
            }
            //保被盗(M2)
            if (param.Sfbbd == "是")
            {
                cyhsxf += decimal.Parse(listT[0].Bdqx);
            }

            //自燃、发动机
            decimal bzrx = 0;
            if (param.Sfbzr == "是")
            {
                bzrx = decimal.Parse(listT[0].Bzrx);
            }
            decimal bfdj = 0;
            if (param.Sfbfdj == "是")
            {
                bfdj = decimal.Parse(listT[0].Bfdj);
            }
            if (bzrx > bfdj)
            {
                cyhsxf += bzrx;
            }
            else
            {
                cyhsxf += bfdj;
            }
            //三者100万
            if (param.Szxbf == 1000000)
            {
                cyhsxf += decimal.Parse(listT[0].Sz100);
            }
            ////路推修码
            //if (param.Sflwxm == "是")
            //{
            //    cyhsxf -= decimal.Parse(listT[0].Qx);
            //}
            ////优质平安
            //if (param.Sfyz == "是" && param.Sfpa == "是")
            //{
            //    cyhsxf += decimal.Parse(listT[0].Uzpa);
            //}

            ////路推修码
            if (param.Sflwxm != null && param.Sflwxm != "")
            {
                YwTxjs txModelT = new YwTxjs();
                txModelT.Txm = param.Sflwxm.Trim();
                IList<YwTxjs> txList = baseDao.List(txModelT);
                if (txList != null && txList.Count > 0)
                {
                    cyhsxf += decimal.Parse(txList[0].Xs);
                }
            }

            //if (param.Ywly == "转入" && param.Sfyz == "是")
            //{
            //    cyhsxf += decimal.Parse(listT[0].Yzzrjs);
            //}

            Jcsxf = Jcsxf + cyhsxf;
            if (Jcsxf < 0)
            {
                Jcsxf = 0;
            }

            param.Sxfcyh = Jcsxf;

            //if (param.Xz != "交强险")
            //{
            //    if (param.Sfypz != "是" && param.Clxs.Trim() == "家庭自用车")
            //    {
            //        if (param.Sxfcyh > 17)
            //        {
            //            param.Sxfcyh = 17;
            //        }
            //    }
            //}

            param.Sxfje = param.Zbf * param.Sxfcyh / 100;
        }
        //计算手续费类型
        private void CalculateSxflx(YwData param, int rowIndex)
        {
            param.Sxflx = "";
            #region 家庭自用车
            if (param.Clxs == "家庭自用车")
            {
                if (param.Ywly == "转入")
                {
                    if (param.Sfbcs == "是")
                    {
                        if (param.Sncbgs.Contains("平安"))
                        {
                            param.Sxflx = "家用车外主体竞回（有保车损）（平安）";
                        }
                        else
                        {
                            param.Sxflx = "家用车外主体竞回（有保车损）（非平安）";
                        }
                    }
                    else
                    {
                        param.Sxflx = "家用车";
                    }
                }
                else
                {
                    param.Sxflx = "家用车";
                }
            }
            #endregion
            #region 非营业客车或工具车
            if (param.Sxflx == "")
            {
                if (param.Clxs == "非营业客车")
                {
                    param.Sxflx = "非营业客车或工具车";
                }
            }
            if (param.Sxflx == "")
            {
                decimal zws = decimal.Parse(param.Zwh);
                decimal dws = decimal.Parse(param.Dws);
                if (zws >= 4 && zws <= 6 && dws < 750)
                {
                    if (param.Cx.Contains("轻型") || param.Cx.Contains("多用途"))
                    {
                        param.Sxflx = "非营业客车或工具车";
                        return;
                    }
                }
            }
            #endregion
            int bbrLen = param.Bbr.Length;
            if (param.Sxflx == "")
            {
                
                if ((param.Clxs == "非营业货车" && bbrLen > 4) || (param.Tk == "F46" && param.Khq == "其它非营业车辆"))
                {
                    param.Sxflx = "企业非营业货车或非营业特种车";
                }
            }
            if (param.Sxflx == "")
            {
                if ((param.Clxs == "非营业货车" && bbrLen <= 4) )
                {
                    param.Sxflx = "个人非营业货车";
                }
            }
       
            if (param.Sxflx == "")
            {
                if (param.Tk == "F43" || (param.Tk == "F46" && param.Khq == "其它营业车辆"))
                {
                    param.Sxflx = "营业车、营业特种车";
                }
            }

            if (param.Sxflx == "")
            {
                throw new Exception("第"+rowIndex+" 行没有找到手续费类型");
            }
           
        }
        
        #endregion
        
        #region 查询统计导出
        public IWorkbook QueryExportData(string type,YwData param,ref string errmsg)
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("dataExport");
            IRow row = sheet.CreateRow(0);
            CreateQueryHead(row);
            IList<YwData> list = baseDao.ListUdf("YwDataExport", param);
            if (list != null && list.Count > 0)
            {
                string oldYwy = "";
                Dictionary<string, decimal> mxDicT = new Dictionary<string, decimal>();
                Dictionary<string, decimal> sumDicT = new Dictionary<string, decimal>();
                mxDicT.Add("报批", 0);sumDicT.Add("报批", 0);
                //mxDicT.Add("追加费用", 0); sumDicT.Add("追加费用", 0);
                mxDicT.Add("总保费", 0); sumDicT.Add("总保费", 0);
                mxDicT.Add("商业保费", 0); sumDicT.Add("商业保费", 0);
                mxDicT.Add("交强保费", 0); sumDicT.Add("交强保费", 0);
                mxDicT.Add("车船税", 0); sumDicT.Add("车船税", 0);
                mxDicT.Add("实际支付市场费用", 0); sumDicT.Add("实际支付市场费用", 0);
                mxDicT.Add("手续费金额", 0); sumDicT.Add("手续费金额", 0);
                //mxDicT.Add("实际支付报批费用", 0); sumDicT.Add("实际支付报批费用", 0);
                mxDicT.Add("税收", 0); sumDicT.Add("税收", 0);
                //mxDicT.Add("自行掌握费用", 0); sumDicT.Add("自行掌握费用", 0);
                //mxDicT.Add("自行掌握费用结余", 0); sumDicT.Add("自行掌握费用结余", 0);
                //mxDicT.Add("自行掌握费用结余奖励70%", 0); sumDicT.Add("自行掌握费用结余奖励70%", 0);
                mxDicT.Add("兑现金额", 0); sumDicT.Add("兑现金额", 0);
                mxDicT.Add("交通通讯费宣传品", 0); sumDicT.Add("交通通讯费宣传品", 0);
                mxDicT.Add("车险月度固定奖励", 0); sumDicT.Add("车险月度固定奖励", 0);
                mxDicT.Add("工行刷卡", 0); sumDicT.Add("工行刷卡", 0);
                mxDicT.Add("总兑现金额", 0); sumDicT.Add("总兑现金额", 0);
                mxDicT.Add("总计", 0); sumDicT.Add("总计", 0);
              
                int i = 0;
                foreach (YwData ywTemp in list)
                {
                   
                    if (oldYwy != "" && oldYwy != ywTemp.Ywy)
                    {
                        
                        i += 1;
                        IRow sumRow = sheet.CreateRow(i);
                        CreateTailRow(book, sumRow, mxDicT);
                        RewriteFY(mxDicT, sumDicT);
                       
                    }
                    i += 1;
                    oldYwy = ywTemp.Ywy;
                    IRow rowT = sheet.CreateRow(i);
                    CreateQueryRow(rowT, ywTemp, mxDicT);

                }
                i += 1;
                IRow lastRow = sheet.CreateRow(i);
                CreateTailRow(book, lastRow, mxDicT);
                RewriteFY(mxDicT, sumDicT);
               
                if (type != "ywy")
                {
                    i += 1;
                    IRow totalRow = sheet.CreateRow(i);
                    CreateSumTailRow(book, totalRow, sumDicT);
                }
            }
            return book;
        }
        
        private void RewriteFY(Dictionary<string, decimal> mxDicT, Dictionary<string, decimal> sumDicT)
        {
            sumDicT["报批"]=mxDicT["报批"]+sumDicT["报批"];
            //sumDicT["追加费用"]=mxDicT["追加费用"]+sumDicT["追加费用"];
            sumDicT["总保费"]=mxDicT["总保费"]+sumDicT["总保费"];
            sumDicT["商业保费"]=mxDicT["商业保费"]+sumDicT["商业保费"];
            sumDicT["交强保费"]=mxDicT["交强保费"]+sumDicT["交强保费"];
            sumDicT["车船税"]=mxDicT["车船税"]+sumDicT["车船税"];
            sumDicT["实际支付市场费用"]=mxDicT["实际支付市场费用"]+sumDicT["实际支付市场费用"];
            sumDicT["手续费金额"]=mxDicT["手续费金额"]+sumDicT["手续费金额"];
            //sumDicT["实际支付报批费用"]=mxDicT["实际支付报批费用"]+ sumDicT["实际支付报批费用"];
            sumDicT["税收"]=mxDicT["税收"]+ sumDicT["税收"];
            //sumDicT["自行掌握费用"]=mxDicT["自行掌握费用"]+sumDicT["自行掌握费用"];
            //sumDicT["自行掌握费用结余"]=mxDicT["自行掌握费用结余"]+sumDicT["自行掌握费用结余"];
            //sumDicT["自行掌握费用结余奖励70%"]=mxDicT["自行掌握费用结余奖励70%"]+ sumDicT["自行掌握费用结余奖励70%"];
            sumDicT["兑现金额"]=mxDicT["兑现金额"]+sumDicT["兑现金额"];
            sumDicT["交通通讯费宣传品"]=mxDicT["交通通讯费宣传品"]+sumDicT["交通通讯费宣传品"];
            sumDicT["车险月度固定奖励"]=mxDicT["车险月度固定奖励"]+sumDicT["车险月度固定奖励"];
            sumDicT["工行刷卡"]=mxDicT["工行刷卡"]+sumDicT["工行刷卡"];
            sumDicT["总兑现金额"]=mxDicT["总兑现金额"]+ sumDicT["总兑现金额"];
            sumDicT["总计"] = mxDicT["总计"] + sumDicT["总计"];


            mxDicT["报批"]=0;
            //mxDicT["追加费用"]=0;
            mxDicT["总保费"]=0;
            mxDicT["商业保费"]=0;
            mxDicT["交强保费"]=0;
            mxDicT["车船税"]=0;
            mxDicT["实际支付市场费用"]=0;
            mxDicT["手续费金额"]=0;
            //mxDicT["实际支付报批费用"]=0;
            mxDicT["税收"]=0;
            //mxDicT["自行掌握费用"]=0;
            //mxDicT["自行掌握费用结余"]=0;
            //mxDicT["自行掌握费用结余奖励70%"]=0;
            mxDicT["兑现金额"]=0;
            mxDicT["交通通讯费宣传品"]=0;
            mxDicT["车险月度固定奖励"]=0;
            mxDicT["工行刷卡"]=0;
            mxDicT["总兑现金额"] = 0;
            mxDicT["总计"] = 0;
        }
       
        public void CreateTailRow(IWorkbook book, IRow row, Dictionary<string, decimal> mxDicT)
        {
            #region 样式
            ICellStyle style = book.CreateCellStyle();//样式
            //设置背景色
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
           
            #endregion

            int index = -1;

            //年份
            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("");
            cellnf.CellStyle = style;
            //月份
            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellValue("");
            cellyf.CellStyle = style;
            //////////////////////////////////// 第一更新
            //部门
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellValue("");
            cell1.CellStyle = style;
            index++;
            //业务员
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellValue("");
            cellywy.CellStyle = style;

            index++;
            //手续费类型
            ICell sxfCell = row.CreateCell(index + 3);
            sxfCell.SetCellValue("");
            sxfCell.CellStyle = style;

            index++;
            //是否无法关联出险次数
            ICell wfglCell = row.CreateCell(index + 3);
            wfglCell.SetCellValue("");
            wfglCell.CellStyle = style;
            

            //上年出险总次数
            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellValue("");
            cell2.CellStyle = style;
            //上年承保公司
            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellValue("");
            cell3.CellStyle = style;
            //是否平安
            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellValue("");
            cell4.CellStyle = style;
            //是否优质
            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellValue("");
            cell5.CellStyle = style;
            //出险2次，是否赔付100%
            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellValue("");
            cell6.CellStyle = style;

            index++;
            //出险2次，是否赔付100%
            ICell cell61 = row.CreateCell(index + 8);
            cell61.SetCellValue("");
            cell61.CellStyle = style;


            //是否采购办
            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellValue("");
            cell7.CellStyle = style;
            //报批
            ICell cell8 = row.CreateCell(index + 10);
            cell8.SetCellType(CellType.Numeric);
            cell8.SetCellValue(double.Parse(mxDicT["报批"].ToString()));
            cell8.CellStyle = style;
            index++;
            //备注
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellValue("");
            cellbz.CellStyle = style;
            //特殊类型
            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellValue("");
            cell9.CellStyle = style;
            ////追加费用
            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellType(CellType.Numeric);
            //cell10.SetCellValue(double.Parse(mxDicT["追加费用"].ToString()));
            //cell10.CellStyle = style;
            index--;
            ////////////////////////////////////////// 系统提取
            //经办
            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellValue("");
            cell11.CellStyle = style;
            //归属
            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellValue("");
            cell12.CellStyle = style;
            //车型
            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellValue("");
            cell13.CellStyle = style;
            //渠道码
            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellValue("");
            cell14.CellStyle = style;
            //条款
            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellValue("");
            cell15.CellStyle = style;
            //车辆类型
            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellValue("");
            cell16.CellStyle = style;
            //被保人
            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellValue("");
            cell17.CellStyle = style;
            //单证号
            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellValue("");
            cell18.CellStyle = style;
            //车牌号
            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellValue("");
            cell19.CellStyle = style;
            //单位性质
            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellValue("");
            cell20.CellStyle = style;
            //座位数
            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellValue("");
            cell21.CellStyle = style;
            //吨位数
            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellValue("");
            cell22.CellStyle = style;
            //是否新保、过户
            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellValue("");
            cell23.CellStyle = style;
            //是否保盗抢
            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellValue("");
            cell24.CellStyle = style;
            //是否保车上人员
            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellValue("");
            cell25.CellStyle = style;
            //是否保自燃
            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellValue("");
            cell26.CellStyle = style;
            //是否保发动机
            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellValue("");
            cell27.CellStyle = style;
            //单保三者
            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellValue("");
            cell28.CellStyle = style;
            //单保交强
            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellValue("");
            cell29.CellStyle = style;
            //是否录推修码
            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellValue("");
            cell30.CellStyle = style;
            //使用年限
            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellValue("");
            cell31.CellStyle = style;
            //是否刷工行卡
            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellValue("");
            cell32.CellStyle = style;
            //业务来源
            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellValue("");
            cell33.CellStyle = style;
            //客户群
            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellValue("");
            cell34.CellStyle = style;
            //签单日期
            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellValue("");
            cell35.CellStyle = style;
            //起保日期
            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellValue("");
            cell36.CellStyle = style;
            //终保日期
            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellValue("");
            cell37.CellStyle = style;
            //总保费
            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellType(CellType.Numeric);
            cell38.SetCellValue(double.Parse(mxDicT["总保费"].ToString()));
            cell38.CellStyle = style;
            //商业保费
            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellType(CellType.Numeric);
            cell39.SetCellValue(double.Parse(mxDicT["商业保费"].ToString()));
            cell39.CellStyle = style;
            //交强保费
            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellType(CellType.Numeric);
            cell40.SetCellValue(double.Parse(mxDicT["交强保费"].ToString()));
            cell40.CellStyle = style;
            //车船税
            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellType(CellType.Numeric);
            cell41.SetCellValue(double.Parse(mxDicT["车船税"].ToString()));
            cell41.CellStyle = style;
            //是否有凭证
            ICell cell42 = row.CreateCell(index + 44);
            cell42.CellStyle = style;
            cell42.SetCellValue("");
            //实际支付市场费用（凭证金额）
            ICell cell43 = row.CreateCell(index + 45);
            cell43.SetCellType(CellType.Numeric);
            cell43.SetCellValue(double.Parse(mxDicT["实际支付市场费用"].ToString()));
            cell43.CellStyle = style;
            //手续费差异化
            ICell cell44 = row.CreateCell(index + 46);
            cell44.SetCellValue("");
            cell44.CellStyle = style;
            //手续费金额
            ICell cell45 = row.CreateCell(index + 47);
            cell45.SetCellType(CellType.Numeric);
            cell45.SetCellValue(double.Parse(mxDicT["手续费金额"].ToString()));
            cell45.CellStyle = style;
            //实际支付报批费用
            //ICell cell46 = row.CreateCell(index + 48);
            //cell46.SetCellType(CellType.Numeric);
            //if ((mxDicT["实际支付市场费用"] - mxDicT["手续费金额"]) > mxDicT["自行掌握费用"] && mxDicT["报批"] < ((mxDicT["实际支付市场费用"] - mxDicT["手续费金额"]) - mxDicT["自行掌握费用"]))
            //{
            //    mxDicT["实际支付报批费用"] = mxDicT["报批"];
            //}
            //else
            //{
            //    if ((mxDicT["实际支付市场费用"] - mxDicT["手续费金额"]) > mxDicT["自行掌握费用"] && mxDicT["报批"] > ((mxDicT["实际支付市场费用"] - mxDicT["手续费金额"]) - mxDicT["自行掌握费用"]))
            //    {
            //        mxDicT["实际支付报批费用"] = mxDicT["实际支付市场费用"] - mxDicT["手续费金额"] - mxDicT["自行掌握费用"];
            //    }
            //    else
            //    {
            //        if (mxDicT["实际支付市场费用"] - mxDicT["手续费金额"] < mxDicT["自行掌握费用"])
            //        {
            //            mxDicT["实际支付报批费用"] = 0;
            //        }
            //        else
            //        {
            //            if (mxDicT["实际支付市场费用"] - mxDicT["手续费金额"] < 0)
            //            {
            //                mxDicT["实际支付报批费用"] = 0;
            //            }
            //        }
            //    }
            //}
            //cell46.SetCellValue(double.Parse(mxDicT["实际支付报批费用"].ToString()));
            //cell46.CellStyle = style;
            index--;
            //税收
            ICell cell47 = row.CreateCell(index + 49);
            cell47.SetCellType(CellType.Numeric);
            cell47.SetCellValue(double.Parse(mxDicT["税收"].ToString()));
            cell47.CellStyle = style;
            ////自行掌握费用
            //ICell cell48 = row.CreateCell(index + 50);
            //cell48.SetCellType(CellType.Numeric);
            //cell48.SetCellValue(double.Parse(mxDicT["自行掌握费用"].ToString()));
            //cell48.CellStyle = style;
            ////自行掌握费用结余
            //ICell cell49 = row.CreateCell(index + 51);
            //cell49.SetCellType(CellType.Numeric);
            //cell49.SetCellValue(double.Parse(mxDicT["自行掌握费用结余"].ToString()));
            //cell49.CellStyle = style;
            ////自行帐务费用结余奖励
            //ICell cell50 = row.CreateCell(index + 52);
            //cell50.SetCellType(CellType.Numeric);
            //mxDicT["自行掌握费用结余奖励70%"] = mxDicT["自行掌握费用结余"]*decimal.Parse("0.7");
            //cell50.SetCellValue(double.Parse(mxDicT["自行掌握费用结余奖励70%"].ToString()));
            //cell50.CellStyle = style;
            ////补提供凭证金额
            //ICell cell51 = row.CreateCell(index + 53);
            //cell51.SetCellValue("");
            //cell51.CellStyle = style;
            index -= 4;
            //兑现金额
            ICell cell52 = row.CreateCell(index + 54);
            cell52.SetCellType(CellType.Numeric);
            
            
            //if (mxDicT["自行掌握费用结余"] < 0)
            //{
            //    mxDicT["兑现金额"] = 0;
            //}
            //else
            //{
            //    if((mxDicT["实际支付市场费用"] - mxDicT["手续费金额"])>(mxDicT["自行掌握费用"]+mxDicT["报批"]))
            //    {
            //        mxDicT["兑现金额"] = mxDicT["自行掌握费用"] + mxDicT["报批"] + mxDicT["手续费金额"];
            //    }else
            //    {
            //        mxDicT["兑现金额"] = mxDicT["自行掌握费用结余奖励70%"] + mxDicT["实际支付市场费用"] + mxDicT["手续费金额"];
            //    }
            //}
            cell52.SetCellValue(double.Parse(mxDicT["兑现金额"].ToString()));
            cell52.CellStyle = style;
            //交通通讯宣传品
            ICell cell53 = row.CreateCell(index + 55);
            cell53.SetCellType(CellType.Numeric);
            cell53.SetCellValue(double.Parse(mxDicT["交通通讯费宣传品"].ToString()));
            cell53.CellStyle = style;
            //车险月度固定奖励
            ICell cell54 = row.CreateCell(index + 56);
            cell54.SetCellType(CellType.Numeric);
            cell54.SetCellValue(double.Parse(mxDicT["车险月度固定奖励"].ToString()));
            cell54.CellStyle = style;
            //工行刷卡
            ICell cell55 = row.CreateCell(index + 57);
            cell55.SetCellType(CellType.Numeric);
            cell55.SetCellValue(double.Parse(mxDicT["工行刷卡"].ToString()));
            cell55.CellStyle = style;
            index++;
            //总计
            ICell cell551 = row.CreateCell(index + 57);
            cell551.SetCellType(CellType.Numeric);
            cell551.SetCellValue(double.Parse(mxDicT["总计"].ToString()));
            cell551.CellStyle = style;


            //总兑现金额
            ICell cell56 = row.CreateCell(index + 58);
            cell56.SetCellType(CellType.Numeric);
            mxDicT["总兑现金额"] = mxDicT["兑现金额"] + mxDicT["交通通讯费宣传品"] + mxDicT["车险月度固定奖励"] + mxDicT["工行刷卡"];
            cell56.SetCellValue(double.Parse(mxDicT["总兑现金额"].ToString()));
            cell56.CellStyle = style;
           
        }

        public void CreateSumTailRow(IWorkbook book, IRow row, Dictionary<string, decimal> sumDicT)
        {
            #region 样式
            ICellStyle style = book.CreateCellStyle();//样式
            //设置背景色
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.BrightGreen.Index;
            style.FillPattern = FillPattern.SolidForeground;
            style.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.BrightGreen.Index;
           
            #endregion

            int index = -1;

            //年份
            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("");
            cellnf.CellStyle = style;
            //月份
            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellValue("");
            cellyf.CellStyle = style;
            //////////////////////////////////// 第一更新
            //部门
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellValue("");
            cell1.CellStyle = style;
            index += 1;
            //业务员
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellValue("");
            cellywy.CellStyle = style;

            index++;
            //手续费类型
            ICell sxfCell = row.CreateCell(index + 3);
            sxfCell.SetCellValue("");
            sxfCell.CellStyle = style;

            index++;
            //是否无法关联出险次数
            ICell wfglCell = row.CreateCell(index + 3);
            wfglCell.SetCellValue("");
            wfglCell.CellStyle = style;


            //上年出险总次数
            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellValue("");
            cell2.CellStyle = style;
            //上年承保公司
            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellValue("");
            cell3.CellStyle = style;
            //是否平安
            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellValue("");
            cell4.CellStyle = style;
            //是否优质
            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellValue("");
            cell5.CellStyle = style;
            //出险2次，是否赔付100%
            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellValue("");
            cell6.CellStyle = style;

            index++;
            //出险2次，是否赔付100%
            ICell cell61 = row.CreateCell(index + 8);
            cell61.SetCellValue("");
            cell61.CellStyle = style;


            //是否采购办
            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellValue("");
            cell7.CellStyle = style;
            //报批
            ICell cell8 = row.CreateCell(index + 10);
            cell8.SetCellType(CellType.Numeric);
            cell8.SetCellValue(double.Parse(sumDicT["报批"].ToString()));
            cell8.CellStyle = style;
            index++;
            //备注
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellValue("");
            cellbz.CellStyle = style;
            //特殊类型
            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellValue("");
            cell9.CellStyle = style;
            ////追加费用
            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellType(CellType.Numeric);
            //cell10.SetCellValue(double.Parse(sumDicT["追加费用"].ToString()));
            //cell10.CellStyle = style;
            index--;
            ////////////////////////////////////////// 系统提取
            //经办
            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellValue("");
            cell11.CellStyle = style;
            //归属
            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellValue("");
            cell12.CellStyle = style;
            //车型
            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellValue("");
            cell13.CellStyle = style;
            //渠道码
            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellValue("");
            cell14.CellStyle = style;
            //条款
            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellValue("");
            cell15.CellStyle = style;
            //车辆类型
            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellValue("");
            cell16.CellStyle = style;
            //被保人
            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellValue("");
            cell17.CellStyle = style;
            //单证号
            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellValue("");
            cell18.CellStyle = style;
            //车牌号
            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellValue("");
            cell19.CellStyle = style;
            //单位性质
            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellValue("");
            cell20.CellStyle = style;
            //座位数
            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellValue("");
            cell21.CellStyle = style;
            //吨位数
            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellValue("");
            cell22.CellStyle = style;
            //是否新保、过户
            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellValue("");
            cell23.CellStyle = style;
            //是否保盗抢
            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellValue("");
            cell24.CellStyle = style;
            //是否保车上人员
            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellValue("");
            cell25.CellStyle = style;
            //是否保自燃
            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellValue("");
            cell26.CellStyle = style;
            //是否保发动机
            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellValue("");
            cell27.CellStyle = style;
            //单保三者
            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellValue("");
            cell28.CellStyle = style;
            //单保交强
            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellValue("");
            cell29.CellStyle = style;
            //是否录推修码
            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellValue("");
            cell30.CellStyle = style;
            //使用年限
            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellValue("");
            cell31.CellStyle = style;
            //是否刷工行卡
            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellValue("");
            cell32.CellStyle = style;
            //业务来源
            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellValue("");
            cell33.CellStyle = style;
            //客户群
            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellValue("");
            cell34.CellStyle = style;
            //签单日期
            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellValue("");
            cell35.CellStyle = style;
            //起保日期
            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellValue("");
            cell36.CellStyle = style;
            //终保日期
            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellValue("");
            cell37.CellStyle = style;
            //总保费
            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellType(CellType.Numeric);
            cell38.SetCellValue(double.Parse(sumDicT["总保费"].ToString()));
            cell38.CellStyle = style;
            //商业保费
            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellType(CellType.Numeric);
            cell39.SetCellValue(double.Parse(sumDicT["商业保费"].ToString()));
            cell39.CellStyle = style;
            //交强保费
            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellType(CellType.Numeric);
            cell40.SetCellValue(double.Parse(sumDicT["交强保费"].ToString()));
            cell40.CellStyle = style;
            //车船税
            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellType(CellType.Numeric);
            cell41.SetCellValue(double.Parse(sumDicT["车船税"].ToString()));
            cell41.CellStyle = style;
            //是否有凭证
            ICell cell42 = row.CreateCell(index + 44);
            cell42.SetCellValue("");
            cell42.CellStyle = style;
            //实际支付市场费用（凭证金额）
            ICell cell43 = row.CreateCell(index + 45);
            cell43.SetCellType(CellType.Numeric);
            cell43.SetCellValue(double.Parse(sumDicT["实际支付市场费用"].ToString()));
            cell43.CellStyle = style;
            //手续费差异化
            ICell cell44 = row.CreateCell(index + 46);
            cell44.SetCellValue("");
            cell44.CellStyle = style;
            //手续费金额
            ICell cell45 = row.CreateCell(index + 47);
            cell45.SetCellType(CellType.Numeric);
            cell45.SetCellValue(double.Parse(sumDicT["手续费金额"].ToString()));
            cell45.CellStyle = style;
            ////实际支付报批费用
            //ICell cell46 = row.CreateCell(index + 48);
            //cell46.SetCellType(CellType.Numeric);
            //cell46.SetCellValue(double.Parse(sumDicT["实际支付报批费用"].ToString()));
            //cell46.CellStyle = style;
            index--;
            //税收
            ICell cell47 = row.CreateCell(index + 49);
            cell47.SetCellType(CellType.Numeric);
            cell47.SetCellValue(double.Parse(sumDicT["税收"].ToString()));
            cell47.CellStyle = style;
            ////自行掌握费用
            //ICell cell48 = row.CreateCell(index + 50);
            //cell48.SetCellType(CellType.Numeric);
            //cell48.SetCellValue(double.Parse(sumDicT["自行掌握费用"].ToString()));
            //cell48.CellStyle = style;
            ////自行掌握费用结余
            //ICell cell49 = row.CreateCell(index + 51);
            //cell49.SetCellType(CellType.Numeric);
            //cell49.SetCellValue(double.Parse(sumDicT["自行掌握费用结余"].ToString()));
            //cell49.CellStyle = style;
            ////自行帐务费用结余奖励
            //ICell cell50 = row.CreateCell(index + 52);
            //cell50.SetCellType(CellType.Numeric);
            //cell50.SetCellValue(double.Parse(sumDicT["自行掌握费用结余奖励70%"].ToString()));
            //cell50.CellStyle = style;
            ////补提供凭证金额
            //ICell cell51 = row.CreateCell(index + 53);
            //cell51.SetCellValue("");
            //cell51.CellStyle = style;
            index -= 4;
            //兑现金额
            ICell cell52 = row.CreateCell(index + 54);
            cell52.SetCellType(CellType.Numeric);
            cell52.SetCellValue(double.Parse(sumDicT["兑现金额"].ToString()));
            cell52.CellStyle = style;
            //交通通讯宣传品
            ICell cell53 = row.CreateCell(index + 55);
            cell53.SetCellType(CellType.Numeric);
            cell53.SetCellValue(double.Parse(sumDicT["交通通讯费宣传品"].ToString()));
            cell53.CellStyle = style;
            //车险月度固定奖励
            ICell cell54 = row.CreateCell(index + 56);
            cell54.SetCellType(CellType.Numeric);
            cell54.SetCellValue(double.Parse(sumDicT["车险月度固定奖励"].ToString()));
            cell54.CellStyle = style;
            //工行刷卡
            ICell cell55 = row.CreateCell(index + 57);
            cell55.SetCellType(CellType.Numeric);
            cell55.SetCellValue(double.Parse(sumDicT["工行刷卡"].ToString()));
            cell55.CellStyle = style;
            index++;
            //总计
            ICell cell551 = row.CreateCell(index + 57);
            cell551.SetCellType(CellType.Numeric);
            cell551.SetCellValue(double.Parse(sumDicT["总计"].ToString()));
            cell551.CellStyle = style;
            
            //总兑现金额
            ICell cell56 = row.CreateCell(index + 58);
            cell56.SetCellType(CellType.Numeric);
            cell56.SetCellValue(double.Parse(sumDicT["总兑现金额"].ToString()));
            cell56.CellStyle = style;

        }
       
        public void CreateQueryHead(IRow row)
        {
            int index = -1;
            
            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("统计年份");

            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellValue("统计月份");
            //////////////////////////////////// 第一更新
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellValue("部门");

            index += 1;
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellValue("业务员");


            index++;
            //手续费类型
            ICell sxfCell = row.CreateCell(index + 3);
            sxfCell.SetCellValue("业务员");

            index++;
            //是否无法关联出险次数
            ICell wfglCell = row.CreateCell(index + 3);
            wfglCell.SetCellValue("是否无法关联出险次数");

            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellValue("上年出险总次数");

            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellValue("上年承保公司");

            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellValue("是否平安");

            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellValue("是否优质");

            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellValue("出险2次，是否赔付100%");

            index++;
            ICell cell61 = row.CreateCell(index + 8);
            cell61.SetCellValue("出险3次，是否赔付200%");

            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellValue("是否采购办");

            ICell cell8 = row.CreateCell(index + 10);
            cell8.SetCellValue("报批");
            index++;
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellValue("备注");

            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellValue("特殊类型");

            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellValue("追加费用");
            index--;
            ////////////////////////////////////////// 系统提取

            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellValue("经办人");

            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellValue("归属人");

            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellValue("车型");

            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellValue("渠道码");

            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellValue("条款");

            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellValue("车辆类型性质");

            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellValue("被保险人");

            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellValue("单证号");

            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellValue("车牌号");

            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellValue("单位性质");

            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellValue("座位数");

            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellValue("吨位数");

            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellValue("是否新保、过户");

            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellValue("是否保盗抢");

            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellValue("是否保车上人员");

            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellValue("是否保自燃");

            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellValue("是否保发动机险");

            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellValue("单保三者");

            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellValue("单保交强");

            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellValue("是否录维修码");

            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellValue("使用年限");

            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellValue("银行卡号");

            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellValue("业务来源");

            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellValue("客户群");

            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellValue("签单日期");

            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellValue("起保日期");

            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellValue("终保日期");

            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellValue("总保费/变动保费");

            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellValue("商业保费");

            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellValue("交强保费");

            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellValue("车船税");

            ICell cell42 = row.CreateCell(index + 44);
            cell42.SetCellValue("是否有凭证");

            ICell cell43 = row.CreateCell(index + 45);
            cell43.SetCellValue("实际支付市场费用（凭证金额）");

            ICell cell44 = row.CreateCell(index + 46);
            cell44.SetCellValue("手续费差异化%");
            ICell cell45 = row.CreateCell(index + 47);
            cell45.SetCellValue("手续费金额");
            //ICell cell46 = row.CreateCell(index + 48);
            //cell46.SetCellValue("实际支付报批费用");
            index--;
            ICell cell47 = row.CreateCell(index + 49);
            cell47.SetCellValue("税收 ");
            //ICell cell48 = row.CreateCell(index + 50);
            //cell48.SetCellValue("自行掌握费用");
            //ICell cell49 = row.CreateCell(index + 51);
            //cell49.SetCellValue("自行掌握费用结余");
            //ICell cell50 = row.CreateCell(index + 52);
            //cell50.SetCellValue("自行掌握费用结余奖励70%");
            //ICell cell51 = row.CreateCell(index + 53);
            //cell51.SetCellValue("补提供凭证差额");
            index -= 4;
            ICell cell52 = row.CreateCell(index +54);
            cell52.SetCellValue("兑现金额");
            ICell cell53 = row.CreateCell(index + 55);
            cell53.SetCellValue("交通通讯费宣传品");
            ICell cell54 = row.CreateCell(index +56);
            cell54.SetCellValue("车险月度固定奖励");
            ICell cell55 = row.CreateCell(index + 57);
            cell55.SetCellValue("工行刷卡");
            index++;
            ICell cell551 = row.CreateCell(index + 57);
            cell551.SetCellValue("总计");
            
            ICell cell56 = row.CreateCell(index + 58);
            cell56.SetCellValue("总兑现金额");
           
        }

        public void CreateQueryRow(IRow row, YwData data, Dictionary<string, decimal> mxDicT)
        {
            int index = -1;
            //年份
            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue(data.Year);
            //月份
            ICell cellyf = row.CreateCell(index + 2);
            cellyf.SetCellValue(data.Month);
            //////////////////////////////////// 第一更新
            //部门
            ICell cell1 = row.CreateCell(index + 3);
            cell1.SetCellValue(data.DepartName);
            //业务员
            index += 1;
            ICell cellywy = row.CreateCell(index + 3);
            cellywy.SetCellValue(data.YwyName);


            index++;
            //手续费类型
            ICell sxfCell = row.CreateCell(index + 3);
            sxfCell.SetCellValue(data.Sxflx);

            index++;
            //是否无法关联出险次数
            ICell wfglCell = row.CreateCell(index + 3);
            wfglCell.SetCellValue(data.Wfglcx);


            //上年出险总次数
            ICell cell2 = row.CreateCell(index + 4);
            cell2.SetCellValue(data.Cxcs);
            //上年承保公司
            ICell cell3 = row.CreateCell(index + 5);
            cell3.SetCellValue(data.Sncbgs);
            //是否平安
            ICell cell4 = row.CreateCell(index + 6);
            cell4.SetCellValue(data.Sfpa);
            //是否优质
            ICell cell5 = row.CreateCell(index + 7);
            cell5.SetCellValue(data.Sfyz);
            //出险2次，是否赔付100%
            ICell cell6 = row.CreateCell(index + 8);
            cell6.SetCellValue(data.Cx2c);

            index++;
            //出险3次，是否赔付200%
            ICell cell61 = row.CreateCell(index + 8);
            cell6.SetCellValue(data.Cx3c);


            //是否采购办
            ICell cell7 = row.CreateCell(index + 9);
            cell7.SetCellValue(data.Sfcgb);
            //报批
            ICell cell8 = row.CreateCell(index + 10);
            //cell8.SetCellType(CellType.Numeric);
            cell8.SetCellValue(double.Parse(data.Bp.ToString()));
           
            mxDicT["报批"] = mxDicT["报批"] + data.Bp;
            index++;
            //备注
            ICell cellbz = row.CreateCell(index + 10);
            cellbz.SetCellValue(data.Bz);
            //特殊类型
            ICell cell9 = row.CreateCell(index + 11);
            cell9.SetCellValue(data.Tslx);
            ////追加费用
            //ICell cell10 = row.CreateCell(index + 12);
            //cell10.SetCellType(CellType.Numeric);
            //cell10.SetCellValue(double.Parse(data.Zjfy.ToString()));
            //mxDicT["追加费用"] = mxDicT["追加费用"] + data.Zjfy;
            index--;
            ////////////////////////////////////////// 系统提取
            //经办
            ICell cell11 = row.CreateCell(index + 13);
            cell11.SetCellValue(data.Jbr);
            //归属
            ICell cell12 = row.CreateCell(index + 14);
            cell12.SetCellValue(data.Gsr);
            //车型
            ICell cell13 = row.CreateCell(index + 15);
            cell13.SetCellValue(data.Cx);
            //渠道码
            ICell cell14 = row.CreateCell(index + 16);
            cell14.SetCellValue(data.Qdm);
            //条款
            ICell cell15 = row.CreateCell(index + 17);
            cell15.SetCellValue(data.Tk);
            //车辆类型
            ICell cell16 = row.CreateCell(index + 18);
            cell16.SetCellValue(data.Clxs);
            //被保人
            ICell cell17 = row.CreateCell(index + 19);
            cell17.SetCellValue(data.Bbr);
            //单证号
            ICell cell18 = row.CreateCell(index + 20);
            cell18.SetCellValue(data.Dzh);
            //车牌号
            ICell cell19 = row.CreateCell(index + 21);
            cell19.SetCellValue(data.Cph);
            //单位性质
            ICell cell20 = row.CreateCell(index + 22);
            cell20.SetCellValue(data.Dwxz);
            //座位数
            ICell cell21 = row.CreateCell(index + 23);
            cell21.SetCellValue(data.Zwh);
            //吨位数
            ICell cell22 = row.CreateCell(index + 24);
            cell22.SetCellValue(data.Dws);
            //是否新保、过户
            ICell cell23 = row.CreateCell(index + 25);
            cell23.SetCellValue(data.Sfxb);
            //是否保盗抢
            ICell cell24 = row.CreateCell(index + 26);
            cell24.SetCellValue(data.Sfbbd);
            //是否保车上人员
            ICell cell25 = row.CreateCell(index + 27);
            cell25.SetCellValue(data.Sfbcsry);
            //是否保自燃
            ICell cell26 = row.CreateCell(index + 28);
            cell26.SetCellValue(data.Sfbzr);
            //是否保发动机
            ICell cell27 = row.CreateCell(index + 29);
            cell27.SetCellValue(data.Sfbfdj);
            //单保三者
            ICell cell28 = row.CreateCell(index + 30);
            cell28.SetCellValue(data.Dbdsz);
            //单保交强
            ICell cell29 = row.CreateCell(index + 31);
            cell29.SetCellValue(data.Dbjq);
            //是否录推修码
            ICell cell30 = row.CreateCell(index + 32);
            cell30.SetCellValue(data.Sflwxm);
            //使用年限
            ICell cell31 = row.CreateCell(index + 33);
            cell31.SetCellValue(data.Synx);
            //是否刷工行卡(银行卡号)
            ICell cell32 = row.CreateCell(index + 34);
            cell32.SetCellValue(data.Yhkh);
            //业务来源
            ICell cell33 = row.CreateCell(index + 35);
            cell33.SetCellValue(data.Ywly);
            //客户群
            ICell cell34 = row.CreateCell(index + 36);
            cell34.SetCellValue(data.Khq);
            //签单日期
            ICell cell35 = row.CreateCell(index + 37);
            cell35.SetCellValue(data.Qdrq.ToShortDateString());
            //起保日期
            ICell cell36 = row.CreateCell(index + 38);
            cell36.SetCellValue(data.Qbrq.ToShortDateString());
            //终保日期
            ICell cell37 = row.CreateCell(index + 39);
            cell37.SetCellValue(data.Zbrq.ToShortDateString());
            //总保费
            ICell cell38 = row.CreateCell(index + 40);
            cell38.SetCellType(CellType.Numeric);
            cell38.SetCellValue(double.Parse(data.Zbf.ToString()));
            mxDicT["总保费"] = mxDicT["总保费"] + data.Zbf;
            //商业保费
            ICell cell39 = row.CreateCell(index + 41);
            cell39.SetCellType(CellType.Numeric);
            cell39.SetCellValue(double.Parse(data.Sybf.ToString()));
            mxDicT["商业保费"] = mxDicT["商业保费"] + data.Sybf;
            //交强保费
            ICell cell40 = row.CreateCell(index + 42);
            cell40.SetCellType(CellType.Numeric);
            cell40.SetCellValue(double.Parse(data.Jqbf.ToString()));
            mxDicT["交强保费"] = mxDicT["交强保费"] + data.Jqbf;
            //车船税
            ICell cell41 = row.CreateCell(index + 43);
            cell41.SetCellType(CellType.Numeric);
            cell41.SetCellValue(double.Parse(data.Cqs.ToString()));
            mxDicT["车船税"] = mxDicT["车船税"] + data.Cqs;
            //是否有凭证
            ICell cell42 = row.CreateCell(index + 44);
            cell42.SetCellValue(data.Sfypz);
            //实际支付市场费用（凭证金额）
            ICell cell43 = row.CreateCell(index + 45);
            cell43.SetCellType(CellType.Numeric);
            cell43.SetCellValue(double.Parse(data.Sjscfy.ToString()));
            mxDicT["实际支付市场费用"] = mxDicT["实际支付市场费用"] + data.Sjscfy;
            //手续费差异化
            ICell cell44 = row.CreateCell(index + 46);
            cell44.SetCellType(CellType.Numeric);
            cell44.SetCellValue(double.Parse(data.Sxfcyh.ToString()));
            //手续费金额
            ICell cell45 = row.CreateCell(index + 47);
            cell45.SetCellType(CellType.Numeric);
            cell45.SetCellValue(double.Parse(data.Sxfje.ToString()));
            mxDicT["手续费金额"] = mxDicT["手续费金额"] + data.Sxfje;

            ////实际支付报批费用
            //ICell cell46 = row.CreateCell(index + 48);
            //cell46.SetCellType(CellType.Numeric);
            //cell46.SetCellValue(double.Parse(data.Sjzfbpfy.ToString()));//"实际支付报批费用"
            index--;
            //税收
            ICell cell47 = row.CreateCell(index + 49);
            cell47.SetCellType(CellType.Numeric);
            cell47.SetCellValue(double.Parse(data.Sh.ToString()));
            mxDicT["税收"] = mxDicT["税收"] + data.Sh;

            ////自行掌握费用
            //ICell cell48 = row.CreateCell(index + 50);
            //cell48.SetCellType(CellType.Numeric);
            //cell48.SetCellValue(double.Parse(data.Zxzwfy.ToString()));
            //mxDicT["自行掌握费用"] = mxDicT["自行掌握费用"] + data.Zxzwfy;

            ////自行掌握费用结余
            //ICell cell49 = row.CreateCell(index + 51);
            //cell49.SetCellType(CellType.Numeric);
            //cell49.SetCellValue(double.Parse(data.Zxzwfyjy.ToString()));//"自行掌握费用结余"
            //mxDicT["自行掌握费用结余"] = mxDicT["自行掌握费用结余"] + data.Zxzwfyjy;

            ////自行掌握费用结余奖励70%
            //ICell cell50 = row.CreateCell(index + 52);
            //cell50.SetCellType(CellType.Numeric);
            //cell50.SetCellValue(double.Parse(data.Zxzwfyjy.ToString()));//"自行掌握费用结余奖励70%"
            //mxDicT["自行掌握费用结余奖励70%"] = mxDicT["自行掌握费用结余奖励70%"] + data.Zxzwfyjyjl;

            ////补提供凭证金额
            //ICell cell51 = row.CreateCell(index + 53);
            //cell51.SetCellValue("");

            index -= 4;

            //兑现金额
            ICell cell52 = row.CreateCell(index + 54);
            cell52.SetCellType(CellType.Numeric);
            cell52.SetCellValue(double.Parse(data.Dxje.ToString()));//"兑现金额"
            mxDicT["兑现金额"] = mxDicT["兑现金额"] + data.Dxje;

            //交通通讯费宣传品
            ICell cell53 = row.CreateCell(index + 55);
            cell53.SetCellType(CellType.Numeric);
            cell53.SetCellValue(double.Parse(data.Jttxf.ToString()));//"交通通讯费宣传品"
            mxDicT["交通通讯费宣传品"] = mxDicT["交通通讯费宣传品"] + data.Jttxf;

            //车险月度固定奖励
            ICell cell54 = row.CreateCell(index + 56);
            cell54.SetCellType(CellType.Numeric);
            cell54.SetCellValue(double.Parse(data.Cxydjl.ToString()));//"车险月度固定奖励"
            mxDicT["车险月度固定奖励"] = mxDicT["车险月度固定奖励"] + data.Cxydjl;

            //工行刷卡
            ICell cell55 = row.CreateCell(index + 57);
            cell55.SetCellType(CellType.Numeric);
            cell55.SetCellValue(double.Parse(data.Ghskjl.ToString()));//"工行刷卡"
            mxDicT["工行刷卡"] = mxDicT["工行刷卡"] + data.Ghskjl;

            index++;
            //总计
            ICell cell551 = row.CreateCell(index + 57);
            cell551.SetCellType(CellType.Numeric);
            cell551.SetCellValue(double.Parse(data.Zj.ToString()));//"总计"
            mxDicT["总计"] = mxDicT["总计"] + data.Zj;

            //总兑现金额
            ICell cell56 = row.CreateCell(index + 58);
            cell56.SetCellType(CellType.Numeric);
            cell56.SetCellValue(double.Parse(data.Zdxje.ToString()));
            mxDicT["总兑现金额"] = mxDicT["总兑现金额"] + data.Zdxje;
           
        }
        #endregion 
        
        
        //判断是否工行卡号
        public bool IsGH(string yhkh)
        {
            if (yhkh == null || yhkh.Trim() == "")
            {
                return false;
            }
            if (config == null)
            {
                config = new XtmConfig();
                config = baseDao.Get(config);
            }
            if (config.Config2 == "")
            {
                return false;
            }
            String[] atts = config.Config2.Split('|');
            for (int i = 0; i < atts.Length; i++)
            {
                if (yhkh.StartsWith(atts[i]))
                {
                    return true;
                }
            }
            return false;
        }
        //获取帐期起始日期
        public DateTime GetBegDate()
        {
            if (config == null)
            {
                config = new XtmConfig();
                config = baseDao.Get(config);
            }
            int jzr = int.Parse(config.Config1);
            DateTime begD = new DateTime();
            if (DateTime.Now.Day > jzr)
            {
                begD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");

            }
            else
            {
                DateTime dtt = DateTime.Now.AddMonths(-1);
                begD = DateTime.Parse("" + dtt.Year + "-" + dtt.Month + "-01");
            }
            return begD;
        }
        
        
        #region 处理结帐
        public void DealJZ()
        {
            try
            {
                Deal1();
                Deal2();
            }
            catch (Exception ex)
            {
            }
        }
        //第一步：未走完流程数据，系统结案
        private void Deal1()
        {
            YwData param = new YwData();
            param.BegD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01").AddMonths(-1);
            param.EndD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");
            param.GetOpType = "JzGetNoEnd";
            IList<YwData> list = baseDao.List(param);
            foreach (YwData temp in list)
            {
                if (temp.Sfypz == "")
                {
                    temp.Sfypz = "否";
                }
                //temp.Sjscfy = 0;
                if (temp.Status == null || temp.Status == "")
                {
                }
                else
                {
                    FirstCalculate(1, temp);
                    SeconeCalculate(temp);
                }
                temp.Status = "5";
                baseDao.Update(temp);
            }
        }
        //第二步：计算财务数据
        private void Deal2()
        {
            //关闭之前所有数据
            YwAnlay upD = new YwAnlay();
            baseDao.UpdateUdf("YwAnlayUpdateEndBz", upD);

            XtmUser user = new XtmUser();
            user.UserType = "ywy";
            IList<XtmUser> ywyList = baseDao.List(user);
           
            foreach (XtmUser userT in ywyList)
            {
                CwCalTemp param = new CwCalTemp();
                param.BegD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01").AddMonths(-1);
                param.EndD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");
                param.YwyCode = userT.UserCode;

                CwCalTemp temp = baseDao.Get(param);
                YwAnlay cwD = new YwAnlay();
                cwD.Year = DateTime.Now.Year;
                cwD.Month = DateTime.Now.Month;
                cwD.YwyCode = userT.UserCode;
                cwD.YwyId = userT.Did;
                cwD.YwyName = userT.UserName;
                if (temp == null)
                {
                    cwD.Cxzdxje = 0;
                }
                else
                {
                    cwD.Cxzdxje = temp.Zdxje;
                }
                //取上月结余
                YwAnlay ctTemp = new YwAnlay();
                ctTemp.Year = DateTime.Now.AddMonths(-1).Year;
                ctTemp.Month = DateTime.Now.AddMonths(-1).Month;
                ctTemp.YwyCode = userT.UserCode;
                ctTemp.YwyId = userT.Did;
                ctTemp.YwyName = userT.UserName;
                IList<YwAnlay> cwListT = baseDao.List(ctTemp);
                if (cwListT == null || cwListT.Count <= 0)
                {
                    cwD.Syjy = 0;
                }
                else
                {
                    cwD.Syjy = cwListT[0].Byjy;
                }
                cwD.Bz = "Y";
                XtmDepart depr=new XtmDepart();
                depr.Did=user.DepartId;
                depr=baseDao.Get(depr);
                cwD.Depart = depr.DepartCode;
                cwD.Byjy = cwD.Syjy + cwD.Cxzdxje;
                baseDao.Insert(cwD);
            }

            XtmConfig config = new XtmConfig();
            config.Config3 = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01").AddMonths(-1).ToShortDateString();
            baseDao.Update(config);
        }
        #endregion
    }
}
