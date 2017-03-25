using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Dao;
using NPOI.HSSF.UserModel;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
namespace HuiYuIfo.PiccFQP1.Service.Yw
{
    public class YwTxjsService
    {
        private BaseDao baseDao = new BaseDao();

        public bool Validate(string type, YwTxjs entity, ref string errmsg)
        {
            switch (type)
            {
                case "all":
                    #region validate all
                    if (entity.Txm.Trim() == "")
                    {
                        errmsg = "推修码不能为空";
                        return false;
                    }
                    if (entity.Xs.Trim() == "")
                    {
                        entity.Xs = "0";
                    }
                    else
                    {
                        try
                        {
                            decimal temp = decimal.Parse(entity.Xs);
                        }
                        catch
                        {
                            errmsg = "系数格式不正确，应该是为数字";
                            return false;
                        }
                    }
                    #endregion
                    break;
            }
            return true;
        }
        public bool CheckExist(string Txm)
        {
            YwTxjs t1 = new YwTxjs();
            t1.Txm = Txm;
            int count = baseDao.Count(t1);
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        public XSSFWorkbook Export()
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("specExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            YwTxjs param = new YwTxjs();
            IList<YwTxjs> list = baseDao.List(param);
            int i = 0;
            foreach (YwTxjs temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateRow(rowT, temp);
            }

            return book;
        }
        public XSSFWorkbook ExportExample()
        {
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("specExport");
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
            if (count < 2)
            {
                errmsg = "总列数至少应该为4列，上传文件格式不正确，请确认";
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
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                DealRow(i, sheet.GetRow(i));

            }
            return true;
        }
        private void CreateRow(IRow row, YwTxjs entity)
        {

            ICell cell = row.CreateCell(0);
            cell.SetCellValue(entity.Txm);
            cell.SetCellType(CellType.String);

            ICell cell1 = row.CreateCell(1);
            cell1.SetCellType(CellType.String);
            cell1.SetCellValue(entity.Xlc);

            ICell cell2 = row.CreateCell(2);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue(entity.Zy);

            ICell cell3 = row.CreateCell(3);
            cell3.SetCellType(CellType.String);
            cell3.SetCellValue(entity.Xs);
           
        }
        private void CreateHead(IRow row)
        {
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("推修码");

            ICell cell2 = row.CreateCell(1);
            cell2.SetCellValue("修理厂");

            ICell cell3 = row.CreateCell(2);
            cell3.SetCellValue("有无专员");

            ICell cell4 = row.CreateCell(3);
            cell4.SetCellValue("推修系数值");
        }
        private void CreateExampleRow(IRow row)
        {
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("推修码");
            cell.SetCellType(CellType.String);

            ICell cell2 = row.CreateCell(1);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue("修理厂");

            ICell cell3 = row.CreateCell(2);
            cell3.SetCellType(CellType.String);
            cell3.SetCellValue("有");

            ICell cell4 = row.CreateCell(3);
            cell4.SetCellType(CellType.String);
            cell4.SetCellValue("20");
 
        }

        private bool CheckCell(int rowIndex, string title, ref string errmsg)
        {
            switch (rowIndex)
            {
                case 0:
                    if (title != "推修码")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【推修码】,请确认";
                        return false;
                    }
                    break;
                case 1:
                    if (title != "修理厂")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【修理厂】,请确认";
                        return false;
                    }
                    break;

                case 2:
                    if (title != "有无专员")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【有无专员】,请确认";
                        return false;
                    }
                    break;

                case 3:
                    if (title != "推修系数值")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【推修系数值】,请确认";
                        return false;
                    }
                    break;
              
            }
            return true;
        }

        private void DealRow(int rowIndex, IRow row)
        {
            YwTxjs temp = new YwTxjs();
            for (int index = 0; index < row.Cells.Count; index++)
            {
                ICell cell = row.GetCell(index);
                cell.SetCellType(CellType.String);
                switch (index)
                {
                    case 0:
                        try
                        {
                            if (cell.StringCellValue.Trim() == "")
                            {
                                return;
                            }
                            temp.Txm = cell.StringCellValue.Trim();
                            if (temp.Txm == "")
                            {
                                throw new Exception("第" + rowIndex + "行    推修码 不能为空");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowIndex + "行    推修码 不能为空");
                        }
                        break;
                    case 1:
                        try
                        {
                            if (cell.StringCellValue.Trim() == "")
                            {
                                temp.Xlc = "";
                            }
                            else
                            {
                                temp.Xlc = cell.StringCellValue.Trim();
                            }
                        }
                        catch
                        {
                            temp.Xlc = "";
                        }
                        break;

                    case 2:
                        try
                        {
                            if (cell.StringCellValue.Trim() == "")
                            {
                                return;
                            }
                            temp.Zy = cell.StringCellValue.Trim();
                            if (temp.Zy == "")
                            {
                                throw new Exception("第" + rowIndex + "行   有无专员 不能为空");
                            }
                            else
                            {
                                if (temp.Zy != "有" && temp.Zy != "无")
                                {
                                    throw new Exception("第" + rowIndex + "行   有无专员 不能为空");
                                }
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowIndex + "行   有无专员 内容应该为 有 或者 无");
                        }
                        break;
                    case 3:
                        decimal temp1 = 0;
                        try
                        {
                            temp1 = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowIndex + "行    推修系数值格式不正确，应该在0和100之间的数字");
                        }

                        temp.Xs = cell.StringCellValue.Trim();
                        break;
                   
                }
            }
            if (this.CheckExist(temp.Txm) == true)
            {
                throw new Exception("第" + rowIndex + " 行  [" + temp.Txm + "]该推修码已经被定义");
            }
            baseDao.Insert(temp);
        }
    }
}