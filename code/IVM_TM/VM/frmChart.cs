using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityClass;
using ControlClass;
using System.Collections;
namespace VM
{
    public partial class frmChart : Form
    {
        ArrayList RecordList = frmMain.RecordList;
        Statistic sStatistic = frmMain.sStatistic;
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

        public int DayDiff(DateTime Last, DateTime Current)
        {
            DateTime dtLast = new DateTime(Convert.ToInt32(Last.Year), Convert.ToInt32(Last.Month), Convert.ToInt32(Last.Day));
            DateTime dtThis = new DateTime(Convert.ToInt32(Current.Year), Convert.ToInt32(Current.Month), Convert.ToInt32(Current.Day));
            int interval = new TimeSpan(dtThis.Ticks - dtLast.Ticks).Days;
            return interval;
        }

        public float GetYAdd(float min, float max)
        {
            if((max - min) / 10!=0)
            //if (((int)(max - min) / 10) != 0)
                return (float)(max - min) / 10;
            else
               return 1;
        }
        //**************************************华丽的分割线******************************************
        //public void Form1()
        //{
        //    InitializeComponent();
        //    // GetData();
        //    paint("收益", "日期", "单位：万元", Profit, 0);
        //}

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
        public frmChart()
        {
            InitializeComponent();
            DateRecordListByDay = sStatistic.GetDateRecordList(strYear, RecordList);
            DateRecordListByMonth = sStatistic.GetDateRecordList(strMonth, RecordList);
            DateRecordListByDay = sStatistic.GetDateRecordList(strDay, RecordList);
            Count = DateRecordListByDay.Count;

        }

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
            DateRecord dateRecordkkk = (DateRecord)DateRecordListByDay[Count-1];
            paint("收益率", "日期", "单位：%", Rate, 0);

        }


        private void frmChart_Load_1(object sender, EventArgs e)
        {
            GetData();
            Invest = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                Invest[i] = (float)dateRecord.Invest;
            }
            DateRecord tempDateRecord = (DateRecord)DateRecordListByDay[Count -1];
            paint("投资", "日期", "单位：元", Invest, 1);
            txtWholeInvest.Text =( (long)tempDateRecord.Invest).ToString();
            txtRe.Text =((long) tempDateRecord.Profit).ToString();
            long tempRate1000 = (long)(tempDateRecord.Rate * 100 * 1000);
            float rate= (float)(tempRate1000 / 1000.0);
            txtC3.Text = rate.ToString();
        }
    }
}