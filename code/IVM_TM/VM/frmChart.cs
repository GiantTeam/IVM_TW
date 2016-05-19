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
       // RecordCompareByDate recordCompareByDate = new RecordCompareByDate();
        ArrayList DateRecordListByYear = new ArrayList();
        ArrayList DateRecordListByMonth = new ArrayList();
        ArrayList DateRecordListByDay = new ArrayList();
        string strYear = "年";
        string strMonth = "月";
        string strDay = "日";
        float[] Profit;
        float[] Rate;
        float[] Invest;
        int Count;
        string[] Time;

        //  DateRecordListByYear =
        //sStatistic.GetDateRecordList(strYear,RecordList);

        int[] date = new int[13] { 0, 20, 13, 10, 15, 7, 16, 1, 8, 9, 3, 19, 12 };
        float[] D1 = new float[13] { 0, 20, 13, 10, 15, 7, 16, 1, 8, 9, 3, 19, 12 };
        float[] D2 = new float[13] { 0, 10, 40, 21, 49, 7, 3, 29, 1, 19, 43, 39, 2 };
        float[] D3 = new float[13] { 0, 2.5f, 3.7f, 10f, 5f, 7f, 6f, 1.5f, 8, 9, 3, 9, 2.8f };
        int intXCount ;
        int g_smonth = 7;
        int g_syear = 2013;
        int yAdd = 10;
        public int diff(int x, int y)
        {
            if ((x - y) % 2 == 0)
            {
                y = y + 30 * (x % 3) + 60 * (x % 6);
            }
            if (x < y)
                return y - x;
            else
                return (30 - x) + y;
        }
        public int sum(int i)
        {
            int j;
            int all = 0;
            if (i == 1)
            {
                return date[1];
            }
            for (j = 1; j < i + 1; j++)
                all += diff(date[j - 1], date[j]);
            return all;
        }
        public float ysum(int i, int yadd, float[] D)
        {
            return (D[i] * 400) / (yadd * 10);
        }
        //**************************************华丽的分割线******************************************
        public void Form1()
        {
            InitializeComponent();
            Count = DateRecordListByDay.Count;
            Profit = new float[Count];
            Time = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                DateTime dateTime = dateRecord.dtmTime;
                Profit[i] = (float)dateRecord.Profit;
                Time[i] = dateTime.Month.ToString()+"/"+dateTime.Day.ToString();
                
            }
            paint("收益", "日期", "单位：万元", Profit, 2);
        }

        //*******************************************************************************************
        public void paint(string strtitle, string strx, string stry, float[] flYData, int yadd)
        {
            int syear = g_syear;
            int smonth = g_smonth - 1;
            //画图初始化
            Bitmap bmap = new Bitmap(800, 500);
            Graphics gph = Graphics.FromImage(bmap);
            gph.Clear(Color.White);

            //三点确定坐标框架

            float YMax = flYData[0];
            float YMin = flYData[0];
            foreach (float temp in flYData)
            {
                if (temp > YMax)
                    YMax = temp;
                if (temp < YMin)
                    YMin = temp;
            }
            float XMax = Count;
            float XMin = 0;

            PointF cpt = new PointF(40, 440);//原点
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

            //绘制XY轴内容
            for (int i = 1; i <= Count; i++, smonth++)
            {
                /* if (i == 1)
                 {
                     gph.DrawString((syear).ToString() + "年", new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + 30 * i - 45, cpt.Y + 20));
                     syear++;
                 }
                 //画y轴刻度：平均下来40点/单位长度
                 if (i < 11)
                 {
                     gph.DrawString((yadd * i).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X - 40, cpt.Y - i * 40 - 6));
                     gph.DrawLine(Pens.Black, cpt.X - 3, cpt.Y - i * 40, cpt.X, cpt.Y - i * 40);
                 }*/

                //画x轴刻度:平均下来一天一个像素点
                PointF temp = new PointF(cpt.X + (int)i * 400 / Count, cpt.Y + 20);
                gph.DrawString(Time[i-1], new Font("宋体", 12), Brushes.Black, temp);
                
                // gph.DrawString(((smonth % 12) + 1).ToString() + "月", new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + 30 * i - 30, cpt.Y + 3));
                // gph.DrawLine(Pens.Black, cpt.X + 30 * i, cpt.Y - 3, cpt.X + 30 * i, cpt.Y);
                /*  if ((smonth % 12) + 1 == 1)
                  {
                      gph.DrawString((syear).ToString() + "年", new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + 30 * i - 45, cpt.Y + 20));
                      syear++;
                  }*/

            }
            
            for (int i = 1; i <= intXCount; i++)
            {
                /*画点
                 * p[i]为数组中按日期排第i个数据，p[0]为第一天的数据，diff(p[i],p[0])为第i天与第0天天数差
                 * p[0].X=cpt.X +p[0].Days;
                 * p[i].X=p[0].X+diff(p[i],p[0]);
                 * p[i].Y=cpt.Y+p[i].Y*0.4;p[i].Y已转化为0-100之间的数
                 */
                gph.DrawEllipse(Pens.Black, cpt.X + sum(i), cpt.Y - ysum(i, yadd, flYData), 3, 3);
                gph.FillEllipse(new SolidBrush(Color.Black), cpt.X + sum(i), cpt.Y - ysum(i, yadd, flYData), 3, 3);
                //画数值
                gph.DrawString(flYData[i].ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + sum(i), cpt.Y - ysum(i, yadd, flYData)));
                //画折线
                if (i > 1)
                {
                    // gph.DrawLine(Pens.Red, cpt.X + sum(i - 1), cpt.Y - ysum(i - 1,yadd,d), cpt.X + sum(i)-1, cpt.Y - ysum(i-1,yadd,d));
                    // gph.DrawLine(Pens.Red, cpt.X + sum(i) - 1, cpt.Y - ysum(i - 1,yadd,d), cpt.X + sum(i), cpt.Y - ysum(i,yadd,d));
                    gph.DrawLine(Pens.Red, cpt.X + sum(i - 1), cpt.Y - ysum(i - 1, yadd, flYData), cpt.X + sum(i), cpt.Y - ysum(i, yadd, flYData));
                }
            }
            //保存输出图片
            //bmap.Save(Response.OutputStream, ImageFormat.Gif);
            pictureBox1.Image = bmap;
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
                Time[i] = dateTime.Month.ToString() + "/" + dateTime.Day.ToString() ;

            }
            paint("收益", "日期", "单位：万元", Profit, 2);
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
           
            Invest = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                Invest[i] = (float)dateRecord.Invest;
            }
            paint("投资", "日期", "单位：万元", Invest, 2);
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
           
            Rate = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                DateRecord dateRecord = (DateRecord)DateRecordListByDay[i];
                Rate[i] = (float)dateRecord.Invest;
            }
            paint("收益率", "日期", "单位：万元", Rate, 2);

        }


    }
}