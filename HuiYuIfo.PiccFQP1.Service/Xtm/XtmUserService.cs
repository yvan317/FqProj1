using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Service.Xtm
{
    public class XtmUserService
    {
        private BaseDao baseDao = new BaseDao();
        public bool Validate(string type,XtmUser entity,ref string errmsg)
        {
            switch (type)
            {
                case "all":
                    #region validate all
                    if (entity.UserCode == "")
                    {
                        errmsg = "用户编码不能为空";
                        return false;
                    }
                    if (entity.UserName == "")
                    {
                        errmsg = "用户名称不能为空";
                        return false;
                    }
                    if (entity.UserType == "")
                    {
                        errmsg = "用户类型不能为空";
                        return false;
                    }
                    if (entity.Status == "")
                    {
                        errmsg = "用户状态不能为空";
                        return false;
                    }
                    if (entity.UserType != "man" && entity.DepartId == 0)
                    {
                        errmsg = "请选择隶属部门";
                        return false;
                    }
                    //if (entity.UserType == "ywy" && entity.DepartId == 0)
                    //{
                    //    errmsg = "业务员必须选择隶属部门";
                    //    return false;
                    //}
                    #endregion
                    break;
            }
            return true;
        }
        public IWorkbook ExportData(ref string errmsg)
        {
            XtmUser param = new XtmUser();
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("userExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            IList<XtmUser> list = baseDao.List(param);
            int i = 0;
            foreach (XtmUser temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateRow(rowT, temp);
            }
            return book;
        }
        private void CreateRow(IRow row, XtmUser temp)
        {
            int index = 0;
            ICell cellxh = row.CreateCell(index + 0);
            cellxh.SetCellType(CellType.String);
            cellxh.SetCellValue(temp.UserCode);

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellType(CellType.String);
            cellnf.SetCellValue(temp.UserName);

            ICell de = row.CreateCell(index + 2);
            de.SetCellType(CellType.String);
            de.SetCellValue(temp.DepartCode);

            ICell lsmc = row.CreateCell(index + 3);
            lsmc.SetCellType(CellType.String);
            lsmc.SetCellValue(temp.DepartName);

        }
        private void CreateHead(IRow row)
        {
            int index = 0;
            ICell dm = row.CreateCell(index + 0);
            dm.SetCellValue("代码");

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("名称");
            ICell ls = row.CreateCell(index + 2);
            ls.SetCellValue("隶属部门");
            ICell lsmc = row.CreateCell(index + 3);
            lsmc.SetCellValue("隶属部门名称");

        }
    }
}
