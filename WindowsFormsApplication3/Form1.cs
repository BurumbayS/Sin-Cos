using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Red, (float) 2.0);
        Pen pp = new Pen(Color.Blue, (float)2.0);
        List<PointF> arr1 = new List<PointF>();
        List<PointF> arr2 = new List<PointF>();
        List<PointF> arr3 = new List<PointF>();
        List<PointF> arr4 = new List<PointF>();

        Timer t = new Timer();
        float x1 = 20;
        float x2 = 20;
        float y1 = 20;
        float y2 = 380;
        float xx1 = 10;
        float yy1 = 200;
        float xx2 = 600;
        float yy2 = 200;
        int cnt = 0;
        float y = 0;
        float x = 20;
        

        public Form1()
        {
            InitializeComponent();
            t.Interval = 20;
            t.Tick += DoIt;
            t.Start();

            arr1.Add(new PointF(20, 200));
            arr1.Add(new PointF(20, 200));
            arr2.Add(new PointF(20, 200));
            arr2.Add(new PointF(20, 200));
            arr3.Add(new PointF(20, 110));
            arr3.Add(new PointF(20, 110));
            arr4.Add(new PointF(20, 290));
            arr4.Add(new PointF(20, 290));
        }

        private void DoIt(object sender, EventArgs e)
        {
            float yy = (float)200 - (float)Math.Sin(y) * 90;
            float xx = (float)200 - (float)Math.Sin(y) * (-90);
            arr1.Add(new PointF(x, yy ));
            arr2.Add(new PointF(x, xx ));

            yy = (float)200 - (float)Math.Cos(y) * 90;
            xx = (float)200 - (float)Math.Cos(y) * (-90);
            arr3.Add(new PointF(x, yy));
            arr4.Add(new PointF(x, xx));

            y += (float) 0.0523599;
            x += 3;

            Refresh();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawLine(p, x1, y1, x2, y2);
            e.Graphics.DrawLine(p, xx1, yy1, xx2, yy2);

            //int x = 20;
                
            for (int i = 20; i < 600; i += 90)
            {
                int px1 = i;
                int py1 = 195;
                int px2 = i;
                int py2 = 205;
                e.Graphics.DrawLine(p, px1, py1, px2, py2);
            }

            e.Graphics.DrawLine(p, 15, 110, 25, 110);
            e.Graphics.DrawLine(p, 15, 290, 25, 290);
            e.Graphics.DrawCurve(p, arr1.ToArray());
            e.Graphics.DrawCurve(p, arr2.ToArray());
            e.Graphics.DrawCurve(pp, arr3.ToArray());
            e.Graphics.DrawCurve(pp, arr4.ToArray());
        }
    }
}
