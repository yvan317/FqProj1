using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.PiccFQP1.Service.Yw;
namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        BaseDao baseD = new BaseDao();
        private string conStr = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            YwDataService service = new YwDataService();
            IList<YwData> dataList = GetYwDataList();
            List<YwData> tempList = new List<YwData>();
            if (dataList.Count > 0)
            {
                foreach (YwData temp in dataList)
                {
                    if (temp.Status=="2"|| temp.Status == "3" || temp.Status == "4" || temp.Status == "5")
                    {
                        tempList.Add(temp);
                    }
                   
                }
                foreach(YwData temp in tempList)
                {
                    //if (temp.Status == "2" || temp.Status == "3")
                    //{
                    //    if (temp.Bbr.Length <= 4)
                    //    {
                    //        if (temp.Sfypz == "是")
                    //        {
                    //            service.FirstCalculate(1, temp);
                    //            service.SeconeCalculate(temp);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        service.FirstCalculate(1, temp);
                    //        service.SeconeCalculate(temp);
                    //    }
                    //}
                    try
                    {
                        service.FirstCalculate(1, temp);
                        service.SeconeCalculate(temp);

                        //if (temp.Status=="2"||temp.Status == "3")
                        //{

                        //    service.FirstCalculate(1, temp);

                        //}
                        //else
                        //{
                        //    service.FirstCalculate(1, temp);
                        //    service.SeconeCalculate(temp);
                        //}
                        temp.Status = "4";
                        baseD.Update(temp);
                    }
                    catch
                    {
                        continue;
                    }
                  
                }
            }
            MessageBox.Show("Ok");
        }

        private IList<YwData> GetYwDataList()
        {
            YwData data = new YwData();
            //data.Dzh = "PDAA201635110000060776";
            IList<YwData> list=baseD.List(data);
            return list;
        }
       
    }
}
