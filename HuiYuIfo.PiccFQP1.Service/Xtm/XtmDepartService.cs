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
    public class XtmDepartService
    {
        private BaseDao baseDao = new BaseDao();
        public bool Validate(string type, XtmDepart entity, ref string errmsg)
        {
            switch (type)
            {
                case "all":
                    #region validate all
                    if (entity.DepartCode == "")
                    {
                        errmsg = "机构编码不能为空";
                        return false;
                    }
                    if (entity.DepartName == "")
                    {
                        errmsg = "机构名称不能为空";
                        return false;
                    }
                   
                    #endregion
                    break;
            }
            return true;
        }

        public IWorkbook ExportData(ref string errmsg)
        {
            XtmDepart param = new XtmDepart();
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet("departExport");
            IRow row = sheet.CreateRow(0);
            CreateHead(row);
            IList<XtmDepart> list = baseDao.List(param);
            int i = 0;
            foreach (XtmDepart temp in list)
            {
                i += 1;
                IRow rowT = sheet.CreateRow(i);
                CreateRow(rowT, temp);
            }
            return book;
        }
        private void CreateRow(IRow row, XtmDepart temp)
        {
            int index = 0;
            ICell cellxh = row.CreateCell(index + 0);
            cellxh.SetCellType(CellType.String);
            cellxh.SetCellValue(temp.DepartCode);

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellType(CellType.String);
            cellnf.SetCellValue(temp.DepartName);

        }
        private void CreateHead(IRow row)
        {
            int index = 0;
            ICell dm = row.CreateCell(index + 0);
            dm.SetCellValue("代码");

            ICell cellnf = row.CreateCell(index + 1);
            cellnf.SetCellValue("名称");

           
        }
    }
}
