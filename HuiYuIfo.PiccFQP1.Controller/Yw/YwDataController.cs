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
    public class YwDataController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                case "jz"://结帐
                    YwDataService service = new YwDataService();
                    this.BeginTran();
                    try
                    {
                        service.DealJZ();
                        this.CommitTran();

                    }
                    catch (Exception ex)
                    {
                        this.RollbackTran();
                    }
                    break;
            }
            return true;
        } 
    }
}
