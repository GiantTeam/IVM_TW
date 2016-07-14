using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using ControlClass;
using EntityClass;
using ClassLibrary;

namespace VM
{
    public partial class frmTable : Form
    {

       // public static string strDefaultExcelFileWholePath ;
        string strExcelFileWholePath;
        static public ArrayList RecordList = new ArrayList();
        static public Statistic sStatistic = new Statistic();

        ArrayList DateRecordListByYear = new ArrayList();
        ArrayList DateRecordListByMonth = new ArrayList();
        ArrayList DateRecordListByDay = new ArrayList();

        string strYear = "年";
        string strMonth = "月";
        string strDay = "日";
        float[] Profit;
        float[] Rate;
        float[] Invest;
        int[] Interval;
        int Count;
        string[] Time;

        public frmTable(String strTableName)
        {
            InitializeComponent();
            strExcelFileWholePath = strTableName;
            RecordList = sStatistic.LoadDataFromExcel(strExcelFileWholePath );
            //显示RecorlList的中的内容 
            ShowContentOfRecordList();
            DateRecordListByDay = sStatistic.GetDateRecordList(strYear, RecordList);
            DateRecordListByMonth = sStatistic.GetDateRecordList(strMonth, RecordList);
            DateRecordListByDay = sStatistic.GetDateRecordList(strDay, RecordList);
            Count = DateRecordListByDay.Count;

        }

    




        //public void mmuImport_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog frm = new OpenFileDialog();
        //    frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        strExcelFileWholePath = frm.FileName;
        //        RecordList = sStatistic.LoadDataFromExcel(strExcelFileWholePath);
        //        //显示RecorlList的中的内容                     
        //        ShowContentOfRecordList();
        //    }
        //}

        //重构函数：清空表格内容
        private void ClearWholeTable()
        {
            int index;
            for (index = 0; index < this.grpStatisticTable.Rows.Count;)
            {
                grpStatisticTable.Rows.RemoveAt(index);
            }
        }


        //清空文件内容
        private void mmuEmpty_Click(object sender, EventArgs e)
        {
            ClearWholeTable();
            RecordList.Clear();
            //将结果写入文件
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //保存
        private void mmuSave_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            for (int i = 0; i < RecordList.Count; i++)
            {
                Record recordl = (Record)RecordList[i];
                record.dtmDate = recordl.dtmDate;
                record.dblID = Convert.ToDouble(grpStatisticTable.Rows[i].Cells[4].Value);
                record.dblMoney = Convert.ToDouble(grpStatisticTable.Rows[i].Cells[2].Value);
                record.strName = grpStatisticTable.Rows[i].Cells[3].Value.ToString();
                record.strType = grpStatisticTable.Rows[i].Cells[1].Value.ToString();
                RecordList.RemoveAt(i);
                RecordList.Insert(i, record);
            }
            saveToExcel();
        }

        private void saveToExcel()
        {
            //生成RecordList中的内容      
            if (strExcelFileWholePath == "")
            {
                SaveFileDialog frm = new SaveFileDialog();
                frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                frm.FileName = "投资记录表.xlsx";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    strExcelFileWholePath = frm.FileName;
                }
            }
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }

        //导出
        private void mmuExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            frm.FileName = "投资记录表.xlsx";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                strExcelFileWholePath = frm.FileName;
            }
            sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
        }



        //页面中部：表格处理
        private void mmuChart_Click(object sender, EventArgs e)
        {
            LoadChart();
            //frmChart chart;
            //chart = new frmChart();
            //chart.Show();
        }

        //页面下部
        //增加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void AddRecord(double money = 0, string name = "", double id = -1,string type = "投资")
        {
            int index;
            for (index = 0; index < grpStatisticTable.Rows.Count; index++)
            {
                grpStatisticTable.Rows[index].Selected = false;
            }
            index = addgrpRow(grpStatisticTable);
            grpStatisticTable.Rows[index].Selected = true;
            Record record = new Record();
            if (id == -1)
                id = index;
            record.dtmDate = System.DateTime.Now;
            record.dblID = id;
            record.dblMoney = money;
            record.strType = type;
            record.strName = name;
            RecordList.Add(record);
            MessageBox.Show("已成功添加一条记录！");
            ShowContentOfRecordList();
        }

        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < grpStatisticTable.Rows.Count; index++)
            {
                if (grpStatisticTable.Rows[index].Selected == true)
                {
                    grpStatisticTable.Rows.RemoveAt(index);
                    RecordList.RemoveAt(index);
                    sStatistic.WriteDataToExcel(RecordList, strExcelFileWholePath);
                    break;
                }
            }
        }

        //重构函数：为表格添加行
        private int addgrpRow(DataGridView grp)
        {
            DataGridViewRow Row = new DataGridViewRow();
            grp.RowHeadersWidth = 45;
            int index = grp.Rows.Add(Row);
            return index;
        }

        private void ShowContentOfRecordList()
        {
            ClearWholeTable();
            int RecordCount = RecordList.Count;
            for (int i = 0; i < RecordCount; i++)
            {
                Record record = (Record)RecordList[i];
                double TempRecordID = record.dblID;
                bool ShuhuiOrNot = false;//默认没有赎回
                for (int recordIndex = i + 1; recordIndex < RecordCount; recordIndex++)
                {
                    if (TempRecordID == ((Record)RecordList[recordIndex]).dblID)
                    {
                        ShuhuiOrNot = true;
                        break;
                    }
                }
                int index = addgrpRow(grpStatisticTable);
                grpStatisticTable.Rows[index].Cells[0].Value = record.dtmDate;
                grpStatisticTable.Rows[index].Cells[1].Value = record.strType;
                grpStatisticTable.Rows[index].Cells[2].Value = record.dblMoney;
                grpStatisticTable.Rows[index].Cells[3].Value = record.strName;
                grpStatisticTable.Rows[index].Cells[4].Value = record.dblID;
                if (record.strType.Equals("赎回"))
                {
                    grpStatisticTable.Rows[index].Cells[5].Value = "";
                }
                else
                    grpStatisticTable.Rows[index].Cells[5].Value = (ShuhuiOrNot ==false) ? "赎回" : "";
            }
        }


        private void grpStatisticTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string buttonText = grpStatisticTable.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (buttonText.Equals("赎回") && e.ColumnIndex == 5)
                {
                    grpStatisticTable.Rows[e.RowIndex].Cells[5].Value = "";
                    double money = Convert.ToDouble(grpStatisticTable.Rows[e.RowIndex].Cells[2].Value);
                    string name = grpStatisticTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int id = Convert.ToInt32(grpStatisticTable.Rows[e.RowIndex].Cells[4].Value);
                    AddRecord(money, name, id, "赎回");
                }
            }
            catch (System.NullReferenceException) { }
        }











        public int DayDiff(DateTime Last, DateTime Current)
        {
            DateTime dtLast = new DateTime(Convert.ToInt32(Last.Year), Convert.ToInt32(Last.Month), Convert.ToInt32(Last.Day));
            DateTime dtThis = new DateTime(Convert.ToInt32(Current.Year), Convert.ToInt32(Current.Month), Convert.ToInt32(Current.Day));
            int interval = new TimeSpan(dtThis.Ticks - dtLast.Ticks).Days;
            return interval;
        }

        public float GetYAdd(float min, float max)
        {
            if ((max - min) / 10 != 0)
                //if (((int)(max - min) / 10) != 0)
                return (float)(max - min) / 10;
            else
                return 1;
        }

        //**************************************华丽的分割线******************************************

        private void GetData()
        {
            Count = DateRecordListByDay.Count;
            Profit = new float[Count];
            Time = new string[Count];
            Interval = new int[Count];
            DateRecord dateRecordFirst = (DateRecord)DateRecordListByDay[0];
            DateTime dateTimeFirst = dateRecordFirst.dtmTime;
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                DateTime dateTime = dateRecord.dtmTime;
                Profit[i] = (float)dateRecord.Profit;
                Time[i] = dateTime.Month.ToString() + "/" + dateTime.Day.ToString();
                Interval[i] = DayDiff(dateTimeFirst, dateTime);
            }
        }

        //*******************************************************************************************
        public void paint(string strtitle, string strx, string stry, float[] flYData, int type)
        {
            //画图初始化
            Bitmap bmap = new Bitmap(900, 500);
            Graphics gph = Graphics.FromImage(bmap);
            gph.Clear(Color.White);

            float YMax = flYData[0];
            float YMin = flYData[0];
            foreach (float temp in flYData)
            {
                if (temp > YMax)
                    YMax = temp;
                if (temp < YMin)
                    YMin = temp;
            }
            float yAdd = GetYAdd(YMin, YMax);

            //三点确定坐标框架
            PointF cpt = new PointF(60, 440);//原点
            PointF ex = new PointF(760, cpt.Y);//x轴端点
            PointF ey = new PointF(cpt.X, 40);//y轴端点
            //
            PointF[] xpt = new PointF[3] { new PointF(ex.X + 15, ex.Y), new PointF(ex.X, ex.Y - 8), new PointF(ex.X, ex.Y + 8) };//x轴三角形
            PointF[] ypt = new PointF[3] { new PointF(ey.X, ey.Y - 15), new PointF(ey.X - 8, ey.Y), new PointF(ey.X + 8, ey.Y) };//y轴三角形
            gph.DrawString(strtitle, new Font("宋体", 14), Brushes.Black, new PointF(ex.X - 80, ey.Y - 30));//图表标题
            //画x轴
            gph.DrawLine(Pens.Black, cpt.X, cpt.Y, ex.X, ex.Y);
            gph.DrawPolygon(Pens.Black, xpt);
            gph.FillPolygon(new SolidBrush(Color.Black), xpt);
            gph.DrawString(strx, new Font("宋体", 12), Brushes.Black, new PointF(ex.X + 5, ex.Y + 5));

            //画y轴
            gph.DrawString(strx, new Font("宋体", 12), Brushes.Black, new PointF(ex.X + 5, ex.Y + 5));
            gph.DrawLine(Pens.Black, cpt.X, cpt.Y, ey.X, ey.Y);
            gph.DrawPolygon(Pens.Black, ypt);
            gph.FillPolygon(new SolidBrush(Color.Black), ypt);
            gph.DrawString(stry, new Font("宋体", 12), Brushes.Black, new PointF(0, 7));


            //画y轴刻度：平均下来40点/单位长度
            for (int i = 0; i < 11; i++)
            {
                gph.DrawString((YMin + (yAdd * i)).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(0, cpt.Y - i * 40 - 10));
                gph.DrawLine(Pens.Black, cpt.X, cpt.Y - i * 40, cpt.X + 3, cpt.Y - i * 40);
            }

            if (Count > 1 && yAdd != 0)
            {
                //绘制XY轴内容
                int xAdd;
                float yDataAdd;
                for (int i = 0; i < Count; i++)
                {
                    xAdd = Interval[i] * 700 / Interval[Count - 1];
                    yDataAdd = (float)(flYData[i] - YMin) * 40 / yAdd;



                    //画x轴刻度:平均下来一天一个像素点
                    PointF temp = new PointF(cpt.X + xAdd, cpt.Y + 20);
                    gph.DrawString(Time[i], new Font("宋体", 12), Brushes.Black, cpt.X + xAdd - 15, cpt.Y + 15 + (i % 2) * 10);
                    gph.DrawLine(Pens.Black, cpt.X + xAdd, cpt.Y - 3, cpt.X + xAdd, cpt.Y);
                    //画点
                    gph.DrawEllipse(Pens.Black, cpt.X + xAdd, cpt.Y - yDataAdd, 3, 3);
                    gph.FillEllipse(new SolidBrush(Color.Black), cpt.X + xAdd, cpt.Y - yDataAdd, 3, 3);
                    //画数值
                    gph.DrawString(flYData[i].ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + xAdd + 3, cpt.Y - yDataAdd - 3));
                    //画折线
                    if (i > 0 && type == 0)
                    {
                        gph.DrawLine(Pens.Blue, cpt.X + Interval[i - 1] * 700 / Interval[Count - 1], cpt.Y - (float)(flYData[i - 1] - YMin) * 40 / yAdd, cpt.X + xAdd, cpt.Y - yDataAdd);
                    }
                    if (i > 0 && type == 1)
                    {
                        gph.DrawLine(Pens.Blue, cpt.X + Interval[i - 1] * 700 / Interval[Count - 1], cpt.Y - (float)(flYData[i - 1] - YMin) * 40 / yAdd,
                            cpt.X + xAdd, cpt.Y - (int)(flYData[i - 1] - YMin) * 40 / yAdd);

                        gph.DrawLine(Pens.Blue, cpt.X + xAdd, cpt.Y - (float)(flYData[i - 1] - YMin) * 40 / yAdd,
                          cpt.X + xAdd, cpt.Y - yDataAdd);
                    }
                }
                pictureBox1.Image = bmap;
            }
        }
        //******************************************************************************************


        private void btnCReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnC1_Click(object sender, EventArgs e)
        {

            Profit = new float[Count];
            Time = new string[Count];
            for (int i = 0; i < Count; i++)
            {

                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                DateTime dateTime = dateRecord.dtmTime;

                Profit[i] = (float)dateRecord.Profit;
                Time[i] = dateTime.Month.ToString() + "/" + dateTime.Day.ToString();

            }
            paint("收益", "日期", "单位：元", Profit, 0);
        }

        private void btnC2_Click(object sender, EventArgs e)
        {

            Invest = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                Invest[i] = (float)dateRecord.Invest;
            }
            paint("投资", "日期", "单位：元", Invest, 1);
        }

        private void btnC3_Click(object sender, EventArgs e)
        {

            Rate = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                long tempRate1000 = (long)(dateRecord.Rate * 100 * 1000);
                Rate[i] = (float)(tempRate1000 / 1000.0);
            }
            DateRecord dateRecordkkk = (DateRecord)DateRecordListByDay[Count - 1];
            paint("收益率", "日期", "单位：%", Rate, 0);

        }




        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            GetData();
            Invest = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                Invest[i] = (float)dateRecord.Invest;
            }
            DateRecord tempDateRecord = (DateRecord)DateRecordListByDay[Count - 1];
            paint("投资", "日期", "单位：元", Invest, 1);
            txtWholeInvest.Text = ((long)tempDateRecord.Invest).ToString();
            lblRemain.Text = ((long)(100000 - tempDateRecord.Invest)).ToString();
            txtRe.Text = ((long)tempDateRecord.Profit).ToString();
            long tempRate1000 = (long)(tempDateRecord.Rate * 100 * 1000);
            float rate = (float)(tempRate1000 / 1000.0);
            txtC3.Text = rate.ToString();
        }



        private void frmTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("关闭前是否保存投资表的内容?", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                saveToExcel();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
