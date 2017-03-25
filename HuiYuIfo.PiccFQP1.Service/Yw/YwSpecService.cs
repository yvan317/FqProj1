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
    public class YwSpecService
    {
        private BaseDao baseDao = new BaseDao();

        public bool Validate(string type, YwSpec entity, ref string errmsg)
        {
            switch (type)
            {
                case "all":
                    #region validate all
                    if (entity.SpecName == "")
                    {
                        errmsg = "特殊类型不能为空";
                        return false;
                    }
                    if (entity.Jqxfv < 0 || entity.Jqxfv > 100)
                    {
                        errmsg = "交强费率超出范围，只能在0和100之间";
                        return false;
                    }
                    if (entity.Syxfv < 0 || entity.Syxfv > 100)
                    {
                        errmsg = "商业费率超出范围，只能在0和100之间";
                        return false;
                    }
                    #endregion
                    break;
            }
            return true;
        }
        public bool CheckExist(string specName)
        {
            YwSpec t1 = new YwSpec();
            t1.SpecName = specName;
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
            YwSpec param=new YwSpec();
            IList<YwSpec> list = baseDao.List(param);
            int i = 0;
            foreach (YwSpec temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateRow(rowT,temp);
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
            if (count < 3)
            {
                errmsg = "总列数至少应该为3列，上传文件格式不正确，请确认";
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
        private void CreateRow(IRow row,YwSpec entity)
        {
            ICell cell = row.CreateCell(0);
            cell.SetCellValue(entity.SpecName);
            cell.SetCellType(CellType.String);
            ICell cell1 = row.CreateCell(1);
            cell1.SetCellType(CellType.String);
            cell1.SetCellValue(entity.Syxfv.ToString());
            ICell cell2 = row.CreateCell(2);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue(entity.Jqxfv.ToString());
        }
        private void CreateHead(IRow row)
        {
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("特殊类型");
            ICell cell1 = row.CreateCell(1);
            cell1.SetCellValue("商业险费率(%)");
            ICell cell2 = row.CreateCell(2);
            cell2.SetCellValue("交强险费率(%)");
        }
        private void CreateExampleRow(IRow row)
        {
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("特殊类型1");
            cell.SetCellType(CellType.String);
            ICell cell1 = row.CreateCell(1);
            cell1.SetCellType(CellType.String);
            cell1.SetCellValue("20");
            ICell cell2 = row.CreateCell(2);
            cell2.SetCellType(CellType.String);
            cell2.SetCellValue("12");
        }

        private bool CheckCell(int rowIndex, string title, ref string errmsg)
        {
            switch (rowIndex)
            {
                case 0:
                    if (title != "特殊类型")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【特殊类型】,请确认";
                        return false;
                    }
                    break;
                case 1:
                    if (title != "商业险费率(%)")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【商业险费率(%)】,请确认";
                        return false;
                    }
                    break;
                case 2:
                    if (title != "交强险费率(%)")
                    {
                        errmsg = "第" + (rowIndex + 1) + "列抬头不正确，应该为【交强险费率(%)】,请确认";
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void DealRow(int rowIndex, IRow row)
        {
            YwSpec temp = new YwSpec();
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
                            temp.SpecName = cell.StringCellValue.Trim();
                            if (temp.SpecName == "")
                            {
                                throw new Exception("第" + rowIndex + "行    特殊类型 不能为空");
                            }
                        }
                        catch
                        {
                            throw new Exception("第" + rowIndex + "行    特殊类型 不能为空");
                        }
                        break;
                    case 1:
                        decimal temp1 = 0;
                        try
                        {
                            temp1 = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowIndex + "行    商业险费率(%)格式不正确，应该在0和100之间的数字");
                        }
                        if (temp1 < 0 || temp1 > 100)
                        {
                            throw new Exception("第" + rowIndex + "行    商业险费率(%)应该在0和100之间");
                        }
                        temp.Syxfv = temp1;
                        break;
                    case 2:
                        decimal temp2;
                        try
                        {
                            temp2 = decimal.Parse(cell.StringCellValue.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("第" + rowIndex + "行    交强险费率(%)格式不正确，应该在0和100之间的数字");
                        }
                        if (temp2 < 0 || temp2 > 100)
                        {
                            throw new Exception("第" + rowIndex + "行    交强险费率(%)应该在0和100之间");
                        }
                        temp.Jqxfv = temp2;
                        break;
                }
            }
            if (this.CheckExist(temp.SpecName) == true)
            {
                throw new Exception("第" + rowIndex + " 行  [" + temp.SpecName + "]该特殊类型已经被定义");
            }
            baseDao.Insert(temp);
        }
    }
}