using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figure3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = panel1.CreateGraphics();
            Pen pn = new Pen(Color.Black, 5);
            string combo = comboBox1.Text;
            if (combo == "Отрезок")
            {
                graphics.DrawLine(pn, 10, 10, 100, 50);
            }

            if (combo == "Круг")
            {
                graphics.DrawEllipse(pn, 50, 50, 50, 50);
            }

            if (combo == "Прямоугольник")
            {
                graphics.DrawRectangle(pn, 50, 50, 50, 50);
            }

            if (combo == "Треугольник")
            {
                Point point1 = new Point(20, 20);
                Point point2 = new Point(100, 150);
                Point point3 = new Point(20, 150);
                Point[] curvePoints =
             {
                 point1, point2, point3,
             };
                graphics.DrawPolygon(pn, curvePoints);

                graphics.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var graphics = panel1.CreateGraphics();
            graphics.Clear(Color.White);
        }
    }
}
