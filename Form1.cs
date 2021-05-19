using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Figure3
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(700, 900);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox1.CreateGraphics();
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
            var graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";
                if (pictureBox1.Image != null)
                {
                    try
                    {
                        bmp.Save(savedialog.FileName, ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
}
